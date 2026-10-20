using HotelApp.DAL.Models.Reservas;

namespace HotelApp.DAL.Models.Clientes;

public class Huesped
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Documento { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
