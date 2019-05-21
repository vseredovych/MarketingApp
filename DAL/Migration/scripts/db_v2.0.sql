INSERT INTO `DbVersions` () VALUES();


ALTER TABLE Products
ADD FOREIGN KEY (MerchantId) REFERENCES Merchants(Id);