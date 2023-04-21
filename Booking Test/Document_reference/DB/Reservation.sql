create table Reservation (
	Id int identity (1,1) primary key ,
	room_id INT,
	customer_id INT,
	num_adults INT,
	num_children INT,
	occupant VARCHAR(50),
	checkin_date DATE,
	checkout_date DATE,
	vehicle VARCHAR(50),
	agency VARCHAR(50),
	constraint FK_RESERVATION_REFERENCE_ROOM foreign key (room_id) references Room (Id),
   constraint FK_RESERVATION_REFERENCE_CUSTOMER foreign key (customer_id) references Customer (Id),
);
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (3, 15, 4, 4, 'Benedict Reichelt', '9/26/2023', '10/6/2023', 'Leathery Pore Lichen', 'Tenangle Pipewort');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (4, 7, 3, 4, 'Loree Vedekhin', '2/1/2023', '11/4/2023', 'Mojave Sandwort', 'Truncate Pottia Moss');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (5, 18, 4, 3, 'Tiebout Ellice', '1/22/2023', '4/13/2023', 'Shrubland Nehe', 'Indiangrass');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (7, 10, 3, 5, 'Antonius Wilton', '2/6/2023', '6/28/2023', 'Swampforest Beaksedge', 'Condensed Dicranum Moss');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (3, 13, 5, 5, 'Griff Loggie', '3/23/2023', '9/8/2023', 'Eurasian Catchfly', 'Westminster Dewberry');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (7, 19, 2, 4, 'Loy Yesinov', '3/24/2023', '12/13/2023', 'Fragrant Ash', 'Broomcorn Millet');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (7, 17, 3, 5, 'Hesther Grayer', '4/1/2023', '6/20/2023', 'Mexican Yellowshow', 'Torrey Wolfberry');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (5, 8, 4, 5, 'Merill Gambrell', '6/13/2023', '7/27/2023', 'Bower Wattle', 'Arizona Needle Grama');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (1, 6, 3, 3, 'Montgomery Crace', '12/11/2023', '8/20/2023', 'Greenman''s Bluet', 'Wright''s Sensitive Pea');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (3, 19, 2, 1, 'Witty Brisland', '3/13/2023', '6/20/2023', 'Blackberry', 'Big Pine Biscuitroot');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (6, 18, 4, 2, 'Grant Filkov', '10/16/2023', '8/15/2023', 'Desert Wolfberry', 'Roundtip Twinpod');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (4, 18, 3, 3, 'Ryann Latter', '4/16/2023', '6/8/2023', 'Britton''s Wild Petunia', 'Szatala''s Crabseye Lichen');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (7, 14, 3, 3, 'Vida Syres', '5/8/2023', '3/7/2023', 'Hairy Clematis', 'False Wheatgrass');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (5, 10, 5, 2, 'Gertruda Ong', '12/19/2023', '12/1/2023', 'Relaxgrass', 'Parrot-lily');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (6, 17, 1, 3, 'Manolo Deas', '9/25/2023', '5/16/2023', 'Fourwing Saltbush', 'Savannah Dewberry');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (5, 5, 5, 3, 'Carlene Woolford', '12/6/2023', '12/10/2023', 'Petunia', 'Mudbabies');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (2, 8, 3, 5, 'Jessee Risen', '3/2/2023', '10/8/2023', 'Pinkscale Blazing Star', 'Wallroth''s Mycomicrothelia Lichen');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (1, 15, 4, 5, 'Rutger Scotson', '7/3/2023', '10/15/2023', 'Redstem Saxifrage', 'Bluefly Honeysuckle');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (3, 16, 1, 5, 'Merline Pool', '5/11/2023', '3/16/2023', 'Anini', 'Tall Brome');
insert into Reservation (room_id, customer_id, num_adults, num_children, occupant, checkin_date, checkout_date, vehicle, agency) values (4, 6, 3, 2, 'Hurleigh Loraine', '1/14/2023', '6/30/2023', 'Cyrtandra', 'Seaside Alumroot');
