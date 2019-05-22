# References update
INSERT INTO `DbVersions` () VALUES();

# Add references
ALTER TABLE Products
ADD FOREIGN KEY (MerchantId) REFERENCES Merchants(Id);