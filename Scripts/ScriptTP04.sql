--USE master
--GO

--DROP DATABASE BibliotecaNew
--GO

CREATE DATABASE BibliotecaNew
go 

USE BibliotecaNew
Go

CREATE TABLE Livros
(
id INT identity primary key,
titulo VARCHAR(max),
subtitulo VARCHAR(max),
autor VARCHAR(60),
resumo VARCHAR(max),
capa VARCHAR(max),
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
Constraint fk_livros FOREIGN KEY (livroId) REFERENCES Livros (id)
)
go

CREATE TABLE Listas
(
ListaId INT identity primary key,
nome VARCHAR(60),
livroId INT,
Constraint fk_livros_Lista FOREIGN KEY (livroId) REFERENCES Livros (id)
)

insert into Livros(titulo, autor, resumo, quantidade)
values('A batalha do apocalipse', 'Eduardo Spohr','Edição Especial do best-seller de Eduardo Spohr. com capa dura. capítulos inéditos. textos extras. organogramas e ilustrações. Há muitos e muitos anos. tantos quanto o número de estrelas no céu. o paraíso celeste foi palco de um terrível levante. Um grupo de anjos guerreiros. amantes da justiça e da liberdade. desafiou a tirania dos poderosos arcanjos. levantando armas contra seus opressores. Expulsos. os renegados foram forçados ao exílio e condenados a vagar pelo mundo dos homens até o', 10),
('Use a Cabeça Java', 'Sierra,Kathy','Use a Cabeça Java é uma experiência completa de aprendizado em programação orientada a objetos (OO) e Java. Projetado de acordo com princípios de aprendizado mentalmente amigáveis, este livro o mostrará tudo, dos aspectos básico da linguagem a tópicos avançados que incluem segmentos, soquetes de rede e programação distribuída. O mais importante é que você aprenderá a pensar como um desenvolvedor orientado a objetos. Você vai participar de jogos, resolver quebra-cabeças, refletir sobre mistérios e interagir com Java de formas nunca imaginadas. No decorrer da leitura, você escreverá muitos códigos Java reais, inclusive o jogo sink a dot com e o cliente de bate-papo de uma rede. A abordagem de aprendizado da série Use a Cabeça o ajudará a memorizar rapidamente o conhecimento de maneira permanente. Prepare-se para abrir sua mente enquanto aprende (e compreende) tópicos-chave, entre eles - A linguagem Java; Desenvolvimento orientado a objetos; Criação, teste e implantação de aplicativos; Uso da biblioteca do API Java; Manipulação de exceções; Uso de vários segmentos; Programação de GUI com o Swing; Rede com RMI e soquetes; Conjuntos e tipos genéricos.', 15)
go
insert into Autores(nome, genero)
values('Eduardo Spohr', 'M'),
('Sierra,Kathy', 'M')
go
insert into Listas(nome)
values('Lido'),
('Para ler')
go

DELETE Listas