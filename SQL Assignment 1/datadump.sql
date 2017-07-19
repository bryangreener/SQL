-- MySQL dump 10.13  Distrib 5.7.13, for Linux (x86_64)
--
-- Host: localhost    Database: computer
-- ------------------------------------------------------
-- Server version	5.7.13-0ubuntu0.16.04.2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `computer`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `computer` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `computer`;

--
-- Table structure for table `laptop`
--

DROP TABLE IF EXISTS `laptop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `laptop` (
  `model` char(10) NOT NULL,
  `speed` decimal(5,2) DEFAULT NULL,
  `ram` int(11) DEFAULT NULL,
  `hdisk` int(11) DEFAULT NULL,
  `screen` decimal(5,2) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`model`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `laptop`
--

LOCK TABLES `laptop` WRITE;
/*!40000 ALTER TABLE `laptop` DISABLE KEYS */;
INSERT INTO `laptop` VALUES ('2001',2.00,2048,240,20.10,3673.00),('2002',1.73,1024,80,17.00,949.00),('2003',1.80,512,60,15.40,549.00),('2004',2.00,512,60,13.30,1150.00),('2005',2.16,1024,120,17.00,2500.00),('2006',2.00,2048,80,15.40,1700.00),('2007',1.83,1024,120,13.30,1429.00),('2008',1.60,1024,100,15.40,900.00),('2009',1.60,512,80,14.10,680.00),('2010',2.00,2048,160,15.40,2300.00);
/*!40000 ALTER TABLE `laptop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pc`
--

DROP TABLE IF EXISTS `pc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pc` (
  `model` char(10) NOT NULL,
  `speed` decimal(5,2) DEFAULT NULL,
  `ram` int(11) DEFAULT NULL,
  `hdisk` int(11) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`model`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pc`
--

