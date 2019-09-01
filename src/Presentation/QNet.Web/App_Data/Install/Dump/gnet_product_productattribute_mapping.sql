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
-- Table structure for table `product_productattribute_mapping`
--

DROP TABLE IF EXISTS `product_productattribute_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_productattribute_mapping` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) NOT NULL,
  `ProductAttributeId` int(11) NOT NULL,
  `TextPrompt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsRequired` bit(1) NOT NULL,
  `AttributeControlTypeId` int(11) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  `ValidationMinLength` int(11) DEFAULT NULL,
  `ValidationMaxLength` int(11) DEFAULT NULL,
  `ValidationFileAllowedExtensions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ValidationFileMaximumSize` int(11) DEFAULT NULL,
  `DefaultValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConditionAttributeXml` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Product_ProductAttribute_Mapping_ProductAttributeId` (`ProductAttributeId`),
  KEY `IX_Product_ProductAttribute_Mapping_ProductId` (`ProductId`),
  KEY `IX_Product_ProductAttribute_Mapping_ProductId_DisplayOrder` (`ProductId`,`DisplayOrder`),
  CONSTRAINT `FK_Product_ProductAttribute_Mapping_ProductAttribute_ProductAt5` FOREIGN KEY (`ProductAttributeId`) REFERENCES `productattribute` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Product_ProductAttribute_Mapping_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_productattribute_mapping`
--

LOCK TABLES `product_productattribute_mapping` WRITE;
/*!40000 ALTER TABLE `product_productattribute_mapping` DISABLE KEYS */;
INSERT INTO `product_productattribute_mapping` VALUES (1,1,6,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL),(2,1,7,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL),(3,1,4,NULL,1,2,0,NULL,NULL,NULL,NULL,NULL,NULL),(4,1,5,NULL,1,2,0,NULL,NULL,NULL,NULL,NULL,NULL),(5,1,9,NULL,0,3,0,NULL,NULL,NULL,NULL,NULL,NULL),(6,24,8,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL),(7,24,1,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL),(8,24,2,NULL,1,45,0,NULL,NULL,NULL,NULL,NULL,NULL),(9,25,8,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL),(10,25,1,NULL,1,40,0,NULL,NULL,NULL,NULL,NULL,NULL),(11,27,8,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL),(12,29,3,'Enter your text:',1,4,0,NULL,NULL,NULL,NULL,NULL,NULL),(13,31,8,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `product_productattribute_mapping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:08
