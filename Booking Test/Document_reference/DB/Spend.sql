create table Spend (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
	item VARCHAR(50),
	quantity INT,
	price DECIMAL(5,2),
	constraint FK_SPEND_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);
insert into Spend (reservation_id, item, quantity, price) values ('3704D5E0-96B8-4700-AB4A-01C28DB682E3', 'Santa Cruz Island Silverhosackia', 10, 102.02);
insert into Spend (reservation_id, item, quantity, price) values ('F7836055-CFEF-4675-991B-07E164D87A1F', 'Lindheimer''s Crownbeard', 3, 185.82);
insert into Spend (reservation_id, item, quantity, price) values ('2CA55F2A-5720-40E3-8B29-33E946EF3215', 'Arrowfeather Threeawn', 4, 43.23);
insert into Spend (reservation_id, item, quantity, price) values ('1D0C9F1B-BBD0-4BBF-B8E7-67D5D70B2E8F', 'Farewell To Spring', 2, 157.63);
insert into Spend (reservation_id, item, quantity, price) values ('2D17A3EA-9266-41AC-A3BB-8DC3F1B13948', 'Kauai Cyrtandra', 7, 114.447);
insert into Spend (reservation_id, item, quantity, price) values ('9AA0D7EE-AE07-4379-A4FB-99D96828E3D2', 'Iberian Geranium', 9, 161.29);
insert into Spend (reservation_id, item, quantity, price) values ('2E281E04-171E-4B18-ADFF-A08A52968534', 'Pingpong-ball Cactus', 2, 72.25);
insert into Spend (reservation_id, item, quantity, price) values ('39A79E67-6233-4098-9DE7-A1873C9FCAB0', 'Lesser Hawkbit', 10, 194.29);
insert into Spend (reservation_id, item, quantity, price) values ('35C6C283-D659-44F2-8B42-A3C8C3704DAD', 'Woodland Climbing Bamboo', 6, 150.765);
insert into Spend (reservation_id, item, quantity, price) values ('06E7C0EF-6658-492D-9942-A57CE648A471', 'Hawkweed Buckwheat', 5, 23.28);
