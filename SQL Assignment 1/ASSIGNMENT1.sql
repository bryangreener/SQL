/*
Bryan Greener
Assignment 1
*/
LOAD DATA LOCAL INFILE 'C:/Users/Bryan/Desktop/SQL Assignment 1/product.txt' INTO TABLE Product 
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\r\n';
LOAD DATA LOCAL INFILE 'C:/Users/Bryan/Desktop/SQL Assignment 1/pcTEMP.txt' INTO TABLE PC
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\r\n';
LOAD DATA LOCAL INFILE 'C:/Users/Bryan/Desktop/SQL Assignment 1/laptop.txt' INTO TABLE Laptop
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\r\n';
LOAD DATA LOCAL INFILE 'C:/Users/Bryan/Desktop/SQL Assignment 1/printer.txt' INTO TABLE Printer
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\r\n';
SELECT *
FROM PC;

# 1
SELECT DISTINCT model, speed, hdisk
FROM PC
WHERE PC.price < '1000.00';

# 2
SELECT DISTINCT maker
FROM Product
WHERE Product.type = 'Printer';
                
# 3
SELECT DISTINCT model, ram, screen
FROM Laptop
WHERE price > '1500.00';

# 4
SELECT DISTINCT *
FROM Printer
WHERE color=true;

# 5
SELECT DISTINCT model, hdisk
FROM PC
WHERE speed > 3.20 AND price < 2000.00;

# 6
SELECT DISTINCT maker, speed
FROM Product NATURAL JOIN Laptop
WHERE hdisk >= 30;

# 7
SELECT DISTINCT PC.model, PC.price
FROM Product P, PC
WHERE P.maker='B' AND P.model=PC.model
UNION
SELECT DISTINCT L.model, L.price
FROM Product P, Laptop L
WHERE P.maker='B' AND P.model=L.model
UNION
SELECT DISTINCT PRI.model, PRI.price
FROM Product P, Printer PRI
WHERE P.maker='B' AND P.model=PRI.model;

# 8
SELECT DISTINCT maker
FROM Product P
WHERE P.type='Laptop' NOT IN (
SELECT DISTINCT maker
FROM Product P
WHERE P.type='PC');

# 9
SELECT DISTINCT hdisk
FROM PC p1
WHERE (
SELECT *
FROM PC p2
WHERE p1.hdisk = p2.hdisk);
