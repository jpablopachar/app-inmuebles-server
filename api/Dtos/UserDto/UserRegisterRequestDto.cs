using System.ComponentModel.DataAnnotations;

namespace api.Dtos.UserDto;

/// <summary>
/// Representa la solicitud de registro de un nuevo usuario en la aplicación.
/// </summary>
/// <param name="Name">Nombre del usuario.</param>
/// <param name="LastName">Apellido del usuario.</param>
/// <param name="Phone">Número de teléfono del usuario, si se proporciona.</param>
/// <param name="Email">Correo electrónico del usuario.</param>
/// <param name="UserName">Nombre de usuario con una longitud mínima de 3 caracteres y máxima de 50.</param>
/// <param name="Password">Contraseña del usuario con una longitud mínima de 8 caracteres.</param>
public record UserRegisterRequestDto(
    [param: Required, StringLength(80)] string Name,
    [param: Required, StringLength(80)] string LastName,
    [param: Phone] string? Phone,
    [param: Required, EmailAddress] string Email,
    [param: Required, StringLength(50, MinimumLength = 3)] string UserName,
    [param: Required, MinLength(8)] string Password
);
