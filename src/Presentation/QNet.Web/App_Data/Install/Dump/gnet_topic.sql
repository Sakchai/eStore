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
-- Table structure for table `topic`
--

DROP TABLE IF EXISTS `topic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `topic` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SystemName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IncludeInSitemap` bit(1) NOT NULL,
  `IncludeInTopMenu` bit(1) NOT NULL,
  `IncludeInFooterColumn1` bit(1) NOT NULL,
  `IncludeInFooterColumn2` bit(1) NOT NULL,
  `IncludeInFooterColumn3` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  `AccessibleWhenStoreClosed` bit(1) NOT NULL,
  `IsPasswordProtected` bit(1) NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Body` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Published` bit(1) NOT NULL,
  `TopicTemplateId` int(11) NOT NULL,
  `MetaKeywords` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MetaDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MetaTitle` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SubjectToAcl` bit(1) NOT NULL,
  `LimitedToStores` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `topic`
--

LOCK TABLES `topic` WRITE;
/*!40000 ALTER TABLE `topic` DISABLE KEYS */;
INSERT INTO `topic` VALUES (1,'AboutUs',0,0,1,0,0,20,0,0,NULL,'About us','<p>Put your &quot;About Us&quot; information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(2,'CheckoutAsGuestOrRegister',0,0,0,0,0,1,0,0,NULL,'','<p><strong>Register and save time!</strong><br />Register with us for future convenience:</p><ul><li>Fast and easy check out</li><li>Easy access to your order history and status</li></ul>',1,1,NULL,NULL,NULL,0,0),(3,'ConditionsOfUse',0,0,1,0,0,15,0,0,NULL,'Conditions of Use','<p>Put your conditions of use information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(4,'ContactUs',0,0,0,0,0,1,0,0,NULL,'','<p>Put your contact information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(5,'ForumWelcomeMessage',0,0,0,0,0,1,0,0,NULL,'Forums','<p>Put your welcome message here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(6,'HomepageText',0,0,0,0,0,1,0,0,NULL,'Welcome to our store','<p>Online shopping is the process consumers go through to purchase products or services over the Internet. You can edit this in the admin site.</p><p>If you have questions, see the <a href=\"http://docs.nopcommerce.com/\">Documentation</a>, or post in the <a href=\"https://www.nopcommerce.com/boards/\">Forums</a> at <a href=\"https://www.nopcommerce.com\">nopCommerce.com</a></p>',1,1,NULL,NULL,NULL,0,0),(7,'LoginRegistrationInfo',0,0,0,0,0,1,0,0,NULL,'About login / registration','<p>Put your login / registration information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(8,'PrivacyInfo',0,0,1,0,0,10,0,0,NULL,'Privacy notice','<p>Put your privacy policy information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(9,'PageNotFound',0,0,0,0,0,1,0,0,NULL,'','<p><strong>The page you requested was not found, and we have a fine guess why.</strong></p><ul><li>If you typed the URL directly, please make sure the spelling is correct.</li><li>The page no longer exists. In this case, we profusely apologize for the inconvenience and for any damage this may cause.</li></ul>',1,1,NULL,NULL,NULL,0,0),(10,'ShippingInfo',0,0,1,0,0,5,0,0,NULL,'Shipping & returns','<p>Put your shipping &amp; returns information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(11,'ApplyVendor',0,0,0,0,0,1,0,0,NULL,'','<p>Put your apply vendor instructions here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0),(12,'VendorTermsOfService',0,0,0,0,0,1,0,0,NULL,'Terms of services for vendors','<p>Put your terms of service information here. You can edit this in the admin site.</p>',1,1,NULL,NULL,NULL,0,0);
/*!40000 ALTER TABLE `topic` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:15