LOCK TABLES `pc` WRITE;
/*!40000 ALTER TABLE `pc` DISABLE KEYS */;
INSERT INTO `pc` VALUES ('1001',2.66,1024,250,2114.00),('1002',2.10,512,250,995.00),('1003',1.42,512,80,478.00),('1004',2.80,1024,250,649.00),('1005',3.20,512,250,630.00),('1006',3.20,1024,320,1049.00),('1007',2.20,1024,200,510.00),('1008',2.20,2048,250,770.00),('1009',2.00,1024,250,650.00),('1010',2.80,2048,300,770.00),('1011',1.86,2048,160,959.00),('1012',2.80,1024,160,649.00),('1013',3.06,512,80,529.00);
/*!40000 ALTER TABLE `pc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `printer`
--

DROP TABLE IF EXISTS `printer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `printer` (
  `model` char(10) NOT NULL,
  `color` tinyint(1) DEFAULT NULL,
  `type` char(10) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`model`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `printer`
--

LOCK TABLES `printer` WRITE;
/*!40000 ALTER TABLE `printer` DISABLE KEYS */;
INSERT INTO `printer` VALUES ('3001',1,'ink-jet',99.00),('3002',0,'laser',239.00),('3003',1,'laser',899.00),('3004',1,'ink-jet',120.00),('3005',0,'laser',120.00),('3006',1,'ink-jet',100.00),('3007',1,'laser',200.00);
/*!40000 ALTER TABLE `printer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `maker` char(10) NOT NULL,
  `model` char(10) NOT NULL,
  `type` char(10) DEFAULT NULL,
  PRIMARY KEY (`maker`,`model`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('A','1001','pc'),('A','1002','pc'),('A','1003','pc'),('A','2004','laptop'),('A','2005','laptop'),('A','2006','laptop'),('B','1004','pc'),('B','1005','pc'),('B','1006','pc'),('B','2007','laptop'),('C','1007','pc'),('D','1008','pc'),('D','1009','pc'),('D','1010','pc'),('D','3004','printer'),('D','3005','printer'),('E','1011','pc'),('E','1012','pc'),('E','1013','pc'),('E','2001','laptop'),('E','2002','laptop'),('E','2003','laptop'),('E','3001','printer'),('E','3002','printer'),('E','3003','printer'),('F','2008','laptop'),('F','2009','laptop'),('G','2010','laptop'),('H','3006','printer'),('H','3007','printer');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `battleship`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `battleship` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `battleship`;

--
-- Table structure for table `battles`
--

DROP TABLE IF EXISTS `battles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `battles` (
  `name` varchar(20) NOT NULL,
  `bdate` date DEFAULT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `battles`
--

LOCK TABLES `battles` WRITE;
/*!40000 ALTER TABLE `battles` DISABLE KEYS */;
INSERT INTO `battles` VALUES ('Denmark Strait','1941-05-24'),('Guadalcanal','1942-11-15'),('North Cape','1943-12-26'),('Surigao Strait','1944-10-25');
/*!40000 ALTER TABLE `battles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classes` (
  `class` varchar(20) NOT NULL,
  `type` varchar(20) DEFAULT NULL,
  `country` varchar(20) DEFAULT NULL,
  `guns` int(11) DEFAULT NULL,
  `bore` int(11) DEFAULT NULL,
  `displacement` int(11) DEFAULT NULL,
  PRIMARY KEY (`class`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES ('Bismarck','bb','Germany',8,15,42000),('Iowa','bb','USA',9,16,46000),('Kongo','bc','Japan',8,14,32000),('North Carolina','bb','USA',9,16,37000),('Renown','bc','Gt. Britain',6,15,32000),('Revenge','bb','Gt. Britain',8,15,29000),('Tennessee','bb','USA',12,14,32000),('Yamato','bb','Japan',9,18,65000);
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `outcomes`
--

DROP TABLE IF EXISTS `outcomes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `outcomes` (
  `ship` varchar(20) NOT NULL,
  `battle` varchar(20) NOT NULL,
  `result` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ship`,`battle`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `outcomes`
--

LOCK TABLES `outcomes` WRITE;
/*!40000 ALTER TABLE `outcomes` DISABLE KEYS */;
INSERT INTO `outcomes` VALUES ('Arizona','Pearl Harbor','sunk'),('Bismarck','Denmark Strait','sunk'),('California','Surigao Strait','ok'),('Duke of York','North Cape','ok'),('Fuso','Surigao Strait','sunk'),('Hood','Denmark Strait','sunk'),('King George V','Denmark Strait','ok'),('Kirishima','Guadalcanal','sunk'),('Prince of Wales','Denmark Strait','damaged'),('Rodney','Denmark Strait','ok'),('Scharnhorst','North Cape','sunk'),('South Dakota','Guadalcanal','damaged'),('Tennessee','Surigao Strait','ok'),('Washington','Guadalcanal','ok'),('West Virginia','Surigao Strait','ok'),('Yamashiro','Surigao Strait','sunk');
/*!40000 ALTER TABLE `outcomes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ships`
--

DROP TABLE IF EXISTS `ships`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ships` (
  `name` varchar(20) NOT NULL,
  `class` varchar(20) DEFAULT NULL,
  `launched` decimal(4,0) DEFAULT NULL,
  PRIMARY KEY (`name`),
  KEY `class` (`class`),
  CONSTRAINT `ships_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`class`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ships`
--

LOCK TABLES `ships` WRITE;
/*!40000 ALTER TABLE `ships` DISABLE KEYS */;
INSERT INTO `ships` VALUES ('California','Tennessee',1921),('Haruna','Kongo',1915),('Hiei','Kongo',1914),('Iowa','Iowa',1943),('Kirishima','Kongo',1915),('Kongo','Kongo',1913),('Missouri','Iowa',1944),('Musashi','Yamato',1942),('New Jersey','Iowa',1943),('North Carolina','North Carolina',1941),('Ramillies','Revenge',1917),('Renown','Renown',1916),('Repulse','Renown',1916),('Resolution','Revenge',1916),('Revenge','Revenge',1916),('Royal Oak','Revenge',1916),('Royal Sovereign','Revenge',1916),('Tennessee','Tennessee',1920),('Washington','North Carolina',1941),('Wisconsin','Iowa',1944),('Yamato','Yamato',1941);
/*!40000 ALTER TABLE `ships` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `catalog`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `catalog` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `catalog`;

--
-- Table structure for table `catalog`
--

DROP TABLE IF EXISTS `catalog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `catalog` (
  `sid` decimal(9,0) NOT NULL,
  `pid` decimal(9,0) NOT NULL,
  `cost` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`sid`,`pid`),
  KEY `pid` (`pid`),
  CONSTRAINT `catalog_ibfk_1` FOREIGN KEY (`sid`) REFERENCES `suppliers` (`sid`),
  CONSTRAINT `catalog_ibfk_2` FOREIGN KEY (`pid`) REFERENCES `parts` (`pid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catalog`
--

LOCK TABLES `catalog` WRITE;
/*!40000 ALTER TABLE `catalog` DISABLE KEYS */;
INSERT INTO `catalog` VALUES (1,3,0.50),(1,4,0.50),(1,8,11.70),(2,1,16.50),(2,3,0.55),(2,8,7.95),(3,8,12.50),(3,9,1.00),(4,5,2.20),(4,6,1247548.23),(4,7,1247548.23);
/*!40000 ALTER TABLE `catalog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parts`
--

DROP TABLE IF EXISTS `parts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parts` (
  `pid` decimal(9,0) NOT NULL,
  `pname` varchar(40) DEFAULT NULL,
  `color` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`pid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parts`
--

LOCK TABLES `parts` WRITE;
/*!40000 ALTER TABLE `parts` DISABLE KEYS */;
INSERT INTO `parts` VALUES (1,'Left Handed Bacon Stretcher Cover','Red'),(2,'Smoke Shifter End','Black'),(3,'Acme Widget Washer','Red'),(4,'Acme Widget Washer','Silver'),(5,'I Brake for Crop Circles Sticker','Translucent'),(6,'Anti-Gravity Turbine Generator','Cyan'),(7,'Anti-Gravity Turbine Generator','Magenta'),(8,'Fire Hydrant Cap','Red'),(9,'7 Segment Display','Green');
/*!40000 ALTER TABLE `parts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suppliers` (
  `sid` decimal(9,0) NOT NULL,
  `sname` varchar(30) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`sid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Acme Widget Suppliers','1 Grub St., Potemkin Village, IL 61801'),(2,'Big Red Tool and Die','4 My Way, Bermuda Shorts, OR 90305'),(3,'Perfunctory Parts','99999 Short Pier, Terra Del Fuego, TX 41299'),(4,'Alien Aircaft Inc.','2 Groom Lake, Rachel, NV 51902');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `company`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `company` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `company`;

--
-- Table structure for table `dept`
--

DROP TABLE IF EXISTS `dept`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dept` (
  `did` decimal(2,0) NOT NULL,
  `dname` varchar(20) DEFAULT NULL,
  `budget` decimal(10,2) DEFAULT NULL,
  `managerid` decimal(9,0) DEFAULT NULL,
  PRIMARY KEY (`did`),
  KEY `managerid` (`managerid`),
  CONSTRAINT `dept_ibfk_1` FOREIGN KEY (`managerid`) REFERENCES `emp` (`eid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dept`
--

LOCK TABLES `dept` WRITE;
/*!40000 ALTER TABLE `dept` DISABLE KEYS */;
INSERT INTO `dept` VALUES (1,'Hardware',1048572.12,141582651),(2,'Operations',12099101.00,287321212),(3,'Legal',222988.13,248965255),(4,'Marketing',538099.54,548977562),(5,'Software',400011.12,141582651),(6,'Production',12099101.00,578875478),(7,'Shipping',5.00,489456522);
/*!40000 ALTER TABLE `dept` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emp`
--

DROP TABLE IF EXISTS `emp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `emp` (
  `eid` decimal(9,0) NOT NULL,
  `ename` varchar(30) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `salary` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`eid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emp`
--

LOCK TABLES `emp` WRITE;
/*!40000 ALTER TABLE `emp` DISABLE KEYS */;
INSERT INTO `emp` VALUES (11564812,'John Williams',35,74098.00),(15487874,'Gene Edwards',51,41008.00),(15645489,'Daniel Evans',25,40312.00),(51135593,'Maria White',22,24998.00),(54879887,'Dorthy Lewis',33,41008.00),(60839453,'Charles Harris',24,24998.00),(74454898,'Scott Bell',23,70100.00),(90873519,'Elizabeth Taylor',27,33055.00),(98784544,'Eric Collins',23,41008.00),(112348546,'Joseph Thompson',26,24998.00),(115987938,'Christopher Garcia',60,24998.00),(128778823,'William Ward',33,24998.00),(132977562,'Angela Martinez',31,24998.00),(141582651,'Mary Johnson',44,94011.00),(141582657,'Stanley Browne',23,14093.00),(142519864,'Susan Martin',39,56990.00),(156465461,'Eric Cooper',26,24998.00),(156489494,'Gil Richardson',32,70100.00),(159542516,'Matt Nelson',33,48990.00),(178949844,'Chad Stewart',29,24998.00),(179887498,'Dorthy Howard',28,40312.00),(242518965,'James Smith',68,27099.00),(248965255,'Barbara Wilson',48,95021.00),(254099823,'Patricia Jones',28,42783.00),(254898318,'Gim Rogers',25,32175.00),(267894232,'Paul Hall',25,24998.00),(269734834,'Rick Carter',38,24998.00),(274878974,'Harry Watson',30,24998.00),(280158572,'Margaret Clark',40,24998.00),(287321212,'Michael Miller',62,131072.00),(289562686,'Thomas Robinson',34,32175.00),(291795563,'Haywood Kelly',36,32175.00),(298489484,'Lisa Gray',31,24998.00),(301221823,'Juan Rodriguez',30,32175.00),(310454876,'Milo Brooks',22,39910.00),(318548912,'Ann Mitchell',23,32175.00),(320874981,'Daniel Lee',23,32175.00),(322654189,'Lisa Walker',38,32175.00),(334568786,'William Moore',32,32175.00),(348121549,'Trey Phillips',69,32175.00),(351565322,'Nancy Allen',30,39910.00),(355548984,'Tom Murphy',41,32175.00),(356187925,'Robert Brown',28,35431.00),(390487451,'Mark Coleman',42,39910.00),(451519864,'Mark Young',34,39910.00),(454565232,'Louis Jenkins',20,39910.00),(455798411,'Luis Hernandez',44,39910.00),(486512566,'David Anderson',20,25199.00),(489221823,'Richard Jackson',33,32996.00),(489456522,'Linda Davis',26,25971.00),(548977562,'Donald King',43,92048.00),(550156548,'George Wright',42,41008.00),(552455318,'Ana Lopez',35,41008.00),(556784565,'Kenneth Hill',81,41008.00),(567354612,'Karen Scott',70,39910.00),(573284895,'Steven Green',29,39910.00),(574489456,'Betty Adams',39,39910.00),(578875478,'Edward Baker',50,101071.00),(619023588,'Jennifer Thomas',24,34654.00);
/*!40000 ALTER TABLE `emp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `works`
--

DROP TABLE IF EXISTS `works`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `works` (
  `eid` decimal(9,0) NOT NULL,
  `did` decimal(2,0) NOT NULL,
  `pct_time` decimal(3,0) DEFAULT NULL,
  PRIMARY KEY (`eid`,`did`),
  KEY `did` (`did`),
  CONSTRAINT `works_ibfk_1` FOREIGN KEY (`eid`) REFERENCES `emp` (`eid`),
  CONSTRAINT `works_ibfk_2` FOREIGN KEY (`did`) REFERENCES `dept` (`did`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `works`
--

LOCK TABLES `works` WRITE;
/*!40000 ALTER TABLE `works` DISABLE KEYS */;
INSERT INTO `works` VALUES (11564812,3,100),(15487874,6,100),(15645489,6,100),(51135593,2,100),(54879887,6,100),(60839453,2,100),(74454898,6,100),(90873519,2,100),(98784544,6,100),(112348546,2,100),(115987938,2,100),(128778823,6,100),(132977562,2,100),(141582651,1,50),(141582651,5,50),(141582657,1,25),(141582657,5,75),(142519864,2,100),(156465461,6,100),(156489494,6,100),(159542516,4,100),(178949844,6,100),(179887498,6,100),(242518965,1,100),(248965255,3,100),(254099823,3,100),(254898318,6,100),(267894232,6,100),(269734834,2,100),(274878974,6,100),(280158572,2,100),(287321212,2,100),(289562686,6,100),(291795563,6,100),(298489484,6,100),(301221823,2,100),(310454876,6,100),(318548912,2,100),(320874981,2,100),(322654189,2,100),(334568786,6,100),(348121549,2,100),(351565322,2,100),(355548984,6,100),(356187925,2,100),(390487451,6,100),(451519864,2,100),(454565232,6,50),(455798411,2,100),(486512566,4,100),(489221823,2,100),(489456522,7,100),(548977562,4,100),(550156548,2,50),(552455318,2,25),(556784565,2,25),(567354612,2,75),(573284895,2,50),(574489456,2,50),(578875478,6,100),(619023588,1,100);
/*!40000 ALTER TABLE `works` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `university`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `university` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `university`;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `cname` varchar(40) NOT NULL,
  `meets_at` varchar(20) DEFAULT NULL,
  `room` varchar(10) DEFAULT NULL,
  `fid` decimal(9,0) DEFAULT NULL,
  PRIMARY KEY (`cname`),
  KEY `fid` (`fid`),
  CONSTRAINT `class_ibfk_1` FOREIGN KEY (`fid`) REFERENCES `faculty` (`fid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES ('Air Quality Engineering','TuTh 10:30-11:45','R15',11564812),('American Political Parties','TuTh 2-3:15','20 AVW',619023588),('Archaeology of the Incas','MWF 3-4:15','R128',248965255),('Aviation Accident Investigation','TuTh 1-2:50','Q3',11564812),('Communication Networks','MW 9:30-10:45','20 AVW',141582651),('Dairy Herd Management','TuTh 12:30-1:45','R128',356187925),('Data Structures','MWF 10','R128',489456522),('Database Systems','MWF 12:30-1:45','1320 DCL',142519864),('Intoduction to Math','TuTh 8-9:30','R128',489221823),('Introductory Latin','MWF 3-4:15','R12',248965255),('Marketing Research','MW 10-11:15','1320 DCL',489221823),('Multivariate Analysis','TuTh 2-3:15','R15',90873519),('Operating System Design','TuTh 12-1:20','20 AVW',489456522),('Optical Electronics','TuTh 12:30-1:45','R15',254099823),('Orbital Mechanics','MWF 8','1320 DCL',11564812),('Organic Chemistry','TuTh 12:30-1:45','R12',489221823),('Patent Law','F 1-2:50','R128',90873519),('Perception','MTuWTh 3','Q3',489221823),('Seminar in American Art','M 4','R15',489221823),('Social Cognition','Tu 6:30-8:40','R15',159542516),('Urban Economics','MWF 11','20 AVW',489221823);
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrolled`
--

DROP TABLE IF EXISTS `enrolled`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enrolled` (
  `snum` decimal(9,0) NOT NULL,
  `cname` varchar(40) NOT NULL,
  PRIMARY KEY (`snum`,`cname`),
  KEY `cname` (`cname`),
  CONSTRAINT `enrolled_ibfk_1` FOREIGN KEY (`snum`) REFERENCES `student` (`snum`),
  CONSTRAINT `enrolled_ibfk_2` FOREIGN KEY (`cname`) REFERENCES `class` (`cname`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrolled`
--

LOCK TABLES `enrolled` WRITE;
/*!40000 ALTER TABLE `enrolled` DISABLE KEYS */;
INSERT INTO `enrolled` VALUES (556784565,'Air Quality Engineering'),(301221823,'American Political Parties'),(552455318,'Communication Networks'),(567354612,'Data Structures'),(112348546,'Database Systems'),(115987938,'Database Systems'),(322654189,'Database Systems'),(348121549,'Database Systems'),(552455318,'Database Systems'),(112348546,'Operating System Design'),(115987938,'Operating System Design'),(322654189,'Operating System Design'),(455798411,'Operating System Design'),(552455318,'Operating System Design'),(567354612,'Operating System Design'),(455798411,'Optical Electronics'),(99354543,'Patent Law'),(301221823,'Perception'),(301221823,'Social Cognition'),(574489456,'Urban Economics');
/*!40000 ALTER TABLE `enrolled` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculty`
--

DROP TABLE IF EXISTS `faculty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculty` (
  `fid` decimal(9,0) NOT NULL,
  `fname` varchar(30) DEFAULT NULL,
  `deptid` decimal(2,0) DEFAULT NULL,
  PRIMARY KEY (`fid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculty`
--

LOCK TABLES `faculty` WRITE;
/*!40000 ALTER TABLE `faculty` DISABLE KEYS */;
INSERT INTO `faculty` VALUES (11564812,'John Williams',68),(90873519,'Elizabeth Taylor',11),(141582651,'Mary Johnson',20),(142519864,'Ivana Teach',20),(159542516,'William Moore',33),(242518965,'James Smith',68),(248965255,'Barbara Wilson',12),(254099823,'Patricia Jones',68),(287321212,'Michael Miller',12),(356187925,'Robert Brown',12),(486512566,'David Anderson',20),(489221823,'Richard Jackson',33),(489456522,'Linda Davis',20),(548977562,'Ulysses Teach',20),(619023588,'Jennifer Thomas',11);
/*!40000 ALTER TABLE `faculty` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `snum` decimal(9,0) NOT NULL,
  `sname` varchar(30) DEFAULT NULL,
  `major` varchar(25) DEFAULT NULL,
  `level` varchar(2) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  PRIMARY KEY (`snum`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (51135593,'Maria White','English','SR',21),(60839453,'Charles Harris','Architecture','SR',22),(99354543,'Susan Martin','Law','JR',20),(112348546,'Joseph Thompson','Computer Science','SO',19),(115987938,'Christopher Garcia','Computer Science','JR',20),(132977562,'Angela Martinez','History','SR',20),(269734834,'Thomas Robinson','Psychology','SO',18),(280158572,'Margaret Clark','Animal Science','FR',18),(301221823,'Juan Rodriguez','Psychology','JR',20),(318548912,'Dorthy Lewis','Finance','FR',18),(320874981,'Daniel Lee','Electrical Engineering','FR',17),(322654189,'Lisa Walker','Computer Science','SO',17),(348121549,'Paul Hall','Computer Science','JR',18),(351565322,'Nancy Allen','Accounting','JR',19),(451519864,'Mark Young','Finance','FR',18),(455798411,'Luis Hernandez','Electrical Engineering','FR',17),(462156489,'Donald King','Mechanical Engineering','SO',19),(550156548,'George Wright','Education','SR',21),(552455318,'Ana Lopez','Computer Engineering','SR',19),(556784565,'Kenneth Hill','Civil Engineering','SR',21),(567354612,'Karen Scott','Computer Engineering','FR',18),(573284895,'Steven Green','Kinesiology','SO',19),(574489456,'Betty Adams','Economics','JR',20),(578875478,'Edward Baker','Veterinary Medicine','SR',21);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `flights`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `flights` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `flights`;

--
-- Table structure for table `aircraft`
--

DROP TABLE IF EXISTS `aircraft`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aircraft` (
  `aid` decimal(9,0) NOT NULL,
  `aname` varchar(30) DEFAULT NULL,
  `cruisingrange` decimal(6,0) DEFAULT NULL,
  PRIMARY KEY (`aid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aircraft`
--

LOCK TABLES `aircraft` WRITE;
/*!40000 ALTER TABLE `aircraft` DISABLE KEYS */;
INSERT INTO `aircraft` VALUES (1,'Boeing 747-400',8430),(2,'Boeing 737-800',3383),(3,'Airbus A340-300',7120),(4,'British Aerospace Jetstream 41',1502),(5,'Embraer ERJ-145',1530),(6,'SAAB 340',2128),(7,'Piper Archer III',520),(8,'Tupolev 154',4103),(9,'Lockheed L1011',6900),(10,'Boeing 757-300',4010),(11,'Boeing 777-300',6441),(12,'Boeing 767-400ER',6475),(13,'Airbus A320',2605),(14,'Airbus A319',1805),(15,'Boeing 727',1504),(16,'Schwitzer 2-33',30);
/*!40000 ALTER TABLE `aircraft` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `certified`
--

DROP TABLE IF EXISTS `certified`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `certified` (
  `eid` decimal(9,0) NOT NULL,
  `aid` decimal(9,0) NOT NULL,
  PRIMARY KEY (`eid`,`aid`),
  KEY `aid` (`aid`),
  CONSTRAINT `certified_ibfk_1` FOREIGN KEY (`eid`) REFERENCES `employees` (`eid`),
  CONSTRAINT `certified_ibfk_2` FOREIGN KEY (`aid`) REFERENCES `aircraft` (`aid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `certified`
--

LOCK TABLES `certified` WRITE;
/*!40000 ALTER TABLE `certified` DISABLE KEYS */;
INSERT INTO `certified` VALUES (142519864,1),(269734834,1),(550156548,1),(567354612,1),(11564812,2),(141582651,2),(142519864,2),(242518965,2),(269734834,2),(552455318,2),(556784565,2),(567354612,2),(142519864,3),(269734834,3),(390487451,3),(556784565,3),(567354612,3),(573284895,3),(269734834,4),(567354612,4),(573284895,4),(159542516,5),(269734834,5),(556784565,5),(567354612,5),(573284895,5),(90873519,6),(269734834,6),(356187925,6),(574489456,6),(142519864,7),(159542516,7),(269734834,7),(548977562,7),(552455318,7),(567354612,7),(574489457,7),(269734834,8),(310454876,8),(355548984,8),(574489456,8),(269734834,9),(310454876,9),(355548984,9),(567354612,9),(11564812,10),(141582651,10),(142519864,10),(242518965,10),(269734834,10),(274878974,10),(567354612,10),(142519864,11),(269734834,11),(567354612,11),(141582651,12),(142519864,12),(269734834,12),(274878974,12),(550156548,12),(567354612,12),(142519864,13),(269734834,13),(390487451,13),(269734834,14),(390487451,14),(552455318,14),(269734834,15),(567354612,15);
/*!40000 ALTER TABLE `certified` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employees` (
  `eid` decimal(9,0) NOT NULL,
  `ename` varchar(30) DEFAULT NULL,
  `salary` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`eid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (11564812,'John Williams',153972.00),(15645489,'Donald King',18050.00),(90873519,'Elizabeth Taylor',32021.00),(141582651,'Mary Johnson',178345.00),(142519864,'Betty Adams',227489.00),(159542516,'William Moore',48250.00),(242518965,'James Smith',120433.00),(248965255,'Barbara Wilson',43723.00),(254099823,'Patricia Jones',24450.00),(269734834,'George Wright',289950.00),(274878974,'Michael Miller',99890.00),(287321212,'Michael Miller',48090.00),(310454876,'Joseph Thompson',212156.00),(310454877,'Chad Stewart',33546.00),(348121549,'Haywood Kelly',32899.00),(355548984,'Angela Martinez',212156.00),(356187925,'Robert Brown',44740.00),(390487451,'Lawrence Sperry',212156.00),(486512566,'David Anderson',743001.00),(489221823,'Richard Jackson',23980.00),(489456522,'Linda Davis',127984.00),(548977562,'William Ward',84476.00),(550156548,'Karen Scott',205187.00),(552455318,'Larry West',101745.00),(552455348,'Dorthy Lewis',92013.00),(556784565,'Mark Young',205187.00),(567354612,'Lisa Walker',256481.00),(573284895,'Eric Cooper',114323.00),(574489456,'William Jones',105743.00),(574489457,'Milo Brooks',20.00),(619023588,'Jennifer Thomas',54921.00);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `flights`
--

DROP TABLE IF EXISTS `flights`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `flights` (
  `flno` decimal(4,0) NOT NULL,
  `origin` varchar(20) DEFAULT NULL,
  `destination` varchar(20) DEFAULT NULL,
  `distance` decimal(6,0) DEFAULT NULL,
  `departs` datetime DEFAULT NULL,
  `arrives` datetime DEFAULT NULL,
  `price` decimal(7,2) DEFAULT NULL,
  PRIMARY KEY (`flno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flights`
--

LOCK TABLES `flights` WRITE;
/*!40000 ALTER TABLE `flights` DISABLE KEYS */;
INSERT INTO `flights` VALUES (2,'Los Angeles','Tokyo',5478,'2005-04-12 12:30:00','2005-04-13 15:55:00',780.99),(7,'Los Angeles','Sydney',7487,'2005-04-12 22:30:00','2005-04-14 06:10:00',1278.56),(13,'Los Angeles','Chicago',1749,'2005-04-12 08:45:00','2005-04-12 20:45:00',220.98),(33,'Los Angeles','Honolulu',2551,'2005-04-12 09:15:00','2005-04-12 11:15:00',375.23),(34,'Los Angeles','Honolulu',2551,'2005-04-12 12:45:00','2005-04-12 15:18:00',425.98),(68,'Chicago','New York',802,'2005-04-12 09:00:00','2005-04-12 12:02:00',202.45),(76,'Chicago','Los Angeles',1749,'2005-04-12 08:32:00','2005-04-12 10:03:00',220.98),(99,'Los Angeles','Washington D.C.',2308,'2005-04-12 09:30:00','2005-04-12 21:40:00',235.98),(149,'Pittsburgh','New York',303,'2005-04-12 09:42:00','2005-04-12 12:09:00',116.50),(304,'Minneapolis','New York',991,'2005-04-12 10:00:00','2005-04-12 01:39:00',101.56),(346,'Los Angeles','Dallas',1251,'2005-04-12 11:50:00','2005-04-12 19:05:00',225.43),(387,'Los Angeles','Boston',2606,'2005-04-12 07:03:00','2005-04-12 17:03:00',261.56),(701,'Detroit','New York',470,'2005-04-12 08:55:00','2005-04-12 10:26:00',180.56),(702,'Madison','New York',789,'2005-04-12 07:05:00','2005-04-12 10:12:00',202.34),(2223,'Madison','Pittsburgh',517,'2005-04-12 08:02:00','2005-04-12 10:01:00',189.98),(4884,'Madison','Chicago',84,'2005-04-12 22:12:00','2005-04-12 23:02:00',112.45),(5694,'Madison','Minneapolis',247,'2005-04-12 08:32:00','2005-04-12 09:33:00',120.11),(7789,'Madison','Detroit',319,'2005-04-12 06:15:00','2005-04-12 08:19:00',120.33);
/*!40000 ALTER TABLE `flights` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-09 11:23:28
