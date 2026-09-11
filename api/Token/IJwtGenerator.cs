using api.Models;

namespace api.Token;

/// <summary>
/// Define las operaciones para generar tokens JWT.
/// </summary>
public interface IJwtGenerator
{
    /// <summary>
    /// Crea un token JWT para el usuario especificado.
    /// </summary>
    /// <param name="user">Usuario para el que se generará el token.</param>
    /// <returns>Token JWT generado.</returns>
    string CreateToken(AppUser user);
}
