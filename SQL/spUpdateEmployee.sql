USE [Artsoft]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployee]    Script Date: 06.05.2023 12:30:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateEmployee]
	@id uniqueidentifier,
	@name NVARCHAR(50),
    @surname NVARCHAR(50),
    @age INT,
    @gender int,
	@departid int,
	@prid int
AS
BEGIN
	UPDATE Employee
SET Name=@name,Surname=@surname,Age=@age,Gender=@gender,DepartmentId=@departid,Pro_LangId=@prid
WHERE Id =@id
END
