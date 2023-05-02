create table Availability (
	id INT identity (1,1) primary key,
	roomnumber_id int not null,
    reservation_id UNIQUEIDENTIFIER,
    date Date,
	availability VARCHAR(30) DEFAULT 'Available',
    constraint FK_Availability_REFERENCE_ROOMNUMBER foreign key (roomnumber_id) references RoomNumber (Id),
    constraint FK_Availability_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id),
);
