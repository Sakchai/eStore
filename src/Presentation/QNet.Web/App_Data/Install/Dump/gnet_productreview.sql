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
-- Table structure for table `productreview`
--

DROP TABLE IF EXISTS `productreview`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `productreview` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `StoreId` int(11) NOT NULL,
  `IsApproved` bit(1) NOT NULL,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ReviewText` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ReplyText` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CustomerNotifiedOfReply` bit(1) NOT NULL,
  `Rating` int(11) NOT NULL,
  `HelpfulYesTotal` int(11) NOT NULL,
  `HelpfulNoTotal` int(11) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductReview_CustomerId` (`CustomerId`),
  KEY `IX_ProductReview_ProductId` (`ProductId`),
  KEY `IX_ProductReview_StoreId` (`StoreId`),
  CONSTRAINT `FK_ProductReview_Customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProductReview_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProductReview_Store_StoreId` FOREIGN KEY (`StoreId`) REFERENCES `store` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productreview`
--

LOCK TABLES `productreview` WRITE;
/*!40000 ALTER TABLE `productreview` DISABLE KEYS */;
INSERT INTO `productreview` VALUES (1,1,25,1,1,'Some sample review','This sample review is for the adidas Consortium Campus 80s Running Shoes. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771970'),(2,1,27,1,1,'Some sample review','This sample review is for the Nike Tailwind Loose Short-Sleeve Running Shirt. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771971'),(3,1,28,1,1,'Some sample review','This sample review is for the Oversized Women T-Shirt. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771971'),(4,1,29,1,1,'Some sample review','This sample review is for the Custom T-Shirt. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771972'),(5,1,30,1,1,'Some sample review','This sample review is for the Levi\'s 511 Jeans. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771973'),(6,1,31,1,1,'Some sample review','This sample review is for the Obey Propaganda Hat. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771974'),(7,1,38,1,1,'Some sample review','This sample review is for the First Prize Pies. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771976'),(8,1,37,1,1,'Some sample review','This sample review is for the Fahrenheit 451 by Ray Bradbury. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771976'),(9,1,23,1,1,'Some sample review','This sample review is for the Portable Sound Speakers. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771969'),(10,1,39,1,1,'Some sample review','This sample review is for the Pride and Prejudice. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771977'),(11,1,40,1,1,'Some sample review','This sample review is for the Elegant Gemstone Necklace (rental). I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771978'),(12,1,43,1,1,'Some sample review','This sample review is for the $25 Virtual Gift Card. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771979'),(13,1,36,1,1,'Some sample review','This sample review is for the Science & Faith. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771975'),(14,1,22,1,1,'Some sample review','This sample review is for the Universal 7-8 Inch Tablet Cover. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771968'),(15,1,14,1,1,'Some sample review','This sample review is for the Nikon D5500 DSLR - Black. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771964'),(16,1,17,1,1,'Some sample review','This sample review is for the Apple iCam. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771965'),(17,1,16,1,1,'Some sample review','This sample review is for the Leica T Mirrorless Digital Camera. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771964'),(18,1,44,1,1,'Some sample review','This sample review is for the $50 Physical Gift Card. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771980'),(19,1,11,1,1,'Some sample review','This sample review is for the Windows 8 Pro. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771962'),(20,1,10,1,1,'Some sample review','This sample review is for the Adobe Photoshop CS4. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771962'),(21,1,9,1,1,'Some sample review','This sample review is for the Lenovo Thinkpad X1 Carbon Laptop. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771961'),(22,1,8,1,1,'Some sample review','This sample review is for the HP Envy 6-1180ca 15.6-Inch Sleekbook. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771960'),(23,1,7,1,1,'Some sample review','This sample review is for the HP Spectre XT Pro UltraBook. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771959'),(24,1,6,1,1,'Some sample review','This sample review is for the Samsung Series 9 NP900X4C Premium Ultrabook. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771959'),(25,1,5,1,1,'Some sample review','This sample review is for the Asus N551JK-XO076H Laptop. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771958'),(26,1,4,1,1,'Some sample review','This sample review is for the Apple MacBook Pro 13-inch. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771957'),(27,1,3,1,1,'Some sample review','This sample review is for the Lenovo IdeaCentre 600 All-in-One PC. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,4,0,0,'2019-08-23 05:44:47.771956'),(28,1,2,1,1,'Some sample review','This sample review is for the Digital Storm VANQUISH 3 Custom Performance PC. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771955'),(29,1,1,1,1,'Some sample review','This sample review is for the Build your own computer. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771589'),(30,1,19,1,1,'Some sample review','This sample review is for the HTC One Mini Blue. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771966'),(31,1,45,1,1,'Some sample review','This sample review is for the $100 Physical Gift Card. I\'ve been waiting for this product to be available. It is priced just right.',NULL,0,5,0,0,'2019-08-23 05:44:47.771981');
/*!40000 ALTER TABLE `productreview` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:27
