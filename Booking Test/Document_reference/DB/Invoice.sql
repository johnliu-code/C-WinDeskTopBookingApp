create table Invoice (
	Id int identity(1,1) primary key,
	customer_id INT,
	reservations VARCHAR(50),
	spends VARCHAR(50),
	constraint FK_INVOICE_REFERENCE_CUSTOMER foreign key (customer_id) references Customer (Id)
);
insert into Invoice (customer_id, reservations, spends) values (15, '["233CB7D7-5CC9-4DC1-AD55-056F9945FDBD"]', '[8,9,17]');
insert into Invoice (customer_id, reservations, spends) values (18, '["2C687FCC-69AF-460A-9C6C-069A14304C29"]', '[4,11,12,18]');
insert into Invoice (customer_id, reservations, spends) values (10, '["762EFCD03-6219-493E-BA00-208BA44E28E5"]', '[10,19]');
insert into Invoice (customer_id, reservations, spends) values (13, '["F6C2F9FB-EA32-4FA5-96AB-2261FA6AF580"]', '[13,14,16]');
insert into Invoice (customer_id, reservations, spends) values (19, '["3569F6ED-202F-4EFC-8C2A-2406826D0966"]', '[15,20]');
