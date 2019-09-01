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
-- Table structure for table `download`
--

DROP TABLE IF EXISTS `download`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `download` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DownloadGuid` varchar(64) NOT NULL,
  `UseDownloadUrl` bit(1) NOT NULL,
  `DownloadUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DownloadBinary` longblob,
  `ContentType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Filename` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Extension` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsNew` bit(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DownloadGuid` (`DownloadGuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `download`
--

LOCK TABLES `download` WRITE;
/*!40000 ALTER TABLE `download` DISABLE KEYS */;
INSERT INTO `download` VALUES (1,'DA7F344A-03B7-4763-BA1F-4B85CB99E563',0,NULL,'','application/x-zip-co','Night_Vision_1','.zip',1),(2,'6530EC5F-25F4-4E2D-A949-3D1AE4D84399',0,NULL,'','text/plain','Night_Vision_1','.txt',1),(3,'C7EE2510-F9D3-4294-83CD-5B7BBE25A8FC',0,NULL,'','application/x-zip-co','If_You_Wait_1','.zip',1),(4,'9B792396-57FF-461A-8C8C-A7F25569EE5D',0,NULL,'','text/plain','If_You_Wait_1','.txt',1),(5,'6D67D566-E4E3-4EBE-AA6E-203BBA6E5C75',0,NULL,'','application/x-zip-co','Science_And_Faith','.zip',1);
/*!40000 ALTER TABLE `download` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:16
