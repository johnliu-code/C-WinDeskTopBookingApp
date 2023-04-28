create table CreditCard (
	id INT identity (1,1) primary key,
	holder_name VARCHAR(50),
	card_number VARCHAR(50),
	expire_date DATE,
	cvv INT,
	card_type VARCHAR(50),
	customer_id INT NOT NULL,
	constraint FK_CREDITCARD_REFERENCE_CUSTOMER foreign key (customer_id) references Customer (Id),
);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Thaddeus Gidley', '6304466951487944', '04/15/2024', 762, 'laser', 1);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Genvieve Kennagh', '30345195566909', '01/16/2024', 783, 'diners-club-carte-blanche', 2);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Valdemar Gooderham', '0604758477908079992', '11/01/2025', 788, 'maestro', 3);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Doralia Storkes', '6706166704629602', '05/24/2023', 233, 'laser', 4);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Hedwiga Swaile', '4027247651028', '06/21/2023', 571, 'visa', 5);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Tarrance Gitting', '3562650823557646', '01/26/2024', 712, 'jcb', 6);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Marna Dyke', '5048378993021016', '01/25/2025', 274, 'mastercard', 7);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Verne Worsley', '348815391024678', '01/26/2025', 961, 'americanexpress', 8);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Sasha Storrier', '4026005133699943', '09/20/2023', 341, 'visa-electron', 9);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Teodorico Brimilcome', '3568467734834053', '11/15/2025', 261, 'jcb', 10);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Kathye Honywill', '201535910223835', '02/03/2024', 984, 'diners-club-enroute', 11);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Udale Marnes', '6767356662514883177', '05/16/2026', 646, 'solo', 12);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Hurlee Hebble', '3557098079054941', '10/17/2024', 855, 'jcb', 13);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Merrili Thring', '3565277623178857', '01/26/2025', 936, 'jcb', 14);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Dianna Salliere', '3563257920792958', '10/30/2023', 860, 'jcb', 15);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Sianna MacMarcuis', '5100140317048629', '04/30/2025', 902, 'mastercard', 16);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Tobey Darth', '3553471513611614', '08/09/2023', 483, 'jcb', 17);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Renate Tather', '3573009663697003', '06/26/2024', 164, 'jcb', 18);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Billie Emblen', '5602236113640990', '10/13/2023', 647, 'bankcard', 19);
insert into CreditCard (holder_name, card_number, expire_date, cvv, card_type, customer_id) values ('Rodrigo De Ferraris', '30025299506387', '11/20/2024', 366, 'diners-club-carte-blanche', 20);
