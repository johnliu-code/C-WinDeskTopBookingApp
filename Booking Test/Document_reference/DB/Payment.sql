create table Payment (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
    creditcard_id INT,
	bill_amount DECIMAL(5,2),
    pay_percentage DECIMAL(5,2),
    payed_amount DECIMAL(5,2),
    balance DECIMAL(5,2),
	
	constraint FK_Payment_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);