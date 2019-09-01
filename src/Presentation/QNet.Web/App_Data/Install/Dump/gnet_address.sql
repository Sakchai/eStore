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
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `address` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Company` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CountryId` int(11) DEFAULT NULL,
  `StateProvinceId` int(11) DEFAULT NULL,
  `County` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `City` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Address1` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Address2` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ZipPostalCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FaxNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CustomAttributes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Address_CountryId` (`CountryId`),
  KEY `IX_Address_StateProvinceId` (`StateProvinceId`),
  CONSTRAINT `FK_Address_Country_CountryId` FOREIGN KEY (`CountryId`) REFERENCES `country` (`Id`),
  CONSTRAINT `FK_Address_StateProvince_StateProvinceId` FOREIGN KEY (`StateProvinceId`) REFERENCES `stateprovince` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,'John','Smith','admin@yourStore.com','QNet Solutions Ltd',1,16,NULL,'New York','21 West 52nd Street','','10021','12345678','',NULL,'2019-08-23 05:43:50.749925'),(2,'Steve','Gates','steve_gates@nopCommerce.com','Steve Company',1,47,NULL,'Los Angeles','750 Bel Air Rd.','','90077','87654321','',NULL,'2019-08-23 05:43:55.947762'),(3,'Arthur','Holmes','arthur_holmes@nopCommerce.com','Holmes Company',233,NULL,NULL,'London','221B Baker Street','','NW1 6XE','111222333','',NULL,'2019-08-23 05:43:56.537443'),(4,'James','Pan','james_pan@nopCommerce.com','Pan Company',233,NULL,NULL,'St Andrews','St Katharine’s West 16','','KY16 9AX','369258147','',NULL,'2019-08-23 05:43:56.964192'),(5,'Brenda','Lindgren','brenda_lindgren@nopCommerce.com','Brenda Company',1,52,NULL,'Ketchikan','1249 Tongass Avenue, Suite B','','99901','14785236','',NULL,'2019-08-23 05:43:57.537778'),(6,'Victoria','Terces','victoria_victoria@nopCommerce.com','Terces Company',153,37,NULL,'Saskatoon','201 1st Avenue South','','S7K 1J9','45612378','',NULL,'2019-08-23 05:43:58.028412'),(7,NULL,NULL,NULL,NULL,1,16,NULL,'New York','21 West 52nd Street',NULL,'10021',NULL,NULL,NULL,'2019-08-23 05:44:53.984234'),(8,NULL,NULL,NULL,NULL,1,47,NULL,'Los Angeles','300 South Spring Stree',NULL,'90013',NULL,NULL,NULL,'2019-08-23 05:44:54.142443'),(9,'John','Smith','affiliate_email@gmail.com','Company name here...',1,16,NULL,'New York','21 West 52nd Street',NULL,'10021','123456789',NULL,NULL,'2019-08-23 05:44:54.765458'),(10,'Steve','Gates','steve_gates@nopCommerce.com','Steve Company',1,47,NULL,'Los Angeles','750 Bel Air Rd.','','90077','87654321','',NULL,'2019-08-23 05:43:55.947762'),(11,'Steve','Gates','steve_gates@nopCommerce.com','Steve Company',1,47,NULL,'Los Angeles','750 Bel Air Rd.','','90077','87654321','',NULL,'2019-08-23 05:43:55.947762'),(12,'Arthur','Holmes','arthur_holmes@nopCommerce.com','Holmes Company',233,NULL,NULL,'London','221B Baker Street','','NW1 6XE','111222333','',NULL,'2019-08-23 05:43:56.537443'),(13,'Arthur','Holmes','arthur_holmes@nopCommerce.com','Holmes Company',233,NULL,NULL,'London','221B Baker Street','','NW1 6XE','111222333','',NULL,'2019-08-23 05:43:56.537443'),(14,'James','Pan','james_pan@nopCommerce.com','Pan Company',233,NULL,NULL,'St Andrews','St Katharine’s West 16','','KY16 9AX','369258147','',NULL,'2019-08-23 05:43:56.964192'),(15,'Brenda','Lindgren','brenda_lindgren@nopCommerce.com','Brenda Company',1,52,NULL,'Ketchikan','1249 Tongass Avenue, Suite B','','99901','14785236','',NULL,'2019-08-23 05:43:57.537778'),(16,'Brenda','Lindgren','brenda_lindgren@nopCommerce.com','Brenda Company',1,52,NULL,'Ketchikan','1249 Tongass Avenue, Suite B','','99901','14785236','',NULL,'2019-08-23 05:43:57.537778'),(17,'Brenda','Lindgren','brenda_lindgren@nopCommerce.com','Brenda Company',1,52,NULL,'Ketchikan','1249 Tongass Avenue, Suite B','','99901','14785236','',NULL,'2019-08-23 05:43:57.537778'),(18,'Victoria','Terces','victoria_victoria@nopCommerce.com','Terces Company',153,37,NULL,'Saskatoon','201 1st Avenue South','','S7K 1J9','45612378','',NULL,'2019-08-23 05:43:58.028412'),(19,'Victoria','Terces','victoria_victoria@nopCommerce.com','Terces Company',153,37,NULL,'Saskatoon','201 1st Avenue South','','S7K 1J9','45612378','',NULL,'2019-08-23 05:43:58.028412');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:33
