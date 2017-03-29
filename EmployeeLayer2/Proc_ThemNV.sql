use EmployeeDB
go

create proc ThemNV
	@ID int,
	@LastName nvarchar (50),
	@FirstName nvarchar (50),
	@DeptID int
as
	begin
		
		insert into Employees(ID, LastName, FirstName, DepID)
		values (@ID, @LastName, @FirstName, @DeptID)
	end

go