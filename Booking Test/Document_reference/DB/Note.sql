create table Note (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
    content VARCHAR(50),
    create_at Date,
	constraint FK_NOTE_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);