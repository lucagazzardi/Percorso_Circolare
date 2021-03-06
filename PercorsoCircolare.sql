USE [master]
GO
/****** Object:  Database [PercorsoCircolare]    Script Date: 05/01/2019 11:59:35 ******/
CREATE DATABASE [PercorsoCircolare]
 CONTAINMENT = NONE
GO
ALTER DATABASE [PercorsoCircolare] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PercorsoCircolare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PercorsoCircolare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET ARITHABORT OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PercorsoCircolare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PercorsoCircolare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PercorsoCircolare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PercorsoCircolare] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PercorsoCircolare] SET  MULTI_USER 
GO
ALTER DATABASE [PercorsoCircolare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PercorsoCircolare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PercorsoCircolare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PercorsoCircolare] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PercorsoCircolare] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PercorsoCircolare] SET QUERY_STORE = OFF
GO
USE [PercorsoCircolare]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PercorsoCircolare]
GO
/****** Object:  Table [dbo].[Classroom]    Script Date: 05/01/2019 11:59:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 05/01/2019 11:59:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[Year] [int] NULL,
	[BeginDate] [date] NULL,
	[EndDate] [date] NULL,
	[ResourceId] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 05/01/2019 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LectureDate] [date] NULL,
	[TeacherResourceId] [int] NOT NULL,
	[BackupResourceId] [int] NOT NULL,
	[ClassroomId] [int] NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 05/01/2019 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[CourseId] [int] NOT NULL,
	[Credits] [int] NOT NULL,
	[LessonsNumber] [smallint] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 05/01/2019 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[Id] [int] NOT NULL,
	[Username] [varchar](8) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceStatus]    Script Date: 05/01/2019 11:59:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceStatus](
	[Id] [int] NOT NULL,
	[EnumKey] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_ResourceStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Classroom] ON 

INSERT [dbo].[Classroom] ([Id], [Name]) VALUES (1, N'Polifunzionale')
INSERT [dbo].[Classroom] ([Id], [Name]) VALUES (2, N'R101')
INSERT [dbo].[Classroom] ([Id], [Name]) VALUES (3, N'R102')
INSERT [dbo].[Classroom] ([Id], [Name]) VALUES (4, N'Campus piano terra')
INSERT [dbo].[Classroom] ([Id], [Name]) VALUES (5, N'Campus primo piano')
SET IDENTITY_INSERT [dbo].[Classroom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Description], [Year], [BeginDate], [EndDate], [ResourceId]) VALUES (1, N'Percorso sviluppo', 2019, CAST(N'2019-01-01' AS Date), CAST(N'2019-01-20' AS Date), 2)
INSERT [dbo].[Course] ([Id], [Description], [Year], [BeginDate], [EndDate], [ResourceId]) VALUES (2, N'Percorso sviluppo avanzato', 2019, CAST(N'2019-01-21' AS Date), CAST(N'2019-02-15' AS Date), 1)
INSERT [dbo].[Course] ([Id], [Description], [Year], [BeginDate], [EndDate], [ResourceId]) VALUES (3, N'Percorso SQL avanzato', 2019, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-21' AS Date), 1)
INSERT [dbo].[Course] ([Id], [Description], [Year], [BeginDate], [EndDate], [ResourceId]) VALUES (4, N'Percorso circolare', 2019, CAST(N'2019-01-09' AS Date), CAST(N'2019-09-30' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (1, N'Prima lezione .NET', 1, 1, CAST(N'2019-01-01' AS Date), 1, 2, 2)
INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (2, N'Prima lezione sviluppo web', 2, 1, CAST(N'2019-01-20' AS Date), 1, 2, 2)
INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (3, N'Prima lezione .NET avanzato', 3, 2, CAST(N'2019-01-21' AS Date), 2, 1, 1)
INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (4, N'Prima lezione Angular', 4, 2, CAST(N'2019-02-15' AS Date), 2, 1, 1)
INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (5, N'Prima lezione SQL', 5, 3, CAST(N'2019-03-07' AS Date), 3, 6, 1)
INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (6, N'C# e .NET', 6, 4, CAST(N'2019-01-09' AS Date), 2, 3, 1)
INSERT [dbo].[Lesson] ([Id], [Description], [ModuleId], [CourseId], [LectureDate], [TeacherResourceId], [BackupResourceId], [ClassroomId]) VALUES (7, N'Classi astratte', 6, 4, CAST(N'2019-01-12' AS Date), 6, 8, 2)
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[Module] ON 

INSERT [dbo].[Module] ([Id], [Name], [Description], [CourseId], [Credits], [LessonsNumber]) VALUES (1, N'.NET', N'Sviluppo in ambito .NET', 1, 10, 1)
INSERT [dbo].[Module] ([Id], [Name], [Description], [CourseId], [Credits], [LessonsNumber]) VALUES (2, N'Sviluppo web', N'Sviluppo di applicazioni web', 1, 10, 1)
INSERT [dbo].[Module] ([Id], [Name], [Description], [CourseId], [Credits], [LessonsNumber]) VALUES (3, N'.NET avanzato', N'Sviluppo in ambito .NET avanzato', 2, 10, 1)
INSERT [dbo].[Module] ([Id], [Name], [Description], [CourseId], [Credits], [LessonsNumber]) VALUES (4, N'Angular', N'Sviluppo web con Angular', 2, 10, 1)
INSERT [dbo].[Module] ([Id], [Name], [Description], [CourseId], [Credits], [LessonsNumber]) VALUES (5, N'Operazioni CRUD', N'Panoramica delle operazioni CRUD', 3, 10, 1)
INSERT [dbo].[Module] ([Id], [Name], [Description], [CourseId], [Credits], [LessonsNumber]) VALUES (6, N'Sviluppo in ambito .NET', N'Panoramica su .NET e programmazione', 4, 30, 3)
SET IDENTITY_INSERT [dbo].[Module] OFF
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (1, N'gazzalu1', N'Luca', N'Gazzardi', 2)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (2, N'zaccalu1', N'Luca', N'Zaccaro', 1)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (3, N'macrial1', N'Alessandro', N'Macrì', 1)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (4, N'zaffast1', N'Stefano', N'Zaffaroni', 1)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (5, N'acchima1', N'Marco', N'Acchini', 1)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (6, N'sirondo1', N'Domenico', N'Sironi', 1)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (7, N'millema1', N'Marco', N'Millefanti', 1)
INSERT [dbo].[Resource] ([Id], [Username], [FirstName], [LastName], [StatusId]) VALUES (8, N'fantigi1', N'Giovanni', N'Fantini', 1)
INSERT [dbo].[ResourceStatus] ([Id], [EnumKey], [Description]) VALUES (1, N'Available', N'Disponibile')
INSERT [dbo].[ResourceStatus] ([Id], [EnumKey], [Description]) VALUES (2, N'NotAvailable', N'Non disponibile')
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_CourseResource] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[Resource] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_CourseResource]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonBackupTeacher] FOREIGN KEY([BackupResourceId])
REFERENCES [dbo].[Resource] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_LessonBackupTeacher]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonClassroomId] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classroom] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_LessonClassroomId]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonCourse] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_LessonCourse]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonModule] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_LessonModule]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_LessonTeacherResource] FOREIGN KEY([TeacherResourceId])
REFERENCES [dbo].[Resource] ([Id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_LessonTeacherResource]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_ModuleCourse] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_ModuleCourse]
GO
ALTER TABLE [dbo].[Resource]  WITH CHECK ADD  CONSTRAINT [FK_ResourceStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ResourceStatus] ([Id])
GO
ALTER TABLE [dbo].[Resource] CHECK CONSTRAINT [FK_ResourceStatus]
GO
USE [master]
GO
ALTER DATABASE [PercorsoCircolare] SET  READ_WRITE 
GO
