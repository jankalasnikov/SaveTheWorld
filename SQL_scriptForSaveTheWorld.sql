

/*DROP ALL TABLES*/

DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
GO


/*IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'saveTheWorld')
    CREATE DATABASE saveTheWorld

GO

USE saveTheWorld;
*/
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='bankAccount' and xtype='U')
	CREATE TABLE bankAccount (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
		accountNo INT NOT NULL,
		expiryDate DATE NOT NULL,
		ccv int NOT NULL,
		amount float NOT NULL,
		address varchar(150) NOT NULL,
		
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' and xtype='U')
    CREATE TABLE users (
		id INT PRIMARY KEY IDENTITY(1,1) not null,
        email varchar (200) not null unique,
		name varchar(75) not null,
		password varchar(400) not null,
		typeOfUser int not null,
		address VARCHAR(200) NOT NULL,
		city VARCHAR(30) NOT NULL,
		phoneno VARCHAR(15) NOT NULL,
		accountId int FOREIGN KEY REFERENCES bankAccount(id),
		
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='product' and xtype='U')
	CREATE TABLE product (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		productName VARCHAR(100) NOT NULL UNIQUE,
		price FLOAT NOT NULL,
		description VARCHAR(5000) NOT NULL,
		minStock INT NOT NULL, 
		
	)
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='invoice' and xtype='U')
	CREATE TABLE invoice (
		id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
		invoiceNo INT NOT NULL,
		paymentDate Date NOT NULL,
		amount float NOT NULL,
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='orderLine' and xtype='U')
	CREATE TABLE orderLine (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		productId int FOREIGN KEY REFERENCES product(id),
	    quantity float NOT NULL,

	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbOrder' and xtype='U')
	CREATE TABLE tbOrder (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		userId int FOREIGN KEY REFERENCES users(id),
		date DATE NOT NULL,
    	orderLineId int FOREIGN KEY REFERENCES orderLine(id),
		
	)

GO



IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='category' and xtype='U')
	CREATE TABLE category (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	    nameOfCategory varchar(50) NOT NULL,
		
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='disaster' and xtype='U')
	CREATE TABLE disaster (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
		disasterName VARCHAR(50) NOT NULL, 
		description VARCHAR(5000) NOT NULL, 
		region varchar(100) NOT NULL,
		categoryId int FOREIGN KEY REFERENCES category(id),
		priority int NOT NULL,
		victims int NOT NULL,
		accountId int FOREIGN KEY REFERENCES bankAccount(id),
	)

GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='typeOfSubscription' and xtype='U')
	CREATE TABLE typeOfSubscription (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		name varchar(50) NOT NULL,
	    periodOfTimeInDays int NOT NULL,
		
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='subscription' and xtype='U')
	CREATE TABLE subscription (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		typeOfSubscriptionId int FOREIGN KEY REFERENCES typeOfSubscription(id),
		amount float NOT NULL,
	    startDate Date NOT NULL,
		
	)

GO


/*
insert into store(storeName, address) values ('store1','address1');
insert into store(storeName, address) values ('store2','address2');
insert into store(storeName, address) values ('store3','address3');
insert into store(storeName, address) values ('store4','address4');
insert into store(storeName, address) values ('store5','address5');
insert into store(storeName, address) values ('store6','address6');


insert into users(username,name, password, typeOfUser) values (001,'Yordan','$2a$12$9GrLfe8kUqSl2yrvN3IBPO9NTx6je90B1OLPBISOnRXlpmeMN411q', 1);
insert into users(username,name, password, typeOfUser) values (002,'Lyudmil','$2a$12$9GrLfe8kUqSl2yrvN3IBPO9NTx6je90B1OLPBISOnRXlpmeMN411q', 1);
insert into users(username,name, password, typeOfUser) values (003,'Jan','$2a$12$9GrLfe8kUqSl2yrvN3IBPO9NTx6je90B1OLPBISOnRXlpmeMN411q', 2);
insert into users(username,name, password, typeOfUser) values (004,'Henrique','$2a$12$9GrLfe8kUqSl2yrvN3IBPO9NTx6je90B1OLPBISOnRXlpmeMN411q', 2);
insert into users(username,name, password, typeOfUser) values (005,'Valentin','$2a$12$9GrLfe8kUqSl2yrvN3IBPO9NTx6je90B1OLPBISOnRXlpmeMN411q', 2);


insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (30.00,'Pork', 50.00,'BulgarianMafia','Sausage');
insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (20.00,'Chicken', 60.00,'MafiaOfVarna','Chilli Sausage');
insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (20.00,'Chicken', 60.00,'LotOfBalls','Meatball');
insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (40.00,'Beef', 30.00,'LotOfMeat','Steak');
insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (40.00,'Beef', 30.00,'WeHaveMeat','Ground Meat');
insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (30.00,'Pork', 70.00,'GiveMeMeat','Pork Meatball');
insert into product(price, typeOfMeat, minStock, nameOfSupplier, name) values (30.00,'Lamb', 70.00,'BeatMyMeat','Lamb Sausage');

insert into customer(name, street, numberOnStreet, city, phoneno) values ('Petyr Borisov','ul. Vasil Levski','10','Varna','+35900123456');
insert into customer(name, street, numberOnStreet, city, phoneno) values ('Boyko Borissov','ul. Tsar Osvoboditel','13','Varna','+35900567488');
insert into customer(name, street, numberOnStreet, city, phoneno) values ('Hristo Stoichkov','ul. Doyran','22','Varna','+359654098');
insert into customer(name, street, numberOnStreet, city, phoneno) values ('Blagoy Makendzhiev','ul. Makedonia','13','Varna','+359999234651');
insert into customer(name, street, numberOnStreet, city, phoneno) values ('Nikolay Dimitrov','ul. Drin','19','Varna','+3595323963');
insert into customer(name, street, numberOnStreet, city, phoneno) values ('Svetoslav Kovachev','ul. Baba Tonka','2','Varna','+359123456789');
insert into customer(name, street, numberOnStreet, city, phoneno) values ('Martin Raynov','ul. Nikola Kanev','9','Varna','+359765321009');
*/