USE [master]
GO
/****** Object:  Database [ProyectLeMoulin]    Script Date: 26/08/2014 02:01:04 ******/
CREATE DATABASE [ProyectLeMoulin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectLeMoulin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProyectLeMoulin.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProyectLeMoulin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProyectLeMoulin_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProyectLeMoulin] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectLeMoulin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectLeMoulin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectLeMoulin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectLeMoulin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectLeMoulin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyectLeMoulin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectLeMoulin] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProyectLeMoulin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET RECOVERY FULL 
GO
ALTER DATABASE [ProyectLeMoulin] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectLeMoulin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectLeMoulin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectLeMoulin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectLeMoulin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProyectLeMoulin', N'ON'
GO
USE [ProyectLeMoulin]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[AppointmentDiary]    Script Date: 26/08/2014 02:01:04 ******/
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
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_ConsultantBookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[Prenom] [nvarchar](max) NULL,
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
/****** Object:  Table [dbo].[Categories]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[CategoryProduct]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProduct](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[detail] [nchar](10) NULL,
 CONSTRAINT [PK_CategoryProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[Evenements]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evenements](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[TitleEvenement] [nvarchar](150) NOT NULL,
	[PrincipalPhotoEvenement] [nvarchar](300) NULL,
	[PlaceEvenement] [nvarchar](150) NOT NULL,
	[AdresseEvenement] [nvarchar](300) NOT NULL,
	[DateStart] [date] NOT NULL,
	[HourStart] [time](7) NULL,
	[DateEnd] [date] NOT NULL,
	[HourEnd] [time](7) NULL,
	[Text] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Poublier] [bit] NULL,
 CONSTRAINT [PK_Evenements] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menus]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nouvelles]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nouvelles](
	[NouvelleId] [int] IDENTITY(1,1) NOT NULL,
	[NouvelleTitle] [nvarchar](150) NOT NULL,
	[NouvellePrincipalPhoto] [nvarchar](300) NULL,
	[NouvelleText] [text] NOT NULL,
	[NouvelleDate] [date] NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Publier] [bit] NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[NouvelleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NouvellesPicture]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NouvellesPicture](
	[BlogId] [int] NOT NULL,
	[PictureId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPicture] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[PictureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[WeekId] [int] NOT NULL,
	[Quantite] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC,
	[WeekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[WeekId] [int] NULL,
	[Commande_Payee] [bit] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Page_Section]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page_Section](
	[idpage] [int] NOT NULL,
	[idSection] [int] NOT NULL,
 CONSTRAINT [PK_Page_Section] PRIMARY KEY CLUSTERED 
(
	[idpage] ASC,
	[idSection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PagePicture]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[Pages]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](15) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Text] [text] NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Principal] [bit] NOT NULL,
	[SousMenu] [int] NULL,
	[Poublier] [bit] NULL,
 CONSTRAINT [PK_Pages_1] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 26/08/2014 02:01:04 ******/
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
/****** Object:  Table [dbo].[Section]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Section](
	[idSection] [int] IDENTITY(1,1) NOT NULL,
	[Contenu] [varchar](max) NULL,
	[Nom] [varchar](50) NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[idSection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 26/08/2014 02:01:04 ******/
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
	[PostalCode] [nvarchar](7) NOT NULL,
	[Ville] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WeekProduct]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeekProduct](
	[WeekId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Format] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_WeekProduct] PRIMARY KEY CLUSTERED 
