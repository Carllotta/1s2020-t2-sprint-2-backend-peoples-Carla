-- DQL

USE M_Peoples;

SELECT * FROM Funcionarios;



--Exibi as informações de um objeto pelo seu ID
SELECT * FROM Funcionarios WHERE ID_Funcionario = 1;


--Buscando objeto através do nome

GO

CREATE PROCEDURE BuscarNome 
@Nome VARCHAR(255)
AS
SELECT * FROM Funcionarios 
WHERE Nome = @Nome;

EXEC BuscarNome 'Catarina'


--Listando funcionários em ordem alfabética 
GO

CREATE PROCEDURE ordemnsASC
AS
SELECT * FROM FuncionarioS ORDER BY Nome ASC

EXEC ordemnsASC