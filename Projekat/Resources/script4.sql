BEGIN TRANSACTION

UPDATE Trener SET Diploma = '../resources/images/diploma.jpg';

UPDATE Trener SET Sertifikat = '../resources/images/certificate.jpg';

COMMIT TRANSACTION;