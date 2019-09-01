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
-- Table structure for table `activitylog`
--

DROP TABLE IF EXISTS `activitylog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activitylog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ActivityLogTypeId` int(11) NOT NULL,
  `EntityId` int(11) DEFAULT NULL,
  `EntityName` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CustomerId` int(11) NOT NULL,
  `Comment` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `IpAddress` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ActivityLog_ActivityLogTypeId` (`ActivityLogTypeId`),
  KEY `IX_ActivityLog_CustomerId` (`CustomerId`),
  KEY `IX_ActivityLog_CreatedOnUtc` (`CreatedOnUtc` DESC),
  CONSTRAINT `FK_ActivityLog_ActivityLogType_ActivityLogTypeId` FOREIGN KEY (`ActivityLogTypeId`) REFERENCES `activitylogtype` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ActivityLog_Customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activitylog`
--

LOCK TABLES `activitylog` WRITE;
/*!40000 ALTER TABLE `activitylog` DISABLE KEYS */;
INSERT INTO `activitylog` VALUES (1,27,NULL,NULL,1,'Edited a category (\'Computers\')','2019-08-23 05:44:59.774128','127.0.0.1'),(2,19,NULL,NULL,1,'Edited a discount (\'Sample discount with coupon code\')','2019-08-23 05:44:59.903177','127.0.0.1'),(3,38,NULL,NULL,1,'Edited a specification attribute (\'CPU Type\')','2019-08-23 05:45:00.054975','127.0.0.1'),(4,79,NULL,NULL,1,'Added a new product attribute (\'Some attribute\')','2019-08-23 05:45:00.164069','127.0.0.1'),(5,146,NULL,NULL,1,'Deleted a gift card (\'bdbbc0ef-be57\')','2019-08-23 05:45:00.263275','127.0.0.1');
/*!40000 ALTER TABLE `activitylog` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:31
