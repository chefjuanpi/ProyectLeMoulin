USE [master]
GO
/****** Object:  Database [LeMoulindaCote]    Script Date: 03/07/2014 18:20:25 ******/
CREATE DATABASE [LeMoulindaCote]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeMoulindaCote', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LeMoulindaCote.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LeMoulindaCote_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LeMoulindaCote_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LeMoulindaCote] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeMoulindaCote].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeMoulindaCote] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LeMoulindaCote] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeMoulindaCote] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeMoulindaCote] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LeMoulindaCote] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeMoulindaCote] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LeMoulindaCote] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET RECOVERY FULL 
GO
ALTER DATABASE [LeMoulindaCote] SET  MULTI_USER 
GO
ALTER DATABASE [LeMoulindaCote] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeMoulindaCote] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeMoulindaCote] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeMoulindaCote] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LeMoulindaCote', N'ON'
GO
USE [LeMoulindaCote]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppointmentDiary]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentDiary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[SomeImportantKey] [int] NOT NULL,
	[DateTimeScheduled] [datetime] NOT NULL,
	[AppointmentLength] [int] NOT NULL,
	[StatusENUM] [int] NOT NULL,
 CONSTRAINT [PK_ConsultantBookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogPicture]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPicture](
	[BlogId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPicture] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[PictureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[PictureId] [int] NOT NULL,
	[Text] [nvarchar](4000) NOT NULL,
	[Date] [date] NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogTag]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTag](
	[BlogId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_BlogTag] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryProduct]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProduct](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Comment] [nvarchar](128) NOT NULL,
	[Validate] [bit] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menus]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantite] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Date_Fin_Commande] [date] NOT NULL,
	[Date_Recuperation] [date] NULL,
	[Commande_Payee] [bit] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PagePicture]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagePicture](
	[PageId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
 CONSTRAINT [PK_PagePicture] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC,
	[PictureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pages]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[MenuId] [nvarchar](128) NULL,
	[Title] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[Pictures] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Pictures] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[TVQ] [bit] NOT NULL,
	[TPS] [bit] NOT NULL,
	[Avaibled] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Section]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[PageId] [int] NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](256) NOT NULL,
	[ContactName] [nvarchar](256) NOT NULL,
	[Adress] [nvarchar](256) NOT NULL,
	[E-Mail] [nvarchar](256) NULL,
	[Phone] [nvarchar](256) NOT NULL,
	[Fax] [nvarchar](256) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagPage]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagPage](
	[PageId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_TagPage] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Types]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Week]    Script Date: 03/07/2014 18:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Week](
	[DateSemaine] [date] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Format] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Week] PRIMARY KEY CLUSTERED 
(
	[DateSemaine] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AppointmentDiary] ON 

INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (1, N'Appt: 0', 0, CAST(0x0000A36A00000000 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (2, N'Appt: 1', 1, CAST(0x0000A35D011AE5E0 AS DateTime), 60, 2)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (3, N'Appt: 2', 2, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (4, N'Appt: 3', 3, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (5, N'Appt: 4', 4, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (6, N'Appt: 5', 5, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (7, N'Appt: 6', 6, CAST(0x0000A35A00B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (8, N'Appt: 7', 7, CAST(0x0000A36000B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (9, N'Appt: 8', 8, CAST(0x0000A35A00B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (10, N'Appt: 9', 9, CAST(0x0000A36000B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (11, N'Appt: 10', 10, CAST(0x0000A35A00B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (12, N'Appt: 11', 11, CAST(0x0000A36000B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (13, N'Appt: 12', 12, CAST(0x0000A35A00B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (14, N'Appt: 13', 13, CAST(0x0000A36000B80560 AS DateTime), 15, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (15, N'Appt: 14', 14, CAST(0x0000A35500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (16, N'Appt: 15', 15, CAST(0x0000A36500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (17, N'Appt: 16', 16, CAST(0x0000A35500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (18, N'Appt: 17', 17, CAST(0x0000A36500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (19, N'Appt: 18', 18, CAST(0x0000A35500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (20, N'Appt: 19', 19, CAST(0x0000A36500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (21, N'Appt: 20', 20, CAST(0x0000A35500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (22, N'Appt: 21', 21, CAST(0x0000A36500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (23, N'Appt: 22', 22, CAST(0x0000A35500986F70 AS DateTime), 30, 1)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (24, N'Appt: 23', 23, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (25, N'Appt: 24', 24, CAST(0x0000A35800CC9ED0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (26, N'Appt: 25', 25, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (27, N'Appt: 26', 26, CAST(0x0000A35800CC9ED0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (28, N'Appt: 27', 27, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (29, N'Appt: 28', 28, CAST(0x0000A35800CC9ED0 AS DateTime), 30, 0)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM]) VALUES (30, N'Appt: 29', 29, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0)
SET IDENTITY_INSERT [dbo].[AppointmentDiary] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 03/07/2014 18:20:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 03/07/2014 18:20:25 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 03/07/2014 18:20:25 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 03/07/2014 18:20:25 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 03/07/2014 18:20:25 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 03/07/2014 18:20:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF_ConsultantBookings_Status]  DEFAULT ((0)) FOR [StatusENUM]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BlogPicture]  WITH CHECK ADD  CONSTRAINT [FK_BlogPicture_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([BlogId])
GO
ALTER TABLE [dbo].[BlogPicture] CHECK CONSTRAINT [FK_BlogPicture_Blogs]
GO
ALTER TABLE [dbo].[BlogPicture]  WITH CHECK ADD  CONSTRAINT [FK_BlogPicture_Pictures] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Pictures] ([Pictures])
GO
ALTER TABLE [dbo].[BlogPicture] CHECK CONSTRAINT [FK_BlogPicture_Pictures]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Types] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Types] ([TypeId])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Types]
GO
ALTER TABLE [dbo].[BlogTag]  WITH CHECK ADD  CONSTRAINT [FK_BlogTag_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([BlogId])
GO
ALTER TABLE [dbo].[BlogTag] CHECK CONSTRAINT [FK_BlogTag_Blogs]
GO
ALTER TABLE [dbo].[BlogTag]  WITH CHECK ADD  CONSTRAINT [FK_BlogTag_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[BlogTag] CHECK CONSTRAINT [FK_BlogTag_Tags]
GO
ALTER TABLE [dbo].[CategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProduct_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[CategoryProduct] CHECK CONSTRAINT [FK_CategoryProduct_Categories]
GO
ALTER TABLE [dbo].[CategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProduct_Products1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[CategoryProduct] CHECK CONSTRAINT [FK_CategoryProduct_Products1]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([BlogId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Blogs]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Pages] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Pages] ([PageId])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Pages]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers]
GO
ALTER TABLE [dbo].[PagePicture]  WITH CHECK ADD  CONSTRAINT [FK_PagePicture_Pages] FOREIGN KEY([PageId])
REFERENCES [dbo].[Pages] ([PageId])
GO
ALTER TABLE [dbo].[PagePicture] CHECK CONSTRAINT [FK_PagePicture_Pages]
GO
ALTER TABLE [dbo].[PagePicture]  WITH CHECK ADD  CONSTRAINT [FK_PagePicture_Pictures] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Pictures] ([Pictures])
GO
ALTER TABLE [dbo].[PagePicture] CHECK CONSTRAINT [FK_PagePicture_Pictures]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Pages] FOREIGN KEY([PageId])
REFERENCES [dbo].[Pages] ([PageId])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Pages]
GO
ALTER TABLE [dbo].[TagPage]  WITH CHECK ADD  CONSTRAINT [FK_TagPage_Pages] FOREIGN KEY([PageId])
REFERENCES [dbo].[Pages] ([PageId])
GO
ALTER TABLE [dbo].[TagPage] CHECK CONSTRAINT [FK_TagPage_Pages]
GO
ALTER TABLE [dbo].[TagPage]  WITH CHECK ADD  CONSTRAINT [FK_TagPage_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[TagPage] CHECK CONSTRAINT [FK_TagPage_Tags]
GO
ALTER TABLE [dbo].[Week]  WITH CHECK ADD  CONSTRAINT [FK_Week_Products1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Week] CHECK CONSTRAINT [FK_Week_Products1]
GO
ALTER TABLE [dbo].[Week]  WITH CHECK ADD  CONSTRAINT [FK_Week_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[Week] CHECK CONSTRAINT [FK_Week_Suppliers]
GO
USE [master]
GO
ALTER DATABASE [LeMoulindaCote] SET  READ_WRITE 
GO
