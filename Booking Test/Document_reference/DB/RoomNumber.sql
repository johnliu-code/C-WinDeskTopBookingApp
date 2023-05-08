create table RoomNumber (
	id INT identity (1,1) primary key,
	room_id int not null,
	room_number VARCHAR(30),
    constraint FK_ROOMNUMBER_REFERENCE_ROOM foreign key (room_id) references RoomNumber (Id),
);
insert into RoomNumber (room_id, room_number) values (1, '1Q-1');
insert into RoomNumber (room_id, room_number) values (1, '1Q-2');
insert into RoomNumber (room_id, room_number) values (1, '1Q-3');
insert into RoomNumber (room_id, room_number) values (1, '1Q-4');
insert into RoomNumber (room_id, room_number) values (2, '1Q1DS-1');
insert into RoomNumber (room_id, room_number) values (2, '1Q1DS-2');
insert into RoomNumber (room_id, room_number) values (2, '1Q1DS-3');
insert into RoomNumber (room_id, room_number) values (2, '1Q1DS-4');
insert into RoomNumber (room_id, room_number) values (2, '1Q1DS-5');
insert into RoomNumber (room_id, room_number) values (3, '2D-1');
insert into RoomNumber (room_id, room_number) values (3, '2D-2');
insert into RoomNumber (room_id, room_number) values (3, '2D-3');
insert into RoomNumber (room_id, room_number) values (4, '2Q-1');
insert into RoomNumber (room_id, room_number) values (4, '2Q-2');
insert into RoomNumber (room_id, room_number) values (4, '2Q-3');
insert into RoomNumber (room_id, room_number) values (5, 'OmegaS-1');
insert into RoomNumber (room_id, room_number) values (5, 'OmegaS-2');
insert into RoomNumber (room_id, room_number) values (6, 'YamaskaS-1');
insert into RoomNumber (room_id, room_number) values (6, 'YamaskaS-21');
insert into RoomNumber (room_id, room_number) values (7, 'Romanticas-1');
