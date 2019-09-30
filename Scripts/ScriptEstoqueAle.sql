USE master
GO

DROP database portoAle
go

CREATE DATABASE portoAle
go

USE portoAle
go

CREATE TABLE Bl
(
	blId int primary key identity,
	numero int,
	consignee varchar(max),
	navio varchar(max),
)
go

CREATE TABLE Container
(
	containerId int primary key identity,
	numero int,
	tipo varchar(max),
	tamanho decimal(10,2),
	blId int
)
GO

INSERT INTO bl(numero, consignee, navio) VALUES(100, 'ECO Porto', 'Costa do atlantico'),
(15, 'ECO Porto', 'Costa do atlantico'),
(25, 'DPWorld', 'Costa do atlantico')
GO

INSERT INTO Container(numero, tipo, tamanho, blId) VALUES(55, 'C54', 10.00, 1),
(55, 'C54', 15.00, 1)
GO