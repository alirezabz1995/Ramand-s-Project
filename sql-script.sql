
CREATE DATABASE users;
USE users;


CREATE TABLE UserTable (
    Id INT PRIMARY KEY,
    Password NVARCHAR(255) NOT NULL
);


CREATE PROCEDURE AddUser
    @Id INT,
    @Password NVARCHAR(255)
AS
BEGIN
    INSERT INTO UserTable (Id, Password) VALUES (@Id, @Password);
END;


CREATE PROCEDURE GetAllUsers
AS
BEGIN
    SELECT * FROM UserTable;
END;
