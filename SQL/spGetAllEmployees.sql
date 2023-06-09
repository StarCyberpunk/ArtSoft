USE [Artsoft]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 06.05.2023 12:29:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetAllEmployees] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT Employee.Id
      ,Employee.Name
      ,Employee.Surname
      ,Employee.Age
      ,Employee.Gender
	  ,Department.Id as DepartId
	  ,Department.Floor as DepartFloor
      ,Department.Name as DepartName
	  ,Programming_language.Id as PrId
      ,Programming_language.Name as PrName
FROM Employee
INNER JOIN Department on (Department.Id=Employee.DepartmentId)
INNER JOIN Programming_language on (Programming_language.Id=Employee.Pro_LangId)
END
