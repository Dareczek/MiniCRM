insert into Client(Adress,Email,Telephone,Active,Name,Nip,Surname,Pesel) values
	('Warzywna','Warzywa@gmail.com','89651123','Yes','wololo','1111-11','',''),
	('Owocowa','Owocowa@gmail.com','123456789','No','wwww','','qqqq','123123');

insert into Product(Name,Price,Descriptionik,Amount) values
	('Eliksir',2,'Dobry jest',2);
	
insert into Orderik(Paid,Statusik,Amount,DataTimik,ProductId) values
	(0,'Oczekujace','12','2013-05-24',1);
	
insert into ClientOrder(OrderikId,ClientId,ProductId,Paid,Statusik,Amount,DataTimik,Telefon,Email) values
	(1,2,1,0,'Oczekujace','12','2013-05-24','123456789','Owocowa@gmail.com');	
	

