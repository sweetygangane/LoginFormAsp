CREATE   DATABASE RegistrationDB;

USE RegistrationDB;

CREATE TABLE Registration
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100),
    Address VARCHAR(200),
    Gender VARCHAR(20),
    Phone VARCHAR(20),
    Email VARCHAR(100),
    Username VARCHAR(50),
    Password VARCHAR(50)
);

select * from  Registration
