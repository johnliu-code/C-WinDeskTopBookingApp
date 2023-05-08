create table LockState (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
    block_price BIT,
    no_placement BIT,
    pre_reserved BIT,
	
	constraint FK_LockState_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);