namespace HotelApp.DAL.Models.Infraestructura;

public class TipoHabitacion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
}
