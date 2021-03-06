USE [master]
GO
/****** Object:  Database [Rubrica]    Script Date: 26/11/2021 15:01:01 ******/
CREATE DATABASE [Rubrica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Rubrica', FILENAME = N'C:\Users\sanna\Rubrica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Rubrica_log', FILENAME = N'C:\Users\sanna\Rubrica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Rubrica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Rubrica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Rubrica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Rubrica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Rubrica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Rubrica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Rubrica] SET ARITHABORT OFF 
GO
ALTER DATABASE [Rubrica] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Rubrica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Rubrica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Rubrica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Rubrica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Rubrica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Rubrica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Rubrica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Rubrica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Rubrica] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Rubrica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Rubrica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Rubrica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Rubrica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Rubrica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Rubrica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Rubrica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Rubrica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Rubrica] SET  MULTI_USER 
GO
ALTER DATABASE [Rubrica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Rubrica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Rubrica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Rubrica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Rubrica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Rubrica] SET QUERY_STORE = OFF
GO
USE [Rubrica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Rubrica]
GO
/****** Object:  Table [dbo].[Contatto]    Script Date: 26/11/2021 15:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contatto](
	[IdContatto] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Cognome] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Contatto] PRIMARY KEY CLUSTERED 
(
	[IdContatto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indirizzo]    Script Date: 26/11/2021 15:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indirizzo](
	[IdIndirizzo] [int] IDENTITY(1,1) NOT NULL,
	[Tipologia] [nvarchar](30) NOT NULL,
	[Via] [nvarchar](30) NOT NULL,
	[Citta] [nvarchar](30) NOT NULL,
	[Cap] [nchar](5) NOT NULL,
	[Provincia] [nvarchar](30) NOT NULL,
	[Nazione] [nvarchar](30) NOT NULL,
	[IdContatto] [int] NOT NULL,
 CONSTRAINT [PK_Indirizzo] PRIMARY KEY CLUSTERED 
(
	[IdIndirizzo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contatto] ON 

INSERT [dbo].[Contatto] ([IdContatto], [Nome], [Cognome]) VALUES (1, N'Stefania', N'Sanna')
INSERT [dbo].[Contatto] ([IdContatto], [Nome], [Cognome]) VALUES (3, N'Silvia', N'Bella')
INSERT [dbo].[Contatto] ([IdContatto], [Nome], [Cognome]) VALUES (5, N'Mauro', N'Sanna')
INSERT [dbo].[Contatto] ([IdContatto], [Nome], [Cognome]) VALUES (7, N'Nicolò', N'Caddeo')
SET IDENTITY_INSERT [dbo].[Contatto] OFF
GO
SET IDENTITY_INSERT [dbo].[Indirizzo] ON 

INSERT [dbo].[Indirizzo] ([IdIndirizzo], [Tipologia], [Via], [Citta], [Cap], [Provincia], [Nazione], [IdContatto]) VALUES (1, N'Domicilio', N'Rossini', N'Cagliari', N'09128', N'Cagliari', N'Italia', 1)
INSERT [dbo].[Indirizzo] ([IdIndirizzo], [Tipologia], [Via], [Citta], [Cap], [Provincia], [Nazione], [IdContatto]) VALUES (2, N'Residenza', N'Pessina', N'Cagliari', N'09212', N'Cagliari', N'Italia', 1)
INSERT [dbo].[Indirizzo] ([IdIndirizzo], [Tipologia], [Via], [Citta], [Cap], [Provincia], [Nazione], [IdContatto]) VALUES (3, N'Domicilio', N'Genovesi', N'Cagliari', N'09125', N'Cagliari', N'Italia', 3)
INSERT [dbo].[Indirizzo] ([IdIndirizzo], [Tipologia], [Via], [Citta], [Cap], [Provincia], [Nazione], [IdContatto]) VALUES (4, N'Domicilio', N'Dante', N'Cagliari', N'09134', N'Cagliari', N'Italia', 7)
SET IDENTITY_INSERT [dbo].[Indirizzo] OFF
GO
ALTER TABLE [dbo].[Indirizzo]  WITH CHECK ADD  CONSTRAINT [FK_Indirizzo] FOREIGN KEY([IdContatto])
REFERENCES [dbo].[Contatto] ([IdContatto])
GO
ALTER TABLE [dbo].[Indirizzo] CHECK CONSTRAINT [FK_Indirizzo]
GO
USE [master]
GO
ALTER DATABASE [Rubrica] SET  READ_WRITE 
GO
