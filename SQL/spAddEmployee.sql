USE [Artsoft]
GO
/****** Object:  StoredProcedure [dbo].[spAddEmployee]    Script Date: 06.05.2023 12:28:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spAddEmployee]
@id uniqueidentifier,
	@name NVARCHAR(50),
    @surname NVARCHAR(50),
    @age INT,
    @gender int,
	@departid int,
	@prid int
AS
BEGIN
	
	SET NOCOUNT ON;
INSERT INTO Employee(Id,Name,Surname,Age,Gender,DepartmentId,Pro_LangId) 
VALUES(@id,@name, @surname, @age, @gender,@departid,@prid)
END
