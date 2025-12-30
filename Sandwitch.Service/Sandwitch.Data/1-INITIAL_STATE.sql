DELETE FROM State;
delete from sqlite_sequence where name='State';
INSERT INTO State (LASTMODIFIED,NAME,IMAGEURI,DELETED) VALUES(datetime('now'),"Bizkaia","/assets/img/provincias\Bizkaia_600px.png", false);