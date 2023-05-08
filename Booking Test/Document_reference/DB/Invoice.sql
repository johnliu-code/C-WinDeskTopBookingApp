create table Invoice (
	Id int identity(1,1) primary key,
	customer_id INT,
	reservations VARCHAR(50),
	spends VARCHAR(50),
	constraint FK_INVOICE_REFERENCE_CUSTOMER foreign key (customer_id) references Customer (Id)
);
insert into Invoice (customer_id, reservations, spends) values (15, '["3704D5E0-96B8-4700-AB4A-01C28DB682E3"]', '[8,9,17]');
insert into Invoice (customer_id, reservations, spends) values (18, '["F7836055-CFEF-4675-991B-07E164D87A1F"]', '[4,11,12,18]');
insert into Invoice (customer_id, reservations, spends) values (10, '["2CA55F2A-5720-40E3-8B29-33E946EF3215"]', '[10,19]');
insert into Invoice (customer_id, reservations, spends) values (13, '["1D0C9F1B-BBD0-4BBF-B8E7-67D5D70B2E8F"]', '[13,14,16]');
insert into Invoice (customer_id, reservations, spends) values (19, '["2D17A3EA-9266-41AC-A3BB-8DC3F1B13948"]', '[15,20]');
