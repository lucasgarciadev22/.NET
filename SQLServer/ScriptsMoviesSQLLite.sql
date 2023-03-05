CREATE TABLE Atores (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  PrimeiroNome VARCHAR(20),
  UltimoNome VARCHAR(20),
  Genero VARCHAR(1)
);

CREATE TABLE ElencoFilme (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  IdAtor INTEGER NOT NULL,
  IdFilme INTEGER,
  Papel VARCHAR(30),
  FOREIGN KEY (IdAtor) REFERENCES Atores (Id)
);

CREATE TABLE Filmes (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome VARCHAR(50),
  Ano INTEGER,
  Duracao INTEGER
);

CREATE TABLE FilmesGenero (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  IdGenero INTEGER,
  IdFilme INTEGER,
  FOREIGN KEY (IdGenero) REFERENCES Generos (Id),
  FOREIGN KEY (IdFilme) REFERENCES Filmes (Id)
);

CREATE TABLE Generos (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome VARCHAR(20)
);

INSERT INTO Atores (PrimeiroNome, UltimoNome, Genero) VALUES ('James', 'Stewart', 'M');
INSERT INTO ElencoFilme (IdAtor, IdFilme, Papel) VALUES (1, 1, 'John Scottie Ferguson');
INSERT INTO Filmes (Nome, Ano, Duracao) VALUES ('De Volta para o Futuro', 1985, 116);
INSERT INTO FilmesGenero (IdGenero, IdFilme) VALUES (1, 1);
INSERT INTO Generos (Genero) VALUES ('Ação');
