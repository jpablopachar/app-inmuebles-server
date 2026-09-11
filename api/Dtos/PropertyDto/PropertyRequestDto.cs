using System.ComponentModel.DataAnnotations;

namespace api.Dtos.PropertyDto;

/// <summary>
/// Representa la solicitud de registro de una propiedad.
/// </summary>
/// <param name="Name">Nombre de la propiedad. Debe tener entre 3 y 120 caracteres.</param>
/// <param name="Address">Dirección de la propiedad. Tiene un máximo de 250 caracteres.</param>
/// <param name="Price">Precio de la propiedad. Debe ser mayor a 0 y no exceder 999999999.</param>
/// <param name="Picture">URL opcional de la imagen de la propiedad. Debe ser una URL válida y tener como máximo 2048 caracteres.</param>
public record PropertyRequestDto(
    [param: Required, StringLength(120, MinimumLength = 3)] string Name,
    [param: Required, StringLength(250)] string Address,
    [param: Range(typeof(decimal), "0.01", "999999999")] decimal Price,
    [param: Url, StringLength(2048)] string? Picture
);
