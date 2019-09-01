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
-- Table structure for table `giftcard`
--

DROP TABLE IF EXISTS `giftcard`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `giftcard` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PurchasedWithOrderItemId` int(11) DEFAULT NULL,
  `GiftCardTypeId` int(11) NOT NULL,
  `Amount` decimal(18,4) NOT NULL,
  `IsGiftCardActivated` bit(1) NOT NULL,
  `GiftCardCouponCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RecipientName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RecipientEmail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SenderName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SenderEmail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Message` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsRecipientNotified` bit(1) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_GiftCard_PurchasedWithOrderItemId` (`PurchasedWithOrderItemId`),
  CONSTRAINT `FK_GiftCard_OrderItem_PurchasedWithOrderItemId` FOREIGN KEY (`PurchasedWithOrderItemId`) REFERENCES `orderitem` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `giftcard`
--

LOCK TABLES `giftcard` WRITE;
/*!40000 ALTER TABLE `giftcard` DISABLE KEYS */;
INSERT INTO `giftcard` VALUES (1,3,0,25.0000,0,'','Brenda Lindgren','brenda_lindgren@nopCommerce.com','Steve Gates','steve_gates@nopCommerce.com','',0,'2019-08-23 05:44:55.845348');
/*!40000 ALTER TABLE `giftcard` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:29
