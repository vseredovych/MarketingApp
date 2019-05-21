DROP DATABASE IF EXISTS MarketingApp;
CREATE DATABASE  MarketingApp;
USE MarketingApp;

CREATE TABLE `Users` (
  `Id` bigint NOT NULL AUTO_INCREMENT, 
  `FirstName` varchar(30) NOT NULL,
  `Mail` varchar(30) NOT NULL,
  `Password` varchar(30),
  `Dob` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uk_Merchants_Id` (`Id`)
);

ALTER TABLE Users AUTO_INCREMENT=4294967296;

CREATE TABLE `Products` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `Price` double NOT NULL,
  `Status` varchar(30) NOT NULL,
  `MerchantId` bigint DEFAULT NULL,
  `CreatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uk_Products_Id` (`Id`)
);

ALTER TABLE Products AUTO_INCREMENT=4294967296;

CREATE TABLE `Orders` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` varchar(30) NOT NULL,
  `Status` varchar(30) NOT NULL,
  `CreatedAt` varchar(30) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uk_Products_Id` (`Id`)
);

ALTER TABLE Orders AUTO_INCREMENT=4294967296;

CREATE TABLE `OrderedItems` (
	`OrderId` bigint NOT NULL AUTO_INCREMENT,
	`ProductId` bigint NOT NULL,
	`Quantity` INT NOT NULL,
	PRIMARY KEY (`OrderId`)
);

ALTER TABLE OrderedItems AUTO_INCREMENT=4294967296;

CREATE TABLE `OrdersOrderedItems` (
	`OrderId` bigint NOT NULL,
	`OrderedItemId` bigint NOT NULL
);

ALTER TABLE OrdersOrderedItems AUTO_INCREMENT=4294967296;


CREATE TABLE `Merchants` (
 `Id` bigint NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `Dob` date DEFAULT NULL,
  `CurrentCity` varchar(30),
	PRIMARY KEY (`Id`)
);

ALTER TABLE Merchants AUTO_INCREMENT=4294967296;

CREATE TABLE `DbVersions` (
	Id int NOT NULL AUTO_INCREMENT,
 	PRIMARY KEY (`Id`)
);

INSERT INTO `DbVersions` () VALUES();