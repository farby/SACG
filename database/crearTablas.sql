--Se crean las tablas de SACG con sus restricciones

create table Personas (
	Documento int primary key,
	Nombre varchar(25),
	Apellido varchar(25),
	Telefono varchar(10)
);

create table Establecimientos (
	DICOSE bigint primary key,
	RUT bigint,
	BPS bigint,
	RazonSocial varchar(25),
	Responsable int references Personas,
	Departamento varchar(25),
	SeccionPolicial int,
	Paraje varchar(25),
	Direccion varchar(50),
	Telefono varchar(10),
	Fax varchar(10),
	Email varchar(25),
	Superficie int,
	Estado varchar(10)
);

create table Eventos (
	ID int primary key,
	Tipo varchar(25),
	Nombre varchar(50),
	Fecha datetime,
	Observaciones varchar(MAX),
	DICOSEOrigen bigint null,
	DICOSEDestino bigint null
);

create table Historias (
	ID int primary key,
	Evento int references Eventos
);

create table Animales (
	ID int primary key,
	RFID bigint,
	DICOSE bigint references Establecimientos,
	Sexo char(1) check (Sexo in ('M', 'H')),
	AñoNacimiento int,
	AñoMuerte int,
	EstacionNacimiento char(1) check (EstacionNacimiento in ('V', 'O', 'P', 'I')),
	RazaCruza varchar(25),
	Historia int references Historias
);
