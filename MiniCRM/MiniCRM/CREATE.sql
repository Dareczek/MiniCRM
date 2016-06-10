CREATE TABLE Client
(
	ClientId int identity(1, 1) primary key,
	Adress varchar,
	Email varchar,
	Telephone varchar,
	Active varchar
	YesNo byte,
);

CREATE TABLE BusinessClient
(
	BusinessClientId int identity(1, 1) primary key,
	ClientId int foreign key references Client(ClientId),
	Adress varchar,
	Email varchar,
	Telephone varchar,
	Active varchar,
	YesNo byte,
	Nip varchar,
    Name varchar
);

CREATE TABLE RetailClient
(
	RetailClientId int identity(1, 1) primary key,
	ClientId int foreign key references Client(ClientId),
	Adress varchar,
	Email varchar,
	Telephone varchar,
	Active varchar,
	YesNo varchar,
	Pesel varchar,
    Name varchar,
	Surname varchar
);

CREATE TABLE Product
(
	ProductId int identity(1, 1) primary key,
	Name varchar,
	Price double,
	Descriptionik varchar,
	Amount int
);

CREATE TABLE Orderik
(
	OrderikId int identity(1, 1) primary key,
	Paid int,
	Statusik varchar,
	Amount int,
	DataTimik date,
);



CREATE TABLE ClientOrder
(
	ClientOrderId int identity(1, 1) primary key,
	OrderikId int foreign key references Order(OrderikId),
	ClientId int foreign key references Client(ClientId),
	ProductId int foreign key references Product(ProductId),
	Paid int,
	Statusik varchar,
	Amount int,
	DataTimik date,
	Telefon varchar,
	Email varchar
);
		
CREATE TABLE Settings
(
	Loginek varchar primary key,
	Passwordek varchar
);
