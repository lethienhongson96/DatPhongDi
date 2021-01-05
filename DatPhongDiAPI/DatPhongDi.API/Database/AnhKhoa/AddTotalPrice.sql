USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddTotalPrice]    Script Date: 2020-12-21 09:01:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Hoang
-- Create date: 30/10/2020
-- Description:	Update Course
-- =============================================
ALTER PROCEDURE [dbo].[sp_AddTotalPrice]
	@TotalPrice money,
	@BookingId int
AS
BEGIN

UPDATE [dbo].[Booking]
   SET [TotalPrice] = @TotalPrice
 WHERE @BookingId = [Id]
END





