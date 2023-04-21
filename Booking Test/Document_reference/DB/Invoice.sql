create table Invoice (
	Id int identity(1,1) primary key,
	customer_id INT,
	reservations VARCHAR(50),
	spends VARCHAR(50),
	constraint FK_INVOICE_REFERENCE_CUSTOMER foreign key (customer_id) references Customer (Id)
);
insert into Invoice (customer_id, reservations, spends) values (15, '[1]', '[8,9,17]');
insert into Invoice (customer_id, reservations, spends) values (18, '[3]', '[4,11,12,18]');
insert into Invoice (customer_id, reservations, spends) values (10, '[4]', '[10,19]');
insert into Invoice (customer_id, reservations, spends) values (13, '[5]', '[13,14,16]');
insert into Invoice (customer_id, reservations, spends) values (19, '[6]', '[15,20]');

