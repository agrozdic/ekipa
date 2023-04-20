BEGIN TRANSACTION;

INSERT INTO Jezik VALUES (1, 'srpski');

INSERT INTO Jezik VALUES (2, 'engleski');



INSERT INTO Osoba VALUES (1, 'Ana', 'Anic', 'aanic@mail.com', 'Adresa 1, Mesto', '1234567890001234', 1);

INSERT INTO Osoba VALUES (2, 'Bojan', 'Bojanic', 'bbojanic@mail.com', 'Adresa 2, Mesto', '1234567890001234', 1);

INSERT INTO Osoba VALUES (3, 'Cvetko', 'Cvetkovic', 'ccvetkovic@mail.com', 'Adresa 3, Mesto', '1234567890001234', 1);

INSERT INTO Osoba VALUES (4, 'Danny', 'Danielie', 'ddanielie@mail.com', 'Adresa 4, Mesto', '1234567890001234', 2);



INSERT INTO Klijent VALUES (1, 1, 170, 55, 'U potpunosti zdrava.');

INSERT INTO Klijent VALUES (2, 2, 180, 85, 'Operisan zglob desne noge pre 10 godina.');




INSERT INTO Trener VALUES (1, 3, './Resources/diploma.jpg', './Resources/certificate.jpg', 'Trener');

INSERT INTO Trener VALUES (2, 4, './Resources/diploma.jpg', './Resources/certificate.jpg', 'Trener');



INSERT INTO Korisnik VALUES (1, 1, 'aanic', 'aanic');

INSERT INTO Korisnik VALUES (2, 2, 'bbojanic', 'bbojanic');

INSERT INTO Korisnik VALUES (3, 3, 'ccvetkovic', 'ccvetkovic');

INSERT INTO Korisnik VALUES (4, 4, 'ddanielie', 'ddanielie');



INSERT INTO ListaDodatnihJezika VALUES (1, 2);

INSERT INTO ListaDodatnihJezika VALUES (2, 2);

INSERT INTO ListaDodatnihJezika VALUES (2, 2);

INSERT INTO ListaDodatnihJezika VALUES (2, 1);



INSERT INTO Rekvizit VALUES (1, 'strunjaca', NULL);

INSERT INTO Rekvizit VALUES (2, 'teg', 'od 5kg');

INSERT INTO Rekvizit VALUES (1, 'teg', 'od 10 kg');


CREATE TABLE ListaKlijentRekvizit(
	KlijentID INT NOT NULL,
	RekvizitID INT NOT NULL
);


INSERT INTO ListaKlijentRekvizit VALUES (1, 1);

INSERT INTO ListaKlijentRekvizit VALUES (2, 1);

INSERT INTO ListaKlijentRekvizit VALUES (2, 2);



INSERT INTO Cilj VALUES (1, 'ojacanje', NULL);

INSERT INTO Cilj VALUES (2, 'gubitak tezine', NULL);

INSERT INTO Cilj VALUES (3, 'sticanje dodatne tezine', NULL);



INSERT INTO ListaKlijentCilj VALUES (1, 1);

INSERT INTO ListaKlijentCilj VALUES (1, 3);

INSERT INTO ListaKlijentCilj VALUES (2, 1);

INSERT INTO ListaKlijentCilj VALUES (2, 2);



INSERT INTO Termin VALUES (1, 1, '01/05/2023', '12:00', 1);

INSERT INTO Termin VALUES (2, 1, '01/05/2023', '13:00', 1);

INSERT INTO Termin VALUES (3, 1, '01/05/2023', '14:00', 0);

INSERT INTO Termin VALUES (4, 2, '02/05/2023', '22:00', 0);

INSERT INTO Termin VALUES (5, 2, '02/05/2023', '23:00', 1);



INSERT INTO Trening VALUES (1, 1, 1, 3, 'Plan', NULL, NULL);

INSERT INTO Trening VALUES (2, 2, 2, 4, 'Plan', NULL, NULL);

COMMIT TRANSACTION;