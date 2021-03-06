USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveBookingDetail]    Script Date: 1/3/2021 5:55:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HongSon
-- Create date: 1/3/2021
-- Description:	Create or update bookingdetail
-- =============================================
ALTER PROCEDURE [dbo].[sp_SaveBookingDetail] 
	-- Add the parameters for the stored procedure here
	@Id int
	,@BookingId int
	,@RoomId int
	,@Price money
AS
BEGIN
	
	DECLARE @Message NVARCHAR(100) = N'Đã xảy ra lỗi, vui lòng thử lại sau!'
	BEGIN TRY
		IF(ISNULL(@Id,0) = 0)
		BEGIN
			INSERT INTO [dbo].[BookingDetail]
					   ([BookingId]
					   ,[RoomId]
					   ,[Price])
				 VALUES
					   (@BookingId
					   ,@RoomId
					   ,@Price)

			SET @Message = N'Booking Detail đã được tạo thành công'
			SET @Id = SCOPE_IDENTITY()
		END

		ELSE -- update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[BookingDetail] WHERE @Id = Id))
			BEGIN
				SET @Message = N'Không tìm thấy Booking Detail này'
			END

			ELSE
			BEGIN
				
				UPDATE [dbo].[BookingDetail]
				   SET [BookingId] = @BookingId
					  ,[RoomId] = @RoomId
					  ,[Price] = @Price
				 WHERE [Id]=@Id

				 SET @Message = N'Booking Detail đã được cập nhật thành công'
			END
		END

		SELECT @Message AS [Message], @Id AS Id

	END TRY

	BEGIN CATCH

		SELECT @Message AS [Message], @Id AS Id

	END CATCH
END
