USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomerById]    Script Date: 11/23/2020 11:52:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Phúc Vui
-- Create date: 18/11/2020
-- Description:	Get Customer by Id 
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetCustomerById] 
	@Id int
AS
BEGIN
DECLARE @Message Nvarchar(50) = N'Có gì đó sai, vui lòng thử lại'
	IF(EXISTS(SELECT * FROM [dbo].[Customer] WHERE @Id = [Id]))
	BEGIN
		SELECT [Id]
		  ,[Name]
		  ,[PhoneNum]
		  ,[Email]
		  ,[Country]
		  ,[Passport]
	  FROM [dbo].[Customer]
	WHERE @Id = Id
	SET @Message = N'Tìm thấy khách hàng thành công'
	END
	ELSE
	BEGIN
		SET @Message = N'Không tìm thấy khách hàng trong cơ sở dữ liệu'
	END
	SELECT @Message AS [Message], @Id as [Id]
END

--exec [dbo].[sp_GetCustomerById] 1
