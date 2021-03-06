USE [master]
GO
/****** Object:  Database [Bullkart]    Script Date: 4/15/2018 6:21:04 PM ******/
CREATE DATABASE [Bullkart]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bullkart', FILENAME = 'C:\Users\bhatt\Database\Bullkart.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bullkart_log', FILENAME = 'C:\Users\bhatt\Database\Bullkart_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Bullkart] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bullkart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bullkart] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bullkart] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bullkart] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bullkart] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bullkart] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bullkart] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Bullkart] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bullkart] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bullkart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bullkart] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bullkart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bullkart] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bullkart] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bullkart] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bullkart] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Bullkart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bullkart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bullkart] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bullkart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bullkart] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bullkart] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Bullkart] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bullkart] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bullkart] SET  MULTI_USER 
GO
ALTER DATABASE [Bullkart] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bullkart] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bullkart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bullkart] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bullkart] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bullkart] SET QUERY_STORE = OFF
GO
USE [Bullkart]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Bullkart]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 4/15/2018 6:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](128) NULL,
	[Address1] [varchar](128) NULL,
	[Address2] [varchar](128) NULL,
	[City] [varchar](64) NULL,
	[State] [varchar](32) NULL,
	[Email] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogs]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogs](
	[CatalogId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[CatalogName] [varchar](32) NULL,
	[Description] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[CatalogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](32) NULL,
	[Description] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLines]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[OrderLineId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Amount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[AddressId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](32) NULL,
	[Description] [varchar](256) NULL,
	[CategoryId] [int] NULL,
	[CatalogId] [int] NULL,
	[Price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [varchar](32) NULL,
	[Description] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/15/2018 6:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Catalogs] ON 

INSERT [dbo].[Catalogs] ([CatalogId], [CategoryId], [CatalogName], [Description]) VALUES (1, 10, N'Jeans', N'Women''s jeans')
INSERT [dbo].[Catalogs] ([CatalogId], [CategoryId], [CatalogName], [Description]) VALUES (2, 10, N'Tops', N'Tops for women')
SET IDENTITY_INSERT [dbo].[Catalogs] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (8, N'Movies', N'Movies discs')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (9, N'Men', N'Men related clothes, shoes')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (10, N'Women', N'Women related clothes, shoes')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (11, N'Accessories', N'Unisex accessories')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [CategoryId], [CatalogId], [Price]) VALUES (1, N'Shawshank Redemption', N'One of the greatest films starring Morgan Freeman', 8, NULL, 10.0000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [CategoryId], [CatalogId], [Price]) VALUES (2, N'Levis Denim - M', N'Medium sized Levis Denim for Women', 10, 1, 10.0000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [CategoryId], [CatalogId], [Price]) VALUES (3, N'Bulls Top - M', N'Medium sized top with Bulls logo', 10, 2, 10.0000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [CategoryId], [CatalogId], [Price]) VALUES (4, N'Bulls Top - L', N'Large sized top with Bulls logo', 10, 2, 10.0000)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([StatusId], [StatusCode], [Description]) VALUES (1, N'New', N'Order is new')
INSERT [dbo].[Statuses] ([StatusId], [StatusCode], [Description]) VALUES (2, N'Deleted', N'Deleted status - Soft Delete')
INSERT [dbo].[Statuses] ([StatusId], [StatusCode], [Description]) VALUES (3, N'Received', N'Order has been received')
INSERT [dbo].[Statuses] ([StatusId], [StatusCode], [Description]) VALUES (4, N'Shipped', N'Order is shipped')
INSERT [dbo].[Statuses] ([StatusId], [StatusCode], [Description]) VALUES (5, N'Cancelled', N'Order is cancelled')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
USE [master]
GO
ALTER DATABASE [Bullkart] SET  READ_WRITE 
GO
