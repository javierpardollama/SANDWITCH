DELETE FROM Flag;
delete from sqlite_sequence where name='Flag';
INSERT INTO Flag (LASTMODIFIED,NAME, IMAGEURI, DELETED) VALUES(datetime('now'),"Verde","/assets/img/banderas\Verde_500px.png", false);
INSERT INTO Flag (LASTMODIFIED,NAME, IMAGEURI, DELETED) VALUES(datetime('now'),"Amarilla","/assets/img/banderas\Amarilla_500px.png", false);
INSERT INTO Flag (LASTMODIFIED,NAME, IMAGEURI, DELETED) VALUES(datetime('now'),"Violeta","/assets/img/banderas\Violeta_500px.png", false);
INSERT INTO Flag (LASTMODIFIED,NAME, IMAGEURI, DELETED) VALUES(datetime('now'),"Roja","/assets/img/banderas\Roja_500px.png", false);
INSERT INTO Flag (LASTMODIFIED,NAME, IMAGEURI, DELETED) VALUES(datetime('now'),"Negra","/assets/img/banderas\Negra_500px.png", false);