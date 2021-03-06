USE [master]
GO

/****** Object:  Database [ALPHA_TIC]    Script Date: 1/03/2021 12:48:14 a. m. ******/
CREATE DATABASE [ALPHA_TIC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALPHA_TIC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ALPHA_TIC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ALPHA_TIC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ALPHA_TIC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ALPHA_TIC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ALPHA_TIC] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET ARITHABORT OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ALPHA_TIC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ALPHA_TIC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ALPHA_TIC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ALPHA_TIC] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET RECOVERY FULL 
GO

ALTER DATABASE [ALPHA_TIC] SET  MULTI_USER 
GO

ALTER DATABASE [ALPHA_TIC] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ALPHA_TIC] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ALPHA_TIC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ALPHA_TIC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ALPHA_TIC] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ALPHA_TIC] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ALPHA_TIC] SET  READ_WRITE 
GO


