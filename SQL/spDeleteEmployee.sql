USE [Artsoft]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployee]    Script Date: 06.05.2023 12:29:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spDeleteEmployee] 
	@id uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;
	Delete Employee where id=@id 
END
