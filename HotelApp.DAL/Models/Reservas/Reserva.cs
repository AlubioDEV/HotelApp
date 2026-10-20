using HotelApp.DAL.Models.Clientes;
using HotelApp.DAL.Models.Enums;
using HotelApp.DAL.Models.Infraestructura;
using HotelApp.DAL.Models.Notificaciones;

namespace HotelApp.DAL.Models.Reservas;

public class Reserva
{
    public int Id { get; set; }
    public int HuespedId { get; set; }
    public int HabitacionId { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public int CantidadHuespedes { get; set; }
    public decimal Total { get; set; }
    public EstadoReserva Estado { get; set; } = EstadoReserva.Pending;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;   // auditoría RNF-007
    public DateTime? FechaActualizacion { get; set; }

    public Huesped Huesped { get; set; } = null!;
    public Habitacion Habitacion { get; set; } = null!;
    public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}
