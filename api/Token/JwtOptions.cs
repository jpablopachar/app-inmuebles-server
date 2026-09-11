namespace api.Token;

/// <summary>
/// Configuración de autenticación JWT para la aplicación.
/// </summary>
/// <remarks>
/// Esta clase representa la sección de configuración <c>Jwt</c> utilizada para
/// generar y validar tokens de acceso.
/// </remarks>
public sealed class JwtOptions
{
    /// <summary>
    /// Nombre de la sección de configuración en el archivo de configuración.
    /// </summary>
    public const string SectionName = "Jwt";

    /// <summary>
    /// Clave secreta usada para firmar los tokens JWT.
    /// </summary>
    /// <value>Cadena de texto con la clave simétrica o secreta del token.</value>
    public required string Key { get; init; }

    /// <summary>
    /// Emisor del token JWT.
    /// </summary>
    /// <value>Identificador del servicio o aplicación que emite los tokens.</value>
    public required string Issuer { get; init; }

    /// <summary>
    /// Audiencia esperada por el token JWT.
    /// </summary>
    /// <value>Identificador del consumidor o recurso que valida el token.</value>
    public required string Audience { get; init; }

    /// <summary>
    /// Duración en minutos de validez del token JWT.
    /// </summary>
    /// <value>Tiempo de expiración del token en minutos. El valor predeterminado es 60.</value>
    public int ExpirationMinutes { get; init; } = 60;
}
