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
-- Table structure for table `picture`
--

DROP TABLE IF EXISTS `picture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `picture` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MimeType` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SeoFilename` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `AltAttribute` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `TitleAttribute` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsNew` bit(1) NOT NULL,
  `VirtualPath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `picture`
--

LOCK TABLES `picture` WRITE;
/*!40000 ALTER TABLE `picture` DISABLE KEYS */;
INSERT INTO `picture` VALUES (1,'image/jpeg','computers',NULL,NULL,1,NULL),(2,'image/pjpeg','desktops',NULL,NULL,0,NULL),(3,'image/pjpeg','notebooks',NULL,NULL,0,NULL),(4,'image/pjpeg','software',NULL,NULL,0,NULL),(5,'image/jpeg','electronics',NULL,NULL,0,NULL),(6,'image/jpeg','camera-photo',NULL,NULL,0,NULL),(7,'image/jpeg','cell-phones',NULL,NULL,0,NULL),(8,'image/pjpeg','accessories',NULL,NULL,0,NULL),(9,'image/jpeg','apparel',NULL,NULL,0,NULL),(10,'image/jpeg','shoes',NULL,NULL,1,NULL),(11,'image/jpeg','clothing',NULL,NULL,1,NULL),(12,'image/pjpeg','apparel-accessories',NULL,NULL,1,NULL),(13,'image/jpeg','digital-downloads',NULL,NULL,0,NULL),(14,'image/jpeg','book',NULL,NULL,1,NULL),(15,'image/jpeg','jewelry',NULL,NULL,1,NULL),(16,'image/jpeg','gift-cards',NULL,NULL,1,NULL),(17,'image/pjpeg','apple',NULL,NULL,1,NULL),(18,'image/pjpeg','hp',NULL,NULL,1,NULL),(19,'image/pjpeg','nike',NULL,NULL,1,NULL),(20,'image/jpeg','build-your-own-computer',NULL,NULL,0,NULL),(21,'image/jpeg','build-your-own-computer',NULL,NULL,1,NULL),(22,'image/jpeg','digital-storm-vanquish-3-custom-performance-pc',NULL,NULL,0,NULL),(23,'image/jpeg','lenovo-ideacentre-600-all-in-one-pc',NULL,NULL,0,NULL),(24,'image/jpeg','apple-macbook-pro-13-inch',NULL,NULL,0,NULL),(25,'image/jpeg','apple-macbook-pro-13-inch',NULL,NULL,1,NULL),(26,'image/jpeg','asus-n551jk-xo076h-laptop',NULL,NULL,0,NULL),(27,'image/jpeg','samsung-series-9-np900x4c-premium-ultrabook',NULL,NULL,1,NULL),(28,'image/jpeg','hp-spectre-xt-pro-ultrabook',NULL,NULL,1,NULL),(29,'image/jpeg','hp-spectre-xt-pro-ultrabook',NULL,NULL,1,NULL),(30,'image/jpeg','hp-envy-6-1180ca-156-inch-sleekbook',NULL,NULL,1,NULL),(31,'image/jpeg','lenovo-thinkpad-x1-carbon-laptop',NULL,NULL,1,NULL),(32,'image/jpeg','adobe-photoshop-cs4',NULL,NULL,0,NULL),(33,'image/jpeg','windows-8-pro',NULL,NULL,1,NULL),(34,'image/jpeg','sound-forge-pro-11-recurring',NULL,NULL,1,NULL),(35,'image/jpeg','nikon-d5500-dslr',NULL,NULL,0,NULL),(36,'image/jpeg','nikon-d5500-dslr',NULL,NULL,1,NULL),(37,'image/jpeg','canon-digital-slr-camera-black',NULL,NULL,1,NULL),(38,'image/jpeg','canon-digital-slr-camera-silver',NULL,NULL,1,NULL),(39,'image/jpeg','leica-t-mirrorless-digital-camera',NULL,NULL,0,NULL),(40,'image/jpeg','apple-icam',NULL,NULL,0,NULL),(41,'image/jpeg','htc-one-m8-android-l-50-lollipop',NULL,NULL,0,NULL),(42,'image/jpeg','htc-one-mini-blue',NULL,NULL,1,NULL),(43,'image/jpeg','htc-one-mini-blue',NULL,NULL,1,NULL),(44,'image/jpeg','nokia-lumia-1020',NULL,NULL,1,NULL),(45,'image/jpeg','beats-pill-20-wireless-speaker',NULL,NULL,0,NULL),(46,'image/jpeg','beats-pill-20-wireless-speaker',NULL,NULL,1,NULL),(47,'image/jpeg','universal-7-8-inch-tablet-cover',NULL,NULL,1,NULL),(48,'image/jpeg','portable-sound-speakers',NULL,NULL,1,NULL),(49,'image/pjpeg','natural-print',NULL,NULL,1,NULL),(50,'image/pjpeg','fresh-print',NULL,NULL,1,NULL),(51,'image/pjpeg','nike-floral-roshe-customized-running-shoes',NULL,NULL,1,NULL),(52,'image/pjpeg','nike-floral-roshe-customized-running-shoes',NULL,NULL,1,NULL),(53,'image/pjpeg','adidas-consortium-campus-80s-running-shoes',NULL,NULL,0,NULL),(54,'image/pjpeg','adidas-consortium-campus-80s-running-shoes',NULL,NULL,1,NULL),(55,'image/pjpeg','adidas-consortium-campus-80s-running-shoes',NULL,NULL,1,NULL),(56,'image/pjpeg','nike-sb-zoom-stefan-janoski-medium-mint',NULL,NULL,1,NULL),(57,'image/pjpeg','nike-tailwind-loose-short-sleeve-running-shirt',NULL,NULL,1,NULL),(58,'image/pjpeg','oversized-women-t-shirt',NULL,NULL,1,NULL),(59,'image/jpeg','custom-t-shirt',NULL,NULL,0,NULL),(60,'image/pjpeg','levis-511-jeans',NULL,NULL,1,NULL),(61,'image/pjpeg','levis-511-jeans',NULL,NULL,1,NULL),(62,'image/pjpeg','obey-propaganda-hat',NULL,NULL,1,NULL),(63,'image/jpeg','reversible-horseferry-check-belt',NULL,NULL,1,NULL),(64,'image/pjpeg','ray-ban-aviator-sunglasses',NULL,NULL,1,NULL),(65,'image/jpeg','night-visions',NULL,NULL,1,NULL),(66,'image/jpeg','if-you-wait-donation',NULL,NULL,1,NULL),(67,'image/jpeg','science-faith',NULL,NULL,1,NULL),(68,'image/jpeg','fahrenheit-451-by-ray-bradbury',NULL,NULL,0,NULL),(69,'image/jpeg','first-prize-pies',NULL,NULL,0,NULL),(70,'image/jpeg','pride-and-prejudice',NULL,NULL,1,NULL),(71,'image/pjpeg','elegant-gemstone-necklace-rental',NULL,NULL,0,NULL),(72,'image/pjpeg','flower-girl-bracelet',NULL,NULL,1,NULL),(73,'image/pjpeg','vintage-style-engagement-ring',NULL,NULL,1,NULL),(74,'image/jpeg','25-virtual-gift-card',NULL,NULL,0,NULL),(75,'image/jpeg','50-physical-gift-card',NULL,NULL,0,NULL),(76,'image/jpeg','100-physical-gift-card',NULL,NULL,0,NULL);
/*!40000 ALTER TABLE `picture` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:14
