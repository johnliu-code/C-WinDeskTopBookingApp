create table Period (
	id INT identity (1,1) primary key,
	season_id INT NOT NULL,
	start_date DATE,
	end_date DATE,
	week_day VARCHAR(50)
	constraint FK_Period_REFERENCE_SEASON foreign key (season_id) references Season (Id)
);
insert into Period (season_id, start_date, end_date, week_day) values (1, '3/18/2023', '5/26/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (1, '5/28/2023', '6/16/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (2, '6/17/2023', '6/23/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (2, '9/5/2023', '10/14/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (3, '6/24/2023', '6/29/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (3, '7/2/2023', '7/20/2023', '["Mon", "Tue", "Wed", "Thu", "Sun"]');
insert into Period (season_id, start_date, end_date, week_day) values (3, '8/13/2023', '8/31/2023', '["Mon", "Tue", "Wed", "Thu", "Sun"]');
insert into Period (season_id, start_date, end_date, week_day) values (4, '6/30/2023', '7/1/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (4, '7/7/2023', '7/8/2023', '["Fri", "Sat"]');
insert into Period (season_id, start_date, end_date, week_day) values (4, '7/14/2023', '7/15/2023', '["Fri", "Sat"]');
insert into Period (season_id, start_date, end_date, week_day) values (4, '7/21/2023', '7/27/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (4, '7/30/2023', '8/12/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (5, '7/28/2023', '7/29/2023', '["Fri", "Sat"]');
insert into Period (season_id, start_date, end_date, week_day) values (6, '9/1/2023', '9/4/2023', '["All"]');
insert into Period (season_id, start_date, end_date, week_day) values (7,'5/27/2023', '5/27/2023', '["All"]');

