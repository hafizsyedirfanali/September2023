--SQL Procedures are like functions that can be called with parameters 
--and they perform some specified task/executes set of instructions 
--and can return result

--CREATE NEW PROCEDURE - create proc/procedure <procedurename> <@input parameters with type> as begin <set of instructions> end
create proc spGetStudentList
as
begin
	select * from Students
end

--EXECUTE PROCEDURE (call procedure) exec/execute <procedurename> <inputparameters>
exec spGetStudentList

--UPDATE/ALTER Procedure alter <procedurename> <changes>
alter proc spGetStudentList
as
begin
	select Name,Address,City from Students 
end

--NEW PROC with input
alter proc spGetStudentByCity @City nvarchar(max)
as
begin
 declare @inputCity nvarchar(max) --declare string variable
 set @inputCity = @City --assign value to new variable

 select * from Students where city = @inputCity
end

exec spGetStudentByCity 'Nagpur'