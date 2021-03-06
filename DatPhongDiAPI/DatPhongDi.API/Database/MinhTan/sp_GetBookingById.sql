USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBookingById]    Script Date: 11/23/2020 11:52:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 18/11/2020
-- Description:	Get Booking by Id
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetBookingById]
@Id int
AS
BEGIN
	DECLARE @Message Nvarchar(50) = N'Có gì đó sai, vui lòng thử lại'
	IF(EXISTS(SELECT * FROM [dbo].[Booking] WHERE @Id = [Id] and [Status] != 3))
	BEGIN
		SELECT c.[Id]
			  ,c.[RoomId]
			  ,c.[CustomerId]
			  ,c.[AmountNight]
			   ,FORMAT(c.[CheckIn],'MMM dd yyyy') CheckInStr
			   ,FORMAT(c.[CheckOut],'MMM dd yyyy') ASCheckOutStr
			   ,FORMAT(c.[CreateDate],'MMM dd yyyy') AS CreateDateStr
			  ,FORMAT(c.[ModifiedDate],'MMM dd yyyy') AS ModifiedDateStr
			  ,c.[ModifiedBy]
			  ,c.[Status]
			  ,st.StatusName
		  FROM [dbo].[Booking] AS c
		  INNER JOIN [dbo].[Status] st ON st.[Status] = c.[Status]
		 WHERE @Id = c.Id AND st.TableId = 3
		 SET @Message = N'Tìm thấy thành công'
	END
	ELSE 
	BEGIN
		SET @Message = N'Không tìm thấy'
	END
	SELECT @Message AS [Message], @Id as [Id] 
END


