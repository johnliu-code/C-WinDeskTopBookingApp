create table Customer (
	id INT identity (1,1) primary key,
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	email VARCHAR(50),
	phone VARCHAR(20),
	title VARCHAR(50),
	street VARCHAR(50),
	city VARCHAR(50),
	state VARCHAR(50),
	country VARCHAR(50),
	creditCardId INT  not null,
   constraint FK_Customer_REFERENCE_CREDIT foreign key (CreditCardId) references CreditCard (Id)	
);

insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Thaddeus', 'Gidley', 'tgidley0@thetimes.co.uk', '137.213.199.131', 'Dr', '2877 Lakewood Gardens Road', 'Bei’an', null, 'China', 1);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Genvieve', 'Kennagh', 'gkennagh1@webnode.com', '55.164.172.128', 'Rev', '72095 Reinke Street', 'Maych’ew', null, 'Ethiopia', 2);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Valdemar', 'Gooderham', 'vgooderham2@japanpost.jp', '205.1.250.182', 'Ms', '45 Logan Road', 'Syanno', null, 'Belarus', 3);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Doralia', 'Storkes', 'dstorkes3@wordpress.org', '219.54.149.96', 'Mrs', '72459 Jenifer Hill', 'Dimataling', null, 'Philippines', 4);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Hedwiga', 'Swaile', 'hswaile4@yale.edu', '99.239.128.149', 'Mrs', '939 Charing Cross Terrace', 'Silvino Lobos', null, 'Philippines', 5);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Tarrance', 'Gitting', 'tgitting5@abc.net.au', '75.54.139.159', 'Honorable', '2492 Darwin Point', 'Tanūmah', null, 'Saudi Arabia', 6);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Marna', 'Dyke', 'mdyke6@google.com.hk', '202.131.175.176', 'Mrs', '6925 Fordem Court', 'Chahār Burj', null, 'Afghanistan', 7);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Verne', 'Worsley', 'vworsley7@technorati.com', '180.252.212.116', 'Honorable', '5418 Del Mar Drive', 'Gao’an', null, 'China', 8);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Sasha', 'Storrier', 'sstorrier8@privacy.gov.au', '80.98.101.79', 'Dr', '633 Pawling Road', 'Changtang', null, 'China', 9);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Teodorico', 'Brimilcome', 'tbrimilcome9@surveymonkey.com', '228.25.238.242', 'Ms', '9969 Crownhardt Park', 'Xiakouyi', null, 'China', 10);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Kathye', 'Honywill', 'khonywilla@homestead.com', '171.16.30.96', 'Mr', '6320 Center Crossing', 'San Vicente', null, 'Costa Rica', 11);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Udale', 'Marnes', 'umarnesb@ezinearticles.com', '187.47.150.84', 'Honorable', '0 Gina Way', 'Masindi Port', null, 'Uganda', 12);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Hurlee', 'Hebble', 'hhebblec@vk.com', '126.85.131.167', 'Rev', '70114 Kenwood Plaza', 'Vizal San Pablo', null, 'Philippines', 13);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Merrili', 'Thring', 'mthringd@studiopress.com', '121.13.42.240', 'Dr', '4 Lakewood Gardens Lane', 'Moss', 'Ostfold', 'Norway', 14);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Dianna', 'Salliere', 'dsallieree@weebly.com', '254.231.77.113', 'Mrs', '0805 Moose Center', 'Thaton', null, 'Myanmar', 15);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Sianna', 'MacMarcuis', 'smacmarcuisf@acquirethisname.com', '141.97.144.0', 'Rev', '05838 Longview Street', 'Liulin', null, 'China', 16);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Tobey', 'Darth', 'tdarthg@webmd.com', '96.144.47.245', 'Honorable', '128 Holmberg Avenue', 'Doetinchem', 'Provincie Gelderland', 'Netherlands', 17);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Renate', 'Tather', 'rtatherh@tiny.cc', '0.243.92.29', 'Mrs', '91 Amoth Avenue', 'Zaplavnoye', null, 'Russia', 18);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Billie', 'Emblen', 'bembleni@si.edu', '212.248.249.39', 'Mrs', '65265 Mosinee Trail', 'Velykyi Bereznyi', null, 'Ukraine', 19);
insert into Customer (first_name, last_name, email, phone, title, street, city, state, country, creditCardId) values ('Rodrigo', 'De Ferraris', 'rdeferrarisj@deliciousdays.com', '0.23.50.29', 'Rev', '73 Goodland Hill', 'Chengdong', null, 'China', 20);
