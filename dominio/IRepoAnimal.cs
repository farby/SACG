using System;
using System.Collections.Generic;

public interface IRepoAnimal
{
	Animal AltaAnimal(Int32 ID, Int64 RFID, Char Sexo, Int32 AñoNacimiento, Char EstacionNacimiento, String RazaCruza);

	Animal ModificarAnimal(Int32 ID, Char Sexo, Int32 AñoNacimiento, Char EstacionNacimiento, String RazaCruza);

	Void BajaAnimal(Int32 ID, Int32 AñoMuerte);

	Animal BuscarAnimal(Int32 ID);

	List ReportePesajeAnimal(Int32 ID);

	Evento RegistrarEventoSanitario(Int32 ID, Enum TipoEvento, String Nombre, DateTime Fecha, String Observaciones);

}

