-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: gnet
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `currency`
--

DROP TABLE IF EXISTS `currency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `currency` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CurrencyCode` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Rate` decimal(18,4) NOT NULL,
  `DisplayLocale` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CustomFormatting` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `LimitedToStores` bit(1) NOT NULL,
  `Published` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `UpdatedOnUtc` datetime(6) NOT NULL,
  `RoundingTypeId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Currency_DisplayOrder` (`DisplayOrder`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currency`
--

LOCK TABLES `currency` WRITE;
/*!40000 ALTER TABLE `currency` DISABLE KEYS */;
INSERT INTO `currency` VALUES (1,'US Dollar','USD',1.0000,'en-US','',0,1,1,'2019-08-23 05:43:18.025525','2019-08-23 05:43:18.025593',0),(2,'Australian Dollar','AUD',1.3400,'en-AU','',0,0,2,'2019-08-23 05:43:18.025808','2019-08-23 05:43:18.025808',0),(3,'British Pound','GBP',0.7500,'en-GB','',0,0,3,'2019-08-23 05:43:18.025808','2019-08-23 05:43:18.025808',0),(4,'Canadian Dollar','CAD',1.3200,'en-CA','',0,0,4,'2019-08-23 05:43:18.025809','2019-08-23 05:43:18.025809',0),(5,'Chinese Yuan Renminbi','CNY',6.4300,'zh-CN','',0,0,5,'2019-08-23 05:43:18.025809','2019-08-23 05:43:18.025809',0),(6,'Euro','EUR',0.8600,'','€0.00',0,1,6,'2019-08-23 05:43:18.025814','2019-08-23 05:43:18.025814',0),(7,'Hong Kong Dollar','HKD',7.8400,'zh-HK','',0,0,7,'2019-08-23 05:43:18.025814','2019-08-23 05:43:18.025814',0),(8,'Japanese Yen','JPY',110.4500,'ja-JP','',0,0,8,'2019-08-23 05:43:18.025815','2019-08-23 05:43:18.025815',0),(9,'Russian Rouble','RUB',63.2500,'ru-RU','',0,0,9,'2019-08-23 05:43:18.025815','2019-08-23 05:43:18.025815',0),(10,'Swedish Krona','SEK',8.8000,'sv-SE','',0,0,10,'2019-08-23 05:43:18.025815','2019-08-23 05:43:18.025815',60),(11,'Indian Rupee','INR',68.0300,'en-IN','',0,0,12,'2019-08-23 05:43:18.025815','2019-08-23 05:43:18.025815',0);
/*!40000 ALTER TABLE `currency` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:14:50
