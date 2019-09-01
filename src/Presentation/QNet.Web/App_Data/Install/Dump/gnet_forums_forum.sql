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
-- Table structure for table `forums_forum`
--

DROP TABLE IF EXISTS `forums_forum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `forums_forum` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ForumGroupId` int(11) NOT NULL,
  `Name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NumTopics` int(11) NOT NULL,
  `NumPosts` int(11) NOT NULL,
  `LastTopicId` int(11) NOT NULL,
  `LastPostId` int(11) NOT NULL,
  `LastPostCustomerId` int(11) NOT NULL,
  `LastPostTime` datetime(6) DEFAULT NULL,
  `DisplayOrder` int(11) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `UpdatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Forums_Forum_ForumGroupId` (`ForumGroupId`),
  KEY `IX_Forums_Forum_DisplayOrder` (`DisplayOrder`),
  CONSTRAINT `FK_Forums_Forum_Forums_Group_ForumGroupId` FOREIGN KEY (`ForumGroupId`) REFERENCES `forums_group` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `forums_forum`
--

LOCK TABLES `forums_forum` WRITE;
/*!40000 ALTER TABLE `forums_forum` DISABLE KEYS */;
INSERT INTO `forums_forum` VALUES (1,1,'New Products','Discuss new products and industry trends',0,0,0,0,0,NULL,1,'2019-08-23 05:44:52.005094','2019-08-23 05:44:52.005207'),(2,1,'Mobile Devices Forum','Discuss the mobile phone market',0,0,0,0,0,NULL,10,'2019-08-23 05:44:52.103421','2019-08-23 05:44:52.103421'),(3,1,'Packaging & Shipping','Discuss packaging & shipping',0,0,0,0,0,NULL,20,'2019-08-23 05:44:52.163337','2019-08-23 05:44:52.163337');
/*!40000 ALTER TABLE `forums_forum` ENABLE KEYS */;
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
