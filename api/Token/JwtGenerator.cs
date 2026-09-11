using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace api.Token;

/// <summary>
/// Genera tokens JWT firmados para los usuarios de la aplicación.
/// </summary>
/// <remarks>
/// Los tokens se firman con la clave simétrica y la configuración de emisor,
/// audiencia y duración definidas en <see cref="JwtOptions"/>.
/// </remarks>
public sealed class JwtGenerator : IJwtGenerator
{
    private readonly JwtOptions _jwtOptions;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="JwtGenerator"/>.
    /// </summary>
    /// <param name="jwtOptions">Opciones de configuración utilizadas para generar los tokens.</param>
    /// <exception cref="ArgumentNullException">
    /// Se produce cuando <paramref name="jwtOptions"/> es <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Se produce cuando la clave configurada tiene una longitud inferior a 64 bytes.
    /// </exception>
    public JwtGenerator(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;

        if (Encoding.UTF8.GetByteCount(_jwtOptions.Key) < 64)
        {
            throw new InvalidOperationException("The JWT key must be at least 64 bytes long.");
        }
    }

    /// <summary>
    /// Crea un token JWT para el usuario indicado.
    /// </summary>
    /// <param name="user">Usuario cuyos datos se incluirán en las reclamaciones del token.</param>
    /// <returns>Cadena que contiene el token JWT firmado.</returns>
    /// <exception cref="ArgumentNullException">
    /// Se produce cuando <paramref name="user"/> es <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Se produce cuando el usuario no tiene un nombre de usuario válido.
    /// </exception>
    public string CreateToken(AppUser user)
    {
        ArgumentNullException.ThrowIfNull(user);

        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            throw new InvalidOperationException("User must have a valid username.");
        }

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.NameId, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("userId", user.Id.ToString()),
        };

        if (!string.IsNullOrWhiteSpace(user.Email))
        {
            claims.Add(new(JwtRegisteredClaimNames.Email, user.Email));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
