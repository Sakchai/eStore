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
-- Table structure for table `product_category_mapping`
--

DROP TABLE IF EXISTS `product_category_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_category_mapping` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `IsFeaturedProduct` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Product_Category_Mapping_CategoryId` (`CategoryId`),
  KEY `IX_Product_Category_Mapping_ProductId` (`ProductId`),
  KEY `IX_PCM_Product_and_Category` (`CategoryId`,`ProductId`),
  KEY `IX_PCM_ProductId_Extended` (`ProductId`,`IsFeaturedProduct`,`CategoryId`),
  KEY `IX_Product_Category_Mapping_IsFeaturedProduct` (`IsFeaturedProduct`),
  CONSTRAINT `FK_Product_Category_Mapping_Category_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Product_Category_Mapping_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_category_mapping`
--

LOCK TABLES `product_category_mapping` WRITE;
/*!40000 ALTER TABLE `product_category_mapping` DISABLE KEYS */;
INSERT INTO `product_category_mapping` VALUES (1,1,2,0,1),(2,2,2,0,1),(3,3,2,0,1),(4,4,3,0,1),(5,5,3,0,1),(6,6,3,0,1),(7,7,3,0,1),(8,8,3,0,1),(9,9,3,0,1),(10,10,4,0,1),(11,11,4,0,1),(12,12,4,0,1),(13,13,6,0,1),(14,16,6,0,3),(15,17,6,0,2),(16,18,7,0,1),(17,19,7,0,1),(18,20,7,0,1),(19,21,8,0,1),(20,22,8,0,1),(21,23,8,0,1),(22,24,10,0,1),(23,25,10,0,1),(24,26,10,0,1),(25,27,11,0,1),(26,28,11,0,1),(27,29,11,0,1),(28,30,11,0,1),(29,31,12,0,1),(30,32,12,0,1),(31,33,12,0,1),(32,34,13,0,1),(33,35,13,0,1),(34,36,13,0,1),(35,37,14,0,1),(36,38,14,0,1),(37,39,14,0,1),(38,40,15,0,1),(39,41,15,0,1),(40,42,15,0,1),(41,43,16,0,2),(42,44,16,0,3),(43,45,16,0,4);
/*!40000 ALTER TABLE `product_category_mapping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:02
