BEGIN TRANSACTION;

UPDATE Cilj SET Obrisano=0;

UPDATE Jezik SET Obrisano=0;

UPDATE Klijent SET Obrisano=0;

UPDATE Korisnik SET Obrisano=0;

UPDATE Osoba SET Obrisano=0;

UPDATE Rekvizit SET Obrisano=0;

UPDATE Termin SET Obrisano=0;

UPDATE Trener SET Obrisano=0;

UPDATE Trening SET Obrisano=0;

COMMIT TRANSACTION;