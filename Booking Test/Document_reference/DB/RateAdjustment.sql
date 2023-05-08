create table RateAdjustment (
	Id int identity(1,1) primary key,
	adjust_type VARCHAR(50),
	adjust_value DECIMAL(5,2)
);
insert into RateAdjustment (adjust_type, adjust_value) values ('Discout VIP', 0.10);
insert into RateAdjustment (adjust_type, adjust_value) values ('Add bed', 10.00);
insert into RateAdjustment (adjust_type, adjust_value) values ('Extra deal', 0.15);
insert into RateAdjustment (adjust_type, adjust_value) values ('Surprise', 30.00);