(
	[WeekId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Weeks]    Script Date: 26/08/2014 02:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weeks](
	[WeekId] [int] IDENTITY(1,1) NOT NULL,
	[Date_Debut] [date] NULL,
	[Date_Fin] [date] NULL,
	[Date_Recuperation] [date] NULL,
 CONSTRAINT [PK_Week_1] PRIMARY KEY CLUSTERED 
(
	[WeekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201407141441556_InitialCreate', N'IdentitySample.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE4B8117D0F907F10F49404DE962F99C1C468EFC2DBB637467CC3B46791B7015B62B7859148AD44796D04FB65FB904FCA2FA4A83B6FBA74CBDDEDC500034B2C9E2A16ABC862A9D8FFFBFDBFD31F5EC2C07AC671E25372661F4D0E6D0B13977A3E599DD9295B7EF7C9FEE1FB3FFF697AE9852FD6CF25DD09A7839E2439B39F188B4E1D27719F70889249E8BB314DE8924D5C1A3AC8A3CEF1E1E13F9CA3230703840D589635FD9C12E687387B80C719252E8E588A825BEAE12029DE43CB3C43B5EE50889308B9F8CCBEF630F465AF731446019EE41D6CEB3CF0110833C7C1D2B61021942106A29E7E49F09CC594ACE611BC40C1E36B84816E898204174338ADC9FB8EE6F0988FC6A93B96506E9A301A0E043C3A29D4E3C8DDD752B25DA90F147899298B8F3A5362ADBFCF340005C80C4F6741CC89CFECDB8AC57912DD6136293B4E72C8AB18E07EA5F1B74913F1C0EADDEFA032A7E3C921FF7760CDD280A5313E233865310A0EAC877411F8EEBFF0EB23FD86C9D9C9D16279F2E9C347E49D7CFC3B3EF9D01C298C15E88417F0EA21A6118E4136BCACC66F5B8ED8CF913B56DD1A7D72AD802D8167D8D62D7AB9C164C59EC0678E3FD9D695FF82BDF24D615C5F880F8E049D589CC2E35D1A046811E0AADD69E5C9FF6FE17AFCE1E3285CEFD0B3BFCAA65EE20F8E13835F7DC641D69A3CF951EE5EC27C7F2DC8AE621AF267D1BEF2D6AF739AC62E1F0C35923CA278859928DDD4A98DB7974973A8F1CDBA44DD7FD3E692AAE6AD25E5035AC7134A16DBF68652DEB7E5DBDBE2CEA308262F332DAE913683D3EE57130900CC21A6AFD86537F896A6814F6A0B3AEA6B410446F6875E1069D8C214FEECC5B49DC7438CC916D85C86C80F4658DC7B7081D06AE9C721AE26EC470AAE84C860F53FA02481B5CDFB274A9EDE5C4173ECA631771A065EF3F6B3FE4409BE4BC305F7E4EDF11A6D6A1E7FA557C86534BE24BCD7C67837D4FD46537649BC0BC4F017E69680FCF1D10FFB038C22CEB9EBE224B90263C6DE8CC2C9A104BC26ECE478301C5F6F771D5CCD02E487FAE84ADA19BE96A47584A5A750A22C03992ED26A13F586AE7CD24FD492D42C6A4ED1296A413654540ED64FD282D22C6846D029674E355AEC9ACDD0F8C16B06BBFFD1EB667188692D68A8710E2B24FE09131CC332E63D20C6704CEA19E8B36EEC22EEC9A68F337DF3BD29E3F4330AD2B159ADE50DD92230BE3764B0FBEF0D9998F0FAD9F77854D2E3485712037C2F7AFD69B1DBE724C9B6ED0EC230B7CD7C3B6B80C95DCE9384BA7EE6059A645E918A11E58718CEEACECBE4A391733B303030749F6F79F006C666CB46754F2E708019B6CEDD3CD93943898B3C558D30206F8060E58EAA11ACCEF188C2FD4DE109968E63DE09F14350029EEA13A6BA854F5C3F4241A796A49E3DB7303EF68A87DC7281234C38C34E4DF461AE4FE970012A3ED2A4746968EA342CAEDD100D51AB69CEBB42D87ADE954CCB566CB2237636D86511BFBD8961B66B6C0BC6D9AE923E0218D393BB30D0E2ACD2D700E483CBBE19A8746232186811526DC540458DEDC0404595BC3B03CD8FA87DE75F3AAFEE9B798A07E5ED6FEBADEADA816D0AFAD833D3CC634FE8C3A0078E55F3BC58F046FCC234873390B3389F2545A82B9B48F62D0433316553C7BBDA38D46907918DA80DB036B40ED0E2C3A602A438D400E1CA5C5EAB7445143100B6CCBBB5C2166BBF04DBB00115BBF981B74168FE0C2C1B67AFD34735B2CA1A1423EF755868E0680C425EBCC481F7508A292FAB2AA64F2C3C241A6E0CAC988C16057544AE06259583195D4BA569766B4917900D09C936D292143E19B4540E66742D1536DAAD244D5030202CD84845E2163E92B395998E6AB7A9DAA64E5EFA55BC983A861AB1E92D8A229FAC1A3563C51B6B9E178CCDBE9B0F2FA30A730CC74D34D55495B415274663B4C2522BB00649AFFC38611788A105E2799E99172A64DABDD5B0FC972C9BDBA73A89E53E5052F3BFC5B55D2C4710B65B351E2960AE6090210F6AB24CBAC604F4DD2D5EC68702146B92F7331AA42131C758E6DEF927BC66FFFC8D8A307524F995184A519812E98ADAEF3537AA5F8C374F5514B3FE5C99214C1A2F63D0A6CE4D71A919A54C5335514CA9AB9DCD9D299C193A5F72B0387CBA3A11DEC8BB78158CE05C548949DBFA9785344D88F25D7F94A24EA60952BC1A88D128B550C01A6D03C62754C308A3145AFA234A252F4D48A9698094CDC21641C866C35A78068DEA29FA73504B599AE86A6B7F644D514B135AD3BC06B64666B9AD3FAAA6EEA509AC69EE8F5D17C1C8ABF91EEFA2C683D426DB687EDCDE6C1F3560BCCDD23CCE36DCA82A6802355E0FC42AEA0614B0E2FD5E1A94F1CCB98941E58996CD0CCA80615E7F844FF2E2F2D35A4760C614BEB38BDB784B9D81196F98D9BEA97128A74E99A4E25E9D3EA553E6B438F1755F57528E8039896D956A84EDFD3561389C7082C9FC976016F8982FE625C12D22FE12272CAF2DB18F0F8F8EA5EB4EFB73F5C849122FD09C984DF78FC439DB4299187946B1FB8462B5686383EB3935A8920FBF261E7E39B3FF93F53ACD522BFCAFECF581759D7C21FE2F29343CC629B67E538B50C7B9AED07EE6DBD3CB25FDB57AFDEFAF79D703EB3E068F39B50E255DAE33C3E2959341D2E45D379066ED8B28EFD8A1EA7B1725E65F42F4F2D726D0F02B1C1B4109D734B403957C74FD5B190B9F8D722363A3F16A6F5D6C3619EACD8AB1F04651A1E9E6C43A58C65B131E3CB2ECD6C4B0C1EA6F51AC239AF106854F8683C9F727FAAF8C65CF1DEE7E9A93DA3656C94CCF9DF5E71B15A3EE7ABB54CAD4377274B5147D00DC06E5E66B58C63BABD41E6DC3D614628F86BD4BD37EF3EAEB7D29B8AE4B61765B67BDCDD2EA960F677FA88AEA3DA801D4D434EDBE6E7ADBB666CA2EEF79F1E9B0EAE83D33B6A2D26DF735D0DB363653E679CF8D6D50A5F39ED9DAAEF6CF1D5B5AEF2D74E775CB6A0996E12B912E3DDD55979CE7F2E184BFA060047944995F27D517C29998D5C66264589398999A2BF064C68AE3287C158A76B6C3C65A6CF8AD832D68DAD91AEA56DB7817EB7F2BEF82A69DB7A11A741715D5DA7A4C5D957BC73AD65626F69E2AA885917414EC77C5ACAD9FFCDF53C1F4284A11BCC7F0D9FAFDD4478FA292315D67403DB4FA051AF6CEC6CF6AC2FE9DF8AB1A82FFC826C1AEB06B5634D76449CBCD5B92A824913234B798210FB6D4F398F94BE43268E639E6EC3E7C96B7E35F3A16D8BB26F7298B520643C6E12210125E3C0868E39F157D8B324FEFA3ECA75DC6180288E9F3DCFC3DF931F503AF92FB4A93133240F0E8A2C8E8F2B9643CB3BB7AAD90EE28E90954A8AF0A8A1E7118050096DC93397AC6EBC806E6778357C87DAD33802690EE8910D53EBDF0D12A46615260D4FDE1116CD80B5FBEFF3FB1E1456D5D560000, N'6.1.0-30225')
SET IDENTITY_INSERT [dbo].[AppointmentDiary] ON 

INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (1, N'Appt: 0', 0, CAST(0x0000A36A00000000 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (2, N'Appt: 1', 1, CAST(0x0000A35D011AE5E0 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (3, N'Appt: 2', 2, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (4, N'Appt: 3', 3, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (5, N'Appt: 4', 4, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (6, N'Appt: 5', 5, CAST(0x0000A35D00FCAF80 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (7, N'Appt: 6', 6, CAST(0x0000A35A00B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (8, N'Appt: 7', 7, CAST(0x0000A36000B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (9, N'Appt: 8', 8, CAST(0x0000A35A00B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (10, N'Appt: 9', 9, CAST(0x0000A36000B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (11, N'Appt: 10', 10, CAST(0x0000A35A00B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (12, N'Appt: 11', 11, CAST(0x0000A36000B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (13, N'Appt: 12', 12, CAST(0x0000A35A00B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (14, N'Appt: 13', 13, CAST(0x0000A36000B80560 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (15, N'Appt: 14', 14, CAST(0x0000A35500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (16, N'Appt: 15', 15, CAST(0x0000A36500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (17, N'Appt: 16', 16, CAST(0x0000A35500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (18, N'Appt: 17', 17, CAST(0x0000A36500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (19, N'Appt: 18', 18, CAST(0x0000A35500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (20, N'Appt: 19', 19, CAST(0x0000A36500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (21, N'Appt: 20', 20, CAST(0x0000A35500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (22, N'Appt: 21', 21, CAST(0x0000A36500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (23, N'Appt: 22', 22, CAST(0x0000A35500986F70 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (24, N'Appt: 23', 23, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (25, N'Appt: 24', 24, CAST(0x0000A35800CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (26, N'Appt: 25', 25, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (27, N'Appt: 26', 26, CAST(0x0000A35800CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (28, N'Appt: 27', 27, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (29, N'Appt: 28', 28, CAST(0x0000A35800CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (30, N'Appt: 29', 29, CAST(0x0000A36200CC9ED0 AS DateTime), 30, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (31, N'Appt: 0', 0, CAST(0x0000A37400DBBA00 AS DateTime), 30, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (32, N'Appt: 1', 1, CAST(0x0000A37400AA49C0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (33, N'Appt: 2', 2, CAST(0x0000A37400AA49C0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (34, N'Appt: 3', 3, CAST(0x0000A37400AA49C0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (35, N'Appt: 4', 4, CAST(0x0000A37400AA49C0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (36, N'Appt: 5', 5, CAST(0x0000A37400AA49C0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (37, N'Appt: 6', 6, CAST(0x0000A36B00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (38, N'Appt: 7', 7, CAST(0x0000A37D00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (39, N'Appt: 8', 8, CAST(0x0000A36B00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (40, N'Appt: 9', 9, CAST(0x0000A37D00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (41, N'Appt: 10', 10, CAST(0x0000A36B00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (42, N'Appt: 11', 11, CAST(0x0000A37D00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (43, N'Appt: 12', 12, CAST(0x0000A36B00C9DFB0 AS DateTime), 45, 1, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (44, N'Appt: 13', 13, CAST(0x0000A38200986F70 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (45, N'Appt: 14', 14, CAST(0x0000A36600986F70 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (46, N'Appt: 15', 15, CAST(0x0000A38200986F70 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (47, N'Appt: 16', 16, CAST(0x0000A36600986F70 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (48, N'Appt: 17', 17, CAST(0x0000A38200986F70 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (49, N'Appt: 18', 18, CAST(0x0000A36600986F70 AS DateTime), 60, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (50, N'Appt: 19', 19, CAST(0x0000A38000D79B50 AS DateTime), 45, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (51, N'Appt: 20', 20, CAST(0x0000A36800D79B50 AS DateTime), 45, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (52, N'Appt: 21', 21, CAST(0x0000A38000D79B50 AS DateTime), 45, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (53, N'Appt: 22', 22, CAST(0x0000A36800D79B50 AS DateTime), 45, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (54, N'Appt: 23', 23, CAST(0x0000A38000D79B50 AS DateTime), 45, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (55, N'Appt: 24', 24, CAST(0x0000A36800D79B50 AS DateTime), 45, 2, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (56, N'Appt: 25', 25, CAST(0x0000A37600A78AA0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (57, N'Appt: 26', 26, CAST(0x0000A37200A78AA0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (58, N'Appt: 27', 27, CAST(0x0000A37600A78AA0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (59, N'Appt: 28', 28, CAST(0x0000A37200A78AA0 AS DateTime), 15, 0, NULL)
INSERT [dbo].[AppointmentDiary] ([ID], [Title], [SomeImportantKey], [DateTimeScheduled], [AppointmentLength], [StatusENUM], [UserId]) VALUES (60, N'Appt: 29', 29, CAST(0x0000A37600A78AA0 AS DateTime), 15, 0, NULL)
SET IDENTITY_INSERT [dbo].[AppointmentDiary] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a4cd8fb3-0e77-444d-87af-09087b2ed98e', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6791a311-450a-4b2a-9a9a-1f3142fffaf9', N'Admin groupe d''achats')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1fa8e7cb-2dc9-41f5-aecf-a27a60e37423', N'Groupe d''achats')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1e0f6c6e-cf56-4542-8885-1355d0d4714c', N'1fa8e7cb-2dc9-41f5-aecf-a27a60e37423')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'52d81c3d-6d95-40c5-b246-340ec6bc40b9', N'a4cd8fb3-0e77-444d-87af-09087b2ed98e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'1fa8e7cb-2dc9-41f5-aecf-a27a60e37423')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'a4cd8fb3-0e77-444d-87af-09087b2ed98e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bd45b2ee-ecad-4646-b4dd-4d101732a485', N'1fa8e7cb-2dc9-41f5-aecf-a27a60e37423')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bd45b2ee-ecad-4646-b4dd-4d101732a485', N'a4cd8fb3-0e77-444d-87af-09087b2ed98e')
INSERT [dbo].[AspNetUsers] ([Id], [Nom], [Prenom], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e0f6c6e-cf56-4542-8885-1355d0d4714c', N'pablo', N'jojo', N'test@test.com', 1, N'ACTtyOb+NHcmvEMC6i6Mt/vXJiPdLLUfxGI0OqSoFi7pg0MWM9xvxNfzH+LDuUTT+Q==', N'06bba788-75fe-499f-8d1b-ca501b5ee63e', NULL, 0, 0, NULL, 1, 0, N'test@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [Nom], [Prenom], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'52d81c3d-6d95-40c5-b246-340ec6bc40b9', N'lundi', N'jhon', N'lundi@test.com', 0, N'APrYq8CvBkRMQQmaa9/hNEkIusU1Jj+3QZvKhlcaQi3drocD7Oqn5nzx6kXnx56tLQ==', N'9c5dfd5c-3d53-436b-bca2-d0a5e5211f2d', NULL, 0, 0, NULL, 1, 0, N'lundi@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [Nom], [Prenom], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'aguilar', N'Pablo', N'admin@example.com', 0, N'APzTNGmQ5YAVqUUcEnO1ERAt1+bDRroAAx8J7f18o4uMqEpq9mNmeu6JM4C6zi52Tg==', N'2697076b-5157-4074-9177-de3ac89e4299', NULL, 0, 0, NULL, 0, 0, N'admin@example.com')
INSERT [dbo].[AspNetUsers] ([Id], [Nom], [Prenom], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bd45b2ee-ecad-4646-b4dd-4d101732a485', N'Goyette', N'Michel', N'goym06@hotmail.com', 0, N'AJRpw2R5V/hZ/jTlYBiM39y7VaFP5wx6esw4qy1wfKQGzHvk2QghD/z368eoMO4Tiw==', N'0e8d7750-fb1c-4bf0-bc8d-574226b56739', NULL, 0, 0, NULL, 1, 0, N'goym06@hotmail.com')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1, N'legumes', NULL)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'viande', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
INSERT [dbo].[CategoryProduct] ([ProductId], [CategoryId], [detail]) VALUES (1, 1, NULL)
INSERT [dbo].[CategoryProduct] ([ProductId], [CategoryId], [detail]) VALUES (2, 2, NULL)
INSERT [dbo].[CategoryProduct] ([ProductId], [CategoryId], [detail]) VALUES (4, 1, NULL)
INSERT [dbo].[CategoryProduct] ([ProductId], [CategoryId], [detail]) VALUES (5, 2, NULL)
INSERT [dbo].[CategoryProduct] ([ProductId], [CategoryId], [detail]) VALUES (6, 2, NULL)
SET IDENTITY_INSERT [dbo].[Evenements] ON 

INSERT [dbo].[Evenements] ([EventId], [TitleEvenement], [PrincipalPhotoEvenement], [PlaceEvenement], [AdresseEvenement], [DateStart], [HourStart], [DateEnd], [HourEnd], [Text], [UserId], [Poublier]) VALUES (2, N'ggfhg', N'desert.jpg', N'ffgf', N'fgfgf', CAST(0xE5380B00 AS Date), CAST(0x0700DE16CF860000 AS Time), CAST(0xEA380B00 AS Date), CAST(0x070050CFDF960000 AS Time), N'<p><img src="../tinyfilemanager.net/resources/files/922931_638836456130081_1030856133_n.jpg" alt="" />fgfgfgfgfgfg</p>', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
INSERT [dbo].[Evenements] ([EventId], [TitleEvenement], [PrincipalPhotoEvenement], [PlaceEvenement], [AdresseEvenement], [DateStart], [HourStart], [DateEnd], [HourEnd], [Text], [UserId], [Poublier]) VALUES (3, N'fgfgf', N'483212_366270143486563_1736725180_n.jpg', N'dfdf', N'fdfd', CAST(0xE4380B00 AS Date), CAST(0x070050CFDF960000 AS Time), CAST(0xE6380B00 AS Date), CAST(0x0700A4ABE38F0000 AS Time), N'<p><img src="../tinyfilemanager.net/resources/files/1508998_518090941637815_1814660164_n.jpg" alt="" width="219" height="292" />wewewewewew</p>', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
INSERT [dbo].[Evenements] ([EventId], [TitleEvenement], [PrincipalPhotoEvenement], [PlaceEvenement], [AdresseEvenement], [DateStart], [HourStart], [DateEnd], [HourEnd], [Text], [UserId], [Poublier]) VALUES (4, N'ya dice', N'http://localhost:28141/tinyfilemanager.net/resources/files/1509057_407332502731526_1822018121_n.jpg', N'adas', N'asas', CAST(0xD9380B00 AS Date), CAST(0x070080461C860000 AS Time), CAST(0xDF380B00 AS Date), CAST(0x0700E80A7E8E0000 AS Time), N'<p>grgggggggggggggggggggggg</p>', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 0)
INSERT [dbo].[Evenements] ([EventId], [TitleEvenement], [PrincipalPhotoEvenement], [PlaceEvenement], [AdresseEvenement], [DateStart], [HourStart], [DateEnd], [HourEnd], [Text], [UserId], [Poublier]) VALUES (5, N'test', N'1393850815-md-119793_md_13562_samsung_galaxy_s5_handson1.png', N'rere', N'erere', CAST(0xE8380B00 AS Date), CAST(0x070080461C860000 AS Time), CAST(0xF0380B00 AS Date), CAST(0x0700E80A7E8E0000 AS Time), N'<p>ererer<img src="../tinyfilemanager.net/resources/files/483212_366270143486563_1736725180_n.jpg" alt="" /></p>', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
INSERT [dbo].[Evenements] ([EventId], [TitleEvenement], [PrincipalPhotoEvenement], [PlaceEvenement], [AdresseEvenement], [DateStart], [HourStart], [DateEnd], [HourEnd], [Text], [UserId], [Poublier]) VALUES (6, N'dernier test', N'http://localhost:28141/tinyfilemanager.net/resources/files/483212_366270143486563_1736725180_n.jpg', N'jojojo', N'123 jojo', CAST(0xEA380B00 AS Date), CAST(0x0700DC5527970000 AS Time), CAST(0xF3380B00 AS Date), CAST(0x0700FE56659F0000 AS Time), N'<p>ttttyrtry<img src="../tinyfilemanager.net/resources/files/922931_638836456130081_1030856133_n.jpg" alt="" /></p>', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 0)
INSERT [dbo].[Evenements] ([EventId], [TitleEvenement], [PrincipalPhotoEvenement], [PlaceEvenement], [AdresseEvenement], [DateStart], [HourStart], [DateEnd], [HourEnd], [Text], [UserId], [Poublier]) VALUES (7, N'La Fète des voisines', N'1488254_407332482731528_1997471036_n.jpg', N'test ev 01', N'123', CAST(0xEA380B00 AS Date), CAST(0x070010ACD1530000 AS Time), CAST(0xEC380B00 AS Date), CAST(0x0700B0BD58750000 AS Time), N'<p>t</p>', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
SET IDENTITY_INSERT [dbo].[Evenements] OFF
SET IDENTITY_INSERT [dbo].[Nouvelles] ON 

INSERT [dbo].[Nouvelles] ([NouvelleId], [NouvelleTitle], [NouvellePrincipalPhoto], [NouvelleText], [NouvelleDate], [UserId], [Publier]) VALUES (2, N'Lunes Otra Vez', NULL, N'<h1 style="text-align: center; color: #ff0000;"><span style="color: #000080;">Esta Semana el rojo es el color de moda</span></h1>
<p>&nbsp;</p>
<p><img src="../tinyfilemanager.net/resources/files/297258_10151556305136562_67690510_n.jpg" alt="" />estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto.</p>
<p>&nbsp;</p>
<p>estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto&nbsp;estoy probando poner texto.</p>
<p>&nbsp;</p>
<p>&nbsp;ya dice que sse puede</p>
<p>&nbsp;</p>', CAST(0xD3380B00 AS Date), N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 0)
INSERT [dbo].[Nouvelles] ([NouvelleId], [NouvelleTitle], [NouvellePrincipalPhoto], [NouvelleText], [NouvelleDate], [UserId], [Publier]) VALUES (6, N'super duper', N'http://localhost:28141/tinyfilemanager.net/resources/files/483212_366270143486563_1736725180_n.jpg', N'<p>hey como van</p>
<p>&nbsp;</p>
<h1 style="color: #ff0000;"><img src="../tinyfilemanager.net/resources/files/922931_638836456130081_1030856133_n.jpg" alt="" width="131" height="189" />ac eets jkkajkajskjaksa</h1>
<p>&nbsp;</p>
<p style="text-align: right;">fdfdfdfdfdfdfdfd</p>', CAST(0xD8380B00 AS Date), N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
INSERT [dbo].[Nouvelles] ([NouvelleId], [NouvelleTitle], [NouvellePrincipalPhoto], [NouvelleText], [NouvelleDate], [UserId], [Publier]) VALUES (7, N'Test nouvelles Fonctionalites', N'1509057_407332502731526_1822018121_n.jpg', N'<h1 style="color: #ff0000;">ya dice&nbsp;</h1>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>yo voy a caminar mucho</p>
<p>&nbsp;</p>
<p><img style="display: block; margin-left: auto; margin-right: auto;" src="../tinyfilemanager.net/resources/files/1488254_407332482731528_1997471036_n.jpg" alt="" width="481" height="359" /></p>
<p>&nbsp;</p>', CAST(0xE6380B00 AS Date), N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
INSERT [dbo].[Nouvelles] ([NouvelleId], [NouvelleTitle], [NouvellePrincipalPhoto], [NouvelleText], [NouvelleDate], [UserId], [Publier]) VALUES (8, N'test de ajax', NULL, N'<p>je adore &eacute;crit en fran&ccedil;ais!!!! est la lange du diable jejeje</p>', CAST(0xE6380B00 AS Date), N'79bf8b3b-298a-4dc5-984b-3269bde48bca', 1)
SET IDENTITY_INSERT [dbo].[Nouvelles] OFF
INSERT [dbo].[Page_Section] ([idpage], [idSection]) VALUES (1, 1)
INSERT [dbo].[Page_Section] ([idpage], [idSection]) VALUES (1, 2)
INSERT [dbo].[Page_Section] ([idpage], [idSection]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[Pages] ON 

INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (1, N'Accueil', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'1', N'1', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (2, N'Évenements', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'1', N'1', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (3, N'Groupe d''achats', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'1', N'1', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (4, N'Contactez-Nous', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'1', N'1', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (5, N'test01 public', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<p>enfants de contactes-nous</p>', N'test01', 0, 2, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (6, N'test 2 prive', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<p>sigue la prueba</p>', N'test2 prive', 0, 4, 0)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (7, N'À propos', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<h1 style="color: #ff0000;"><span style="color: #000080;"><strong>Mision</strong></span></h1>
<p><span style="color: #000000;"><strong>ttttttttttttttttttttttttttt</strong></span></p>
<p>&nbsp;</p>
<p><span style="color: #000000;"><strong>UUUUUUUUUUUUUUUUUUUUUUUUUUUU</strong></span></p>
<p>&nbsp;</p>
<p><span style="color: #000000;"><strong><img style="display: block; margin-left: auto; margin-right: auto;" src="../tinyfilemanager.net/resources/files/1393850815-md-119793_md_13562_samsung_galaxy_s5_handson1.png" alt="" width="158" height="211" /></strong></span></p>
<p>&nbsp;</p>
<h1 style="color: #ff0000;">la grande histoire</h1>', N'À propos de nous', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (10, N'test06', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<p>enfant</p>', N'test 06 enfant', 0, 7, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (11, N'test 07 prin', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<p>p</p>', N'test 07 principal', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (12, N'test 08 prin', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<p>p</p>', N'test 08', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (16, N'Script', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<div id="lunes">hola</div>
<p>&nbsp;</p>
<script>// <![CDATA[
$(function(){

   $("#lunes").click(function(){

       console.log("hola!!!");

      });

});
// ]]></script>', N'test de Scripting', 1, NULL, 1)
INSERT [dbo].[Pages] ([PageID], [MenuName], [UserId], [Text], [Title], [Principal], [SousMenu], [Poublier]) VALUES (17, N'Histoire', N'79bf8b3b-298a-4dc5-984b-3269bde48bca', N'<p>rgtrtr</p>', N'Notre Hiostoire Des Reves', 0, 7, 1)
SET IDENTITY_INSERT [dbo].[Pages] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [TVQ], [TPS], [Avaibled]) VALUES (1, N'patates', NULL, 0, 0, 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [TVQ], [TPS], [Avaibled]) VALUES (2, N'steak', NULL, 1, 1, 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [TVQ], [TPS], [Avaibled]) VALUES (4, N'tomates', NULL, 1, 1, 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [TVQ], [TPS], [Avaibled]) VALUES (5, N'poulet', NULL, 0, 0, 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [TVQ], [TPS], [Avaibled]) VALUES (6, N'bacon', NULL, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Section] ON 

INSERT [dbo].[Section] ([idSection], [Contenu], [Nom]) VALUES (1, N'<h1 style="color: #ff0000;">WOW!!!</h1>
<p>&nbsp;</p>
<p>test importante</p>
<p>&nbsp;</p>
<p>la unitilisation</p>
<p>&nbsp;</p>
<p><img class="img-responsive" src="../tinyfilemanager.net/resources/files/1509057_407332502731526_1822018121_n.jpg" alt="" width="394" height="294" /></p>', N'AccueilContenu')
INSERT [dbo].[Section] ([idSection], [Contenu], [Nom]) VALUES (2, N'<iframe src="//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Farriba.ec&amp;width&amp;height=427&amp;colorscheme=light&amp;show_faces=false&amp;header=true&amp;stream=true&amp;show_border=true&amp;appId=1419640888298583" scrolling="no" frameborder="0" style="border:none; overflow:hidden; height:427px;" allowTransparency="true"></iframe>', N'AccueilGauche')
INSERT [dbo].[Section] ([idSection], [Contenu], [Nom]) VALUES (3, NULL, N'AccueilDroite')
SET IDENTITY_INSERT [dbo].[Section] OFF
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [ContactName], [Adress], [E-Mail], [Phone], [Fax], [PostalCode], [Ville]) VALUES (1, N'test', N'test', N'123', N'res@yrt.com', N'4182536989', N'4182563987', N'd5d 5d5', N'test')
INSERT [dbo].[Suppliers] ([SupplierId], [SupplierName], [ContactName], [Adress], [E-Mail], [Phone], [Fax], [PostalCode], [Ville]) VALUES (2, N'fdgfd', N'gfhgfx', N'4565', N'gf@fdg', N'564654654654', N'763456', N'd4d4d4', N'ef')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
INSERT [dbo].[WeekProduct] ([WeekId], [ProductId], [SupplierId], [UnitPrice], [Quantity], [Format]) VALUES (1, 1, 1, 1.0000, 1, N'carton 20ml')
INSERT [dbo].[WeekProduct] ([WeekId], [ProductId], [SupplierId], [UnitPrice], [Quantity], [Format]) VALUES (1, 2, 1, 1.0000, 1, N'carton 20ml')
INSERT [dbo].[WeekProduct] ([WeekId], [ProductId], [SupplierId], [UnitPrice], [Quantity], [Format]) VALUES (1, 4, 1, 1.0000, 1, N'carton 20ml')
INSERT [dbo].[WeekProduct] ([WeekId], [ProductId], [SupplierId], [UnitPrice], [Quantity], [Format]) VALUES (1, 5, 1, 1.0000, 1, N'carton 20ml')
INSERT [dbo].[WeekProduct] ([WeekId], [ProductId], [SupplierId], [UnitPrice], [Quantity], [Format]) VALUES (1, 6, 1, 1.0000, 1, N'carton 20ml')
SET IDENTITY_INSERT [dbo].[Weeks] ON 

INSERT [dbo].[Weeks] ([WeekId], [Date_Debut], [Date_Fin], [Date_Recuperation]) VALUES (1, CAST(0xED380B00 AS Date), CAST(0xF8380B00 AS Date), CAST(0xFB380B00 AS Date))
INSERT [dbo].[Weeks] ([WeekId], [Date_Debut], [Date_Fin], [Date_Recuperation]) VALUES (2, CAST(0xF4380B00 AS Date), CAST(0xFD380B00 AS Date), CAST(0xFF380B00 AS Date))
SET IDENTITY_INSERT [dbo].[Weeks] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 26/08/2014 02:01:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 26/08/2014 02:01:04 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 26/08/2014 02:01:04 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 26/08/2014 02:01:04 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 26/08/2014 02:01:04 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 26/08/2014 02:01:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF_ConsultantBookings_Status]  DEFAULT ((0)) FOR [StatusENUM]
GO
ALTER TABLE [dbo].[AppointmentDiary]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentDiary_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AppointmentDiary] CHECK CONSTRAINT [FK_AppointmentDiary_AspNetUsers]
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
REFERENCES [dbo].[Nouvelles] ([NouvelleId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Blogs]
GO
ALTER TABLE [dbo].[Evenements]  WITH CHECK ADD  CONSTRAINT [FK_Evenements_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Evenements] CHECK CONSTRAINT [FK_Evenements_AspNetUsers]
GO
ALTER TABLE [dbo].[Nouvelles]  WITH CHECK ADD  CONSTRAINT [FK_Nouvelles_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Nouvelles] CHECK CONSTRAINT [FK_Nouvelles_AspNetUsers]
GO
ALTER TABLE [dbo].[NouvellesPicture]  WITH CHECK ADD  CONSTRAINT [FK_BlogPicture_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Nouvelles] ([NouvelleId])
GO
ALTER TABLE [dbo].[NouvellesPicture] CHECK CONSTRAINT [FK_BlogPicture_Blogs]
GO
ALTER TABLE [dbo].[NouvellesPicture]  WITH CHECK ADD  CONSTRAINT [FK_BlogPicture_Pictures] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Pictures] ([Pictures])
GO
ALTER TABLE [dbo].[NouvellesPicture] CHECK CONSTRAINT [FK_BlogPicture_Pictures]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Week] FOREIGN KEY([WeekId], [ProductId])
REFERENCES [dbo].[WeekProduct] ([WeekId], [ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Week]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Weeks] FOREIGN KEY([WeekId])
REFERENCES [dbo].[Weeks] ([WeekId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Weeks]
GO
ALTER TABLE [dbo].[Page_Section]  WITH CHECK ADD  CONSTRAINT [FK_Page_Section_Pages] FOREIGN KEY([idpage])
REFERENCES [dbo].[Pages] ([PageID])
GO
ALTER TABLE [dbo].[Page_Section] CHECK CONSTRAINT [FK_Page_Section_Pages]
GO
ALTER TABLE [dbo].[Page_Section]  WITH CHECK ADD  CONSTRAINT [FK_Page_Section_Section] FOREIGN KEY([idSection])
REFERENCES [dbo].[Section] ([idSection])
GO
ALTER TABLE [dbo].[Page_Section] CHECK CONSTRAINT [FK_Page_Section_Section]
GO
ALTER TABLE [dbo].[PagePicture]  WITH CHECK ADD  CONSTRAINT [FK_PagePicture_Pictures] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Pictures] ([Pictures])
GO
ALTER TABLE [dbo].[PagePicture] CHECK CONSTRAINT [FK_PagePicture_Pictures]
GO
ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Pages] CHECK CONSTRAINT [FK_Pages_AspNetUsers]
GO
ALTER TABLE [dbo].[WeekProduct]  WITH CHECK ADD  CONSTRAINT [FK_Week_Products1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[WeekProduct] CHECK CONSTRAINT [FK_Week_Products1]
GO
ALTER TABLE [dbo].[WeekProduct]  WITH CHECK ADD  CONSTRAINT [FK_Week_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[WeekProduct] CHECK CONSTRAINT [FK_Week_Suppliers]
GO
ALTER TABLE [dbo].[WeekProduct]  WITH CHECK ADD  CONSTRAINT [FK_WeekProduct_Weeks] FOREIGN KEY([WeekId])
REFERENCES [dbo].[Weeks] ([WeekId])
GO
ALTER TABLE [dbo].[WeekProduct] CHECK CONSTRAINT [FK_WeekProduct_Weeks]
GO
USE [master]
GO
ALTER DATABASE [ProyectLeMoulin] SET  READ_WRITE 
GO
