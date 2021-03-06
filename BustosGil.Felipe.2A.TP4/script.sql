USE [master]
GO
/****** Object:  Database [libros]    Script Date: 22/11/2020 21:08:35 ******/
CREATE DATABASE [libros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'libros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\libros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'libros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\libros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [libros] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [libros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [libros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [libros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [libros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [libros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [libros] SET ARITHABORT OFF 
GO
ALTER DATABASE [libros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [libros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [libros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [libros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [libros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [libros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [libros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [libros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [libros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [libros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [libros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [libros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [libros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [libros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [libros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [libros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [libros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [libros] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [libros] SET  MULTI_USER 
GO
ALTER DATABASE [libros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [libros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [libros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [libros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [libros] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [libros] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [libros] SET QUERY_STORE = OFF
GO
USE [libros]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 22/11/2020 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[editorial] [varchar](50) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[caracteristica] [varchar](50) NOT NULL,
 CONSTRAINT [PK_libros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[libros] ON 

INSERT [dbo].[libros] ([id], [editorial], [titulo], [tipo], [precio], [caracteristica]) VALUES (1, N'Apagogue', N'Autonomia cientifica', N'Investigacion', 3500, N'2 tomos')
INSERT [dbo].[libros] ([id], [editorial], [titulo], [tipo], [precio], [caracteristica]) VALUES (2, N'Aranzadi', N'Economia cientifica', N'Investigacion', 4200, N'4 tomos')
INSERT [dbo].[libros] ([id], [editorial], [titulo], [tipo], [precio], [caracteristica]) VALUES (3, N'Imaginando', N'El patito feo', N'Cuento', 360, N'Incluye ilustraciones')
INSERT [dbo].[libros] ([id], [editorial], [titulo], [tipo], [precio], [caracteristica]) VALUES (4, N'Sigmar', N'El mago de Oz', N'Cuento', 400, N'No incluye ilustraciones')
INSERT [dbo].[libros] ([id], [editorial], [titulo], [tipo], [precio], [caracteristica]) VALUES (5, N'Entropia', N'Moby Dick', N'Novela', 1200, N'Sin autografiar')
INSERT [dbo].[libros] ([id], [editorial], [titulo], [tipo], [precio], [caracteristica]) VALUES (6, N'Edelvives', N'El monstruo perfecto', N'Novela', 1700, N'Autografiado')
SET IDENTITY_INSERT [dbo].[libros] OFF
GO
USE [master]
GO
ALTER DATABASE [libros] SET  READ_WRITE 
GO
