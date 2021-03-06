USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_IsBooking]    Script Date: 11/30/2020 6:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HongSon
-- Create date: 11/30/2020
-- Description:	Check customer can book or not from typeofroom detail
-- =============================================
ALTER PROCEDURE [dbo].[sp_IsBooking]
	-- Add the parameters for the stored procedure here
	@TypeOfRoomId int, 
	@AmountNight int,
	@AmountRoom int,
	@CheckIn Datetime,
	@CheckOut Datetime
AS
BEGIN

	DECLARE @Message NVARCHAR(100) = N'Có gì đó sai, vui lòng thử lại sau!'

	IF(@AmountRoom > (SELECT COUNT(*) from [dbo].[Room] where [dbo].[Room].[TypeOfRoomId] = @TypeOfRoomId))
		begin
			set @Message=N'Không đủ phòng trống cho ' + CAST(@AmountNight AS VARCHAR(16)) + N' phòng'
		end
	ELSE
		begin
			IF(@AmountRoom <= (SELECT COUNT(*) 
							  from [dbo].[Room] r 
							  INNER JOIN [dbo].[TypeOfRoom] t ON r.[TypeOfRoomId] = t.Id
							  WHERE t.Id=@TypeOfRoomId and r.Id not in (
												 SELECT [RoomId]
												 FROM [dbo].[Booking] b
												  INNER JOIN [dbo].[Room] ro ON b.[RoomId] = ro.Id
												 WHERE 
												 (b.[CheckIn] <= @CheckIn AND b.[CheckOut] >= @CheckIn) or
											     (b.[CheckIn] < @CheckOut AND b.[CheckOut] >= @CheckOut) or 
												 (@CheckIn <= b.[CheckIn] AND @CheckOut >= b.[CheckIn])
												 )))
				begin
					set @Message=N'Có thể đặt phòng '
				end
			ELSE
				begin
					set @Message=N'phòng trống không đủ '
				end
		end
	select @Message as [Message]
END



