USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveBooking]    Script Date: 11/19/2020 9:18:26 AM ******/
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
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@CourseId IS NULL OR @CourseId = 0)
		IF(ISNULL(@Id,0) = 0)
			BEGIN
				IF(@Status =  1 OR @Status = 2 OR @Status = 3)
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

							SET @Message = 'Booking has been created success'
							SET @Id = SCOPE_IDENTITY()
					END
				ELSE
					BEGIN
						SET @Message = 'Invalid status value'
					END
			END

		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM [dbo].[Booking] WHERE [Id] = @Id))
				BEGIN
					SET @Message = 'Booking Id not found'
				END
			ELSE
				BEGIN
		
						IF(@Status =  1 OR @Status = 2 OR @Status = 3)
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

						 SET @Message = 'Student has been updated success'
						
						END
						ELSE
						BEGIN
							SET @Message = 'Invalid status value'
						END
			END
		END
		SELECT @Message AS [Message], @Id AS Id
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @Id AS Id
	END CATCH
END