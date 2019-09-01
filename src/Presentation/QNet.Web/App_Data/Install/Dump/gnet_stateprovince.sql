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
-- Table structure for table `stateprovince`
--

DROP TABLE IF EXISTS `stateprovince`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `stateprovince` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CountryId` int(11) NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Abbreviation` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Published` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_StateProvince_CountryId` (`CountryId`),
  CONSTRAINT `FK_StateProvince_Country_CountryId` FOREIGN KEY (`CountryId`) REFERENCES `country` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stateprovince`
--

LOCK TABLES `stateprovince` WRITE;
/*!40000 ALTER TABLE `stateprovince` DISABLE KEYS */;
INSERT INTO `stateprovince` VALUES (1,1,'AA (Armed Forces Americas)','AA',1,1),(2,1,'Texas','TX',1,1),(3,1,'Tennessee','TN',1,1),(4,1,'South Dakota','SD',1,1),(5,1,'South Carolina','SC',1,1),(6,1,'Rhode Island','RI',1,1),(7,1,'Puerto Rico','PR',1,1),(8,1,'Pennsylvania','PA',1,1),(9,1,'Palau','PW',1,1),(10,1,'Oregon','OR',1,1),(11,1,'Oklahoma','OK',1,1),(12,1,'Ohio','OH',1,1),(13,1,'Northern Mariana Islands','MP',1,1),(14,1,'North Dakota','ND',1,1),(15,1,'North Carolina','NC',1,1),(16,1,'New York','NY',1,1),(17,1,'Utah','UT',1,1),(18,1,'New Mexico','NM',1,1),(19,1,'Vermont','VT',1,1),(20,1,'Virginia','VA',1,1),(21,153,'Quebec','QC',1,1),(22,153,'Prince Edward Island','PE',1,1),(23,153,'Ontario','ON',1,1),(24,153,'Nunavut','NU',1,1),(25,153,'Nova Scotia','NS',1,1),(26,153,'Northwest Territories','NT',1,1),(27,153,'Newfoundland and Labrador','NL',1,1),(28,153,'New Brunswick','NB',1,1),(29,153,'Manitoba','MB',1,1),(30,153,'British Columbia','BC',1,1),(31,153,'Alberta','AB',1,1),(32,1,'Wyoming','WY',1,1),(33,1,'Wisconsin','WI',1,1),(34,1,'West Virginia','WV',1,1),(35,1,'Washington','WA',1,1),(36,1,'Virgin Islands','VI',1,1),(37,153,'Saskatchewan','SK',1,1),(38,1,'New Jersey','NJ',1,1),(39,1,'Nevada','NV',1,1),(40,1,'Georgia','GA',1,1),(41,1,'Florida','FL',1,1),(42,1,'Federated States of Micronesia','FM',1,1),(43,1,'District of Columbia','DC',1,1),(44,1,'Delaware','DE',1,1),(45,1,'Connecticut','CT',1,1),(46,1,'Colorado','CO',1,1),(47,1,'California','CA',1,1),(48,1,'Arkansas','AR',1,1),(49,1,'Arizona','AZ',1,1),(50,1,'AP (Armed Forces Pacific)','AP',1,1),(51,1,'American Samoa','AS',1,1),(52,1,'Alaska','AK',1,1),(53,1,'Alabama','AL',1,1),(54,1,'AE (Armed Forces Europe)','AE',1,1),(55,1,'Guam','GU',1,1),(56,1,'New Hampshire','NH',1,1),(57,1,'Hawaii','HI',1,1),(58,1,'Illinois','IL',1,1),(59,1,'Nebraska','NE',1,1),(60,1,'Montana','MT',1,1),(61,1,'Missouri','MO',1,1),(62,1,'Mississippi','MS',1,1),(63,1,'Minnesota','MN',1,1),(64,1,'Michigan','MI',1,1),(65,1,'Massachusetts','MA',1,1),(66,1,'Maryland','MD',1,1),(67,1,'Marshall Islands','MH',1,1),(68,1,'Maine','ME',1,1),(69,1,'Louisiana','LA',1,1),(70,1,'Kentucky','KY',1,1),(71,1,'Kansas','KS',1,1),(72,1,'Iowa','IA',1,1),(73,1,'Indiana','IN',1,1),(74,1,'Idaho','ID',1,1),(75,153,'Yukon Territory','YT',1,1);
/*!40000 ALTER TABLE `stateprovince` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:14:48
