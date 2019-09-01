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
-- Table structure for table `relatedproduct`
--

DROP TABLE IF EXISTS `relatedproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `relatedproduct` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId1` int(11) NOT NULL,
  `ProductId2` int(11) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RelatedProduct_ProductId1` (`ProductId1`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `relatedproduct`
--

LOCK TABLES `relatedproduct` WRITE;
/*!40000 ALTER TABLE `relatedproduct` DISABLE KEYS */;
INSERT INTO `relatedproduct` VALUES (1,3,2,0),(2,30,26,0),(3,30,24,0),(4,30,25,0),(5,25,27,0),(6,25,26,0),(7,25,24,0),(8,25,30,0),(9,20,23,0),(10,20,21,0),(11,20,19,0),(12,20,18,0),(13,19,23,0),(14,19,21,0),(15,19,20,0),(16,19,18,0),(17,30,27,0),(18,18,23,0),(19,29,30,0),(20,29,28,0),(21,42,40,0),(22,42,41,0),(23,41,40,0),(24,41,42,0),(25,37,39,0),(26,37,38,0),(27,38,37,0),(28,38,39,0),(29,39,37,0),(30,39,38,0),(31,34,36,0),(32,34,35,0),(33,35,36,0),(34,35,34,0),(35,29,31,0),(36,29,27,0),(37,18,21,0),(38,18,20,0),(39,18,19,0),(40,4,6,0),(41,4,9,0),(42,9,8,0),(43,9,6,0),(44,9,4,0),(45,9,5,0),(46,5,7,0),(47,5,6,0),(48,5,4,0),(49,5,9,0),(50,3,1,0),(51,2,4,0),(52,2,9,0),(53,2,3,0),(54,2,1,0),(55,4,5,0),(56,4,7,0),(57,7,9,0),(58,7,6,0),(59,16,20,0),(60,16,17,0),(61,16,13,0),(62,16,19,0),(63,3,4,0),(64,3,9,0),(65,6,7,0),(66,40,41,0),(67,6,8,0),(68,6,5,0),(69,8,6,0),(70,8,7,0),(71,8,4,0),(72,8,5,0),(73,7,8,0),(74,7,5,0),(75,6,4,0),(76,40,42,0);
/*!40000 ALTER TABLE `relatedproduct` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:11
