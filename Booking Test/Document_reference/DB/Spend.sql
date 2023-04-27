create table Spend (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
	item VARCHAR(50),
	quantity INT,
	price DECIMAL(5,2),
	constraint FK_SPEND_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);
insert into Spend (reservation_id, item, quantity, price) values ('233CB7D7-5CC9-4DC1-AD55-056F9945FDBD', 'Santa Cruz Island Silverhosackia', 10, 102.02);
insert into Spend (reservation_id, item, quantity, price) values ('2C687FCC-69AF-460A-9C6C-069A14304C29', 'Lindheimer''s Crownbeard', 3, 185.82);
insert into Spend (reservation_id, item, quantity, price) values ('2C687FCC-69AF-460A-9C6C-069A14304C29', 'Arrowfeather Threeawn', 4, 43.23);
insert into Spend (reservation_id, item, quantity, price) values ('62EFCD03-6219-493E-BA00-208BA44E28E5', 'Farewell To Spring', 2, 157.63);
insert into Spend (reservation_id, item, quantity, price) values ('F6C2F9FB-EA32-4FA5-96AB-2261FA6AF580', 'Kauai Cyrtandra', 7, 114.447);
insert into Spend (reservation_id, item, quantity, price) values ('3569F6ED-202F-4EFC-8C2A-2406826D0966', 'Iberian Geranium', 9, 161.29);
insert into Spend (reservation_id, item, quantity, price) values ('EEC619EB-5419-49F1-AF17-5F5B12F282A2', 'Pingpong-ball Cactus', 2, 72.25);
insert into Spend (reservation_id, item, quantity, price) values ('5674D403-DF73-4F1B-AD45-63BA88A8C3D4', 'Lesser Hawkbit', 10, 194.29);
insert into Spend (reservation_id, item, quantity, price) values ('E55427DE-18C8-47DF-80D0-6CA1C6509C9D', 'Woodland Climbing Bamboo', 6, 150.765);
insert into Spend (reservation_id, item, quantity, price) values ('3C82F71D-F6DE-4FBC-A60A-6D259DD6AF71', 'Hawkweed Buckwheat', 5, 23.28);
insert into Spend (reservation_id, item, quantity, price) values ('D185608F-A9DC-450A-B8FB-7B2DA7B6022A', 'Branching Phacelia', 5, 4.35);
insert into Spend (reservation_id, item, quantity, price) values ('C1B766B3-1DC6-432A-84C9-7FB3FD8185FF', 'Narrowleaf Rose Gentian', 6, 26.91);
insert into Spend (reservation_id, item, quantity, price) values ('158049BA-D603-418A-8F2D-851411219079', 'Greene''s Popcornflower', 8, 81.51);
insert into Spend (reservation_id, item, quantity, price) values ('94259896-8332-48DE-A88C-903D076C0606', 'Scurf Hoarypea', 1, 52.67);
insert into Spend (reservation_id, item, quantity, price) values ('805A18AA-CE50-4747-BE4A-A926FDA14827', 'Sago Palm', 5, 32.88);
insert into Spend (reservation_id, item, quantity, price) values ('7D4C7237-49CE-4CF6-8D53-B38CC230C354', 'Yellowflower Indian Mallow', 2, 95.57);
insert into Spend (reservation_id, item, quantity, price) values ('DC1344B1-CC1B-475F-B281-BC3D5BCD82B0', 'False Horkelia', 8, 154.66);
insert into Spend (reservation_id, item, quantity, price) values ('2F8E7E2E-565F-4D82-832F-CC9831AFD15C', 'Bryobrittonia Moss', 5, 68.87);
insert into Spend (reservation_id, item, quantity, price) values ('55E8A8AB-EBCD-46F9-9B66-F9AAF9AAF680', 'Brazos River Yucca', 10, 102.0);
insert into Spend (reservation_id, item, quantity, price) values ('A4DD0FF5-D4DD-44F9-9B33-F103CCFDE61A', 'Whitemouth Dayflower', 6, 10.89);