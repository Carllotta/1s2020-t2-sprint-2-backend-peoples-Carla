-- DDL 


 CREATE DATABASE M_Peoples;

 USE M_Peoples;

 CREATE TABLE Funcionarios(
ID_Funcionario	INT IDENTITY PRIMARY KEY,
Nome			VARCHAR(200) NOT NULL,
Sobrenome		VARCHAR(200) NOT NULL,
);
GO

ALTER TABLE Funcionarios ADD  DatNascimento DATE;

