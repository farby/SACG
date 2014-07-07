 USE [SACG_DB]
GO

/****** Object:  Table [dbo].[TipoEventos]    Script Date: 7/7/2014 4:19:44 AM ******/
DROP TABLE [dbo].[TipoEventos]
GO

/****** Object:  Table [dbo].[TipoEventos]    Script Date: 7/7/2014 4:19:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoEventos](
	[id] [int] NULL,
	[tipo] [varchar](50) NULL,
	[nombre] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


 
-- DATOS TABLA
insert into TipoEventos (id,tipo,nombre) values (1,SANITARIO,MUERTE);
insert into TipoEventos (id,tipo,nombre) values (2,SANITARIO,PESAJE);
insert into TipoEventos (id,tipo,nombre) values (3,SANITARIO,VACUNAS);
insert into TipoEventos (id,tipo,nombre) values (4,SANITARIO,TRATAMIENTOS);
insert into TipoEventos (id,tipo,nombre) values (5,SANITARIO,PRENIA);
insert into TipoEventos (id,tipo,nombre) values (6,SANITARIO,NACIMIENTOS);
insert into TipoEventos (id,tipo,nombre) values (7,COMPRAVENTA,COMPRA);
insert into TipoEventos (id,tipo,nombre) values (8,COMPRAVENTA,VENTA);


