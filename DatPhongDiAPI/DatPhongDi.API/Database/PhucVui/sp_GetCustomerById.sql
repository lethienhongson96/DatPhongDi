USE [DatPhongDiDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCustomerById]    Script Date: 19/11/2020 09:28:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Phúc Vui
-- Create date: 18/11/2020
-- Description:	Get Customer by Id 
-- =============================================
Create PROCEDURE [dbo].[sp_GetCustomerById] 
	@Id int
AS
BEGIN

	SELECT [Id]
		  ,[Name]
		  ,[PhoneNum]
		  ,[Email]
		  ,[Country]
		  ,[Passport]
	  FROM [dbo].[Customer]
	WHERE @Id = Id
END
GO

