# add indexes update
INSERT INTO `DbVersions` () VALUES();

# SELECT * FROM Users WHERE Gmail = 'mail';
CREATE UNIQUE INDEX Gmail ON Users(Gmail);

# explain select * from Merchants where salary > 10 and salary < 10000;
CREATE INDEX MerchantsSalary ON Merchants(Salary);

# SELECT * FROM Products WHERE Status = 'active' ORDER BY Price
CREATE INDEX status_price ON Products(Status, Price);


window_function_name(expression) 
    OVER (
        [partition_defintion]
        [order_definition]
        [frame_definition]
    )