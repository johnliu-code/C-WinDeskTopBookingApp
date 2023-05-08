create table Cancellation (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
    creditcard_id INT,
    username VARCHAR(50),
    note_id VARCHAR(50),
	
	constraint FK_Cancellation_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);