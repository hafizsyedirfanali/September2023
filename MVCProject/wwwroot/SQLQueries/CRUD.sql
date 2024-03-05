use MySecondDb
--CRUD
--1. READ - select <columnnames> from <tablename> where <filter> order by <sorting> asc/desc
select * from Students
--select Name,Address,City from Students
--select Address,Name,City from Students
--select Name as StudentName,Address as PermanentAddress,City from Students
--select count(Id) as StudentCount from Students
--select Max(postalcode) as MaxValue from Students
--select * from Students where name = 'irfan'
--select * from Students where name like '___oo%'--this will filter names whose fourth and fifth char is oo. _ is for one char. and % is for string
--select * from Students order by PostalCode asc

--CREATE - insert into <tablename> (columns) values (values)
--insert into Students (Id,Name,Address,City,Region,PostalCode,Country) values ('ccb0db60-7be1-42af-bbb4-0606e733c697','Abcd','xyz','Bhandara','Mah','4334343','India')

--UPDATE - DANGER - Update <tablename> set <columnname & values> where <filter>
update Students set Name = 'Suboor' where id = '2931FED4-1D98-4A1B-8C72-FCB6427226F6'

--DELETE - DANGER - Delete <tablename> where <filter>

delete Students where id = '209CFA7C-B72F-4145-7CCF-08DC3BF36A7C'




