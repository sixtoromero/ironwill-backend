USE [master]
GO
/****** Object:  Database [IronWillBD]    Script Date: 06/03/2021 1:24:42 ******/
CREATE DATABASE [IronWillBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IronWillBD', FILENAME = N'/var/opt/mssql/data/IronWillBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IronWillBD_log', FILENAME = N'/var/opt/mssql/data/IronWillBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IronWillBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IronWillBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IronWillBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IronWillBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IronWillBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IronWillBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IronWillBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [IronWillBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IronWillBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IronWillBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IronWillBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IronWillBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IronWillBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IronWillBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IronWillBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IronWillBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IronWillBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IronWillBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IronWillBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IronWillBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IronWillBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IronWillBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IronWillBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IronWillBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IronWillBD] SET RECOVERY FULL 
GO
ALTER DATABASE [IronWillBD] SET  MULTI_USER 
GO
ALTER DATABASE [IronWillBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IronWillBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IronWillBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IronWillBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IronWillBD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IronWillBD', N'ON'
GO
ALTER DATABASE [IronWillBD] SET QUERY_STORE = OFF
GO
USE [IronWillBD]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[IdAgenda] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTipoEjercicio] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Hora] [nvarchar](9) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[IdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial_Clinico]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial_Clinico](
	[IdHistorialClinico] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Observacion] [nvarchar](max) NOT NULL,
	[Peso] [decimal](3, 2) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Historial_Clinico] PRIMARY KEY CLUSTERED 
(
	[IdHistorialClinico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil_Profesional_Instructor]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil_Profesional_Instructor](
	[IdPerfilProfesionalInst] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Perfil_Profesional] [nvarchar](max) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Perfil_Profesional_Instructor] PRIMARY KEY CLUSTERED 
(
	[IdPerfilProfesionalInst] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recomendaciones]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recomendaciones](
	[IdRecomendacion] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Observacion] [nvarchar](max) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Recomendaciones] PRIMARY KEY CLUSTERED 
(
	[IdRecomendacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Retos]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Retos](
	[IdReto] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Reto] [nvarchar](max) NOT NULL,
	[Peso] [decimal](3, 2) NOT NULL,
	[Tiempo] [nvarchar](10) NOT NULL,
	[Logro] [bit] NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Retos] PRIMARY KEY CLUSTERED 
(
	[IdReto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Ejercicios]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Ejercicios](
	[IdTipoEjercicio] [int] IDENTITY(1,1) NOT NULL,
	[Ejercicio] [nvarchar](150) NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Tipos_Ejercicios] PRIMARY KEY CLUSTERED 
(
	[IdTipoEjercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [nvarchar](1) NOT NULL,
	[Documento] [nvarchar](20) NOT NULL,
	[Nombres] [nvarchar](80) NOT NULL,
	[Apellidos] [nvarchar](80) NULL,
	[Direccion] [nvarchar](120) NOT NULL,
	[Celular] [nvarchar](15) NOT NULL,
	[Correo] [nvarchar](250) NOT NULL,
	[Clave] [nvarchar](max) NULL,
	[Genero] [nvarchar](1) NOT NULL,
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Usuarios]
GO
ALTER TABLE [dbo].[Historial_Clinico]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Clinico_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Historial_Clinico] CHECK CONSTRAINT [FK_Historial_Clinico_Usuarios]
GO
ALTER TABLE [dbo].[Perfil]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Perfil] CHECK CONSTRAINT [FK_Perfil_Rol]
GO
ALTER TABLE [dbo].[Perfil]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Perfil] CHECK CONSTRAINT [FK_Perfil_Usuarios]
GO
ALTER TABLE [dbo].[Perfil_Profesional_Instructor]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Profesional_Instructor_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Perfil_Profesional_Instructor] CHECK CONSTRAINT [FK_Perfil_Profesional_Instructor_Usuarios]
GO
ALTER TABLE [dbo].[Recomendaciones]  WITH CHECK ADD  CONSTRAINT [FK_Recomendaciones_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Recomendaciones] CHECK CONSTRAINT [FK_Recomendaciones_Usuarios]
GO
ALTER TABLE [dbo].[Retos]  WITH CHECK ADD  CONSTRAINT [FK_Retos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Retos] CHECK CONSTRAINT [FK_Retos_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[uspDeletePerfilProfesional]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeletePerfilProfesional]
	@IdPerfilProfesionalInst int	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY										
		DELETE FROM [dbo].[Perfil_Profesional_Instructor] WHERE IdPerfilProfesionalInst = @IdPerfilProfesionalInst
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteUsuario]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
	Descripción: Procedimiento encargado de Actualizar los usuarios en la tabla Usuarios
*/
CREATE PROCEDURE [dbo].[uspDeleteUsuario]
	@IdUsuario int	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		
		DELETE FROM [dbo].[Perfil] WHERE IdUsuario = @IdUsuario
		DELETE FROM [dbo].[Perfil_Profesional_Instructor] WHERE IdUsuario = @IdUsuario
		DELETE FROM [dbo].[Agenda] WHERE IdUsuario = @IdUsuario
		DELETE FROM [dbo].[Historial_Clinico] WHERE IdUsuario = @IdUsuario		
		DELETE FROM [dbo].[Recomendaciones] WHERE IdUsuario = @IdUsuario
		DELETE FROM [dbo].[Retos] WHERE IdUsuario = @IdUsuario
		DELETE FROM [dbo].[Tipos_Ejercicios] WHERE IdUsuario = @IdUsuario
		DELETE FROM [dbo].[Usuarios] WHERE IdUsuario = @IdUsuario

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetHistoryAthlete]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetHistoryAthlete]
	@IdUsuario int
