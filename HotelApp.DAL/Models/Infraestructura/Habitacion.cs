using HotelApp.DAL.Models.Enums;
using HotelApp.DAL.Models.Reservas;

namespace HotelApp.DAL.Models.Infraestructura;

public class Habitacion
{
    public int Id { get; set; }
    public int HotelId { get; set; }   // permite la restricción única (HotelId, Numero) - RN-005 / RNF-003
    public int PisoId { get; set; }
    public int TipoId { get; set; }
    public string Numero { get; set; } = null!;
    public int Capacidad { get; set; }
    public decimal TarifaPorNoche { get; set; }
    public EstadoHabitacion Estado { get; set; } = EstadoHabitacion.Available;

    public Hotel Hotel { get; set; } = null!;
    public Piso Piso { get; set; } = null!;
    public TipoHabitacion Tipo { get; set; } = null!;
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
