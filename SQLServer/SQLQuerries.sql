SELECT Nome, Ano FROM Filmes;

SELECT Nome, Ano FROM Filmes ORDER BY Ano ASC;

SELECT Nome, Ano, Duracao FROM Filmes WHERE Nome = 'De Volta para o Futuro';

SELECT * FROM Filmes WHERE Ano = 1997;

SELECT * FROM Filmes WHERE Ano > 2000;

SELECT * FROM Filmes WHERE Duracao > 100 AND Duracao < 150 ORDER BY Duracao ASC;

SELECT Ano, COUNT(*) AS QuantidadeFilmes FROM Filmes GROUP BY Ano ORDER BY QuantidadeFilmes DESC;

SELECT PrimeiroNome, UltimoNome FROM Atores WHERE Genero = 'M';

SELECT PrimeiroNome, UltimoNome FROM Atores WHERE Genero = 'F' ORDER BY PrimeiroNome;

SELECT Filmes.Nome, Generos.Nome AS Genero FROM Filmes INNER JOIN Generos ON Filmes.GeneroId = Generos.Id;

SELECT Filmes.Nome, Generos.Nome AS Genero FROM Filmes INNER JOIN Generos ON Filmes.GeneroId = Generos.Id WHERE Generos.Nome = 'Mistério';

SELECT Filmes.Nome, Atores.PrimeiroNome, Atores.UltimoNome, Elenco.Papel FROM Filmes INNER JOIN Elenco ON Filmes.Id = Elenco.FilmeId INNER JOIN Atores ON Elenco.AtorId = Atores.Id;