AS
SELECT a.IdAgenda
      ,u.Nombres + ' ' + u.Apellidos as Deportista
      ,a.IdTipoEjercicio
	  ,te.Ejercicio
      ,a.Fecha
      ,a.Hora
      ,a.Fecha_Creacion
  FROM dbo.Agenda as a 
  INNER JOIN dbo.Usuarios u ON a.IdUsuario = u.IdUsuario
  INNER JOIN dbo.Tipos_Ejercicios te ON a.IdTipoEjercicio = te.IdTipoEjercicio
  WHERE a.IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[UspgetPerfilPro]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetPerfilPro]
	@IdUsuario INT
AS
SELECT 
IdPerfilProfesionalInst
,IdUsuario
,Perfil_Profesional
Fecha_Creacion
FROM [dbo].[Perfil_Profesional_Instructor] WHERE IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[UspgetTipos_Ejercicios]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetTipos_Ejercicios]	
AS
BEGIN	
	SELECT IdTipoEjercicio
			,Ejercicio
			,Fecha_Creacion FROM [dbo].[Tipos_Ejercicios]
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetUserByLogin]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUserByLogin]
	@Correo nvarchar(80),
	@Clave nvarchar(250)
AS
SELECT u.IdUsuario
,u.TipoDocumento
,u.Documento
,u.Nombres
,u.Apellidos
,u.Direccion
,u.Celular
,u.Correo
,u.Clave
,u.Genero
,u.Fecha_Nacimiento
,u.Estado
,p.IdPerfil
,p.Nombre as Perfil
,u.Fecha_Creacion FROM [dbo].[Usuarios] u
INNER JOIN [dbo].[Perfil] p
ON u.IdUsuario = p.IdUsuario
WHERE u.Correo = @Correo AND u.Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[uspInsertAgenda]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspInsertAgenda]
	@IdUsuario int
	,@IdTipoEjercicio int
	,@Fecha date
	,@Hora nvarchar(20)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		INSERT INTO [dbo].[Agenda] (			
			IdUsuario
			,IdTipoEjercicio
			,Fecha
			,Hora
			,Fecha_Creacion
		) VALUES (
			@IdUsuario
			,@IdTipoEjercicio
			,@Fecha
			,@Hora
			,GETDATE()
		)

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspInsertPerfilProfesional]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspInsertPerfilProfesional]
	@IdUsuario INT,
	@Perfil_Profesional NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		INSERT INTO [dbo].[Perfil_Profesional_Instructor] (			
			IdUsuario
			,Perfil_Profesional
			,Fecha_Creacion
		) VALUES (
			@IdUsuario
			,@Perfil_Profesional
			,GETDATE()
		)

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspInsertUsuario]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	Descripción: Procedimiento encargado de registrar los usuarios en la tabla Usuarios
*/
CREATE PROCEDURE [dbo].[uspInsertUsuario]
	@TipoDocumento	nvarchar(1),
	@Documento	nvarchar(20),
	@Nombres	nvarchar(80),
	@Apellidos	nvarchar(80),
	@Direccion	nvarchar(120),
	@Celular	nvarchar(15),
	@Correo	nvarchar(250),
	@Clave	nvarchar(MAX),
	@Genero	nvarchar(1),
	@Fecha_Nacimiento	datetime,
	@Estado	bit
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		INSERT INTO [dbo].[Usuarios] (			
			TipoDocumento
			,Documento
			,Nombres
			,Apellidos
			,Direccion
			,Celular
			,Correo
			,Clave
			,Genero
			,Fecha_Nacimiento
			,Estado
			,Fecha_Creacion
		) VALUES (
			@TipoDocumento
			,@Documento
			,@Nombres
			,@Apellidos
			,@Direccion
			,@Celular
			,@Correo
			,@Clave
			,@Genero
			,@Fecha_Nacimiento
			,@Estado
			,GETDATE()
		)

	INSERT INTO [dbo].[Perfil] ([IdRol]
      ,[IdUsuario]
      ,[Nombre]
      ,[Fecha_Creacion]) VALUES (3, @@IDENTITY, 'Deportista', getdate())

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdatePerfilProfesional]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUpdatePerfilProfesional]
	@IdPerfilProfesionalInst INT,	
	@Perfil_Profesional NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		UPDATE [dbo].[Perfil_Profesional_Instructor] SET
			Perfil_Profesional = @Perfil_Profesional
		WHERE IdPerfilProfesionalInst = @IdPerfilProfesionalInst
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateUsuario]    Script Date: 06/03/2021 1:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUpdateUsuario]
	@IdUsuario int,
	@TipoDocumento	nvarchar(1),
	@Documento	nvarchar(20),
	@Nombres	nvarchar(80),
	@Apellidos	nvarchar(80),
	@Direccion	nvarchar(120),
	@Celular	nvarchar(15),
	@Clave nvarchar(max),
	@Correo	nvarchar(250),
	@Genero	nvarchar(1),
	@Fecha_Nacimiento	datetime,
	@Estado	bit
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY
		UPDATE [dbo].[Usuarios] SET 		
			TipoDocumento = @TipoDocumento
			,Documento = @Documento
			,Nombres = @Nombres
			,Apellidos = @Apellidos
			,Direccion = @Direccion
			,Celular = @Celular
			,Correo = @Correo
			,Clave = @Clave
			,Genero = @Genero
			,Fecha_Nacimiento = @Fecha_Nacimiento
			,Estado = @Estado
		WHERE IdUsuario = @IdUsuario

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
USE [master]
GO
ALTER DATABASE [IronWillBD] SET  READ_WRITE 
GO
