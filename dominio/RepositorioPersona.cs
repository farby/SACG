using System;
using System.Collections.Generic;

public class RepositorioPersona : IRepoPersona
{

	/// <see>IRepoPersona#AltaPersona(System.Int32, System.String, System.String, System.String)</see>
	public Persona AltaPersona(Int32 Documento, String Nombre, String Apellido, String Telefono)
	{
		return null;
	}


	/// <see>IRepoPersona#ModificarPersona(System.Int32, System.String, System.String, System.String)</see>
	public Persona ModificarPersona(Int32 Documento, String Nombre, String Apellido, String Telefono)
	{
		return null;
	}


	/// <see>IRepoPersona#BajaPersona(System.Int32)</see>
	public Void BajaPersona(Int32 Documento)
	{
		return null;
	}


	/// <see>IRepoPersona#BuscarPersona(System.Int32)</see>
	public List BuscarPersona(Int32 Documento)
	{
		return null;
	}

}

