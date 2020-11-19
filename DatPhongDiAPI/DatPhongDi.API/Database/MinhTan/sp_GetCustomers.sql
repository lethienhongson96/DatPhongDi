USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomer]    Script Date: 19/11/2020 08:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 18/11/2020
-- Description:	Get Customer
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetCustomer]
AS
BEGIN
	SELECT [Id]
      ,[Name]
      ,[PhoneNum]
      ,[Email]
      ,[Country]
      ,[Passport]
  FROM [dbo].[Customer]

END
