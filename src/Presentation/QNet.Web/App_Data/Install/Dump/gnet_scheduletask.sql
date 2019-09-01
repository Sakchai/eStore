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
-- Table structure for table `scheduletask`
--

DROP TABLE IF EXISTS `scheduletask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `scheduletask` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Seconds` int(11) NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Enabled` bit(1) NOT NULL,
  `StopOnError` bit(1) NOT NULL,
  `LastStartUtc` datetime(6) DEFAULT NULL,
  `LastEndUtc` datetime(6) DEFAULT NULL,
  `LastSuccessUtc` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scheduletask`
--

LOCK TABLES `scheduletask` WRITE;
/*!40000 ALTER TABLE `scheduletask` DISABLE KEYS */;
INSERT INTO `scheduletask` VALUES (1,'Send emails',60,'QNet.Services.Messages.QueuedMessagesSendTask, QNet.Services',1,0,'2019-08-23 08:35:31.877562','2019-08-23 08:35:31.998950','2019-08-23 08:35:31.998950'),(2,'Keep alive',300,'QNet.Services.Common.KeepAliveTask, QNet.Services',1,0,'2019-08-23 08:32:17.766893','2019-08-23 08:32:17.962423','2019-08-23 08:32:17.962423'),(3,'Delete guests',600,'QNet.Services.Customers.DeleteGuestsTask, QNet.Services',1,0,'2019-08-23 08:32:19.112951','2019-08-23 08:32:19.389712','2019-08-23 08:32:19.389712'),(4,'Clear cache',600,'QNet.Services.Caching.ClearCacheTask, QNet.Services',0,0,NULL,NULL,NULL),(5,'Clear log',3600,'QNet.Services.Logging.ClearLogTask, QNet.Services',0,0,NULL,NULL,NULL),(6,'Update currency exchange rates',3600,'QNet.Services.Directory.UpdateExchangeRateTask, QNet.Services',1,0,'2019-08-23 08:11:36.223642','2019-08-23 08:11:36.352670','2019-08-23 08:11:36.352670');
/*!40000 ALTER TABLE `scheduletask` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:13
