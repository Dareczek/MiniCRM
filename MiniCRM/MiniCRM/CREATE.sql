CREATE TABLE Client
(
	ClientId int identity(1, 1) primary key not null,
	Address varchar(50) not null,
	Email varchar(30) not null,
	Telephone varchar(20) not null,
	Active varchar(10) not null,
	YesNo varchar(3) not null,
);

CREATE TABLE BusinessClient
(
	ClientId int not null foreign key references Client(ClientId),
	Address varchar(50) not null,
	Email varchar(30) not null,
	Telephone varchar(20) not null,
	Active varchar(10) not null,
	YesNo varchar(3) not null,
	Nip varchar(30) varchar(15) primary key not null,
    Name varchar(30) not null
);

CREATE TABLE RetailClient
(
	ClientId int not null foreign key references Client(ClientId),
	Address varchar(50) not null,
	Email varchar(30) not null,
	Telephone varchar(20) not null,
	Active varchar(10) not null,
	YesNo varchar(3) not null,
	Pesel varchar(30) primary key not null,
    Name varchar(30) not null,
	Surname varchar(30) null
);

CREATE TABLE Order
(
	OrderId int identity(1, 1) primary key not null,
	Paid int not null,
	Status varchar(10) not null,
	Amount int not null,
	DataTime date not null,
);

CREATE TABLE Product
(
	ProductId int identity(1, 1) primary key not null,
	Name varchar(50) not null,
	Price double not null,
	Description varchar(100) not null,
	Amount int not null,
);

CREATE TABLE ClientOrder
(
	OrderId int not null foreign key references Order(OrderId),
	ClientId int not null foreign key references Client(ClientId),
	ProductId int not null foreign key references Product(ProductId),
	Paid int not null,
	Status varchar(10) not null,
	Amount int not null,
	DataTime date not null,
	Telefon varchar(15),
	Email varchar(35) not null,
);
		
CREATE TABLE Settings
(
	Login int identity(1, 1) primary key not null,
	Password varchar(50) not null
);
