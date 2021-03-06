USE [master]
GO
/****** Object:  Database [SACG_DB]    Script Date: 05/07/2014 19:24:03 ******/
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
/****** Object:  StoredProcedure [dbo].[spActivarEstablecimiento]    Script Date: 05/07/2014 19:24:03 ******/
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
/****** Object:  StoredProcedure [dbo].[spAgregarEvento]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAgregarEvento]
(
@Tipo varchar(25),
@Nombre varchar(50),
@Fecha datetime,
@Observaciones varchar(max),
--@DICOSEOrigen bigint,
--@DICOSEDestino bigint,
@Animal int
)
as
begin
	if exists (select * from Animales where ID = @Animal)
	begin
		insert into Eventos values (@Tipo, @Nombre, @Fecha, @Observaciones, '', '', @Animal);
	end
	if @Tipo like '%Muerte%'
	begin
		update Animales set AñoMuerte = year(@fecha) where ID = @Animal
	end
end
;
GO
/****** Object:  StoredProcedure [dbo].[spAgregarTransferencia]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAgregarTransferencia]
(
@Tipo varchar(25),
@Nombre varchar(50),
@Fecha datetime,
@Observaciones varchar(max),
@DICOSEOrigen bigint,
@DICOSEDestino bigint,
@Animal int
)
as
begin
	if exists (select * from Animales where ID = @Animal and DICOSE = @DICOSEOrigen)
	begin
		insert into Eventos values (@Tipo, @Nombre, @Fecha, @Observaciones, @DICOSEOrigen, @DICOSEDestino, @Animal);
	end	
end
;
GO
/****** Object:  StoredProcedure [dbo].[spAltaAnimal]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAltaAnimal]
(
@DICOSE bigint,
@Sexo char(1),
@Ano int,
@Estacion char(1),
@Raza varchar(25)
)
as
begin
	if exists (select * from Establecimientos where DICOSE = @DICOSE)
	begin
		insert into Animales values ('', @DICOSE, @Sexo, @Ano, '', @Estacion, @Raza);
	end	
end
;
GO
/****** Object:  StoredProcedure [dbo].[spAltaAnimalRFID]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAltaAnimalRFID]
(
@RFID bigint,
@DICOSE bigint,
@Sexo char(1),
@Ano int,
@Estacion char(1),
@Raza varchar(25)
)
as
begin
	if exists (select * from Establecimientos where DICOSE = @DICOSE)
	begin
		insert into Animales values (@RFID, @DICOSE, @Sexo, @Ano, '', @Estacion, @Raza);
	end	
end
;
GO
/****** Object:  StoredProcedure [dbo].[spAltaEstablecimiento]    Script Date: 05/07/2014 19:24:03 ******/
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
		insert into Personas values (@Responsable, @Nombre, @Apellido, @Telefono);
	end
	insert into Establecimientos values (@DICOSE, @RUT, @BPS, @RazonSocial, @Responsable, @Departamento, @SeccionalPolicial,
		@Paraje, @Direccion, @Telefono, @Email, @Superficie, 'Pendiente')
	
