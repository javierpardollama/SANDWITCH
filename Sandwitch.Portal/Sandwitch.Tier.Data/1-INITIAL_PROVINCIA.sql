DELETE FROM Provincia;
delete from sqlite_sequence where name='Provincia';
INSERT INTO Provincia (LASTMODIFIED,NAME) VALUES(date('now'),"Bizkaia");