insert into Client(Adress,Email,Telephone,Active,YesNo) values
	('Warzywna','Warzywa@gmail.com','89651123','Yes',1),
	('Owocowa','Owocowa@gmail.com','123456789','No',0);

insert into BusinessClient(ClientId, Adress,Email,Telephone,Active,YesNo,Nip,Name) values
	(1,'Warzywna','Warzywa@gmail.com','89651123','Yes',1,'8888-1','Zbyszko_Pool');

insert into RetailClient(ClientId, Adress,Email,Telephone,Active,YesNo,Pesel,Name,Surname) values
	(2,'Owocowa','Owocowa@gmail.com','123456789','No',0,'9400001231','Geralt','Z Rivii');	

insert into Product(Name,Price,Descriptionik,Amount) values
	('Eliksir',2,'Dobry jest',2);
	
insert into Orderik(Paid,Statusik,Amount,DataTimik) values
	(0,'Oczekujace','12','2013-05-24');
	
insert into ClientOrder(OrderikId,ClientId,ProductId,Paid,Statusik,Amount,DataTimik,Telefon,Email) values
	(1,2,1,0,'Oczekujace','12','2013-05-24','123456789','Owocowa@gmail.com');	
	
insert into Settingsy(Loginek,Passwordek) values
	('gerolt','rivia');	

