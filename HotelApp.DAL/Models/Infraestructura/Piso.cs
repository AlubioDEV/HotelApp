namespace HotelApp.DAL.Models.Infraestructura;

public class Piso
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int Numero { get; set; }
    public bool Activo { get; set; } = true;

    public Hotel Hotel { get; set; } = null!;
    public ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
}
