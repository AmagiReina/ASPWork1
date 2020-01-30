USE Library;

INSERT INTO dbo.Authors (FirstName, LastName)
VALUES ('Alexander', 'Pushkin'),
		('Mikhail', 'Lermontov'),
		('Jack', 'London');

INSERT INTO dbo.Books(Title, Price, AuthorId, Pages)
VALUES ('E.Onegin', 3200, 1, 200),
		('Hero of our Time', 2100, 2, 150),
		('White Fang', 2500, 3, 120);

SELECT b.title, b.price, a.firstName, a.LastName, b.Pages
FROM dbo.Books b
INNER JOIN dbo.Authors a ON a.id = b.AuthorId;