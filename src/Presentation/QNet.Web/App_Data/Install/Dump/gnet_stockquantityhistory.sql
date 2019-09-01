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
-- Table structure for table `stockquantityhistory`
--

DROP TABLE IF EXISTS `stockquantityhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `stockquantityhistory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `QuantityAdjustment` int(11) NOT NULL,
  `StockQuantity` int(11) NOT NULL,
  `Message` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `CombinationId` int(11) DEFAULT NULL,
  `WarehouseId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_StockQuantityHistory_ProductId` (`ProductId`),
  CONSTRAINT `FK_StockQuantityHistory_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stockquantityhistory`
--

LOCK TABLES `stockquantityhistory` WRITE;
/*!40000 ALTER TABLE `stockquantityhistory` DISABLE KEYS */;
INSERT INTO `stockquantityhistory` VALUES (1,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.061919',1,NULL,NULL),(2,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.156634',2,NULL,NULL),(3,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.211378',3,NULL,NULL),(4,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.271470',4,NULL,NULL),(5,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.330121',5,NULL,NULL),(6,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.390072',6,NULL,NULL),(7,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.454223',7,NULL,NULL),(8,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.559286',8,NULL,NULL),(9,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.619827',9,NULL,NULL),(10,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.681955',10,NULL,NULL),(11,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.775083',11,NULL,NULL),(12,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.850833',12,NULL,NULL),(13,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.909491',13,NULL,NULL),(14,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:49.967225',14,NULL,NULL),(15,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.038240',15,NULL,NULL),(16,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.093369',16,NULL,NULL),(17,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.148691',17,NULL,NULL),(18,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.211471',18,NULL,NULL),(19,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.266425',19,NULL,NULL),(20,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.326471',20,NULL,NULL),(21,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.381144',21,NULL,NULL),(22,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.444890',22,NULL,NULL),(23,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.532615',23,NULL,NULL),(24,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.592801',24,NULL,NULL),(25,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.649349',25,NULL,NULL),(26,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.704498',26,NULL,NULL),(27,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.760142',27,NULL,NULL),(28,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.824480',28,NULL,NULL),(29,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.904804',29,NULL,NULL),(30,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:50.971375',30,NULL,NULL),(31,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.050657',31,NULL,NULL),(32,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.102342',33,NULL,NULL),(33,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.161124',34,NULL,NULL),(34,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.225061',35,NULL,NULL),(35,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.278159',36,NULL,NULL),(36,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.332538',37,NULL,NULL),(37,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.389224',38,NULL,NULL),(38,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.470796',39,NULL,NULL),(39,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.553172',40,NULL,NULL),(40,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.621175',41,NULL,NULL),(41,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.676366',42,NULL,NULL),(42,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.734242',43,NULL,NULL),(43,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.792485',44,NULL,NULL),(44,10000,10000,'The stock quantity has been edited','2019-08-23 05:44:51.856804',45,NULL,NULL);
/*!40000 ALTER TABLE `stockquantityhistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:14:46
