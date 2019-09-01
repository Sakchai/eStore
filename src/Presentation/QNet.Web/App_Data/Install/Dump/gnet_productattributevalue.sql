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
-- Table structure for table `productattributevalue`
--

DROP TABLE IF EXISTS `productattributevalue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `productattributevalue` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductAttributeMappingId` int(11) NOT NULL,
  `AttributeValueTypeId` int(11) NOT NULL,
  `AssociatedProductId` int(11) NOT NULL,
  `Name` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ColorSquaresRgb` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ImageSquaresPictureId` int(11) NOT NULL,
  `PriceAdjustment` decimal(18,4) NOT NULL,
  `PriceAdjustmentUsePercentage` bit(1) NOT NULL,
  `WeightAdjustment` decimal(18,4) NOT NULL,
  `Cost` decimal(18,4) NOT NULL,
  `CustomerEntersQty` bit(1) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `IsPreSelected` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  `PictureId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductAttributeValue_ProductAttributeMappingId` (`ProductAttributeMappingId`),
  KEY `IX_ProductAttributeValue_ProductAttributeMappingId_DisplayOrder` (`ProductAttributeMappingId`,`DisplayOrder`),
  CONSTRAINT `FK_ProductAttributeValue_Product_ProductAttribute_Mapping_Prod7` FOREIGN KEY (`ProductAttributeMappingId`) REFERENCES `product_productattribute_mapping` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productattributevalue`
--

LOCK TABLES `productattributevalue` WRITE;
/*!40000 ALTER TABLE `productattributevalue` DISABLE KEYS */;
INSERT INTO `productattributevalue` VALUES (1,1,0,0,'2.2 GHz Intel Pentium Dual-Core E2200',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(2,1,0,0,'2.5 GHz Intel Pentium Dual-Core E2200',NULL,0,15.0000,0,0.0000,0.0000,0,0,1,2,0),(3,2,0,0,'2 GB',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(4,2,0,0,'4GB',NULL,0,20.0000,0,0.0000,0.0000,0,0,0,2,0),(5,2,0,0,'8GB',NULL,0,60.0000,0,0.0000,0.0000,0,0,0,3,0),(6,3,0,0,'320 GB',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(7,3,0,0,'400 GB',NULL,0,100.0000,0,0.0000,0.0000,0,0,0,2,0),(8,4,0,0,'Vista Home',NULL,0,50.0000,0,0.0000,0.0000,0,0,1,1,0),(9,4,0,0,'Vista Premium',NULL,0,60.0000,0,0.0000,0.0000,0,0,0,2,0),(10,5,0,0,'Microsoft Office',NULL,0,50.0000,0,0.0000,0.0000,0,0,1,1,0),(11,5,0,0,'Acrobat Reader',NULL,0,10.0000,0,0.0000,0.0000,0,0,0,2,0),(12,5,0,0,'Total Commander',NULL,0,5.0000,0,0.0000,0.0000,0,0,0,2,0),(13,6,0,0,'8',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(14,6,0,0,'9',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,2,0),(15,6,0,0,'10',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,3,0),(16,6,0,0,'11',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,4,0),(17,7,0,0,'White/Blue',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(18,7,0,0,'White/Black',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,2,0),(19,8,0,0,'Natural',NULL,49,0.0000,0,0.0000,0.0000,0,0,0,1,51),(20,8,0,0,'Fresh',NULL,50,0.0000,0,0.0000,0.0000,0,0,0,2,52),(21,9,0,0,'8',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(22,9,0,0,'9',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,2,0),(23,9,0,0,'10',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,3,0),(24,9,0,0,'11',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,4,0),(25,10,0,0,'Red','#663030',0,0.0000,0,0.0000,0.0000,0,0,1,1,53),(26,10,0,0,'Blue','#363656',0,0.0000,0,0.0000,0.0000,0,0,0,2,54),(27,10,0,0,'Silver','#c5c5d5',0,0.0000,0,0.0000,0.0000,0,0,0,3,55),(28,11,0,0,'Small',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(29,11,0,0,'1X',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,2,0),(30,11,0,0,'2X',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,3,0),(31,11,0,0,'3X',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,4,0),(32,11,0,0,'4X',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,5,0),(33,11,0,0,'5X',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,6,0),(34,13,0,0,'Small',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,1,0),(35,13,0,0,'Medium',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,2,0),(36,13,0,0,'Large',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,3,0),(37,13,0,0,'X-Large',NULL,0,0.0000,0,0.0000,0.0000,0,0,0,4,0);
/*!40000 ALTER TABLE `productattributevalue` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:21
