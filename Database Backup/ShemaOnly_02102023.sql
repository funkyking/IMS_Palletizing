USE [master]
GO
/****** Object:  Database [CRICUT]    Script Date: 2/10/2023 5:31:55 PM ******/
CREATE DATABASE [CRICUT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRICUT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\CRICUT.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CRICUT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\CRICUT_log.ldf' , SIZE = 2560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CRICUT] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRICUT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRICUT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRICUT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRICUT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRICUT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRICUT] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRICUT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRICUT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRICUT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRICUT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRICUT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRICUT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRICUT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRICUT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRICUT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRICUT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRICUT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRICUT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRICUT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRICUT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRICUT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRICUT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRICUT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRICUT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRICUT] SET  MULTI_USER 
GO
ALTER DATABASE [CRICUT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRICUT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRICUT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRICUT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRICUT] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CRICUT]
GO
/****** Object:  Schema [CUPID]    Script Date: 2/10/2023 5:31:55 PM ******/
CREATE SCHEMA [CUPID]
GO
/****** Object:  Table [CUPID].[Access]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[Access](
	[User lvl] [nvarchar](50) NOT NULL,
	[Production] [bit] NOT NULL,
	[Master] [bit] NOT NULL,
	[Setting] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[ContainerMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[ContainerMaster](
	[Master Container ID] [uniqueidentifier] NULL,
	[Master Container Name] [nchar](50) NULL,
	[Completed] [bit] NULL,
	[UserID] [nchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[ContainerShipping]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[ContainerShipping](
	[Loading ID] [uniqueidentifier] NOT NULL,
	[Master Container ID] [uniqueidentifier] NULL,
	[Master Container Name] [nchar](50) NULL,
	[Word Order ID] [uniqueidentifier] NULL,
	[Work Order] [nvarchar](50) NULL,
	[Sub Group] [nvarchar](50) NULL,
	[Pallet No] [nvarchar](50) NULL,
	[Shift] [nvarchar](50) NULL,
	[UserID] [nchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[CustomerMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[CustomerMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Customer ID] [uniqueidentifier] NOT NULL,
	[Company Name] [nvarchar](50) NULL,
	[Customer Name] [nvarchar](50) NULL,
	[Contact No] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Country Code] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Postcode] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[Delete] [bit] NULL,
	[Modified Date] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[FailMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[FailMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[FailID] [uniqueidentifier] NULL,
	[FailCode] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Delete] [bit] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[LineMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[LineMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[LineID] [uniqueidentifier] NOT NULL,
	[Line] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Delete] [bit] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[ModelMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[ModelMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Model ID] [uniqueidentifier] NOT NULL,
	[Model] [nvarchar](50) NULL,
	[Bin] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[BarcodeLength] [int] NULL,
	[Description] [nvarchar](100) NULL,
	[Modified Date] [datetime] NULL,
	[Delete] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[PartMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[PartMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Part ID] [uniqueidentifier] NULL,
	[Part No] [nvarchar](50) NULL,
	[Part Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Modified Date] [datetime] NULL,
	[Delete] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[ProductOrder]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[ProductOrder](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[ProductOrderID] [uniqueidentifier] NULL,
	[SerialNo] [nvarchar](50) NULL,
	[FailID] [uniqueidentifier] NULL,
	[ProductionDate] [datetime] NULL,
	[Process] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[ProductOrderMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[ProductOrderMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[ProductOrderID] [uniqueidentifier] NULL,
	[ProductOrder] [nvarchar](50) NULL,
	[PartID] [uniqueidentifier] NULL,
	[ModelID] [uniqueidentifier] NULL,
	[CustomerID] [uniqueidentifier] NULL,
	[Total] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Delete] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[QCLog]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[QCLog](
	[logID] [uniqueidentifier] NULL,
	[Work Order ID] [uniqueidentifier] NULL,
	[Work Order] [nvarchar](50) NULL,
	[Serial No] [nvarchar](50) NULL,
	[Sub Group] [nvarchar](50) NULL,
	[Pallet No] [nvarchar](50) NULL,
	[Shift] [nvarchar](50) NULL,
	[QCout] [bit] NULL,
	[QCout WID] [uniqueidentifier] NULL,
	[OutDate] [datetime] NULL,
	[OutUser] [nvarchar](50) NULL,
	[QCin] [bit] NULL,
	[InDate] [datetime] NULL,
	[InUser] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[UserMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[UserMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[User ID] [nvarchar](50) NULL,
	[User Name] [nvarchar](100) NULL,
	[User Level] [nvarchar](50) NULL,
	[Password] [nvarchar](200) NULL,
	[Modified Date] [datetime] NULL,
	[Delete] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[WorkOrder]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[WorkOrder](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Work Order ID] [uniqueidentifier] NULL,
	[Line] [nvarchar](50) NULL,
	[Serial No] [nvarchar](50) NULL,
	[Carton] [nchar](4) NULL,
	[Pallet No] [nvarchar](50) NULL,
	[Production Date] [datetime] NULL,
	[Shift] [nchar](10) NULL,
	[QCout] [bit] NULL,
	[OutDate] [datetime] NULL,
	[OutUser] [nvarchar](50) NULL,
	[QCin] [bit] NULL,
	[InDate] [datetime] NULL,
	[InUser] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[WorkOrderMaster]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[WorkOrderMaster](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Work Order ID] [uniqueidentifier] NULL,
	[Work Order] [nvarchar](50) NOT NULL,
	[Sub Group] [nvarchar](50) NULL,
	[Part ID] [uniqueidentifier] NULL,
	[Model ID] [uniqueidentifier] NULL,
	[LineID] [uniqueidentifier] NULL,
	[Quantity] [int] NULL,
	[Count] [int] NULL,
	[Total Order Count] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[Completed] [bit] NULL,
	[Modified Date] [datetime] NULL,
	[ScanOption] [int] NULL,
	[Delete] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[WorkOrderPalletizing]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[WorkOrderPalletizing](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Work Order ID] [uniqueidentifier] NULL,
	[Line] [nvarchar](50) NULL,
	[Serial No] [nvarchar](50) NULL,
	[Carton] [nchar](4) NULL,
	[Pallet No] [nvarchar](50) NULL,
	[Production Date] [datetime] NULL,
	[Shift] [nchar](10) NULL,
	[QCout] [bit] NULL,
	[OutDate] [datetime] NULL,
	[OutUser] [nvarchar](50) NULL,
	[QCin] [bit] NULL,
	[InDate] [datetime] NULL,
	[InUser] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [CUPID].[WorkOrderStatus]    Script Date: 2/10/2023 5:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CUPID].[WorkOrderStatus](
	[Work Order ID] [uniqueidentifier] NULL,
	[Work Order] [nvarchar](255) NULL,
	[Sub Group] [nvarchar](255) NULL,
	[Pallet No] [nvarchar](255) NULL,
	[Shift] [nvarchar](255) NULL,
	[PalletScanCompleted] [bit] NULL,
	[PalletizingCompleted] [bit] NULL,
	[Modified Date] [datetime] NULL,
	[Delete] [bit] NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [CRICUT] SET  READ_WRITE 
GO
