-- Samples Databases and Tables for CS4430/5430
--
-- by Li Yang
-- Updated: 9/9/2016

create database computer;
use computer;

create table product(
	maker char(10),
	model char(10),
	type char(10),
	primary key (maker,model)
);

create table pc (
	model char(10) primary key,
	speed decimal(5,2),
	ram int,
	hdisk int,
	price decimal(10,2)
);

create table laptop (
	model char(10) primary key,
	speed decimal(5,2),
	ram int,
	hdisk int,
	screen decimal(5,2),
	price decimal(10,2)
);

create table printer (
	model char(10) primary key,
	color boolean,
	type char(10),
	price decimal(10,2)
);

create database battleship;
use battleship;

create table classes(
	class varchar(20) primary key,
	type varchar(20),
	country varchar(20),
	guns int,
	bore int,
	displacement int
);

create table ships(
	name varchar(20) primary key,
	class varchar(20),
	launched decimal(4),
	foreign key (class) references classes(class)
);

create table battles(
	name varchar(20) primary key,
	bdate date
);

create table outcomes(
	ship varchar(20),
	battle varchar(20),
	result varchar(20),
	primary key (ship,battle)
);

create database catalog;
use catalog;

create table suppliers(
	sid decimal(9) primary key,
	sname varchar(30),
	address varchar(50)
	);
create table parts(
	pid decimal(9) primary key,
	pname varchar(40),
	color varchar(15)
	);
create table catalog(
	sid decimal(9),
	pid decimal(9),
	cost decimal(10,2),
	primary key(sid,pid),
	foreign key(sid) references suppliers(sid),
	foreign key(pid) references parts(pid)
	);


create database company;
use company;

create table emp(
	eid decimal(9) primary key,
	ename varchar(30),
	age int,
	salary decimal(10,2)
	);
create table dept(
	did decimal(2) primary key,
	dname varchar(20),
	budget decimal(10,2),
	managerid decimal(9),
	foreign key(managerid) references emp(eid)
	);
create table works(
	eid decimal(9),
	did decimal(2),
	pct_time decimal(3),
	primary key(eid,did),
	foreign key(eid) references emp(eid),
	foreign key(did) references dept(did)
	);


create database university;
use university;

create table student(
	snum decimal(9) primary key,
	sname varchar(30),
	major varchar(25),
	level varchar(2),
	age int
	);
create table faculty(
	fid decimal(9) primary key,
	fname varchar(30),
	deptid decimal(2)
	);
create table class(
	cname varchar(40) primary key,
	meets_at varchar(20),
	room varchar(10),
	fid decimal(9),
	foreign key(fid) references faculty(fid)
	);
create table enrolled(
	snum decimal(9),
	cname varchar(40),
	primary key(snum,cname),
	foreign key(snum) references student(snum),
	foreign key(cname) references class(cname)
	);


create database flights;
use flights;

create table flights(
	flno decimal(4) primary key,
	origin varchar(20),
	destination varchar(20),
	distance decimal(6),
	departs datetime,
	arrives datetime,
	price decimal(7,2)
	);
create table aircraft(
	aid decimal(9) primary key,
	aname varchar(30),
	cruisingrange decimal(6)
	);
create table employees(
	eid decimal(9) primary key,
	ename varchar(30),
	salary decimal(10,2)
	);
create table certified(
	eid decimal(9),
	aid decimal(9),
	primary key(eid,aid),
	foreign key(eid) references employees(eid),
	foreign key(aid) references aircraft(aid)
	);































