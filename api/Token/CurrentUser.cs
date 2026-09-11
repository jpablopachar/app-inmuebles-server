using System.Security.Claims;

namespace api.Token;

/// <summary>
/// Proporciona información sobre el usuario de la solicitud HTTP actual.
/// </summary>
/// <param name="httpContextAccessor">Acceso al contexto HTTP actual.</param>
public sealed class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
    private ClaimsPrincipal? Principal => httpContextAccessor.HttpContext?.User;

    /// <summary>
    /// Indica si el usuario actual está autenticado.
    /// </summary>
    public bool IsAuthenticated => Principal?.Identity?.IsAuthenticated == true;

    /// <summary>
    /// Obtiene el identificador del usuario actual.
    /// </summary>
    /// <value>El identificador del usuario, o <see langword="null"/> si no está disponible.</value>
    public Guid? UserId => Guid.TryParse(Principal?.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : null;

    /// <summary>
    /// Obtiene el nombre del usuario actual.
    /// </summary>
    /// <value>El nombre del usuario, o <see langword="null"/> si no está disponible.</value>
    public string? UserName => Principal?.FindFirstValue(ClaimTypes.Name) ?? Principal?.Identity?.Name;
}
