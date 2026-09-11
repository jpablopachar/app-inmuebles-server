using System.ComponentModel.DataAnnotations;

namespace api.Dtos.UserDto;

/// <summary>
/// Representa la solicitud de inicio de sesión de un usuario.
/// </summary>
/// <remarks>
/// Este DTO contiene las credenciales necesarias para autenticar a un usuario en la aplicación.
/// </remarks>
/// <param name="Email">Dirección de correo electrónico del usuario.</param>
/// <param name="Password">Contraseña del usuario.</param>
public record UserLoginRequestDto(
    [param: Required, EmailAddress] string Email,
    [param: Required] string Password
);
