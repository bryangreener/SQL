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

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS Devices;
CREATE TABLE Devices (
id				varchar(8),
type			varchar(10),
location		varchar(30),
installedOn	varchar(30),
active		bool DEFAULT TRUE,
PRIMARY KEY (id),
KEY FK_activeDevices (active)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS Computer;
CREATE TABLE Computer (
id			varchar(8),
os			varchar(20),
location		varchar(30),
installedOn	varchar(30),
active		bool DEFAULT TRUE,
PRIMARY KEY (id),
KEY FK_computer_active (active),
CONSTRAINT FK_active FOREIGN KEY(active) REFERENCES Devices (active) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TRIGGER ComputerDelete BEFORE DELETE ON Computer
FOR EACH ROW
UPDATE Devices SET active = false
WHERE Computer.id = Devices.id;

/*!40101 SET character_set_client = @saved_cs_client */;

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
KEY `FK_server_active` (`active`),
CONSTRAINT `FK_server_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `WAP`;
CREATE TABLE  `WAP` (
`id`			varchar(8),
`ip`			varchar(16),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_wap_active` (`active`),
CONSTRAINT `FK_wap_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Router`;
CREATE TABLE  `Router` (
`id`			varchar(8),
`intIP`			varchar(16),
`extIP`			varchar(16),
`dns`			varchar(16),
`network`		varchar(16),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_router_active` (`active`),
CONSTRAINT `FK_router_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Firewall`;
CREATE TABLE  `Firewall` (
`id`			varchar(8),
`intIP`			varchar(16),
`extIP`			varchar(16),
`dns`			varchar(16),
`network`		varchar(16),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_firewall_active` (`active`),
CONSTRAINT `FK_firewall_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
DROP TABLE IF EXISTS `Switch`;
CREATE TABLE `Switch` (
`id`			varchar(8),
`type`			varchar(1),
`ip`			varchar(16),
`installedOn`	varchar(30),
`active`		bool DEFAULT TRUE,
PRIMARY KEY (`id`),
KEY `FK_switch_active` (`active`),
CONSTRAINT `FK_switch_active` FOREIGN KEY(`active`) REFERENCES `Devices` (`active`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
