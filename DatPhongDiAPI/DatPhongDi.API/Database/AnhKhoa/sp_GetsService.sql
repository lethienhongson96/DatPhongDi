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
	DECLARE @Message NVARCHAR(50) = N'Có gì đó sai vui lòng thử lại'
	BEGIN
	SELECT s.[Id]
		  ,s.[Name]
		  ,s.[Icon]
		  , t.[StatusName]
	  FROM [dbo].[Service] s
	  INNER JOIN [dbo].[Status] t ON t.[Status] = s.[Status]
	  WHERE t.TableId = 4 AND t.[Status] != 2
	  SET @Message = 'Tìm kiếm thành công'
	END
END

exec [dbo].[sp_GetsService]		

