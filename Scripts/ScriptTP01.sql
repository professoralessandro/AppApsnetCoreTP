USE master
GO

DROP DATABASE Biblioteca
GO


CREATE DATABASE Biblioteca
go 

USE Biblioteca
Go

CREATE TABLE Livros
(
livroId INT identity primary key,
nome VARCHAR(60),
autor VARCHAR(60),
preco DECIMAL(10,2),
quantidade INT
)
go

CREATE TABLE Autores
(
autorId INT identity primary key,
nome VARCHAR(60),
email VARCHAR(60),
genero VARCHAR(60),
livroId INT,
Constraint fk_livros FOREIGN KEY (livroId) REFERENCES Livros (livroId)
)
go

INSERT INTO Livros(autor,nome , preco, quantidade) VALUES
('Alessandro','Livro Ale 1', 10.50, 10),
('Alessandro 2','Livro Ale 2', 10.50, 10),
('Alessandro 3','Livro Ale 3', 10.50, 10)
go

INSERT INTO Autores(nome, email, genero, livroId) VALUES
('Alessandro', 'ale@ale.com', 'Masculino', 1),
('Alessandro 2', 'ale@ale.com', 'Masculino', 1),
('Alessandro 3', 'ale@ale.com', 'Masculino', 1)
go