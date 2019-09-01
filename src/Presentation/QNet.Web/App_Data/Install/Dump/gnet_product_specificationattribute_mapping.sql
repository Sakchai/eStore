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
-- Table structure for table `product_specificationattribute_mapping`
--

DROP TABLE IF EXISTS `product_specificationattribute_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_specificationattribute_mapping` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) NOT NULL,
  `AttributeTypeId` int(11) NOT NULL,
  `SpecificationAttributeOptionId` int(11) NOT NULL,
  `CustomValue` varchar(4000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `AllowFiltering` bit(1) NOT NULL,
  `ShowOnProductPage` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Product_SpecificationAttribute_Mapping_ProductId` (`ProductId`),
  KEY `IX_Product_SpecificationAttribute_Mapping_SpecificationAttribu1` (`SpecificationAttributeOptionId`),
  KEY `IX_PSAM_AllowFiltering` (`AllowFiltering`,`ProductId`,`SpecificationAttributeOptionId`),
  KEY `IX_PSAM_SpecificationAttributeOptionId_AllowFiltering` (`SpecificationAttributeOptionId`,`AllowFiltering`,`ProductId`),
  CONSTRAINT `FK_Product_SpecificationAttribute_Mapping_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Product_SpecificationAttribute_Mapping_SpecificationAttribu8` FOREIGN KEY (`SpecificationAttributeOptionId`) REFERENCES `specificationattributeoption` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_specificationattribute_mapping`
--

LOCK TABLES `product_specificationattribute_mapping` WRITE;
/*!40000 ALTER TABLE `product_specificationattribute_mapping` DISABLE KEYS */;
INSERT INTO `product_specificationattribute_mapping` VALUES (1,4,0,1,NULL,0,1,1),(2,4,0,6,NULL,1,1,2),(3,4,0,8,NULL,1,1,3),(4,5,0,5,NULL,0,1,1),(5,5,0,7,NULL,1,1,2),(6,5,0,10,NULL,1,1,3),(7,5,0,13,NULL,0,1,4),(8,6,0,4,NULL,0,1,1),(9,6,0,6,NULL,1,1,2),(10,6,0,9,NULL,1,1,3),(11,6,0,11,NULL,0,1,4),(12,7,0,2,NULL,0,1,1),(13,7,0,6,NULL,1,1,2),(14,7,0,8,NULL,1,1,3),(15,7,0,11,NULL,0,1,4),(16,8,0,5,NULL,0,1,1),(17,8,0,7,NULL,1,1,2),(18,8,0,9,NULL,1,1,3),(19,8,0,12,NULL,0,1,4),(20,9,0,3,NULL,0,1,1),(21,9,0,7,NULL,1,1,2),(22,24,0,14,NULL,1,0,1),(23,25,0,14,NULL,1,0,1),(24,25,0,15,NULL,1,0,2),(25,25,0,16,NULL,1,0,3),(26,26,0,14,NULL,1,0,1);
/*!40000 ALTER TABLE `product_specificationattribute_mapping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:14:55
