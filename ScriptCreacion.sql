USE [master]
GO
/****** Object:  Database [SACG_DB]    Script Date: 03/07/2014 21:16:25 ******/
CREATE DATABASE [SACG_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SACG', FILENAME = N'x:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SACG.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SACG_log', FILENAME = N'x:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SACG_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SACG_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SACG_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SACG_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SACG_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SACG_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SACG_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SACG_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SACG_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SACG_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SACG_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SACG_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SACG_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SACG_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SACG_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SACG_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SACG_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SACG_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SACG_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SACG_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SACG_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SACG_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SACG_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SACG_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SACG_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SACG_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SACG_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SACG_DB] SET  MULTI_USER 
GO
ALTER DATABASE [SACG_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SACG_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SACG_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SACG_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SACG_DB]
GO
/****** Object:  StoredProcedure [dbo].[spActivarEstablecimiento]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spActivarEstablecimiento]
(
@DICOSE bigint
)
as
begin
	update Establecimientos
	set Estado = 'Activo'
	where DICOSE = @DICOSE
end
;
GO
/****** Object:  StoredProcedure [dbo].[spAltaEstablecimiento]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAltaEstablecimiento]
(
@DICOSE bigint,
@RUT bigint,
@BPS bigint,
@RazonSocial varchar(25),
@Responsable int,
@Departamento varchar(25),
@SeccionalPolicial int,
@Paraje varchar(25),
@Direccion varchar(50),
@Telefono varchar(10),
@Email varchar(25),
@Superficie int,
@Nombre varchar(25),
@Apellido varchar(25)
)
as
begin
	if not exists (select * from Personas where Documento = @Responsable)
	begin
		insert into Personas values (@Responsable, @Nombre, @Apellido, '');
	end
	insert into Establecimientos values (@DICOSE, @RUT, @BPS, @RazonSocial, @Responsable, @Departamento, @SeccionalPolicial,
		@Paraje, @Direccion, @Telefono, @Email, @Superficie, 'Pendiente')
	
end
;
GO
/****** Object:  StoredProcedure [dbo].[spBajaEstablecimiento]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spBajaEstablecimiento]
(
@DICOSE bigint
)
as
begin
	update Establecimientos
	set Estado = 'Inactivo'
	where DICOSE = @DICOSE
end
;
GO
/****** Object:  Table [dbo].[Animales]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Animales](
	[ID] [int] NOT NULL,
	[RFID] [bigint] NULL,
	[DICOSE] [bigint] NULL,
	[Sexo] [char](1) NULL,
	[AñoNacimiento] [int] NULL,
	[AñoMuerte] [int] NULL,
	[EstacionNacimiento] [char](1) NULL,
	[RazaCruza] [varchar](25) NULL,
	[Historia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Establecimientos]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Establecimientos](
	[DICOSE] [bigint] NOT NULL,
	[RUT] [bigint] NULL,
	[BPS] [bigint] NULL,
	[RazonSocial] [varchar](25) NULL,
	[Responsable] [int] NULL,
	[Departamento] [varchar](25) NULL,
	[SeccionPolicial] [int] NULL,
	[Paraje] [varchar](25) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](10) NULL,
	[Email] [varchar](25) NULL,
	[Superficie] [int] NULL,
	[Estado] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[DICOSE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Eventos](
	[ID] [int] NOT NULL,
	[Tipo] [varchar](25) NULL,
	[Nombre] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Observaciones] [varchar](max) NULL,
	[DICOSEOrigen] [bigint] NULL,
	[DICOSEDestino] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Historias]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historias](
	[ID] [int] NOT NULL,
	[Evento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personas]    Script Date: 03/07/2014 21:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personas](
	[Documento] [int] NOT NULL,
	[Nombre] [varchar](25) NULL,
	[Apellido] [varchar](25) NULL,
	[Telefono] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (1, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (999, 999, 999, N'999', 999, N'999', 999, N'999', N'999', N'999', N'999', 999, N'Pendiente')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (1, N'Prueba', N'Prueba', N'')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (123, N'', N'', N'')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (999, N'Prueba', N'Prueba', N'')
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD FOREIGN KEY([DICOSE])
REFERENCES [dbo].[Establecimientos] ([DICOSE])
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD FOREIGN KEY([Historia])
REFERENCES [dbo].[Historias] ([ID])
GO
ALTER TABLE [dbo].[Establecimientos]  WITH CHECK ADD FOREIGN KEY([Responsable])
REFERENCES [dbo].[Personas] ([Documento])
GO
ALTER TABLE [dbo].[Historias]  WITH CHECK ADD FOREIGN KEY([Evento])
REFERENCES [dbo].[Eventos] ([ID])
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD CHECK  (([EstacionNacimiento]='I' OR [EstacionNacimiento]='P' OR [EstacionNacimiento]='O' OR [EstacionNacimiento]='V'))
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD CHECK  (([Sexo]='H' OR [Sexo]='M'))
GO
USE [master]
GO
ALTER DATABASE [SACG_DB] SET  READ_WRITE 
GO
