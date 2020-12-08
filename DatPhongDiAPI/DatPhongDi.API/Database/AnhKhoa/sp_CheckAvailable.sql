USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckAvailable]    Script Date: 12/8/2020 1:44:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HongSon
-- Create date: 11/30/2020
-- Description:	Check customer can book or not from typeofroom detail
-- =============================================

ALTER PROCEDURE [dbo].[sp_CheckAvailable]
	@AmountAdults int ,
	@AmountChild int ,
	@CheckIn Datetime ,
	@CheckOut Datetime 
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai, vui lòng thử lại sau!'
	IF(ISDATE(CONVERT(DATEtime,@Checkin)) = 1 AND ISDATE(CONVERT(DATEtime,@CheckOut)) = 1 AND DATEDIFF(day,CONVERT(DATEtime,@Checkin) ,CONVERT(DATEtime,@CheckOut) ) > 0 )
	BEGIN
		IF(@AmountAdults > 0)
		BEGIN 
		select * from (
			(SELECT t.*, r.Size, ROW_NUMBER() over(partition by t.Id ORDER BY i.ImageId) row_num, i.ImagePath from Room as r 
						INNER JOIN TypeOfRoom as t ON r.TypeOfRoomId = t.Id
						INNER JOIN [dbo].[Image] as i ON t.Id = i.[TypeOfRoomId] 
		WHERE ((@AmountAdults <= t.AmountAdults and (@AmountAdults + @AmountChild) <= (t.AmountAdults + t.AmountChild))) and r.Id not in (
													 SELECT [RoomId]
													 FROM [dbo].[Booking] b
													  INNER JOIN [dbo].[Room] r ON b.[RoomId] = r.Id
													 WHERE 
													 ((b.[CheckIn] <= @CheckIn AND b.[CheckOut] > @CheckIn) or
													 (b.[CheckIn] < @CheckOut AND b.[CheckOut] >= @CheckOut) or 
													 (@CheckIn <= b.[CheckIn] AND @CheckOut > b.[CheckIn]))
													 ))) as s where s.row_num = 1
													 
			SET @Message = N'Tìm kiếm thành công'
		END
		ELSE
		BEGIN
			SET @Message = N'Số lượng người lớn không hợp lệ'
		END
	END
	ELSE
	BEGIN
		SET @Message = N'Ngày check in phải nhỏ hơn ngày check out'
	END
	select @Message as [Message]
END

													 