end
;
GO
/****** Object:  StoredProcedure [dbo].[spBajaEstablecimiento]    Script Date: 05/07/2014 19:24:03 ******/
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
/****** Object:  StoredProcedure [dbo].[spModificarEstablecimiento]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spModificarEstablecimiento]
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
@Superficie int
)
as
begin
	if not exists (select * from SACG_DB.dbo.Personas where Documento = @Responsable)
	begin
		insert into SACG_DB.dbo.Personas values (@Responsable, '','', @Telefono);
	end
	update SACG_DB.dbo.Establecimientos
	set RUT = @RUT, BPS = @BPS, RazonSocial = @RazonSocial, Responsable = @Responsable, Departamento = @Departamento,
	SeccionPolicial = @SeccionalPolicial, Paraje = @Paraje, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, Superficie = @Superficie
	where DICOSE = @DICOSE
	
end
;
GO
/****** Object:  Table [dbo].[Animales]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Animales](
	[RFID] [bigint] NULL,
	[DICOSE] [bigint] NULL,
	[Sexo] [char](1) NULL,
	[AñoNacimiento] [int] NULL,
	[AñoMuerte] [int] NULL,
	[EstacionNacimiento] [char](1) NULL,
	[RazaCruza] [varchar](25) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Establecimientos]    Script Date: 05/07/2014 19:24:03 ******/
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
/****** Object:  Table [dbo].[Eventos]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Eventos](
	[Tipo] [varchar](25) NULL,
	[Nombre] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Observaciones] [varchar](max) NULL,
	[DICOSEOrigen] [bigint] NULL,
	[DICOSEDestino] [bigint] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Animal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 05/07/2014 19:24:03 ******/
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
/****** Object:  View [dbo].[Activos]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Activos]
AS
SELECT        DICOSE
FROM            dbo.Establecimientos
WHERE        (Estado LIKE 'Activo')

GO
/****** Object:  View [dbo].[Pendientes]    Script Date: 05/07/2014 19:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Pendientes] as
select DICOSE
from Establecimientos
where estado like 'Pendiente';
GO
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (1, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Activo')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (6, 6, 6, N'6', 6, N'6', 6, N'6', N'6', N'6', N'6', 6, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (8, 8, 8, N'8', 8, N'8', 8, N'8', N'8', N'8', N'8', 8, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (11, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (54, 54, 54, N'54', 4, N'54', 54, N'54', N'4', N'4', N'4', 4, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (95, 5, 5, N'5', 5, N'5', 5, N'5', N'5', N'5', N'5', 5, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (134, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (245, 5, 5, N'', 5, N'5', 5, N'5', N'5', N'5', N'5', 5, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (333, 3, 3, N'3', 3, N'3', 3, N'3', N'3', N'3', N'3', 3, N'Activo')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (999, 999, 999, N'999', 999, N'999', 999, N'999', N'999', N'999', N'999', 999, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (1010, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (1231, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (2111, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (9991, 999, 999, N'999', 1, N'999', 999, N'999', N'999', N'999', N'999', 999, N'Activo')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (13111, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (123321, 999, 999, N'999', 999, N'999', 999, N'999', N'999', N'999', N'999', 999, N'Activo')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (123456, 999, 999, N'999', 11224455, N'999', 999, N'999', N'999', N'2354666', N'999', 999, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (311241, 1, 1, N'1', 1, N'2', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (999234, 999, 999, N'999', 999, N'999', 999, N'999', N'999', N'999', N'999', 999, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (1115884, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Establecimientos] ([DICOSE], [RUT], [BPS], [RazonSocial], [Responsable], [Departamento], [SeccionPolicial], [Paraje], [Direccion], [Telefono], [Email], [Superficie], [Estado]) VALUES (2311111, 1, 1, N'1', 1, N'1', 1, N'1', N'1', N'1', N'1', 1, N'Pendiente')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (1, N'Prueba', N'Prueba', N'')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (3, N'3', N'3', N'3')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (4, N'4', N'4', N'4')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (5, N'5', N'5', N'5')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (6, N'6', N'6', N'6')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (8, N'8', N'8', N'8')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (123, N'', N'', N'')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (999, N'Prueba', N'Prueba', N'')
INSERT [dbo].[Personas] ([Documento], [Nombre], [Apellido], [Telefono]) VALUES (11224455, N'FAB', N'BEN', N'')
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD FOREIGN KEY([DICOSE])
REFERENCES [dbo].[Establecimientos] ([DICOSE])
GO
ALTER TABLE [dbo].[Establecimientos]  WITH CHECK ADD FOREIGN KEY([Responsable])
REFERENCES [dbo].[Personas] ([Documento])
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD FOREIGN KEY([Animal])
REFERENCES [dbo].[Animales] ([ID])
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD CHECK  (([EstacionNacimiento]='I' OR [EstacionNacimiento]='P' OR [EstacionNacimiento]='O' OR [EstacionNacimiento]='V'))
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD CHECK  (([Sexo]='H' OR [Sexo]='M'))
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Establecimientos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Activos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Activos'
GO
USE [master]
GO
ALTER DATABASE [SACG_DB] SET  READ_WRITE 
GO
