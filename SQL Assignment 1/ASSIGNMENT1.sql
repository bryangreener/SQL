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
FROM computer.PC, computer.Product
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
SELECT DISTINCT class, country
FROM battleship.classes
WHERE classes.guns >= 10;

# 29
SELECT DISTINCT name AS shipName
FROM battleship.ships
WHERE launched < 1918;

# 30
SELECT ship, battle
FROM battleship.outcomes
WHERE result = 'sunk';

# 31
SELECT name
FROM battleship.ships
WHERE ships.name = ships.class;

# 32
SELECT name
FROM battleship.ships
WHERE ships.name LIKE 'R%' OR ships.name LIKE 'r%';

# 33
SELECT ship
FROM battleship.outcomes
WHERE outcomes.ship LIKE '% % %';

# 34
SELECT name
FROM battleship.classes JOIN battleship.ships ON classes.class = ships.class
WHERE displacement >= 35000;

# 35
SELECT ships.name, displacement, guns
FROM battleship.classes, battleship.ships, battleship.outcomes
WHERE outcomes.battle = 'Guadalcanal' 
AND ships.name = outcomes.ship 
AND classes.class = ships.class;

# 36
SELECT DISTINCT b1.country
FROM battleship.classes b1, (
	SELECT type, country
	FROM battleship.classes
    WHERE type = 'bc' ) AS b2
WHERE b1.country = b2.country AND b1.type <> b2.type;

# 37
SELECT DISTINCT b1.ship
FROM battleship.outcomes b1, (
	SELECT ship, battle
    FROM battleship.outcomes ) AS b2
WHERE b1.ship = b2.ship AND b1.battle <> b2.battle AND b1.result = 'damaged';

# 38
SELECT battle
FROM battleship.classes, battleship.outcomes, battleship.ships
WHERE ships.name = outcomes.ship
AND classes.class = ships.class
HAVING COUNT( outcomes.battle ) >= 3;

# 39
SELECT DISTINCT country
FROM battleship.classes t1, (
	SELECT MAX(guns) AS guns
    FROM battleship.classes ) t2
WHERE t2.guns = t1.guns;
    
# 40
SELECT classes.class
FROM battleship.classes, battleship.outcomes, battleship.ships
WHERE ships.name = outcomes.ship
AND classes.class = ships.class
AND EXISTS( SELECT ship FROM battleship.outcomes WHERE result = 'sunk' );

# 41
SELECT ships.name
FROM battleship.classes, battleship.ships
WHERE classes.class = ships.class
AND classes.bore = 16;

# 42
SELECT outcomes.battle
FROM battleship.outcomes, battleship.ships
WHERE ships.name = outcomes.ship
AND ships.class = 'Kongo';

# 43
SELECT DISTINCT s1.name
FROM battleship.classes c1, battleship.ships s1
WHERE c1.class = s1.class
AND c1.guns >= ALL(
	SELECT guns
    FROM battleship.classes c2, battleship.ships s2
    WHERE c2.class = s2.class AND c1.bore = c2.bore );
 
# 44
SELECT COUNT(classes.type)
FROM battleship.classes
WHERE classes.type = 'bb';

# 45
SELECT AVG(guns)
FROM battleship.classes
WHERE classes.type = 'bb';

# 46
SELECT AVG(guns)
FROM battleship.classes, battleship.ships
WHERE ships.class = classes.class AND type = 'bb';

# 47
SELECT DISTINCT t1.class, t1.launched
FROM battleship.ships t1
WHERE t1.launched <= ALL(
	SELECT launched
    FROM battleship.ships t2
    WHERE t2.class = t1.class );

# 48
SELECT DISTINCT class, COUNT(outcomes.result)
FROM battleship.ships, battleship.outcomes
WHERE ships.name = outcomes.ship
AND outcomes.result = 'sunk';

# 49
SELECT DISTINCT class, COUNT(outcomes.result)
FROM battleship.ships, battleship.outcomes
WHERE ships.name = outcomes.ship
AND ( SELECT COUNT(ships.class) FROM battleship.ships ) >= 3
AND outcomes.result = 'sunk';

# 50
SELECT country, AVG(( bore * bore * bore )/ 2 ) AS AvgShellWeight
FROM battleship.classes
GROUP BY classes.country;






























