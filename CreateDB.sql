USE [master]
GO
/****** Object:  Database [Zuyd_Natuurbrand_Dectectie]    Script Date: 4/8/2020 3:09:06 PM ******/
CREATE DATABASE [Zuyd_Natuurbrand_Dectectie]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Zuyd_Natuurbrand_Dectectie', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Zuyd_Natuurbrand_Dectectie.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Zuyd_Natuurbrand_Dectectie_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Zuyd_Natuurbrand_Dectectie_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Zuyd_Natuurbrand_Dectectie].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET ARITHABORT OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET RECOVERY FULL 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET  MULTI_USER 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Zuyd_Natuurbrand_Dectectie', N'ON'
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET QUERY_STORE = OFF
GO
USE [Zuyd_Natuurbrand_Dectectie]
GO
/****** Object:  Table [dbo].[koppelmeldingTbl]    Script Date: 4/8/2020 3:09:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[koppelmeldingTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nodeId] [int] NOT NULL,
	[meldingId] [int] NOT NULL,
 CONSTRAINT [PK_koppelmeldingTbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[meldingenTbl]    Script Date: 4/8/2020 3:09:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meldingenTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[datum] [date] NOT NULL,
	[tijd] [time](7) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[beschrijving] [varchar](255) NOT NULL,
 CONSTRAINT [PK_meldingenTbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[metingTbl]    Script Date: 4/8/2020 3:09:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[metingTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nodeId] [int] NOT NULL,
	[datum] [date] NOT NULL,
	[tijd] [time](7) NOT NULL,
	[luchtVochtigheidSensor] [int] NOT NULL,
	[grondSensor] [int] NOT NULL,
	[diepGrondSensor] [int] NOT NULL,
	[temperatuurSensor] [int] NOT NULL,
 CONSTRAINT [PK_metingTbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nodeTbl]    Script Date: 4/8/2020 3:09:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nodeTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[locatie] [varchar](50) NOT NULL,
	[natuurgebied] [varchar](50) NOT NULL,
	[actief] [bit] NOT NULL,
	[batterijVervangen] [date] NOT NULL,
 CONSTRAINT [PK_nodeTbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[koppelmeldingTbl] ON 

INSERT [dbo].[koppelmeldingTbl] ([id], [nodeId], [meldingId]) VALUES (1, 1, 1)
INSERT [dbo].[koppelmeldingTbl] ([id], [nodeId], [meldingId]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[koppelmeldingTbl] OFF
SET IDENTITY_INSERT [dbo].[meldingenTbl] ON 

INSERT [dbo].[meldingenTbl] ([id], [datum], [tijd], [type], [beschrijving]) VALUES (1, CAST(N'2020-04-05' AS Date), CAST(N'14:40:00' AS Time), N'Brandgevaar', N'Mogelijk brandgevaar in dit gebied')
INSERT [dbo].[meldingenTbl] ([id], [datum], [tijd], [type], [beschrijving]) VALUES (2, CAST(N'2020-04-08' AS Date), CAST(N'16:30:00' AS Time), N'Droge grond', N'Mogelijk te droge grond')
SET IDENTITY_INSERT [dbo].[meldingenTbl] OFF
SET IDENTITY_INSERT [dbo].[metingTbl] ON 

INSERT [dbo].[metingTbl] ([id], [nodeId], [datum], [tijd], [luchtVochtigheidSensor], [grondSensor], [diepGrondSensor], [temperatuurSensor]) VALUES (1, 1, CAST(N'2020-04-08' AS Date), CAST(N'14:25:23' AS Time), 60, 560, 520, 23)
INSERT [dbo].[metingTbl] ([id], [nodeId], [datum], [tijd], [luchtVochtigheidSensor], [grondSensor], [diepGrondSensor], [temperatuurSensor]) VALUES (4, 1, CAST(N'2020-04-08' AS Date), CAST(N'15:25:20' AS Time), 50, 540, 500, 21)
INSERT [dbo].[metingTbl] ([id], [nodeId], [datum], [tijd], [luchtVochtigheidSensor], [grondSensor], [diepGrondSensor], [temperatuurSensor]) VALUES (5, 2, CAST(N'2020-04-05' AS Date), CAST(N'16:30:10' AS Time), 40, 420, 370, 24)
INSERT [dbo].[metingTbl] ([id], [nodeId], [datum], [tijd], [luchtVochtigheidSensor], [grondSensor], [diepGrondSensor], [temperatuurSensor]) VALUES (6, 2, CAST(N'2020-04-05' AS Date), CAST(N'17:30:10' AS Time), 70, 780, 740, 22)
SET IDENTITY_INSERT [dbo].[metingTbl] OFF
SET IDENTITY_INSERT [dbo].[nodeTbl] ON 

INSERT [dbo].[nodeTbl] ([id], [locatie], [natuurgebied], [actief], [batterijVervangen]) VALUES (1, N'Heerlen', N'Heiden', 1, CAST(N'2020-04-08' AS Date))
INSERT [dbo].[nodeTbl] ([id], [locatie], [natuurgebied], [actief], [batterijVervangen]) VALUES (2, N'Kerkrade', N'Berenbos', 1, CAST(N'2020-04-05' AS Date))
INSERT [dbo].[nodeTbl] ([id], [locatie], [natuurgebied], [actief], [batterijVervangen]) VALUES (3, N'Maastricht', N'Bos', 0, CAST(N'2020-04-12' AS Date))
SET IDENTITY_INSERT [dbo].[nodeTbl] OFF
ALTER TABLE [dbo].[koppelmeldingTbl]  WITH CHECK ADD  CONSTRAINT [FK_koppel_node] FOREIGN KEY([nodeId])
REFERENCES [dbo].[nodeTbl] ([id])
GO
ALTER TABLE [dbo].[koppelmeldingTbl] CHECK CONSTRAINT [FK_koppel_node]
GO
ALTER TABLE [dbo].[koppelmeldingTbl]  WITH CHECK ADD  CONSTRAINT [FK_koppelmeldingTbl_meldintTbl] FOREIGN KEY([meldingId])
REFERENCES [dbo].[meldingenTbl] ([id])
GO
ALTER TABLE [dbo].[koppelmeldingTbl] CHECK CONSTRAINT [FK_koppelmeldingTbl_meldintTbl]
GO
ALTER TABLE [dbo].[metingTbl]  WITH CHECK ADD  CONSTRAINT [FK_metingTbl_noteTbl] FOREIGN KEY([nodeId])
REFERENCES [dbo].[nodeTbl] ([id])
GO
ALTER TABLE [dbo].[metingTbl] CHECK CONSTRAINT [FK_metingTbl_noteTbl]
GO
USE [master]
GO
ALTER DATABASE [Zuyd_Natuurbrand_Dectectie] SET  READ_WRITE 
GO
