USE [DatPhongDiDb]
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (9, 101, 1, 7, NULL, NULL, N'Có ban công', 28)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (10, 102, 1, 7, NULL, NULL, N'Có ban công', 28)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (11, 103, 1, 7, NULL, NULL, N'Không ban công', 28)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (12, 201, 1, 9, NULL, NULL, N'Có ban công', 35)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (13, 202, 1, 9, NULL, NULL, N'Có ban công', 35)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (14, 203, 1, 7, NULL, NULL, N'Có ban công', 28)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (15, 204, 1, 7, NULL, NULL, N'Có ban công', 28)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (16, 104, 1, 9, NULL, NULL, N'Có ban công', 35)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (17, 105, 1, 9, NULL, NULL, N'Có ban công', 35)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (18, 205, 1, 9, NULL, NULL, N'Có ban công', 35)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (19, 301, 1, 10, NULL, NULL, N'Có ban công', 50)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (20, 401, 1, 10, NULL, NULL, N'Có ban công', 50)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (21, 501, 1, 10, NULL, NULL, N'Có ban công', 50)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (22, 302, 1, 11, NULL, NULL, N'Có ban công', 45)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (23, 402, 1, 11, NULL, NULL, N'Có ban công', 45)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (24, 502, 1, 11, NULL, NULL, N'Có ban công', 45)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (25, 303, 1, 13, NULL, NULL, N'Có ban công', 30)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (26, 403, 1, 13, NULL, NULL, N'Có ban công', 30)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (27, 503, 1, 13, NULL, NULL, N'Có ban công', 30)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (28, 404, 1, 13, NULL, NULL, N'Không ban công', 30)
INSERT [dbo].[Room] ([Id], [Name], [Status], [TypeOfRoomId], [CreateDate], [ModifiedDate], [Description], [Size]) VALUES (29, 504, 1, 13, NULL, NULL, N'Có ban công', 30)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (19, N'Wifi Free', 1, N'wifi.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (20, N'Smart Tivi', 1, N'tivi.jpn')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (21, N'King Bed', 1, N'bed.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (22, N'Bồn Tắm', 1, N'bontam.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (23, N'Két sắt', 1, N'ketsat.jpn')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (24, N'Máy sấy tóc', 1, N'maysaytoc.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (25, N'Minibar', 1, N'minibar.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (26, N'Tủ', 1, N'tu.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (27, N'Trà & Cà phê', 1, N'coffee.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (28, N'Vòi hoa sen', 1, N'voihoasen.jpn')
INSERT [dbo].[Service] ([Id], [Name], [Status], [Icon]) VALUES (29, N'Nước suối', 1, N'nuocsuoi.jpn')
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (1, 1, N'TypeOfRoom', 1, N'Đang Hoạt Động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (2, 1, N'TypeOfRoom', 2, N'Không Hoạt Động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (3, 2, N'Room', 1, N'Phòng trống', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (4, 2, N'Room', 2, N'Đã được thuê', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (5, 2, N'Room', 3, N'Không hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (7, 3, N'Booking', 1, N'Đã xác nhận', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (8, 3, N'Booking', 2, N'Đã nhận phòng', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (9, 4, N'Service', 1, N'Đang hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (10, 4, N'Service', 2, N'Không hoạt động', 0)
INSERT [dbo].[Status] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (11, 3, N'Booking', 3, N'Đã hủy', 0)
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfRoom] ON 

INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status], [AmountAdults], [AmountChild], [PricePerNight]) VALUES (7, N'Phòng Đơn', 1, 2, 1, 850000)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status], [AmountAdults], [AmountChild], [PricePerNight]) VALUES (9, N'Phòng Đôi', 1, 4, 1, 1200000)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status], [AmountAdults], [AmountChild], [PricePerNight]) VALUES (10, N'Phòng Gia Đình', 1, 5, 2, 2000000)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status], [AmountAdults], [AmountChild], [PricePerNight]) VALUES (11, N'Phòng Vip', 1, 4, 2, 2800000)
INSERT [dbo].[TypeOfRoom] ([Id], [Name], [Status], [AmountAdults], [AmountChild], [PricePerNight]) VALUES (13, N'Phòng Couple', 1, 2, 0, 1500000)
SET IDENTITY_INSERT [dbo].[TypeOfRoom] OFF
GO
