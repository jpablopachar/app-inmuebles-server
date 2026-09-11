using Microsoft.AspNetCore.Identity;

namespace api.Models;

/// <summary>
/// Representa un usuario de la aplicación con información adicional de perfil.
/// </summary>
/// <remarks>
/// Esta clase extiende <see cref="IdentityUser{TKey}"/> para incluir datos personalizados
/// requeridos por el sistema, como nombre, apellido y teléfono.
/// </remarks>
public class AppUser : IdentityUser<Guid>
{
    /// <summary>
    /// Obtiene o establece el nombre del usuario.
    /// </summary>
    /// <value>
    /// Nombre del usuario o <c>null</c> si no se ha especificado.
    /// </value>
    public string? Name { get; set; }

    /// <summary>
    /// Obtiene o establece el apellido del usuario.
    /// </summary>
    /// <value>
    /// Apellido del usuario o <c>null</c> si no se ha especificado.
    /// </value>
    public string? LastName { get; set; }

    /// <summary>
    /// Obtiene o establece el número de teléfono del usuario.
    /// </summary>
    /// <value>
    /// Teléfono del usuario o <c>null</c> si no se ha especificado.
    /// </value>
    public string? Phone { get; set; }
}
