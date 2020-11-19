USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeOfRoom]    Script Date: 11/19/2020 9:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetTypeOfRoom] @Id INT
AS
BEGIN
		SELECT [Id]
			  ,[Name]
			  ,[Status]
			  ,(SELECT TOP(1) StatusName FROM [dbo].[Status] WHERE TableId = 1 AND [Status] = T.[Status] AND IsDelete = 0) AS 'StatusName'
		FROM [dbo].[TypeOfRoom] AS T
		WHERE [Status] IN (1,2) AND T.[Id] = @Id
END