
/*USE dmaj0918_1074278;*/
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
    CREATE DATABASE  saveTheWorld

GO
*/

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='bankAccount' and xtype='U')
	CREATE TABLE bankAccount (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
		accountNo INT NOT NULL,
		expiryDate DATE NOT NULL,
		ccv int NOT NULL,
		amount decimal(38,2) NOT NULL,
	    rowVersion timestamp NOT NULL,
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='auser' and xtype='U')
    CREATE TABLE auser (
		id INT PRIMARY KEY IDENTITY(1,1),
		name varchar(75) not null,
		password varchar(400) not null,
		salt varchar(15) NOT NULL,
		typeOfUser int not null,
		email varchar (200) not null unique,
		address VARCHAR(200) NOT NULL,
		phoneno VARCHAR(15) NOT NULL,
		accountId int FOREIGN KEY REFERENCES bankAccount(id),
		rowVersion timestamp NOT NULL,
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbOrder' and xtype='U')
	CREATE TABLE tbOrder (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		userId int FOREIGN KEY REFERENCES auser(id),
		date DATE NOT NULL,
		   
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='propertyValues' and xtype='U')
	CREATE TABLE propertyValues (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	    value varchar(50) NOT NULL,
	
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='property' and xtype='U')
	CREATE TABLE property (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		name varchar(50) NOT NULL,
		sortOrder int NOT NULL,
		propertyValuesId int FOREIGN KEY REFERENCES propertyValues(id),
	)

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='product' and xtype='U')
	CREATE TABLE product (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		productName VARCHAR(100) NOT NULL,
		price decimal(38,2) NOT NULL,
		description VARCHAR(5000) NOT NULL,
		minStock INT NOT NULL, 
		rowVersion timestamp NOT NULL,
	)
GO




IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='orderLine' and xtype='U')
	CREATE TABLE orderLine (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		productId int FOREIGN KEY REFERENCES product(id),
	    quantity int NOT NULL,
	    orderId int FOREIGN KEY REFERENCES tbOrder(id),
		price decimal(38,2) NOT NULL,
	)

GO




IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='invoice' and xtype='U')
	CREATE TABLE invoice (
		id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
		invoiceNo INT NOT NULL,
		paymentDate Date NOT NULL,
		amount float NOT NULL,
		orderId int FOREIGN KEY REFERENCES tbOrder(id),
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
		rowVersion timestamp NOT NULL,
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
		amount decimal NOT NULL,
	    startDate Date NOT NULL,
		userID int FOREIGN KEY REFERENCES auser(id),
	)

GO



IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='productPropertyValues' and xtype='U')
	CREATE TABLE productPropertyValues (
		id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		propertyValuesId int FOREIGN KEY REFERENCES propertyValues(id),
		productId int FOREIGN KEY REFERENCES product(id),
	)

GO




insert into tbOrder(userId, date) values (null,'2019-02-20');


--Bank accounts that will be used for users
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (1,'2019-02-20', 123, '501.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (2,'2019-02-20', 123, '20.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (3,'2019-02-20', 123, '503.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (4,'2019-02-20', 123, '504.00');


--Bank accounts that will be used for disasters
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (5,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (6,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (7,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (8,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (9,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (10,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (11,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (12,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (13,'2019-02-20', 123, '0.00');
insert into bankAccount(accountNo,expiryDate, ccv, amount) values (14,'2019-02-20', 123, '0.00');


insert into auser(name, password, salt, typeOfUser, email, address, phoneno, accountId) values ('Ivan','81cd38eaa18fb4a41d5b179f584ffbfe81bbe5c5a9733d4390e3915b33c651f4','JcEdZMgy0V', 2, 'email1@as.dk', 'Somewhere 1', 121231, 1);
insert into auser(name, password, salt, typeOfUser, email, address, phoneno, accountId) values ('Valentin','087a3a6b86894c0293d646488e6bde33c998238cf18d2704fe7b1eed5dd55f64', 'r5az7oFpjY', 2, 'email2@as.dk', 'Somewhere 2', 08956441, 2);
insert into auser(name, password, salt, typeOfUser, email, address, phoneno, accountId) values ('Denis','d0ba9735945f8e4fee281b8a6517ba9e1bbfed2057ba223349e6c1da4daf64f0', 'zB8gSE079m', 1, 'email3@as.dk', 'Somewhere 3', 654546, 3);
insert into auser(name, password, salt, typeOfUser, email, address, phoneno, accountId) values ('Jan','81cd38eaa18fb4a41d5b179f584ffbfe81bbe5c5a9733d4390e3915b33c651f4','JcEdZMgy0V', 1, 'email4@as.dk', 'Somewhere 4', 121231, 1);
insert into auser(name, password, salt, typeOfUser, email, address, phoneno, accountId) values ('Henrik','087a3a6b86894c0293d646488e6bde33c998238cf18d2704fe7b1eed5dd55f64', 'r5az7oFpjY', 1, 'email5@as.dk', 'Somewhere 5', 08956441, 2);
insert into auser(name, password, salt, typeOfUser, email, address, phoneno, accountId) values ('Yordan','d0ba9735945f8e4fee281b8a6517ba9e1bbfed2057ba223349e6c1da4daf64f0', 'zB8gSE079m', 1, 'email6@as.dk', 'Somewhere 6', 654546, 3);

insert into product(productName, price, description, minStock) values ('Shirt1','5.20','red cool shirt',10);
insert into product(productName, price, description, minStock) values ('Shirt2','20.20','blue cool shirt',10);
insert into product(productName, price, description, minStock) values ('Shirt3','10.50','green cool shirt',10);
insert into product(productName, price, description, minStock) values ('Shirt4','35.11','black cool shirt',10);
insert into product(productName, price, description, minStock) values ('Shirt5','2.58','white cool shirt',10);


insert into category(nameOfCategory) values('Fire');
insert into category(nameOfCategory) values('Flood');
insert into category(nameOfCategory) values('Earthquake');
insert into category(nameOfCategory) values('Tornadoes');

insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Amazon fire','Very bad fire', 'Amazonka', 1, 1, 10,5);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Italy Eartquake','Very bad situation at the moment', 'Verona', 3, 2, 15,6);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Venezia flood','A lot of water on san marco', 'Venezia', 2, 1, 0,7);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Usa tornadoes', 'the wind is crazy', 'Usa', 4, 4, 5,8);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Storm', 'the wind is crazy', 'Usa', 4, 4, 5,9);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Big Fire in Cambodja',' fire', 'Amazonka', 1, 1, 10,10);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Italy Eartquake2','Very bad situation at the moment', 'Verona', 3, 2, 15,11);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Venezia flood2','A lot of water on san marco', 'Venezia', 2, 1, 0,12);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Usa tornadoes2', 'the wind is crazy', 'Usa', 4, 4, 5,13);
insert into disaster(disasterName, description, region, categoryId, priority, victims, accountId) values ('Storm2', 'the wind is crazy', 'Usa', 4, 4, 5,14);

insert into typeOfSubscription(name, periodOfTimeInDays) values ('One month', 30);
insert into typeOfSubscription(name, periodOfTimeInDays) values ('Three month', 90);
insert into typeOfSubscription(name, periodOfTimeInDays) values ('Six month', 180);
insert into typeOfSubscription(name, periodOfTimeInDays) values ('One year', 365);
