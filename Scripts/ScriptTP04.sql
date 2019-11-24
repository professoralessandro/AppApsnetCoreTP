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
values('A batalha do apocalipse', 'Eduardo Spohr','Edi��o Especial do best-seller de Eduardo Spohr. com capa dura. cap�tulos in�ditos. textos extras. organogramas e ilustra��es. H� muitos e muitos anos. tantos quanto o n�mero de estrelas no c�u. o para�so celeste foi palco de um terr�vel levante. Um grupo de anjos guerreiros. amantes da justi�a e da liberdade. desafiou a tirania dos poderosos arcanjos. levantando armas contra seus opressores. Expulsos. os renegados foram for�ados ao ex�lio e condenados a vagar pelo mundo dos homens at� o', 10),
('Use a Cabe�a Java', 'Sierra,Kathy','Use a Cabe�a Java � uma experi�ncia completa de aprendizado em programa��o orientada a objetos (OO) e Java. Projetado de acordo com princ�pios de aprendizado mentalmente amig�veis, este livro o mostrar� tudo, dos aspectos b�sico da linguagem a t�picos avan�ados que incluem segmentos, soquetes de rede e programa��o distribu�da. O mais importante � que voc� aprender� a pensar como um desenvolvedor orientado a objetos. Voc� vai participar de jogos, resolver quebra-cabe�as, refletir sobre mist�rios e interagir com Java de formas nunca imaginadas. No decorrer da leitura, voc� escrever� muitos c�digos Java reais, inclusive o jogo sink a dot com e o cliente de bate-papo de uma rede. A abordagem de aprendizado da s�rie Use a Cabe�a o ajudar� a memorizar rapidamente o conhecimento de maneira permanente. Prepare-se para abrir sua mente enquanto aprende (e compreende) t�picos-chave, entre eles - A linguagem Java; Desenvolvimento orientado a objetos; Cria��o, teste e implanta��o de aplicativos; Uso da biblioteca do API Java; Manipula��o de exce��es; Uso de v�rios segmentos; Programa��o de GUI com o Swing; Rede com RMI e soquetes; Conjuntos e tipos gen�ricos.', 15)
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