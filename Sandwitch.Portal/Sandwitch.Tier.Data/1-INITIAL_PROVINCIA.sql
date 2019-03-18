DELETE FROM Provincia;
delete from sqlite_sequence where name='Provincia';
INSERT INTO Provincia (LASTMODIFIED,NAME,IMAGEURI) VALUES(date('now'),"Bizkaia","provincias\Bizkaia_600px.png");