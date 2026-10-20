namespace HotelApp.DAL.Models.Enums;

public enum EstadoHabitacion { Available, Reserved, Occupied, Cleaning, Maintenance, OutOfService }
public enum EstadoReserva { Pending, Confirmed, InProgress, Completed, Cancelled }
public enum EstadoNotificacion { Pendiente, Enviada, Fallida }
public enum TipoEventoNotificacion { Confirmacion, Modificacion, Cancelacion }
