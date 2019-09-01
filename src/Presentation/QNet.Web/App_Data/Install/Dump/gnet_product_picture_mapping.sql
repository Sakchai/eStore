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
-- Table structure for table `product_picture_mapping`
--

DROP TABLE IF EXISTS `product_picture_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_picture_mapping` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) NOT NULL,
  `PictureId` int(11) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Product_Picture_Mapping_PictureId` (`PictureId`),
  KEY `IX_Product_Picture_Mapping_ProductId` (`ProductId`),
  CONSTRAINT `FK_Product_Picture_Mapping_Picture_PictureId` FOREIGN KEY (`PictureId`) REFERENCES `picture` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Product_Picture_Mapping_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_picture_mapping`
--

LOCK TABLES `product_picture_mapping` WRITE;
/*!40000 ALTER TABLE `product_picture_mapping` DISABLE KEYS */;
INSERT INTO `product_picture_mapping` VALUES (1,1,20,1),(2,1,21,2),(3,2,22,1),(4,3,23,1),(5,4,24,1),(6,4,25,2),(7,5,26,1),(8,6,27,1),(9,7,28,1),(10,7,29,2),(11,8,30,1),(12,9,31,1),(13,10,32,1),(14,11,33,1),(15,12,34,1),(16,13,35,1),(17,13,36,2),(18,14,37,1),(19,15,38,1),(20,16,39,1),(21,17,40,1),(22,18,41,1),(23,19,42,1),(24,19,43,2),(25,20,44,1),(26,21,45,1),(27,21,46,2),(28,22,47,1),(29,23,48,1),(30,24,51,1),(31,24,52,2),(32,25,53,1),(33,25,54,2),(34,25,55,3),(35,26,56,1),(36,27,57,1),(37,28,58,1),(38,29,59,1),(39,30,60,1),(40,30,61,2),(41,31,62,1),(42,32,63,1),(43,33,64,1),(44,34,65,1),(45,35,66,1),(46,36,67,1),(47,37,68,1),(48,38,69,1),(49,39,70,1),(50,40,71,1),(51,41,72,1),(52,42,73,1),(53,43,74,1),(54,44,75,1),(55,45,76,1);
/*!40000 ALTER TABLE `product_picture_mapping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:44
