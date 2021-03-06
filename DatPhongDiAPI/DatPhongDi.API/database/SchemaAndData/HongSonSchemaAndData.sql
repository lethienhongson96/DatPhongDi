USE [DatPhongDiDb]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 11/20/2020 10:18:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AmountNight] [int] NOT NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NOT NULL,
	[CreateDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [nchar](10) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/20/2020 10:18:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[PhoneNum] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Passport] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 11/20/2020 10:18:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PricePerNight] [int] NOT NULL,
	[AmountAdult] [int] NOT NULL,
	[AmountChild] [int] NULL,
	[Status] [int] NOT NULL,
	[TypeOfRoomId] [int] NOT NULL,
	[CreateDate] [date] NOT NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 11/20/2020 10:18:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](150) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 11/20/2020 10:18:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfRoom]    Script Date: 11/20/2020 10:18:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_TypeOfRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [RoomId], [CustomerId], [AmountNight], [CheckIn], [CheckOut], [CreateDate], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, 1, 2, 3, CAST(N'2008-11-11T13:23:44.000' AS DateTime), CAST(N'2008-11-11T13:23:44.000' AS DateTime), CAST(N'2020-11-17' AS Date), CAST(N'2020-11-17' AS Date), NULL, 2)
INSERT [dbo].[Booking] ([Id], [RoomId], [CustomerId], [AmountNight], [CheckIn], [CheckOut], [CreateDate], [ModifiedDate], [ModifiedBy], [Status]) VALUES (2, 1, 2, 3, CAST(N'2020-11-17T17:13:45.313' AS DateTime), CAST(N'2020-11-17T17:13:45.313' AS DateTime), CAST(N'2020-11-18' AS Date), NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [Name], [PricePerNight], [AmountAdult], [AmountChild], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate]) VALUES (1, N'hello11111', 100000, 1, 1, 1, 1, CAST(N'2020-11-17' AS Date), CAST(N'2020-11-17' AS Date))
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (1, 1, N'TypeOfRoom', 1, N'Đang Hoạt Động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (2, 1, N'TypeOfRoom', 2, N'Không Hoạt Động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (3, 2, N'Room', 1, N'Phòng trống', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (4, 2, N'Room', 2, N'Đã được thuê', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (5, 2, N'Room', 3, N'Không hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (6, 3, N'Booking', 1, N'Đang chờ', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (7, 3, N'Booking', 2, N'Đã hoàn thành', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (8, 3, N'Booking', 3, N'Đã hủy', 0)
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfRoom] ON 

INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status]) VALUES (1, N'Phòng Ðôi', 1)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status]) VALUES (3, N'56565656', 2)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status]) VALUES (7, N'tryedit', 1)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status]) VALUES (8, N'phòng gia dình', 1)
SET IDENTITY_INSERT [dbo].[TypeOfRoom] OFF
GO
