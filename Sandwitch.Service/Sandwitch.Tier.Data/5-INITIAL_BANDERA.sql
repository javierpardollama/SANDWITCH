DELETE FROM Bandera;
delete from sqlite_sequence where name='Bandera';
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Verde","/assets/img/banderas\Verde_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Amarilla","/assets/img/banderas\Amarilla_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Violeta","/assets/img/banderas\Violeta_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Roja","/assets/img/banderas\Roja_500px.png");
INSERT INTO Bandera (LASTMODIFIED,NAME, IMAGEURI) VALUES(date('now'),"Negra","/assets/img/banderas\Negra_500px.png");