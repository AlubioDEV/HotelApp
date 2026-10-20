using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Infraestructura");

            migrationBuilder.EnsureSchema(
                name: "Clientes");

            migrationBuilder.EnsureSchema(
                name: "Notificaciones");

            migrationBuilder.EnsureSchema(
                name: "Reservas");

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "Infraestructura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huesped",
                schema: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huesped", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                schema: "Infraestructura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piso",
                schema: "Infraestructura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piso_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "Infraestructura",
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                schema: "Infraestructura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    PisoId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    TarifaPorNoche = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitacion_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "Infraestructura",
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habitacion_Piso_PisoId",
                        column: x => x.PisoId,
                        principalSchema: "Infraestructura",
                        principalTable: "Piso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Habitacion_TipoHabitacion_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "Infraestructura",
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                schema: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HuespedId = table.Column<int>(type: "int", nullable: false),
                    HabitacionId = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadHuespedes = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalSchema: "Infraestructura",
                        principalTable: "Habitacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Huesped_HuespedId",
                        column: x => x.HuespedId,
                        principalSchema: "Clientes",
                        principalTable: "Huesped",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notificacion",
                schema: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    TipoEvento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacion_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalSchema: "Reservas",
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_HotelId_Numero",
                schema: "Infraestructura",
                table: "Habitacion",
                columns: new[] { "HotelId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_PisoId",
                schema: "Infraestructura",
                table: "Habitacion",
                column: "PisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_TipoId",
                schema: "Infraestructura",
                table: "Habitacion",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Documento",
                schema: "Clientes",
                table: "Huesped",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_ReservaId",
                schema: "Notificaciones",
                table: "Notificacion",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Piso_HotelId_Numero",
                schema: "Infraestructura",
                table: "Piso",
                columns: new[] { "HotelId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HabitacionId",
                schema: "Reservas",
                table: "Reserva",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HuespedId",
                schema: "Reservas",
                table: "Reserva",
                column: "HuespedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacion",
                schema: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Reserva",
                schema: "Reservas");

            migrationBuilder.DropTable(
                name: "Habitacion",
                schema: "Infraestructura");

            migrationBuilder.DropTable(
                name: "Huesped",
                schema: "Clientes");

            migrationBuilder.DropTable(
                name: "Piso",
                schema: "Infraestructura");

            migrationBuilder.DropTable(
                name: "TipoHabitacion",
                schema: "Infraestructura");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "Infraestructura");
        }
    }
}
