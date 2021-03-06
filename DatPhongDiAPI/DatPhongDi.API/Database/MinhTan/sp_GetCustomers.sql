USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomers]    Script Date: 11/23/2020 2:40:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Minh Tan
-- Create date: 18/11/2020
-- Description:	Get Customer
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetCustomers]
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
