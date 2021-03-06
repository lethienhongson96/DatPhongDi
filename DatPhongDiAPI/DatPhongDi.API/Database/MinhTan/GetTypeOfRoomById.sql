USE [DatPhongDiDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeOfRoomById]    Script Date: 02/12/2020 13:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetTypeOfRoomById] 
	@Id int
AS
BEGIN
	SELECT t.[Id]
		  ,t.[Name]
		  
		  ,t.[AmountAdults]
		  ,t.[AmountChild]
		  ,t.[PricePerNight]
		  , st.StatusName
	  FROM [dbo].[TypeOfRoom] t
	  INNER JOIN [dbo].[Status] st on st.[Status] = t.[Status]
	WHERE @Id = t.Id AND st.TableId = 1
ENd



