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
-- Table structure for table `product_manufacturer_mapping`
--

DROP TABLE IF EXISTS `product_manufacturer_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_manufacturer_mapping` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) NOT NULL,
  `ManufacturerId` int(11) NOT NULL,
  `IsFeaturedProduct` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Product_Manufacturer_Mapping_ManufacturerId` (`ManufacturerId`),
  KEY `IX_Product_Manufacturer_Mapping_ProductId` (`ProductId`),
  KEY `IX_PMM_Product_and_Manufacturer` (`ManufacturerId`,`ProductId`),
  KEY `IX_PMM_ProductId_Extended` (`ProductId`,`IsFeaturedProduct`,`ManufacturerId`),
  KEY `IX_Product_Manufacturer_Mapping_IsFeaturedProduct` (`IsFeaturedProduct`),
  CONSTRAINT `FK_Product_Manufacturer_Mapping_Manufacturer_ManufacturerId` FOREIGN KEY (`ManufacturerId`) REFERENCES `manufacturer` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Product_Manufacturer_Mapping_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_manufacturer_mapping`
--

LOCK TABLES `product_manufacturer_mapping` WRITE;
/*!40000 ALTER TABLE `product_manufacturer_mapping` DISABLE KEYS */;
INSERT INTO `product_manufacturer_mapping` VALUES (1,4,1,0,2),(2,7,2,0,3),(3,8,2,0,4),(4,17,1,0,1),(5,24,3,0,2),(6,26,3,0,2),(7,27,3,0,2);
/*!40000 ALTER TABLE `product_manufacturer_mapping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:27
