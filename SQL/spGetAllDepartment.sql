USE [Artsoft]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllDepartment]    Script Date: 06.05.2023 12:29:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spGetAllDepartment] 

AS
BEGIN
	SET NOCOUNT ON;
SELECT Id,Name,Floor
FROM Department

END
