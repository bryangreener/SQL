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

set global optimizer_switch='derived_merge=OFF';
CREATE DATABASE /*!32312 IF NOT EXISTS*/ `FinalProject` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `FinalProject`;

DROP TABLE IF EXISTS `Devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Devices` (
`id` varchar(8),
`type` varchar(10),
`location` varchar(30),
`installedOn` varchar(30),
`active` bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_activeDevices` (`active`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `Devices` WRITE;
/*!40000 ALTER TABLE `Devices` DISABLE KEYS */;
INSERT INTO `Devices` VALUES 
	(1,'Desktop','WMU CS Lab','2017-07-01',true),
    (2,'Laptop','Personal','2017-07-05',true),
    (3,'Desktop','CS Office','2005-02-03',false),
    (4,'Desktop','Teacher','2005-02-03',false),
    (5,'Desktop','HR','2017-05-06',true),
    (6,'Server','Floyd Hall Server Room','2003-06-21',false),
    (7,'Server','Rood Hall Server Room','2017-06-21',true),
    (8,'Server','Floyd Hall Server Room','2017-06-21',true),
    (9,'WAP','Floyd B Wing','2015-01-01',true),
    (10,'WAP','Floyd F Wing','2015-01-01',true),
    (11,'Router','Floyd Hall DMZ','2010-01-01',true),
    (12,'Router','Rood Hall DMZ','2010-01-01',true),
    (13,'Firewall','Main Hall DMZ','2010-01-01',true),
    (14,'Firewall','Some Other Hall DMZ','2010-01-01',true),
    (15,'Switch','Unknown','2010-01-01',true),
    (16,'Switch','Floyd Hall Server Room','2010-01-01',true);
    ;
/*!40000 ALTER TABLE `Devices` ENABLE KEYS */;
UNLOCK TABLES;

DROP TABLE IF EXISTS `Computer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Computer` (
`id` varchar(8),
`os` varchar(20),
`location` varchar(30),
`installedOn` varchar(30),
`active` bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_computer_active` (`active`)
#CONSTRAINT `FK_active` FOREIGN KEY (`active`) REFERENCES `Devices` (`active`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `Computer` WRITE;
/*!40000 ALTER TABLE `Computer` DISABLE KEYS */;
INSERT INTO `Computer` VALUES 
	(1,'Windows 7 Pro','WMU CS Lab','2017-07-01',true),
    (2,'Windows 10','Personal','2017-07-05',true),
    (3,'Windows XP','CS Office','2005-02-03',false),
    (4,'Windows XP','Teacher','2005-02-03',false),
    (5,'Windows 7 Home','HR','2017-05-06',true);
    
/*!40000 ALTER TABLE `Computer` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Server`;
CREATE TABLE  `Server` (
`id`			varchar(8),
`os`			varchar(20),
`ip1`			varchar(16),
`ip2`			varchar(16),
`ip3`			varchar(16),
`ip4`			varchar(16),
`dns`			varchar(16),
`network`		varchar(16),
`roles`			varchar(50),
`location`		varchar(30),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_server_active` (`active`)
#CONSTRAINT `FK_server_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `Server` WRITE;
/*!40000 ALTER TABLE `Server` DISABLE KEYS */;
INSERT INTO `Server` VALUES 
	(6,'Windows Server 2003','10.10.0.1','none','none','none','127.0.0.1','10.10.0.1','DNS,DHCP,Exchange','Floyd Hall Server Room','2003-06-21',false),
    (7,'Windows Server 2012 R2','10.10.0.2','none','none','none','127.0.0.1','10.10.0.1','DNS,DHCP,Exchange','Rood Hall Server Room','2017-06-21',true),
    (8,'Windows Server 2012 R2','10.10.0.1','none','none','none','127.0.0.1','10.10.0.1','DNS,DHCP,Exchange','Floyd Hall Server Room','2017-06-21',true);
/*!40000 ALTER TABLE `Server` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `WAP`;
CREATE TABLE  `WAP` (
`id`			varchar(8),
`ip`			varchar(16),
`location`		varchar(30),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_wap_active` (`active`)
#CONSTRAINT `FK_wap_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `WAP` WRITE;
/*!40000 ALTER TABLE `WAP` DISABLE KEYS */;
INSERT INTO `WAP` VALUES 
	(9,'10.10.0.30','Floyd B Wing','2015-01-01',true),
    (10,'10.10.0.31','Floyd F Wing','2015-01-01',true);
/*!40000 ALTER TABLE `WAP` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Router`;
CREATE TABLE  `Router` (
`id`			varchar(8),
`intIP`			varchar(16),
`extIP`			varchar(16),
`dns`			varchar(16),
`network`		varchar(16),
`location`		varchar(30),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_router_active` (`active`)
#CONSTRAINT `FK_router_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `Router` WRITE;
/*!40000 ALTER TABLE `Router` DISABLE KEYS */;
INSERT INTO `Router` VALUES 
	(11,'10.10.0.10','20.20.20.100','10.10.0.1','10.10.0.1','Floyd Hall DMZ','2010-01-01',true),
    (12,'10.10.0.11','20.20.20.101','10.10.0.2','10.10.0.2','Rood Hall DMZ','2010-01-01',true);
/*!40000 ALTER TABLE `Router` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Firewall`;
CREATE TABLE  `Firewall` (
`id`			varchar(8),
`intIP`			varchar(16),
`extIP`			varchar(16),
`dns`			varchar(16),
`network`		varchar(16),
`location`		varchar(30),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_firewall_active` (`active`)
#CONSTRAINT `FK_firewall_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `Firewall` WRITE;
/*!40000 ALTER TABLE `Firewall` DISABLE KEYS */;
INSERT INTO `Firewall` VALUES 
	(13,'10.10.0.20','20.20.20.98','10.10.0.3','10.10.0.3','Main Hall DMZ','2010-01-01',true),
    (14,'10.10.0.21','20.20.20.99','10.10.0.4','10.10.0.4','Some Other Hall DMZ','2010-01-01',true);
/*!40000 ALTER TABLE `Firewall` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Switch`;
CREATE TABLE `Switch` (
`id`			varchar(8),
`type`			varchar(1),
`ip`			varchar(16),
`location`		varchar(30),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_switch_active` (`active`)
#CONSTRAINT `FK_switch_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `Switch` WRITE;
/*!40000 ALTER TABLE `Switch` DISABLE KEYS */;
INSERT INTO `Switch` VALUES 
	(15,'Layer2','none','Unknown','2010-01-01',true),
    (16,'Layer3','10.10.0.50','Floyd Hall Server Room','2010-01-01',true);
/*!40000 ALTER TABLE `Switch` ENABLE KEYS */;
UNLOCK TABLES;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
