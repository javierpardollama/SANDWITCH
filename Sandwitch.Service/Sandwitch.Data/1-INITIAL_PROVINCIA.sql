DELETE FROM Provincia;
delete from sqlite_sequence where name='Provincia';
INSERT INTO Provincia (LASTMODIFIED,NAME,IMAGEURI,DELETED) VALUES(date('now'),"Bizkaia","/assets/img/provincias\Bizkaia_600px.png", false);