using HotelApp.DAL.Models.Enums;
using HotelApp.DAL.Models.Reservas;

namespace HotelApp.DAL.Models.Notificaciones;

public class Notificacion
{
    public int Id { get; set; }
    public int ReservaId { get; set; }
    public TipoEventoNotificacion TipoEvento { get; set; }
    public string Mensaje { get; set; } = null!;
    public EstadoNotificacion Estado { get; set; } = EstadoNotificacion.Pendiente;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaEnvio { get; set; }

    public Reserva Reserva { get; set; } = null!;
}
