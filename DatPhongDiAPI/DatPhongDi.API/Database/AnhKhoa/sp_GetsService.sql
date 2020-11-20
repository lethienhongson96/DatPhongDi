USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStatuses]    Script Date: 11/20/2020 2:12:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Khoa Hoang
-- Create date: 13/11/2020
-- Description:	Get all services
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetsService] 
AS
BEGIN
		SELECT [Id]
			  ,[Name]
			  ,[Icon]
		FROM [dbo].[Service]
END



