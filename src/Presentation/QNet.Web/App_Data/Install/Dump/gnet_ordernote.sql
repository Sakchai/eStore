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
-- Table structure for table `ordernote`
--

DROP TABLE IF EXISTS `ordernote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ordernote` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderId` int(11) NOT NULL,
  `Note` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DownloadId` int(11) NOT NULL,
  `DisplayToCustomer` bit(1) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_OrderNote_OrderId` (`OrderId`),
  CONSTRAINT `FK_OrderNote_Order_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `order` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordernote`
--

LOCK TABLES `ordernote` WRITE;
/*!40000 ALTER TABLE `ordernote` DISABLE KEYS */;
INSERT INTO `ordernote` VALUES (1,1,'Order placed',0,0,'2019-08-23 05:44:55.947170'),(2,1,'Order paid',0,0,'2019-08-23 05:44:56.020575'),(3,2,'Order placed',0,0,'2019-08-23 05:44:56.315105'),(4,3,'Order placed',0,0,'2019-08-23 05:44:56.917463'),(5,4,'Order placed',0,0,'2019-08-23 05:44:57.675983'),(6,4,'Order paid',0,0,'2019-08-23 05:44:57.753927'),(7,4,'Order shipped',0,0,'2019-08-23 05:44:57.809041'),(8,5,'Order placed',0,0,'2019-08-23 05:44:59.159496'),(9,5,'Order paid',0,0,'2019-08-23 05:44:59.216713'),(10,5,'Order shipped',0,0,'2019-08-23 05:44:59.285177'),(11,5,'Order delivered',0,0,'2019-08-23 05:44:59.343357');
/*!40000 ALTER TABLE `ordernote` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:06
