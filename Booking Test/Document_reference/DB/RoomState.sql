create table RoomState (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
	checkin_time VARCHAR(50),
	checkout_time VARCHAR(50),
    state VARCHAR(50),
	constraint FK_ROOMSTATE_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);