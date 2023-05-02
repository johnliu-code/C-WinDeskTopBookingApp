create table Spend (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
	item VARCHAR(50),
	quantity INT,
	price DECIMAL(5,2),
	constraint FK_SPEND_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);
insert into Spend (reservation_id, item, quantity, price) values ('1988457E-A2DA-4A6E-AEC1-052B1208E305', 'Santa Cruz Island Silverhosackia', 10, 102.02);
insert into Spend (reservation_id, item, quantity, price) values ('F5DBD514-89E8-4C5A-89C1-12F0C66BC4A7', 'Lindheimer''s Crownbeard', 3, 185.82);
insert into Spend (reservation_id, item, quantity, price) values ('37DF0905-293A-4CC8-B9D2-134604B800A5', 'Arrowfeather Threeawn', 4, 43.23);
insert into Spend (reservation_id, item, quantity, price) values ('C35DD849-7A23-423D-9842-184282FC44CB', 'Farewell To Spring', 2, 157.63);
insert into Spend (reservation_id, item, quantity, price) values ('EB640F05-8AF4-4268-B54B-1D2C23DE19DC', 'Kauai Cyrtandra', 7, 114.447);
insert into Spend (reservation_id, item, quantity, price) values ('ACF578F0-AFA9-4F75-8F26-225CCA1E5DA0', 'Iberian Geranium', 9, 161.29);
insert into Spend (reservation_id, item, quantity, price) values ('85233991-C12C-41F0-8368-38334B2A4DC4', 'Pingpong-ball Cactus', 2, 72.25);
insert into Spend (reservation_id, item, quantity, price) values ('DCB1E47D-70C5-44A5-846E-3D3FB0BA66C6', 'Lesser Hawkbit', 10, 194.29);
insert into Spend (reservation_id, item, quantity, price) values ('5D03ACA2-15E9-4246-A4AA-4DAAFB785B5D', 'Woodland Climbing Bamboo', 6, 150.765);
insert into Spend (reservation_id, item, quantity, price) values ('452B4DF1-B158-481A-8B05-5868A29919D5', 'Hawkweed Buckwheat', 5, 23.28);
