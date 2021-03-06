USE [master]
GO
/****** Object:  Database [BD_TRANSACCIONES_YMF]    Script Date: 12/4/2020 3:02:44 PM ******/
CREATE DATABASE [BD_TRANSACCIONES_YMF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_TRANSACCIONES_YMF', FILENAME = N'C:\work\test\BCP\db\BD_TRANSACCIONES_YMF.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BD_TRANSACCIONES_YMF_log', FILENAME = N'C:\work\test\BCP\db\BD_TRANSACCIONES_YMF_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_TRANSACCIONES_YMF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET  MULTI_USER 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BD_TRANSACCIONES_YMF]
GO
/****** Object:  User [UsrBcp]    Script Date: 12/4/2020 3:02:44 PM ******/
CREATE USER [UsrBcp] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [BcpUser]    Script Date: 12/4/2020 3:02:44 PM ******/
CREATE USER [BcpUser] FOR LOGIN [BcpUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [UsrBcp]
GO
ALTER ROLE [db_owner] ADD MEMBER [BcpUser]
GO
/****** Object:  Table [dbo].[CUENTA]    Script Date: 12/4/2020 3:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUENTA](
	[NRO_CUENTA] [nvarchar](14) NOT NULL,
	[TIPO] [char](3) NULL,
	[MONEDA] [char](3) NULL,
	[NOMBRE] [nvarchar](40) NULL,
	[SALDO] [decimal](12, 2) NULL,
 CONSTRAINT [PK_CUENTA] PRIMARY KEY CLUSTERED 
(
	[NRO_CUENTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MOVIMIENTO]    Script Date: 12/4/2020 3:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIMIENTO](
	[NRO_CUENTA] [nvarchar](14) NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[TIPO] [char](1) NULL,
	[IMPORTE] [decimal](12, 2) NULL,
 CONSTRAINT [PK_MOVIMIENTO] PRIMARY KEY CLUSTERED 
(
	[FECHA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MOVIMIENTO]  WITH CHECK ADD  CONSTRAINT [FK_MOVIMIENTO_CUENTA] FOREIGN KEY([NRO_CUENTA])
REFERENCES [dbo].[CUENTA] ([NRO_CUENTA])
GO
ALTER TABLE [dbo].[MOVIMIENTO] CHECK CONSTRAINT [FK_MOVIMIENTO_CUENTA]
GO
USE [master]
GO
ALTER DATABASE [BD_TRANSACCIONES_YMF] SET  READ_WRITE 
GO
