/*
Bryan Greener
Assignment 1
*/

# START USING COMPUTER DB
use computer;

# 1
SELECT DISTINCT model, speed, hdisk
FROM computer.PC
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
WHERE speed = 3.20 AND price < 2000.00;

# 6
SELECT DISTINCT maker, speed
FROM Product NATURAL JOIN Laptop
WHERE hdisk >= 30;

# 7
SELECT DISTINCT PC.model, PC.price
FROM computer.Product P, computer.PC
WHERE P.maker='B' AND P.model=PC.model
UNION
SELECT DISTINCT L.model, L.price
FROM computer.Product P, computer.Laptop L
WHERE P.maker='B' AND P.model=L.model
UNION
SELECT DISTINCT PRI.model, PRI.price
FROM computer.Product P, computer.Printer PRI
WHERE P.maker='B' AND P.model=PRI.model;

# 8
SELECT DISTINCT P.maker
FROM computer.Product P NATURAL JOIN computer.Laptop
WHERE P.maker NOT IN (
SELECT DISTINCT maker
FROM computer.Product P NATURAL JOIN computer.PC);

# 9
SELECT DISTINCT PC.hdisk
FROM PC JOIN PC p1
WHERE PC.hdisk=p1.hdisk AND PC.model <> p1.model;

# 10
SELECT DISTINCT p1.model, p2.model
FROM PC p1 JOIN PC p2
WHERE p1.speed=p2.speed AND p1.ram=p2.ram AND p1.model < p2.model;

# 11
SELECT DISTINCT s1.maker
FROM
	((
	SELECT model
	FROM PC P
	WHERE speed >= 3.00
	UNION
	SELECT model
	FROM Laptop L
	WHERE speed >= 3.00
	) T
	NATURAL JOIN product s1,
    (
    SELECT model
    FROM PC P2
    WHERE speed >= 3.00
    UNION
    SELECT model
    from Laptop L2
    WHERE speed >= 3.00
    ) T2
    NATURAL JOIN product s2 )
WHERE s1.maker = s2.maker AND s1.model <> s2.model;

# 12
SELECT DISTINCT maker
FROM PC NATURAL JOIN Product
WHERE PC.speed >= 3.00;

# 13
SELECT model
FROM computer.printer
WHERE price >= ALL( SELECT price FROM computer.printer );

# 14
SELECT model
FROM computer.Laptop
WHERE laptop.speed < ALL ( SELECT speed FROM computer.PC );

# 15
SELECT model
FROM ((
	SELECT model, price
    FROM computer.PC )
    UNION (
    SELECT model, price
    FROM computer.Laptop )
    UNION (
	SELECT model, price
    FROM computer.Printer )) AS t1
WHERE price >= ALL ( SELECT price FROM (
		((
		SELECT model, price
		FROM computer.PC )
		UNION (
		SELECT model, price
		FROM computer.Laptop )
		UNION (
		SELECT model, price
		FROM computer.Printer ))) AS t2);
        
# 16
SELECT maker
FROM computer.product JOIN computer.printer ON product.model = printer.model
WHERE printer.price = ( SELECT MIN(price) FROM printer WHERE color=TRUE ) AND printer.color=TRUE;
    
# 17
SELECT DISTINCT maker
FROM computer.PC JOIN computer.Product ON PC.model = Product.model
WHERE PC.speed =
	( SELECT MAX(speed) FROM computer.PC WHERE PC.ram =
    ( SELECT MIN(ram) FROM computer.PC ));
    
# 18
SELECT AVG(speed)
FROM computer.PC;

# 19
SELECT AVG(speed)
FROM computer.Laptop
WHERE price > 1000.00;

# 20
SELECT AVG(price)
FROM computer.product, computer.pc
WHERE product.model = pc.model AND maker = 'A';

# 21
SELECT AVG(price)
FROM ((
	SELECT price
	FROM computer.product, computer.pc
    WHERE product.model = pc.model AND maker = 'D' )
    UNION (
    SELECT price
    FROM computer.product, computer.laptop
    WHERE product.model = laptop.model AND maker = 'D' )) AS t1;

# 22
SELECT speed, AVG(price)
FROM computer.PC
GROUP BY speed;

# 23
SELECT maker, AVG(screen)
FROM computer.Product JOIN computer.Laptop ON product.model = laptop.model
GROUP BY maker;

# 24
SELECT DISTINCT maker
FROM PC, Product
WHERE pc.model = product.model
GROUP BY product.maker
HAVING COUNT( pc.model ) >= 3;

# 25
SELECT maker, MAX(price)
FROM computer.Product JOIN computer.PC ON product.model = pc.model
GROUP BY maker;

# 26
SELECT AVG(price)
FROM computer.PC
WHERE pc.speed > 2.0;

# 27
SELECT maker, AVG(hdisk)
FROM computer.PC, computer.Product
WHERE PC.model = Product.model AND Product.maker IN (
	SELECT DISTINCT maker
	FROM computer.Product
	WHERE product.type = 'printer' )
GROUP BY product.maker;

# START USING BATTLESHIP DB

use battleship;

# 28












