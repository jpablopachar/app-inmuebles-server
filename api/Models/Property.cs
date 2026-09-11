namespace api.Models;

/**
 * Representa una propiedad inmobiliaria disponible en la plataforma.
 */
public class Property
{
    /// <summary>
    /// Obtiene o establece el identificador único de la propiedad.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre de la propiedad.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Obtiene o establece la dirección física de la propiedad.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Obtiene o establece el precio de la propiedad.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Obtiene o establece la URL o ruta de la imagen principal de la propiedad.
    /// </summary>
    public string? Picture { get; set; }

    /// <summary>
    /// Obtiene la fecha y hora en que la propiedad fue creada.
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// Obtiene o establece el identificador del usuario propietario de la propiedad.
    /// </summary>
    public Guid? UserId { get; set; }
}
