using HotelApp.DAL.Models.Clientes;
using HotelApp.DAL.Models.Infraestructura;
using HotelApp.DAL.Models.Notificaciones;
using HotelApp.DAL.Models.Reservas;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.DAL.Data;

public class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

    public DbSet<Hotel> Hoteles => Set<Hotel>();
    public DbSet<Piso> Pisos => Set<Piso>();
    public DbSet<TipoHabitacion> TiposHabitacion => Set<TipoHabitacion>();
    public DbSet<Habitacion> Habitaciones => Set<Habitacion>();
    public DbSet<Huesped> Huespedes => Set<Huesped>();
    public DbSet<Reserva> Reservas => Set<Reserva>();
    public DbSet<Notificacion> Notificaciones => Set<Notificacion>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Schemas (un schema por subcarpeta de Models)
        mb.Entity<Hotel>().ToTable("Hotel", "Infraestructura");
        mb.Entity<Piso>().ToTable("Piso", "Infraestructura");
        mb.Entity<TipoHabitacion>().ToTable("TipoHabitacion", "Infraestructura");
        mb.Entity<Habitacion>().ToTable("Habitacion", "Infraestructura");
        mb.Entity<Huesped>().ToTable("Huesped", "Clientes");
        mb.Entity<Reserva>().ToTable("Reserva", "Reservas");
        mb.Entity<Notificacion>().ToTable("Notificacion", "Notificaciones");

        mb.Entity<Hotel>().Property(x => x.Nombre).HasMaxLength(150).IsRequired();
        mb.Entity<Hotel>().Property(x => x.Direccion).HasMaxLength(250).IsRequired();
        mb.Entity<TipoHabitacion>().Property(x => x.Nombre).HasMaxLength(80).IsRequired();
        mb.Entity<Habitacion>().Property(x => x.Numero).HasMaxLength(10).IsRequired();
        mb.Entity<Habitacion>().Property(x => x.TarifaPorNoche).HasPrecision(10, 2);
        mb.Entity<Habitacion>().Property(x => x.Estado).HasConversion<string>().HasMaxLength(20);
        mb.Entity<Huesped>().Property(x => x.Nombre).HasMaxLength(150).IsRequired();
        mb.Entity<Huesped>().Property(x => x.Documento).HasMaxLength(30).IsRequired();
        mb.Entity<Reserva>().Property(x => x.Total).HasPrecision(12, 2);
        mb.Entity<Reserva>().Property(x => x.Estado).HasConversion<string>().HasMaxLength(20);
        mb.Entity<Notificacion>().Property(x => x.Estado).HasConversion<string>().HasMaxLength(20);
        mb.Entity<Notificacion>().Property(x => x.TipoEvento).HasConversion<string>().HasMaxLength(20);

        // Unicidad (RN-003, RN-005, huésped por documento)
        mb.Entity<Piso>().HasIndex(x => new { x.HotelId, x.Numero }).IsUnique();
        mb.Entity<Habitacion>().HasIndex(x => new { x.HotelId, x.Numero }).IsUnique();
        mb.Entity<Huesped>().HasIndex(x => x.Documento).IsUnique();

        // Relaciones (sin borrado en cascada para conservar historial - RNF-007)
        mb.Entity<Piso>().HasOne(x => x.Hotel).WithMany(x => x.Pisos).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Restrict);
        mb.Entity<Habitacion>().HasOne(x => x.Piso).WithMany(x => x.Habitaciones).HasForeignKey(x => x.PisoId).OnDelete(DeleteBehavior.Restrict);
        mb.Entity<Habitacion>().HasOne(x => x.Hotel).WithMany().HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Restrict);
        mb.Entity<Habitacion>().HasOne(x => x.Tipo).WithMany(x => x.Habitaciones).HasForeignKey(x => x.TipoId).OnDelete(DeleteBehavior.Restrict);
        mb.Entity<Reserva>().HasOne(x => x.Huesped).WithMany(x => x.Reservas).HasForeignKey(x => x.HuespedId).OnDelete(DeleteBehavior.Restrict);
        mb.Entity<Reserva>().HasOne(x => x.Habitacion).WithMany(x => x.Reservas).HasForeignKey(x => x.HabitacionId).OnDelete(DeleteBehavior.Restrict);
        mb.Entity<Notificacion>().HasOne(x => x.Reserva).WithMany(x => x.Notificaciones).HasForeignKey(x => x.ReservaId).OnDelete(DeleteBehavior.Restrict);
    }
}
