USE [Artsoft]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllProgramming_language]    Script Date: 06.05.2023 12:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spGetAllProgramming_language]
AS
BEGIN
		SELECT Id,Name from Programming_language
END
