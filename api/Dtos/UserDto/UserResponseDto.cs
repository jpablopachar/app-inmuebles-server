namespace api.Dtos.UserDto;

/// <summary>
/// Representa la respuesta del usuario devuelta por la API.
/// </summary>
/// <param name="Id">Identificador único del usuario.</param>
/// <param name="Name">Nombre del usuario.</param>
/// <param name="Token">Token de autenticación del usuario.</param>
/// <param name="LastName">Apellido del usuario.</param>
/// <param name="UserName">Nombre de usuario.</param>
/// <param name="Email">Correo electrónico del usuario.</param>
/// <param name="Phone">Número de teléfono del usuario, si está disponible.</param>
public record UserResponseDto(
    string Id,
    string Name,
    string Token,
    string LastName,
    string UserName,
    string Email,
    string? Phone
);
