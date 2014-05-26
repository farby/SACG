using System;
using System.Collections.Generic;

public class RepositorioEstablecimiento : IRepoEstablecimiento
{

	/// <see>IRepoEstablecimiento#AltaEstablecimiento(System.Int64, System.Int32, System.Int32, System.String, Persona, System.String, System.Int32, System.String, System.String, System.String, System.String, System.String, System.Int32, System.Boolean)</see>
	public Establecimiento AltaEstablecimiento(Int64 DICOSE, Int32 RUT, Int32 BPS, String RazonSocial, Persona Responsable, String Departamento, Int32 SeccionalPolicial, String Paraje, String Direccion, String Telefono, String Fax, String Email, Int32 Superficie, Boolean Estado)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#ModificarEstablecimiento(System.Int64, System.Int32, System.Int32, System.String, Persona, System.String, System.Int32, System.String, System.String, System.String, System.String, System.String, System.Int32)</see>
	public Establecimiento ModificarEstablecimiento(Int64 DICOSE, Int32 RUT, Int32 BPS, String RazonSocial, Persona Responsable, String Departamento, Int32 SeccionalPolicial, String Paraje, String Direccion, String Telefono, String Fax, String Email, Int32 Superficie)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#BajaEstablecimiento(System.Int64)</see>
	public Void BajaEstablecimiento(Int64 DICOSE)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#AceptarSolicitud(System.Int64)</see>
	public Void AceptarSolicitud(Int64 DICOSE)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#ModificarEstado(System.Int64, System.Enum)</see>
	public Void ModificarEstado(Int64 DICOSE, Enum Estado)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#TransferenciaAnimal(System.Int32, System.Int64, System.Int64, System.Enum, System.DateTime, System.String)</see>
	public void TransferenciaAnimal(Int32 IDAnimal, Int64 DICOSEOrigen, Int64 DICOSEDestino, Enum TipoOperacion, DateTime FechaTransaccion, String Observaciones)
	{

	}


	/// <see>IRepoEstablecimiento#StockAnimales(System.Int64)</see>
	public List StockAnimales(Int64 DICOSE)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#AnimalesSinPesar(System.Int64, System.Int32)</see>
	public List AnimalesSinPesar(Int64 DICOSE, Int32 Tiempo)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#ReporteTratamientoAnimal(System.Int64, System.String)</see>
	public List ReporteTratamientoAnimal(Int64 DICOSE, String Tratamiento)
	{
		return null;
	}


	/// <see>IRepoEstablecimiento#BuscarEstablecimiento(System.Int64)</see>
	public List BuscarEstablecimiento(Int64 DICOSE)
	{
		return null;
	}

}

