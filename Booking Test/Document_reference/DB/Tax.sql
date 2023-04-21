create table Tax (
	Id int identity(1,1) primary key,
	tax_type VARCHAR(50),
	value DECIMAL(5,4)
);
insert into Tax (tax_type, value) values ('GST', 0.05);
insert into Tax (tax_type, value) values ('QST', 0.0975);
insert into Tax (tax_type, value) values ('CITY TAX', 0.03);

