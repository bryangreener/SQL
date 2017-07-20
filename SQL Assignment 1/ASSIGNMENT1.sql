/*
Bryan Greener
Assignment 1
*/

SELECT *
FROM computer.PC;

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
SELECT DISTINCT p1.model
FROM computer.Printer p1
WHERE p1.price > ( SELECT DISTINCT price FROM computer.Printer );




















