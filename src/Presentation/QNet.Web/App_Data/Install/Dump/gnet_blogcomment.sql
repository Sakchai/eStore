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
-- Table structure for table `blogcomment`
--

DROP TABLE IF EXISTS `blogcomment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `blogcomment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerId` int(11) NOT NULL,
  `CommentText` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsApproved` bit(1) NOT NULL,
  `StoreId` int(11) NOT NULL,
  `BlogPostId` int(11) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_BlogComment_BlogPostId` (`BlogPostId`),
  KEY `IX_BlogComment_CustomerId` (`CustomerId`),
  KEY `IX_BlogComment_StoreId` (`StoreId`),
  CONSTRAINT `FK_BlogComment_BlogPost_BlogPostId` FOREIGN KEY (`BlogPostId`) REFERENCES `blogpost` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_BlogComment_Customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_BlogComment_Store_StoreId` FOREIGN KEY (`StoreId`) REFERENCES `store` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blogcomment`
--

LOCK TABLES `blogcomment` WRITE;
/*!40000 ALTER TABLE `blogcomment` DISABLE KEYS */;
INSERT INTO `blogcomment` VALUES (1,1,'This is a sample comment for this blog post',1,1,1,'2019-08-23 05:44:52.818041'),(2,1,'This is a sample comment for this blog post',1,1,2,'2019-08-23 05:44:52.818161');
/*!40000 ALTER TABLE `blogcomment` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:07
