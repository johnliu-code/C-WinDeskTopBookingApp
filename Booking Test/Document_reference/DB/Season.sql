create table Season (
	id INT identity (1,1) primary key,
	season_name VARCHAR(50),
	season_level INT
);
insert into Season (season_name, season_level) values ('Supper Economic Season', 1);
insert into Season (season_name, season_level) values ('Economic Season', 1);
insert into Season (season_name, season_level) values ('Regular Season', 1);
insert into Season (season_name, season_level) values ('High season', 1);
insert into Season (season_name, season_level) values ('Extra High Season', 1);
insert into Season (season_name, season_level) values ('Labours day', 3);
insert into Season (season_name, season_level) values ('Conference', 3);
