USE [master]
GO
/****** Object:  Database [UniversityManageWebAppDB]    Script Date: 10/25/2017 8:03:13 AM ******/
CREATE DATABASE [UniversityManageWebAppDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManageWebAppDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManageWebAppDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManageWebAppDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManageWebAppDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManageWebAppDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManageWebAppDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManageWebAppDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManageWebAppDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManageWebAppDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManageWebAppDB]
GO
/****** Object:  Table [dbo].[AllocateClassRooms]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DaysId] [int] NULL,
	[StartId] [int] NULL,
	[EndId] [int] NULL,
	[Allocate] [int] NULL,
 CONSTRAINT [PK_AllocateClassRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [float] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Semester] [int] NOT NULL,
	[AssignTo] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Days]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Days](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DesignationTeacher]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DesignationTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DesignationTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EndTime]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EndTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EndTime] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EndTime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrolledCourse]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrolledCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegistrationId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Result] [int] NULL,
 CONSTRAINT [PK_EnrolledCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grades]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveTeacher]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Credit] [float] NOT NULL,
	[RemainingCredit] [float] NOT NULL,
 CONSTRAINT [PK_SaveTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StartTime]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StartTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StartTime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentRegistration]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[VW_CourseStatistics]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_CourseStatistics] as SELECT c.*, s.Name SemesterName, st.Name TeacherName
FROM [UniversityManageWebAppDB].[dbo].[Course] c
INNER JOIN [UniversityManageWebAppDB].[dbo].[Semester] s
    on c.Semester = s.Id
Left JOIN [UniversityManageWebAppDB].[dbo].[SaveTeacher] st
    on c.AssignTo = st.Id
GO
/****** Object:  View [dbo].[VW_StudentResult]    Script Date: 10/25/2017 8:03:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VW_StudentResult] as SELECT ec.*, c.Code, c.Name CourseName, g.Name GradeName 
FROM [UniversityManageWebAppDB].[dbo].[EnrolledCourse] ec
left JOIN [UniversityManageWebAppDB].[dbo].[Course] c
    on ec.CourseId = c.Id
Left JOIN [UniversityManageWebAppDB].[dbo].[Grades] g
    on ec.Result = g.Id
GO
SET IDENTITY_INSERT [dbo].[AllocateClassRooms] ON 

INSERT [dbo].[AllocateClassRooms] ([Id], [DepartmentId], [CourseId], [RoomId], [DaysId], [StartId], [EndId], [Allocate]) VALUES (15, 12, 7, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[AllocateClassRooms] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [Semester], [AssignTo]) VALUES (7, N'CSE-134', N'Data Structure', 3, N'Major', 12, 3, 13)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [Semester], [AssignTo]) VALUES (8, N'EEE-111', N'Circuit Fundamental', 3, N'Major', 13, 2, 14)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [Semester], [AssignTo]) VALUES (9, N'SWE-123', N'Software Engineering', 3, N'Major', 14, 5, 15)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Days] ON 

INSERT [dbo].[Days] ([Id], [Name]) VALUES (1, N'Saturday')
INSERT [dbo].[Days] ([Id], [Name]) VALUES (2, N'Sunday')
INSERT [dbo].[Days] ([Id], [Name]) VALUES (3, N'Monday')
INSERT [dbo].[Days] ([Id], [Name]) VALUES (4, N'Tuesday')
INSERT [dbo].[Days] ([Id], [Name]) VALUES (5, N'Wednesday')
INSERT [dbo].[Days] ([Id], [Name]) VALUES (6, N'Thursday')
INSERT [dbo].[Days] ([Id], [Name]) VALUES (7, N'Friday')
SET IDENTITY_INSERT [dbo].[Days] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (12, N'CSE', N'Computer Science and Engineering')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (13, N'EEE', N'Electrical and Electronics Engineering')
INSERT [dbo].[Departments] ([Id], [Code], [Name]) VALUES (14, N'SWE', N'Software Engineering')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[DesignationTeacher] ON 

INSERT [dbo].[DesignationTeacher] ([Id], [Name]) VALUES (1, N'Professor')
INSERT [dbo].[DesignationTeacher] ([Id], [Name]) VALUES (2, N'Associate Professor')
INSERT [dbo].[DesignationTeacher] ([Id], [Name]) VALUES (3, N'Assistant Professor')
INSERT [dbo].[DesignationTeacher] ([Id], [Name]) VALUES (4, N'Senior Lecturer')
INSERT [dbo].[DesignationTeacher] ([Id], [Name]) VALUES (5, N'Lecturer')
SET IDENTITY_INSERT [dbo].[DesignationTeacher] OFF
SET IDENTITY_INSERT [dbo].[EndTime] ON 

INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (1, N'10 : 00 AM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (2, N'11 : 30 AM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (3, N'01 : 00 PM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (4, N'02 : 30 PM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (5, N'04 : 00 PM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (6, N'05 : 30 PM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (7, N'07 : 30 PM')
INSERT [dbo].[EndTime] ([Id], [EndTime]) VALUES (8, N'09 : 00 PM')
SET IDENTITY_INSERT [dbo].[EndTime] OFF
SET IDENTITY_INSERT [dbo].[EnrolledCourse] ON 

INSERT [dbo].[EnrolledCourse] ([Id], [StudentRegistrationId], [CourseId], [Date], [Result]) VALUES (12, 11, 7, CAST(0x723D0B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[EnrolledCourse] OFF
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([Id], [Name]) VALUES (1, N'A+')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (2, N'A')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (3, N'A-')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (4, N'B+')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (5, N'B')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (6, N'B-')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (7, N'C+')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (8, N'C')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (9, N'C-')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (10, N'D+')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (11, N'D')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (12, N'D-')
INSERT [dbo].[Grades] ([Id], [Name]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grades] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (1, N'101')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (2, N'102')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (3, N'103')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (4, N'201')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (5, N'202')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (6, N'203')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (7, N'301')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (8, N'302')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (9, N'303')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (10, N'401')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (11, N'402')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (12, N'403')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[SaveTeacher] ON 

INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [Credit], [RemainingCredit]) VALUES (13, N'MD Fuad Ragib', N'Dhaka', N'ragibfuad@gmail.com', N'01767556702', 1, 12, 12, 9)
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [Credit], [RemainingCredit]) VALUES (14, N'alamin', N'Dhaka', N'alamin@gmail.com', N'01767556702', 4, 13, 9, 6)
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [Credit], [RemainingCredit]) VALUES (15, N'Roman', N'Dhaka', N'roman@gmail.com', N'01767556702', 3, 14, 6, 3)
SET IDENTITY_INSERT [dbo].[SaveTeacher] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [Name]) VALUES (1, N'1st Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (2, N'2nd Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (3, N'3rd Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (4, N'4th Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (5, N'5th Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (6, N'6th Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (7, N'7th Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (8, N'8th Semester')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[StartTime] ON 

INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (1, N'08 : 30 AM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (2, N'10 : 00 AM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (3, N'11 : 30 AM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (4, N'01 : 00 PM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (5, N'02 : 30 PM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (6, N'04 : 00 PM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (7, N'06 : 00 PM')
INSERT [dbo].[StartTime] ([Id], [StartTime]) VALUES (8, N'07 : 30 PM')
SET IDENTITY_INSERT [dbo].[StartTime] OFF
SET IDENTITY_INSERT [dbo].[StudentRegistration] ON 

INSERT [dbo].[StudentRegistration] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegNo]) VALUES (11, N'MD Fuad Ragib', N'ragibfuad@gmail.com', N'01767556702', CAST(0x723D0B00 AS Date), N'56,West Razabazar
Dhanmondi,Dhaka', 12, N'CSE-2017-001')
SET IDENTITY_INSERT [dbo].[StudentRegistration] OFF
ALTER TABLE [dbo].[AllocateClassRooms] ADD  CONSTRAINT [DF_AllocateClassRooms_Allocate]  DEFAULT ((1)) FOR [Allocate]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_AssignTo]  DEFAULT ((0)) FOR [AssignTo]
GO
ALTER TABLE [dbo].[EnrolledCourse] ADD  CONSTRAINT [DF_EnrolledCourse_Result]  DEFAULT ((0)) FOR [Result]
GO
USE [master]
GO
ALTER DATABASE [UniversityManageWebAppDB] SET  READ_WRITE 
GO
