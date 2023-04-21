create table Rate (
	Id  int identity (1,1) primary key,
	room_id INT NOT NULL,
	season_id INT NOT NULL,
	price DECIMAL(5,2) NOT NULL,
	constraint FK_RATE_REFERENCE_ROOM foreign key (room_id) references Room (Id),
    constraint FK_RATE_REFERENCE_SEASON foreign key (season_id) references Season (Id)
);
insert into Rate (room_id, season_id, price) values (1, 1, 137.28);
insert into Rate (room_id, season_id, price) values (1, 2, 225.3);
insert into Rate (room_id, season_id, price) values (1, 3, 238.61);
insert into Rate (room_id, season_id, price) values (1, 4, 215.97);
insert into Rate (room_id, season_id, price) values (1, 5, 273.59);
insert into Rate (room_id, season_id, price) values (1, 6, 153.73);
insert into Rate (room_id, season_id, price) values (1, 7, 207.95);
insert into Rate (room_id, season_id, price) values (2, 1, 88.13);
insert into Rate (room_id, season_id, price) values (2, 2, 226.02);
insert into Rate (room_id, season_id, price) values (2, 3, 291.83);
insert into Rate (room_id, season_id, price) values (2, 4, 184.43);
insert into Rate (room_id, season_id, price) values (2, 5, 197.86);
insert into Rate (room_id, season_id, price) values (2, 6, 236.04);
insert into Rate (room_id, season_id, price) values (2, 7, 105.33);
insert into Rate (room_id, season_id, price) values (3, 1, 296.07);
insert into Rate (room_id, season_id, price) values (3, 2, 142.42);
insert into Rate (room_id, season_id, price) values (3, 3, 193.35);
insert into Rate (room_id, season_id, price) values (3, 4, 177.52);
insert into Rate (room_id, season_id, price) values (3, 5, 262.59);
insert into Rate (room_id, season_id, price) values (3, 6, 142.36);
insert into Rate (room_id, season_id, price) values (3, 7, 34.72);
insert into Rate (room_id, season_id, price) values (4, 1, 39.49);
insert into Rate (room_id, season_id, price) values (4, 2, 92.32);
insert into Rate (room_id, season_id, price) values (4, 3, 158.52);
insert into Rate (room_id, season_id, price) values (4, 4, 158.16);
insert into Rate (room_id, season_id, price) values (4, 5, 277.41);
insert into Rate (room_id, season_id, price) values (4, 6, 16.62);
insert into Rate (room_id, season_id, price) values (4, 7, 165.09);
insert into Rate (room_id, season_id, price) values (5, 1, 150.31);
insert into Rate (room_id, season_id, price) values (5, 2, 281.89);
insert into Rate (room_id, season_id, price) values (5, 3, 174.28);
insert into Rate (room_id, season_id, price) values (5, 4, 98.65);
insert into Rate (room_id, season_id, price) values (5, 5, 272.47);
insert into Rate (room_id, season_id, price) values (5, 6, 44.06);
insert into Rate (room_id, season_id, price) values (5, 7, 241.43);
insert into Rate (room_id, season_id, price) values (6, 1, 192.93);
insert into Rate (room_id, season_id, price) values (6, 2, 63.49);
insert into Rate (room_id, season_id, price) values (6, 3, 284.4);
insert into Rate (room_id, season_id, price) values (6, 4, 241.31);
insert into Rate (room_id, season_id, price) values (6, 5, 47.71);
insert into Rate (room_id, season_id, price) values (6, 6, 158.6);
insert into Rate (room_id, season_id, price) values (6, 7, 19.21);
insert into Rate (room_id, season_id, price) values (7, 1, 229.08);
insert into Rate (room_id, season_id, price) values (7, 2, 283.97);
insert into Rate (room_id, season_id, price) values (7, 3, 280.82);
insert into Rate (room_id, season_id, price) values (7, 4, 66.03);
insert into Rate (room_id, season_id, price) values (7, 5, 196.33);
insert into Rate (room_id, season_id, price) values (7, 6, 54.37);

