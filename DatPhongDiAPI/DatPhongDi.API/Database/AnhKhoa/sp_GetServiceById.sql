USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetServiceById]    Script Date: 11/23/2020 9:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetServiceById]	
	 @Id INT
AS
BEGIN
	DECLARE @Message Nvarchar(50) = N'Có gì đó sai, vui lòng thử lại'
	IF(EXISTS(SELECT * FROM [dbo].[Service] WHERE @Id = [Id]))
	BEGIN
SELECT s.Id
      ,s.[Name]
      ,s.Icon
      ,st.StatusName
  FROM [dbo].[Service] s
  INNER JOIN [dbo].[Status] st ON st.[Status] = s.[Status]
	  WHERE @Id = s.Id AND st.TableId = 4
	  SET @Message = N'Tìm thấy dịch vụ thành công'
	END
	ELSE
	BEGIN
		SET @Message = N'Không tìm thấy dịch vụ trong cơ sở dữ liệu'
	END
	
	SELECT @Message AS [Message], @Id as [Id] 
END