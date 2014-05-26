using System;
using System.Collections.Generic;

public interface IRepoEstablecimiento
{
	Establecimiento AltaEstablecimiento(Int64 DICOSE, Int32 RUT, Int32 BPS, String RazonSocial, Persona Responsable, String Departamento, Int32 SeccionalPolicial, String Paraje, String Direccion, String Telefono, String Fax, String Email, Int32 Superficie, Boolean Estado);

	Establecimiento ModificarEstablecimiento(Int64 DICOSE, Int32 RUT, Int32 BPS, String RazonSocial, Persona Responsable, String Departamento, Int32 SeccionalPolicial, String Paraje, String Direccion, String Telefono, String Fax, String Email, Int32 Superficie);

	Void BajaEstablecimiento(Int64 DICOSE);

	Void AceptarSolicitud(Int64 DICOSE);

	Void ModificarEstado(Int64 DICOSE, Enum Estado);

	Void TransferenciaAnimal(Int32 IDAnimal, Int64 DICOSEOrigen, Int64 DICOSEDestino, Enum TipoOperacion, DateTime FechaTransaccion, String Observaciones);

	List StockAnimales(Int64 DICOSE);

	List AnimalesSinPesar(Int64 DICOSE, Int32 Tiempo);

	List ReporteTratamientoAnimal(Int64 DICOSE, String Tratamiento);

	List BuscarEstablecimiento(Int64 DICOSE);

}

