USE [DatPhongDiDb]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 11/23/2020 11:41:57 PM ******/
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
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (1, 1, N'TypeOfRoom', 1, N'Đang Hoạt Động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (2, 1, N'TypeOfRoom', 2, N'Không Hoạt Động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (3, 2, N'Room', 1, N'Phòng trống', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (4, 2, N'Room', 2, N'Đã được thuê', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (5, 2, N'Room', 3, N'Không hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (6, 3, N'Booking', 1, N'Chưa xử lý', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (7, 3, N'Booking', 2, N'đã xác nhận', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (8, 3, N'Booking', 3, N'Đả nhận phòng', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (9, 4, N'Service', 1, N'Đang hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (10, 4, N'Service', 2, N'Không hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (11, 3, N'Booking', 4, N'Đả hủy', 0)
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
