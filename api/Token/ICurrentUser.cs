namespace api.Token;

public interface ICurrentUser
{
    /// <summary>
    /// Indica si el usuario actual está autenticado.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Obtiene el identificador del usuario actual.
    /// </summary>
    Guid? UserId { get; }

    /// <summary>
    /// Obtiene el nombre del usuario actual.
    /// </summary>
    string? UserName { get; }
}
