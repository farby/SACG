using System;
using System.Collections.Generic;

public interface IRepoPersona
{
	Persona AltaPersona(Int32 Documento, String Nombre, String Apellido, String Telefono);

	Persona ModificarPersona(Int32 Documento, String Nombre, String Apellido, String Telefono);

	Void BajaPersona(Int32 Documento);

	List BuscarPersona(Int32 Documento);

}

