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
-- Table structure for table `product_producttag_mapping`
--

DROP TABLE IF EXISTS `product_producttag_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `product_producttag_mapping` (
  `Product_Id` int(11) NOT NULL,
  `ProductTag_Id` int(11) NOT NULL,
  PRIMARY KEY (`Product_Id`,`ProductTag_Id`),
  KEY `IX_Product_ProductTag_Mapping_ProductTag_Id` (`ProductTag_Id`),
  CONSTRAINT `FK_Product_ProductTag_Mapping_ProductTag_ProductTag_Id` FOREIGN KEY (`ProductTag_Id`) REFERENCES `producttag` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Product_ProductTag_Mapping_Product_Product_Id` FOREIGN KEY (`Product_Id`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_producttag_mapping`
--

LOCK TABLES `product_producttag_mapping` WRITE;
/*!40000 ALTER TABLE `product_producttag_mapping` DISABLE KEYS */;
INSERT INTO `product_producttag_mapping` VALUES (1,1),(3,1),(4,1),(5,1),(9,1),(10,1),(11,1),(18,1),(19,1),(20,1),(34,1),(35,1),(36,1),(37,1),(40,1),(41,1),(42,1),(1,2),(2,2),(3,2),(4,2),(5,2),(6,2),(7,2),(8,2),(9,2),(10,2),(11,2),(12,2),(21,2),(22,2),(2,3),(8,3),(12,3),(13,3),(16,3),(20,3),(21,3),(22,3),(24,3),(25,3),(26,3),(27,3),(28,3),(29,3),(30,3),(31,3),(33,3),(4,4),(5,4),(6,4),(8,4),(9,4),(18,4),(19,4),(6,5),(7,5),(37,5),(43,5),(12,6),(13,7),(16,7),(20,7),(18,8),(19,8),(24,9),(25,9),(24,10),(25,10),(26,10),(27,10),(28,10),(29,10),(30,10),(31,10),(33,10),(26,11),(30,11),(27,12),(28,12),(29,12),(34,13),(35,13),(36,13),(37,14),(38,14),(39,14),(40,15),(41,15),(42,15),(43,16);
/*!40000 ALTER TABLE `product_producttag_mapping` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:12
