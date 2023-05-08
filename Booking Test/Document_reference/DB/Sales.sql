create table Sales (
	Id int identity(1,1) primary key,
	reservation_id UNIQUEIDENTIFIER,
	type VARCHAR(50),
    item VARCHAR(50),
	quantity INT,
	price DECIMAL(5,2),
    subtotal DECIMAL(5,2),
    city_tax DECIMAL(5,2),
    GST DECIMAL(5,2),
    QST DECIMAL(5,2),
    total DECIMAL(5,2),
	
	constraint FK_SALES_REFERENCE_RESERVATION foreign key (reservation_id) references Reservation (Id)
);