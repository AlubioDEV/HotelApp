namespace HotelApp.DAL.Models.Infraestructura;

public class Hotel
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public bool Activo { get; set; } = true;

    public ICollection<Piso> Pisos { get; set; } = new List<Piso>();
}
