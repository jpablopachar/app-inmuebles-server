namespace api.Dtos.PropertyDto;

/// <summary>
/// Representa la respuesta de una propiedad devuelta por la API.
/// </summary>
/// <param name="Id">Identificador único de la propiedad.</param>
/// <param name="Name">Nombre de la propiedad.</param>
/// <param name="Address">Dirección física de la propiedad.</param>
/// <param name="Price">Precio de la propiedad.</param>
/// <param name="Picture">Ruta o URL de la imagen principal de la propiedad. Puede ser nula.</param>
/// <param name="CreatedAt">Fecha y hora en que se creó la propiedad.</param>
public record PropertyResponseDto(
    int Id,
    string Name,
    string Address,
    decimal Price,
    string? Picture,
    DateTimeOffset CreatedAt
);
