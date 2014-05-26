using System;
using System.Collections.Generic;

public class RepositorioAnimal : IRepoAnimal
{

	/// <see>IRepoAnimal#AltaAnimal(System.Int32, System.Int64, System.Char, System.Int32, System.Char, System.String)</see>
	/// 
	///  
	public Animal AltaAnimal(Int32 ID, Int64 RFID, Char Sexo, Int32 AñoNacimiento, Char EstacionNacimiento, String RazaCruza)
	{
		return null;
	}


	/// <see>IRepoAnimal#ModificarAnimal(System.Int32, System.Char, System.Int32, System.Char, System.String)</see>
	public Animal ModificarAnimal(Int32 ID, Char Sexo, Int32 AñoNacimiento, Char EstacionNacimiento, String RazaCruza)
	{
		return null;
	}


	/// <see>IRepoAnimal#BajaAnimal(System.Int32, System.Int32)</see>
	public Void BajaAnimal(Int32 ID, Int32 AñoMuerte)
	{
		return null;
	}


	/// <see>IRepoAnimal#BuscarAnimal(System.Int32)</see>
	public Animal BuscarAnimal(Int32 ID)
	{
		return null;
	}


	/// <see>IRepoAnimal#ReportePesajeAnimal(System.Int32)</see>
	public List ReportePesajeAnimal(Int32 ID)
	{
		return null;
	}


	/// <see>IRepoAnimal#RegistrarEventoSanitario(System.Int32, System.Enum, System.String, System.DateTime, System.String)</see>
	public Evento RegistrarEventoSanitario(Int32 ID, Enum TipoEvento, String Nombre, DateTime Fecha, String Observaciones)
	{
		return null;
	}

}

