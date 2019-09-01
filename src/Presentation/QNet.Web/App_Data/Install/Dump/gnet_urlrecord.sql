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
-- Table structure for table `urlrecord`
--

DROP TABLE IF EXISTS `urlrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `urlrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EntityId` int(11) NOT NULL,
  `EntityName` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Slug` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsActive` bit(1) NOT NULL,
  `LanguageId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UrlRecord_Slug` (`Slug`(255)),
  KEY `IX_UrlRecord_Custom_1` (`EntityId`,`EntityName`(255),`LanguageId`,`IsActive`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `urlrecord`
--

LOCK TABLES `urlrecord` WRITE;
/*!40000 ALTER TABLE `urlrecord` DISABLE KEYS */;
INSERT INTO `urlrecord` VALUES (1,1,'Topic','about-us',1,0),(2,2,'Topic','checkoutasguestorregister',1,0),(3,3,'Topic','conditions-of-use',1,0),(4,4,'Topic','contactus',1,0),(5,5,'Topic','forums',1,0),(6,6,'Topic','welcome-to-our-store',1,0),(7,7,'Topic','about-login-registration',1,0),(8,8,'Topic','privacy-notice',1,0),(9,9,'Topic','pagenotfound',1,0),(10,10,'Topic','shipping-returns',1,0),(11,11,'Topic','applyvendor',1,0),(12,12,'Topic','terms-of-services-for-vendors',1,0),(13,1,'Category','computers',1,0),(14,2,'Category','desktops',1,0),(15,3,'Category','notebooks',1,0),(16,4,'Category','software',1,0),(17,5,'Category','electronics',1,0),(18,6,'Category','camera-photo',1,0),(19,7,'Category','cell-phones',1,0),(20,8,'Category','others',1,0),(21,9,'Category','apparel',1,0),(22,10,'Category','shoes',1,0),(23,11,'Category','clothing',1,0),(24,12,'Category','accessories',1,0),(25,13,'Category','digital-downloads',1,0),(26,14,'Category','books',1,0),(27,15,'Category','jewelry',1,0),(28,16,'Category','gift-cards',1,0),(29,1,'Manufacturer','apple',1,0),(30,2,'Manufacturer','hp',1,0),(31,3,'Manufacturer','nike',1,0),(32,1,'ProductTag','awesome',1,0),(33,2,'ProductTag','computer',1,0),(34,3,'ProductTag','cool',1,0),(35,4,'ProductTag','compact',1,0),(36,5,'ProductTag','nice',1,0),(37,6,'ProductTag','game',1,0),(38,7,'ProductTag','camera',1,0),(39,8,'ProductTag','cell',1,0),(40,9,'ProductTag','shoes-2',1,0),(41,10,'ProductTag','apparel-2',1,0),(42,11,'ProductTag','jeans',1,0),(43,12,'ProductTag','shirt',1,0),(44,13,'ProductTag','digital',1,0),(45,14,'ProductTag','book',1,0),(46,15,'ProductTag','jewelry-2',1,0),(47,16,'ProductTag','gift',1,0),(48,1,'Product','build-your-own-computer',1,0),(49,2,'Product','digital-storm-vanquish-3-custom-performance-pc',1,0),(50,3,'Product','lenovo-ideacentre-600-all-in-one-pc',1,0),(51,4,'Product','apple-macbook-pro-13-inch',1,0),(52,5,'Product','asus-n551jk-xo076h-laptop',1,0),(53,6,'Product','samsung-series-9-np900x4c-premium-ultrabook',1,0),(54,7,'Product','hp-spectre-xt-pro-ultrabook',1,0),(55,8,'Product','hp-envy-6-1180ca-156-inch-sleekbook',1,0),(56,9,'Product','lenovo-thinkpad-x1-carbon-laptop',1,0),(57,10,'Product','adobe-photoshop-cs4',1,0),(58,11,'Product','windows-8-pro',1,0),(59,12,'Product','sound-forge-pro-11-recurring',1,0),(60,13,'Product','nikon-d5500-dslr',1,0),(61,14,'Product','nikon-d5500-dslr-black',1,0),(62,15,'Product','nikon-d5500-dslr-red',1,0),(63,16,'Product','leica-t-mirrorless-digital-camera',1,0),(64,17,'Product','apple-icam',1,0),(65,18,'Product','htc-one-m8-android-l-50-lollipop',1,0),(66,19,'Product','htc-one-mini-blue',1,0),(67,20,'Product','nokia-lumia-1020',1,0),(68,21,'Product','beats-pill-20-wireless-speaker',1,0),(69,22,'Product','universal-7-8-inch-tablet-cover',1,0),(70,23,'Product','portable-sound-speakers',1,0),(71,24,'Product','nike-floral-roshe-customized-running-shoes',1,0),(72,25,'Product','adidas-consortium-campus-80s-running-shoes',1,0),(73,26,'Product','nike-sb-zoom-stefan-janoski-medium-mint',1,0),(74,27,'Product','nike-tailwind-loose-short-sleeve-running-shirt',1,0),(75,28,'Product','oversized-women-t-shirt',1,0),(76,29,'Product','custom-t-shirt',1,0),(77,30,'Product','levis-511-jeans',1,0),(78,31,'Product','obey-propaganda-hat',1,0),(79,32,'Product','reversible-horseferry-check-belt',1,0),(80,33,'Product','ray-ban-aviator-sunglasses',1,0),(81,34,'Product','night-visions',1,0),(82,35,'Product','if-you-wait-donation',1,0),(83,36,'Product','science-faith',1,0),(84,37,'Product','fahrenheit-451-by-ray-bradbury',1,0),(85,38,'Product','first-prize-pies',1,0),(86,39,'Product','pride-and-prejudice',1,0),(87,40,'Product','elegant-gemstone-necklace-rental',1,0),(88,41,'Product','flower-girl-bracelet',1,0),(89,42,'Product','vintage-style-engagement-ring',1,0),(90,43,'Product','25-virtual-gift-card',1,0),(91,44,'Product','50-physical-gift-card',1,0),(92,45,'Product','100-physical-gift-card',1,0),(93,1,'BlogPost','how-a-blog-can-help-your-growing-e-commerce-business',1,1),(94,2,'BlogPost','why-your-online-store-needs-a-wish-list',1,1),(95,1,'NewsItem','about-nopcommerce',1,1),(96,2,'NewsItem','nopcommerce-new-release',1,1),(97,3,'NewsItem','new-online-store-is-open',1,1),(98,1,'Vendor','vendor-1',1,0),(99,2,'Vendor','vendor-2',1,0);
/*!40000 ALTER TABLE `urlrecord` ENABLE KEYS */;
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
