CREATE database a;

CREATE TABLE `Users` (
  `Id` bigint NOT NULL AUTO_INCREMENT, 
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `Dob` date DEFAULT NULL,
  `CurrentSity` varchar(30),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uk_Users_Id` (`Id`)
);

ALTER TABLE Users AUTO_INCREMENT=4294967296;

CREATE TABLE `Products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `Price` double NOT NULL,
  `Status` varchar(30) NOT NULL,
  `MerchantId` int(11) DEFAULT NULL,
  `CreatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uk_Products_Id` (`Id`)
);

ALTER TABLE Products AUTO_INCREMENT=4294967296;

CREATE TABLE `Orders` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(30) NOT NULL,
  `Status` varchar(30) NOT NULL,
  `CreatedAt` varchar(30) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uk_Products_Id` (`Id`)
);

ALTER TABLE Orders AUTO_INCREMENT=4294967296;

CREATE TABLE `OrderedItems` (
	`OrderId` INT NOT NULL AUTO_INCREMENT,
	`ProductId` INT NOT NULL,
	`Quantity` INT NOT NULL,
	PRIMARY KEY (`OrderId`)
);

ALTER TABLE OrderedItems AUTO_INCREMENT=4294967296;

CREATE TABLE `OrdersOrderedItems` (
	`OrderId` INT NOT NULL,
	`OrderedItemId` INT NOT NULL
);

ALTER TABLE OrdersOrderedItems AUTO_INCREMENT=4294967296;


CREATE TABLE `Merchants` (
	`Id` INT NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `Dob` date DEFAULT NULL,
  `CurrentSity` varchar(30),
	PRIMARY KEY (`Id`)
);

ALTER TABLE Merchants AUTO_INCREMENT=4294967296;

CREATE TABLE `Migration` (
	Id INT NOT NULL AUTO_INCREMENT,
  DbVersion INT NOT NULL,
 	PRIMARY KEY (`Id`)
);

INSERT INTO `Migration` (DbVersion) VALUES (1);