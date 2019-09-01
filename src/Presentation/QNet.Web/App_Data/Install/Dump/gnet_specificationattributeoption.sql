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
-- Table structure for table `specificationattributeoption`
--

DROP TABLE IF EXISTS `specificationattributeoption`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `specificationattributeoption` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SpecificationAttributeId` int(11) NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ColorSquaresRgb` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SpecificationAttributeOption_SpecificationAttributeId` (`SpecificationAttributeId`),
  CONSTRAINT `FK_SpecificationAttributeOption_SpecificationAttribute_Specifi6` FOREIGN KEY (`SpecificationAttributeId`) REFERENCES `specificationattribute` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specificationattributeoption`
--

LOCK TABLES `specificationattributeoption` WRITE;
/*!40000 ALTER TABLE `specificationattributeoption` DISABLE KEYS */;
INSERT INTO `specificationattributeoption` VALUES (1,1,'13.0\'\'',NULL,2),(2,1,'13.3\'\'',NULL,3),(3,1,'14.0\'\'',NULL,4),(4,1,'15.0\'\'',NULL,4),(5,1,'15.6\'\'',NULL,5),(6,2,'Intel Core i5',NULL,1),(7,2,'Intel Core i7',NULL,2),(8,3,'4 GB',NULL,1),(9,3,'8 GB',NULL,2),(10,3,'16 GB',NULL,3),(11,4,'128 GB',NULL,7),(12,4,'500 GB',NULL,4),(13,4,'1 TB',NULL,3),(14,5,'Grey','#8a97a8',2),(15,5,'Red','#8a374a',3),(16,5,'Blue','#47476f',4);
/*!40000 ALTER TABLE `specificationattributeoption` ENABLE KEYS */;
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
