CREATE TABLE Client
(
	ClientId int identity(1, 1) primary key,
	Adress varchar(max),
	Email varchar(max),
	Telephone varchar(max),
	Active varchar(max),
	Name varchar(max),
	Nip varchar(max),
    Surname varchar(max),
	Pesel varchar(max)
);

CREATE TABLE Product
(
	ProductId int identity(1, 1) primary key,
	Name varchar(max),
	Price float,
	Descriptionik varchar(max),
	Amount int
);

CREATE TABLE Orderik
(
	OrderikId int identity(1, 1) primary key,
	Paid int,
	Statusik varchar(max),
	Amount int,
	DataTimik date,
	ProductId int references Product(ProductId)
);



CREATE TABLE ClientOrder
(
	ClientOrderId int identity(1, 1) primary key,
	ClientId int references Client(ClientId),
	ProductId int references Product(ProductId),
	Paid int,
	Statusik varchar(max),
	Amount int,
	DataTimik date,
	Telefon varchar(max),
	Email varchar(max)
);
