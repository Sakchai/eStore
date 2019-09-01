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
-- Table structure for table `customer_customerrole_mapping`
--

DROP TABLE IF EXISTS `customer_customerrole_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `customer_customerrole_mapping` (
  `Customer_Id` int(11) NOT NULL,
  `CustomerRole_Id` int(11) NOT NULL,
  PRIMARY KEY (`Customer_Id`,`CustomerRole_Id`),
  KEY `IX_Customer_CustomerRole_Mapping_CustomerRole_Id` (`CustomerRole_Id`),
  KEY `IX_Customer_CustomerRole_Mapping_Customer_Id` (`Customer_Id`),
  CONSTRAINT `FK_Customer_CustomerRole_Mapping_CustomerRole_CustomerRole_Id` FOREIGN KEY (`CustomerRole_Id`) REFERENCES `customerrole` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Customer_CustomerRole_Mapping_Customer_Customer_Id` FOREIGN KEY (`Customer_Id`) REFERENCES `customer` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_customerrole_mapping`
--

LOCK TABLES `customer_customerrole_mapping` WRITE;
/*!40000 ALTER TABLE `customer_customerrole_mapping` DISABLE KEYS */;
INSERT INTO `customer_customerrole_mapping` VALUES (1,1),(1,2),(1,3),(4,3),(5,3),(6,3),(7,3),(8,3),(2,4),(3,4),(9,4),(10,4),(11,4),(12,4),(13,4);
/*!40000 ALTER TABLE `customer_customerrole_mapping` ENABLE KEYS */;
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
