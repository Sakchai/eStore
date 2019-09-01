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
-- Table structure for table `genericattribute`
--

DROP TABLE IF EXISTS `genericattribute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `genericattribute` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EntityId` int(11) NOT NULL,
  `KeyGroup` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Key` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StoreId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_GenericAttribute_EntityId_and_KeyGroup` (`EntityId`,`KeyGroup`(255))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genericattribute`
--

LOCK TABLES `genericattribute` WRITE;
/*!40000 ALTER TABLE `genericattribute` DISABLE KEYS */;
INSERT INTO `genericattribute` VALUES (1,1,'Customer','FirstName','John',0),(2,1,'Customer','LastName','Smith',0),(3,4,'Customer','FirstName','Steve',0),(4,4,'Customer','LastName','Gates',0),(5,5,'Customer','FirstName','Arthur',0),(6,5,'Customer','LastName','Holmes',0),(7,6,'Customer','FirstName','James',0),(8,6,'Customer','LastName','Pan',0),(9,7,'Customer','FirstName','Brenda',0),(10,7,'Customer','LastName','Lindgren',0),(11,8,'Customer','FirstName','Victoria',0),(12,8,'Customer','LastName','Terces',0),(13,1,'Customer','product-advanced-mode','True',0),(14,1,'Customer','ProductPage.HidePricesBlock','True',0),(15,1,'Customer','ProductPage.HideShippingBlock','False',0),(16,1,'Customer','ProductPage.HideInventoryBlock','True',0),(17,1,'Customer','ProductPage.HidePicturesBlock','False',0),(18,1,'Customer','ProductPage.HideProductAttributesBlock','False',0),(19,1,'Customer','ProductPage.HideSpecificationAttributeBlock','False',0),(20,1,'Customer','ProductPage.HideGiftCardBlock','False',0),(21,1,'Customer','ProductPage.HideDownloadableBlock','False',0),(22,1,'Customer','ProductPage.HideRentalBlock','False',0),(23,1,'Customer','ProductPage.HideRecurringBlock','False',0),(24,1,'Customer','ProductPage.HideSEOBlock','False',0),(25,1,'Customer','ProductPage.HideRelatedProductsBlock','False',0),(26,1,'Customer','ProductPage.HideCrossSellsProductsBlock','False',0),(27,1,'Customer','ProductPage.HidePurchasedWithOrdersBlock','False',0),(28,1,'Customer','ProductPage.HideInfoBlock','True',0),(29,1,'Customer','LastContinueShoppingPage','http://localhost:15536/camera-photo',1),(30,1,'Customer','category-advanced-mode','True',0),(31,1,'Customer','CategoryPage.HideDisplayBlock','False',0),(32,1,'Customer','CategoryPage.HideMappingsBlock','False',0),(33,1,'Customer','CategoryPage.HideSEOBlock','False',0),(34,1,'Customer','CategoryPage.HideProductsBlock','False',0),(35,13,'Customer','LastContinueShoppingPage','http://localhost:15536/camera-photo',1);
/*!40000 ALTER TABLE `genericattribute` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:18
