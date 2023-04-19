--UC1
Create Database EmployeePayRoll;
Use EmployeePayRoll;

--UC2
Create table Employee_PayRoll(
EmployeeId int identity(1,1) Primary Key, 
EmployeeName Varchar(255),
EmployeeSalary Bigint,
StartDate DateTime,
);

--UC3
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Anand','10000','2020-10-16');
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Sai','20000','2019-10-16');
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Kumar','30000','2018-10-16');
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Vijaya','40000','2021-10-16');
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Rowthu','50000','2022-10-16');
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Harsha','60000','2017-10-16');
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate)values('Ramani','70000','2016-10-16');

--UC4
Select * from Employee_PayRoll;

--UC5
Select * from Employee_PayRoll where StartDate between CAST('2020-01-01' as Date) and CURRENT_TIMESTAMP; 

--UC6
Alter table Employee_PayRoll Add Gender Varchar(1);
Update Employee_PayRoll set Gender='M' where EmployeeName='Anand';
Update Employee_PayRoll set Gender='M' where EmployeeName='Sai';
Update Employee_PayRoll set Gender='M' where EmployeeName='Kumar';
Update Employee_PayRoll set Gender='M' where EmployeeName='Vijaya';
Update Employee_PayRoll set Gender='M' where EmployeeName='Rowthu';
Update Employee_PayRoll set Gender='F' where EmployeeName='Harsha';
Update Employee_PayRoll set Gender='F' where EmployeeName='Ramani';

--UC7
Select SUM(EmployeeSalary)from Employee_PayRoll where Gender='M' group by Gender;
Select AVG(EmployeeSalary)from Employee_PayRoll where Gender='M' group by Gender;
Select Min(EmployeeSalary)from Employee_PayRoll where Gender='M' group by Gender;
Select Max(EmployeeSalary)from Employee_PayRoll where Gender='M' group by Gender;
Select Count(EmployeeSalary)from Employee_PayRoll group by Gender;

--UC8
Alter table Employee_PayRoll Add EmployeePhNo Varchar(10),Address varchar(30),Department varchar(20);
Update Employee_PayRoll set EmployeePhNo='9515495154',Address='Kakinada',Department='Hr' where EmployeeName='Anand';
Update Employee_PayRoll set EmployeePhNo='7894561232',Address='Vizag',Department='Associate' where EmployeeName='Sai';
Update Employee_PayRoll set EmployeePhNo='1234569871',Address='Rajamundry',Department='JrAssociate' where EmployeeName='Kumar';
Update Employee_PayRoll set EmployeePhNo='9876543214',Address='Yanam',Department='SeniorAssociate' where EmployeeName='Vijaya';
Update Employee_PayRoll set EmployeePhNo='9638527412',Address='Vijayawada',Department='Production' where EmployeeName='Rowthu';
Update Employee_PayRoll set EmployeePhNo='7539514568',Address='Nellore',Department='Quality' where EmployeeName='Harsha';
Update Employee_PayRoll set EmployeePhNo='9517538526',Address='Banglore',Department='Accounts' where EmployeeName='Ramani';

--UC9
Alter table Employee_PayRoll Add BasicPay Bigint,Deductions Bigint,TaxPayable Bigint,IncomeTax Bigint,NetPay Bigint;
Update Employee_PayRoll set BasicPay=1000,Deductions=1000,TaxPayable=1000,IncomeTax=2000,NetPay=5000 where EmployeeName='Anand';
Update Employee_PayRoll set BasicPay=2000,Deductions=2000,TaxPayable=2000,IncomeTax=3000,NetPay=10000 where EmployeeName='Sai';
Update Employee_PayRoll set BasicPay=3000,Deductions=3000,TaxPayable=3000,IncomeTax=9000,NetPay=20000 where EmployeeName='Kumar';
Update Employee_PayRoll set BasicPay=4000,Deductions=4000,TaxPayable=4000,IncomeTax=10000,NetPay=25000 where EmployeeName='Vijaya';
Update Employee_PayRoll set BasicPay=5000,Deductions=5000,TaxPayable=5000,IncomeTax=20000,NetPay=35000 where EmployeeName='Rowthu';
Update Employee_PayRoll set BasicPay=6000,Deductions=6000,TaxPayable=6000,IncomeTax=20000,NetPay=22000 where EmployeeName='Harsha';
Update Employee_PayRoll set BasicPay=1000,Deductions=1000,TaxPayable=1000,IncomeTax=20000,NetPay=45000 where EmployeeName='Ramani';

--UC10
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate,Gender,EmployeePhNo,Address,Department,BasicPay,Deductions,TaxPayable,IncomeTax,NetPay)
values('Terissa','10000','2020-10-16','F','1234567891','Hyderabad','Sales',1000,1000,1000,2000,5000);
Insert into Employee_PayRoll(EmployeeName,EmployeeSalary,StartDate,Gender,EmployeePhNo,Address,Department,BasicPay,Deductions,TaxPayable,IncomeTax,NetPay)
values('Terissa','10000','2020-10-16','F','1234567891','Hyderabad','Marketing',1000,1000,1000,2000,5000);

--UC10-Refactor
Alter table Employee_PayRoll drop column Department;

create table Department(
EmployeeId int Primary key identity(1,1),
DeptName varchar(20),
EmpID int Foreign Key REFERENCES Employee_PayRoll(EmployeeId)
);
insert into Department(DeptName,EmpID)values('Sales',1);
insert into Department(DeptName,EmpID)values('Marketing',1);

select * from Department where EmpID=1;

--UC11-Storedprocedure
Create Procedure AddEmployee
(
@EmployeeName varchar(30),
@EmployeeSalary Bigint,
@StartDate Date,
@Gender varchar(1),
@EmployeePhNo varchar(10),
@Address varchar(100),
@BasicPay Bigint,
@Deductions Bigint,
@TaxPayable Bigint,
@IncomeTax Bigint,
@NetPay Bigint
)
As
Begin
insert into Employee_PayRoll values(@EmployeeName,@EmployeeSalary,@StartDate,@Gender,@EmployeePhNo,@Address,@BasicPay,@Deductions,@TaxPayable,@IncomeTax,@NetPay);
End

--UC12-Delete procedure
Create Procedure DeleteEmployee
(
@EmployeeId int
)
As 
Begin
Delete from Employee_PayRoll where EmployeeId=@EmployeeId;
End

--UC13-Update
Create Procedure UpdateEmployee
(
@EmployeeId int,
@EmployeeName varchar(30)
)
As
Begin
Update Employee_PayRoll set EmployeeName=@EmployeeName where EmployeeId=@EmployeeId;
End


