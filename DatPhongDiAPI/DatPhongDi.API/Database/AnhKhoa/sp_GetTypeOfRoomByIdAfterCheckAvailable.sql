USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeOfRoomByIdAfterCheckAvailable]    Script Date: 12/9/2020 6:20:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HongSon
-- Create date: 11/30/2020
-- Description:	Check customer can book or not from typeofroom detail
-- =============================================

ALTER PROCEDURE [dbo].[sp_GetTypeOfRoomByIdAfterCheckAvailable]
	@Id int,
	@CheckIn Datetime,
	@CheckOut Datetime 
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai, vui lòng thử lại sau!'
		select t.*,COUNT(*) as 'AmountAvailableRoom',r.Size from Room as r
								inner join TypeOfRoom as t on r.TypeOfRoomId = t.Id
								WHERE @Id = t.Id and r.Id not in (
													 SELECT [RoomId]
													 FROM [dbo].[Booking] b
													  INNER JOIN [dbo].[Room] r ON b.[RoomId] = r.Id
													 WHERE 
													 ((b.[CheckIn] <= @CheckIn AND b.[CheckOut] > @CheckIn) or
													 (b.[CheckIn] < @CheckOut AND b.[CheckOut] >= @CheckOut) or 
													 (@CheckIn <= b.[CheckIn] AND @CheckOut > b.[CheckIn]))
													 ) group by t.Id, t.[Name],t.PricePerNight, t.[Status],t.AmountAdults, t.AmountChild, r.Size							 
			SET @Message = N'Tìm kiếm thành công'
	select @Message as [Message]
END

													 