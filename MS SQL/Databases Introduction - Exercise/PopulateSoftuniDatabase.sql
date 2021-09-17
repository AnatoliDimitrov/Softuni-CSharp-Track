INSERT INTO [Towns]([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments]([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02-03-2004', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02-03-2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '12-08-2016', 525.25),
('Georgi', 'Teziev ', 'Ivanov', 'CEO', 2, '09-12-2007', 3000.00),
('Peter', 'Pan ', 'Pan', 'Intern', 3, '12-28-2019', 599.88)