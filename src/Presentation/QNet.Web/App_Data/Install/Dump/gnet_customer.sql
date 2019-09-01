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
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `customer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerGuid` varchar(64) NOT NULL,
  `Username` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailToRevalidate` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `AdminComment` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsTaxExempt` bit(1) NOT NULL,
  `AffiliateId` int(11) NOT NULL,
  `VendorId` int(11) NOT NULL,
  `HasShoppingCartItems` bit(1) NOT NULL,
  `RequireReLogin` bit(1) NOT NULL,
  `FailedLoginAttempts` int(11) NOT NULL,
  `CannotLoginUntilDateUtc` datetime(6) DEFAULT NULL,
  `Active` bit(1) NOT NULL,
  `Deleted` bit(1) NOT NULL,
  `IsSystemAccount` bit(1) NOT NULL,
  `SystemName` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `LastIpAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `LastLoginDateUtc` datetime(6) DEFAULT NULL,
  `LastActivityDateUtc` datetime(6) NOT NULL,
  `RegisteredInStoreId` int(11) NOT NULL,
  `BillingAddress_Id` int(11) DEFAULT NULL,
  `ShippingAddress_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `CustomerGuid` (`CustomerGuid`),
  KEY `IX_Customer_BillingAddress_Id` (`BillingAddress_Id`),
  KEY `IX_Customer_ShippingAddress_Id` (`ShippingAddress_Id`),
  KEY `IX_Customer_Email` (`Email`(255)),
  KEY `IX_Customer_Username` (`Username`(255)),
  KEY `IX_Customer_CustomerGuid` (`CustomerGuid`),
  KEY `IX_Customer_SystemName` (`SystemName`(255)),
  KEY `IX_Customer_CreatedOnUtc` (`CreatedOnUtc` DESC),
  CONSTRAINT `FK_Customer_Address_BillingAddress_Id` FOREIGN KEY (`BillingAddress_Id`) REFERENCES `address` (`Id`),
  CONSTRAINT `FK_Customer_Address_ShippingAddress_Id` FOREIGN KEY (`ShippingAddress_Id`) REFERENCES `address` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'BFBA0754-4F54-4E78-8872-47B740F55590','admin@yourStore.com','admin@yourStore.com',NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,'127.0.0.1','2019-08-23 05:43:50.637351','2019-08-23 05:58:23.578221','2019-08-23 06:31:27.859153',1,1,1),(2,'EF808117-D6BF-4FFD-9E1B-2D45CE6E9CE9',NULL,'builtin@search_engine_record.com',NULL,'Built-in system guest record used for requests from search engines.',0,0,0,0,0,0,NULL,1,0,1,'SearchEngine',NULL,'2019-08-23 05:43:52.081090',NULL,'2019-08-23 05:43:52.081090',1,NULL,NULL),(3,'662BF3CC-8047-4E02-BE19-18491D200EB7',NULL,'builtin@background-task-record.com',NULL,'Built-in system record used for background tasks.',0,0,0,0,0,0,NULL,1,0,1,'BackgroundTask',NULL,'2019-08-23 05:43:52.162091',NULL,'2019-08-23 05:43:52.162092',1,NULL,NULL),(4,'1695E1CB-FBFE-443A-9ED8-01443FE37D36','steve_gates@nopCommerce.com','steve_gates@nopCommerce.com',NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,NULL,'2019-08-23 05:43:55.858140',NULL,'2019-08-23 05:43:55.858140',1,2,2),(5,'3B1FB7F6-FA11-4006-BE83-7748C85D9F24','arthur_holmes@nopCommerce.com','arthur_holmes@nopCommerce.com',NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,NULL,'2019-08-23 05:43:56.448821',NULL,'2019-08-23 05:43:56.448821',1,3,3),(6,'EA5AB8A5-78C2-49BC-82E8-113E8613EC23','james_pan@nopCommerce.com','james_pan@nopCommerce.com',NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,NULL,'2019-08-23 05:43:56.930567',NULL,'2019-08-23 05:43:56.930567',1,4,4),(7,'7AA5D16E-6351-4CBD-88BD-AC000E81F741','brenda_lindgren@nopCommerce.com','brenda_lindgren@nopCommerce.com',NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,NULL,'2019-08-23 05:43:57.424630',NULL,'2019-08-23 05:43:57.424630',1,5,5),(8,'36F65A99-C4AB-4DC7-8DB8-28C677AC2D9F','victoria_victoria@nopCommerce.com','victoria_victoria@nopCommerce.com',NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,NULL,'2019-08-23 05:43:57.889887',NULL,'2019-08-23 05:43:57.889887',1,6,6),(9,'EF5AD093-54DB-4154-8997-466DAED690E5',NULL,NULL,NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,'127.0.0.1','2019-08-23 05:45:28.781047',NULL,'2019-08-23 05:45:28.781094',0,NULL,NULL),(10,'2B5ED486-A1E5-4D3F-940E-0B6C52F4FB23',NULL,NULL,NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,'127.0.0.1','2019-08-23 05:48:53.722871',NULL,'2019-08-23 05:48:53.722871',0,NULL,NULL),(11,'9F79E707-047F-4172-98D0-3125FAF4B601',NULL,NULL,NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,'127.0.0.1','2019-08-23 05:52:48.538939',NULL,'2019-08-23 05:52:48.539275',0,NULL,NULL),(12,'7073A6F1-3E61-41B9-BBD7-77A11B6F39CA',NULL,NULL,NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,'127.0.0.1','2019-08-23 05:57:44.485926',NULL,'2019-08-23 05:57:44.486033',0,NULL,NULL),(13,'4709DBC7-90F5-43DA-9047-E74D761E512B',NULL,NULL,NULL,NULL,0,0,0,0,0,0,NULL,1,0,0,NULL,'127.0.0.1','2019-08-23 08:26:31.467327',NULL,'2019-08-23 08:34:13.215025',0,NULL,NULL);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:04
