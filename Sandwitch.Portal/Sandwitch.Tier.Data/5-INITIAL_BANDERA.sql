DELETE FROM Bandera;
delete from sqlite_sequence where name='Bandera';
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Verde","banderas\Verde_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Amarilla","banderas\Amarilla_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Violeta","banderas\Violeta_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Roja","banderas\Roja_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Negra","banderas\Negra_500px.png");