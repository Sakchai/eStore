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
-- Table structure for table `queuedemail`
--

DROP TABLE IF EXISTS `queuedemail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `queuedemail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PriorityId` int(11) NOT NULL,
  `From` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FromName` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `To` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ToName` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ReplyTo` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ReplyToName` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CC` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Bcc` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Subject` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Body` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AttachmentFilePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AttachmentFileName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AttachedDownloadId` int(11) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `DontSendBeforeDateUtc` datetime(6) DEFAULT NULL,
  `SentTries` int(11) NOT NULL,
  `SentOnUtc` datetime(6) DEFAULT NULL,
  `EmailAccountId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_QueuedEmail_EmailAccountId` (`EmailAccountId`),
  KEY `IX_QueuedEmail_CreatedOnUtc` (`CreatedOnUtc` DESC),
  KEY `IX_QueuedEmail_SentOnUtc_DontSendBeforeDateUtc_Extended` (`SentOnUtc`,`DontSendBeforeDateUtc`,`SentTries`),
  CONSTRAINT `FK_QueuedEmail_EmailAccount_EmailAccountId` FOREIGN KEY (`EmailAccountId`) REFERENCES `emailaccount` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `queuedemail`
--

LOCK TABLES `queuedemail` WRITE;
/*!40000 ALTER TABLE `queuedemail` DISABLE KEYS */;
/*!40000 ALTER TABLE `queuedemail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:25
