create table Spend (
	Id int identity(1,1) primary key,
	reservation_id INT,
	item VARCHAR(50),
	quantity INT,
	price DECIMAL(5,2),
	constraint FK_SPEND_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);
insert into Spend (reservation_id, item, quantity, price) values (7, 'Santa Cruz Island Silverhosackia', 10, 102.02);
insert into Spend (reservation_id, item, quantity, price) values (4, 'Lindheimer''s Crownbeard', 3, 185.82);
insert into Spend (reservation_id, item, quantity, price) values (7, 'Arrowfeather Threeawn', 4, 43.23);
insert into Spend (reservation_id, item, quantity, price) values (3, 'Farewell To Spring', 2, 157.63);
insert into Spend (reservation_id, item, quantity, price) values (4, 'Kauai Cyrtandra', 7, 114.447);
insert into Spend (reservation_id, item, quantity, price) values (5, 'Iberian Geranium', 9, 161.29);
insert into Spend (reservation_id, item, quantity, price) values (4, 'Pingpong-ball Cactus', 2, 72.25);
insert into Spend (reservation_id, item, quantity, price) values (1, 'Lesser Hawkbit', 10, 194.29);
insert into Spend (reservation_id, item, quantity, price) values (1, 'Woodland Climbing Bamboo', 6, 150.765);
insert into Spend (reservation_id, item, quantity, price) values (4, 'Hawkweed Buckwheat', 5, 23.28);
insert into Spend (reservation_id, item, quantity, price) values (3, 'Branching Phacelia', 5, 4.35);
insert into Spend (reservation_id, item, quantity, price) values (3, 'Narrowleaf Rose Gentian', 6, 26.91);
insert into Spend (reservation_id, item, quantity, price) values (5, 'Greene''s Popcornflower', 8, 81.51);
insert into Spend (reservation_id, item, quantity, price) values (5, 'Scurf Hoarypea', 1, 52.67);
insert into Spend (reservation_id, item, quantity, price) values (6, 'Sago Palm', 5, 32.88);
insert into Spend (reservation_id, item, quantity, price) values (5, 'Yellowflower Indian Mallow', 2, 95.57);
insert into Spend (reservation_id, item, quantity, price) values (1, 'False Horkelia', 8, 154.66);
insert into Spend (reservation_id, item, quantity, price) values (3, 'Bryobrittonia Moss', 5, 68.87);
insert into Spend (reservation_id, item, quantity, price) values (4, 'Brazos River Yucca', 10, 102.0);
insert into Spend (reservation_id, item, quantity, price) values (6, 'Whitemouth Dayflower', 6, 10.89);
