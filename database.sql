-- Crear una nueva base de datos llamada "Contpaqi"
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Contpaqi')BEGIN
	CREATE DATABASE Contpaqi;
END 
GO

-- Usar la base de datos recién creada
USE Contpaqi;

-- Crear la tabla "Employee" si no existe
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee')
BEGIN
    CREATE TABLE Employee (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        MiddleName NVARCHAR(50) NOT NULL,
        Age INT NOT NULL,
        DateOfBirth DATE NOT NULL,
        Gender NVARCHAR(10) NOT NULL,
        CivilStatus NVARCHAR(20) NOT NULL,
        Rfc NVARCHAR(13) NOT NULL,
        Address NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        PhoneNumber NVARCHAR(15) NOT NULL,
        Position NVARCHAR(50) NOT NULL,
        HireDate DATE NOT NULL DEFAULT GETDATE(),
        EndDate DATE NULL
    );
END;