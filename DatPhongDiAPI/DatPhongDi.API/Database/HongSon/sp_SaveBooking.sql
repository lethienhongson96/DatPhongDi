USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveBooking]    Script Date: 11/23/2020 11:53:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_SaveBooking]
	   @Id int,
	   @RoomId int,
       @CustomerId int,
       @AmountNight int,
	   @Checkin datetime,
	   @CheckOut datetime,
	   @Status int
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Có gì đó sai, vui lòng thử lại sau!'
	BEGIN TRY
		-- Create
		--IF(@CourseId IS NULL OR @CourseId = 0)
		IF(ISNULL(@Id,0) = 0)
			BEGIN
				IF(@Status =  1 OR @Status = 2 OR @Status = 3)
					BEGIN
					IF(ISDATE(CONVERT(DATEtime,@Checkin)) = 1 AND ISDATE(CONVERT(DATEtime,@CheckOut)) = 1 AND DATEDIFF(day,CONVERT(DATEtime,@Checkin) ,CONVERT(DATEtime,@CheckOut) ) > 0 )
						BEGIN
							INSERT INTO [dbo].[Booking]
								   ([RoomId]
								   ,[CustomerId]
								   ,[AmountNight]
								   ,[CheckIn]
								   ,[CheckOut]
								   ,[CreateDate]
								   ,[ModifiedDate]
								   ,[ModifiedBy]
								   ,[Status])
							 VALUES
								   (@RoomId
								   ,@CustomerId
								   ,@AmountNight
								   ,@CheckIn
								   ,@CheckOut
								   ,GETDATE()
								   ,null
								   ,null
								   ,@Status)

							SET @Message = 'Tạo thành công'
							SET @Id = SCOPE_IDENTITY()
						END
					 ELSE
						BEGIN
							SET @Message = 'Ngày Checkout phải sau ngày Checkin'
						END
					END
				ELSE
					BEGIN
						SET @Message = 'Trạng thái không đúng'
					END
			END

		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Booking] WHERE [Id] = @Id))
				BEGIN
					SET @Message = 'Không tìm thấy'
				END
			ELSE
				BEGIN
		
						IF(@Status =  1 OR @Status = 2 OR @Status = 3)
						BEGIN
							IF(ISDATE(CONVERT(DATEtime,@Checkin)) = 1 AND ISDATE(CONVERT(DATEtime,@CheckOut)) = 1 AND DATEDIFF(day,CONVERT(DATEtime,@Checkin) ,CONVERT(DATEtime,@CheckOut) ) > 0 )
								BEGIN
									UPDATE [dbo].[Booking]
							   SET [RoomId] = @RoomId
								  ,[CustomerId] = @CustomerId
								  ,[AmountNight] = @AmountNight
								  ,[CheckIn] = @CheckIn
								  ,[CheckOut] = @CheckOut
								  ,[CreateDate] = CreateDate
								  ,[ModifiedDate] = GETDATE()
								  ,[ModifiedBy] = null
								  ,[Status] = @Status
							 WHERE [Id]=@Id

						 SET @Message = 'Cập nhật thành công'
								END
								ELSE
								BEGIN
									SET @Message = N'Ngày Checkout phải sau ngày Checkin'
								END
						END
						ELSE
						BEGIN
							SET @Message = 'Trạng thái không đúng'
						END
			END
		END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END