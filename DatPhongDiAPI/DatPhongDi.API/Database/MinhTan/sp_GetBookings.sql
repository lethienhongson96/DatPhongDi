USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBookings]    Script Date: 11/23/2020 2:28:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 17/11/2020
-- Description:	Get all Booking
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetBookings]
AS
BEGIN
	SELECT c.[Id]
		  ,c.[RoomId]
		  ,c.[CustomerId]
		  ,c.[AmountNight]
		  ,c.CheckIn
		  ,c.CheckOut
		  ,c.CreateDate
		  ,c.ModifiedDate
		   ,FORMAT(c.[CheckIn],'MMM dd yyyy') AS CheckInStr
		   ,FORMAT(c.[CheckOut],'MMM dd yyyy') AS CheckOutStr
		   ,FORMAT(c.[CreateDate],'MMM dd yyyy') AS CreateDateStr
		  ,FORMAT(c.[ModifiedDate],'MMM dd yyyy') AS ModifiedDateStr
		  ,c.[ModifiedBy]
		  ,c.[Status]
		 ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 3 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
	  FROM [dbo].[Booking] AS c
	WHERE [Status] in (1,2)
END