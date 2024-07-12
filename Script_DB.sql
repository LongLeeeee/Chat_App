create table Users
(
	USERID varchar(30) primary key,
	USERNAME varchar(40),
	CREATIONDATE smalldatetime,
	EMAIL varchar(50),
	PWD varchar(20), 
)
create table List_Group 
(
	GROUPNAME varchar(40) primary key,
	USERID_CREATION varchar(30),
	CREATIONDATE smalldatetime,
	foreign key (USERID_CREATION) references Users(USERID),
)
create table List_User_A_Group
(
	GROUPNAME varchar(40),
	USERID varchar(30),
	constraint PK primary key (GROUPNAME,USERID),
)
create table Notifications
(
	USERID_RECEIVE varchar(30),
	USERID_SEND varchar(30),
	CREATIONDATE smalldatetime,
	CONTENT varchar(1000),
	constraint PK_NOTI primary key (USERID_RECEIVE,USERID_SEND),
	foreign key (USERID_RECEIVE) references Users(USERID),
	foreign key (USERID_SEND) references Users(USERID),
)
create table Friends
(
	USERID_1 varchar(30),
	USERID_2 varchar(30),
	SENDDATE smalldatetime,
	constraint PK1 primary key (USERID_1,USERID_2),
	foreign key (USERID_1) references Users(USERID),
	foreign key (USERID_2) references Users(USERID),
)
create table Messages_Group
(
	GROUPNAME varchar(40) references List_Group(GROUPNAME),
	CONTENT varchar(8000),
	SENDDATE smalldatetime,
	USERID_SEND varchar(30) references Users(USERID),
)
create table Messages_Friend
(
	ROOMKEY varchar(100) primary key,
	USERID_RECEIVE varchar(30),
	USERID_SEND varchar(30),
	SENDDATE smalldatetime,
	CONTENT varchar(8000),
)
