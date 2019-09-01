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
-- Table structure for table `permissionrecord`
--

DROP TABLE IF EXISTS `permissionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `permissionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SystemName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Category` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permissionrecord`
--

LOCK TABLES `permissionrecord` WRITE;
/*!40000 ALTER TABLE `permissionrecord` DISABLE KEYS */;
INSERT INTO `permissionrecord` VALUES (1,'Access admin area','AccessAdminPanel','Standard'),(2,'Admin area. Allow Customer Impersonation','AllowCustomerImpersonation','Customers'),(3,'Admin area. Manage Products','ManageProducts','Catalog'),(4,'Admin area. Manage Categories','ManageCategories','Catalog'),(5,'Admin area. Manage Manufacturers','ManageManufacturers','Catalog'),(6,'Admin area. Manage Product Reviews','ManageProductReviews','Catalog'),(7,'Admin area. Manage Product Tags','ManageProductTags','Catalog'),(8,'Admin area. Manage Attributes','ManageAttributes','Catalog'),(9,'Admin area. Manage Customers','ManageCustomers','Customers'),(10,'Admin area. Manage Vendors','ManageVendors','Customers'),(11,'Admin area. Manage Current Carts','ManageCurrentCarts','Orders'),(12,'Admin area. Manage Orders','ManageOrders','Orders'),(13,'Admin area. Manage Recurring Payments','ManageRecurringPayments','Orders'),(14,'Admin area. Manage Gift Cards','ManageGiftCards','Orders'),(15,'Admin area. Manage Return Requests','ManageReturnRequests','Orders'),(16,'Admin area. Access order country report','OrderCountryReport','Orders'),(17,'Admin area. Manage Affiliates','ManageAffiliates','Promo'),(18,'Admin area. Manage Campaigns','ManageCampaigns','Promo'),(19,'Admin area. Manage Discounts','ManageDiscounts','Promo'),(20,'Admin area. Manage Newsletter Subscribers','ManageNewsletterSubscribers','Promo'),(21,'Admin area. Manage Polls','ManagePolls','Content Management'),(22,'Admin area. Manage News','ManageNews','Content Management'),(23,'Admin area. Manage Blog','ManageBlog','Content Management'),(24,'Admin area. Manage Widgets','ManageWidgets','Content Management'),(25,'Admin area. Manage Topics','ManageTopics','Content Management'),(26,'Admin area. Manage Forums','ManageForums','Content Management'),(27,'Admin area. Manage Message Templates','ManageMessageTemplates','Content Management'),(28,'Admin area. Manage Countries','ManageCountries','Configuration'),(29,'Admin area. Manage Languages','ManageLanguages','Configuration'),(30,'Admin area. Manage Settings','ManageSettings','Configuration'),(31,'Admin area. Manage Payment Methods','ManagePaymentMethods','Configuration'),(32,'Admin area. Manage External Authentication Methods','ManageExternalAuthenticationMethods','Configuration'),(33,'Admin area. Manage Tax Settings','ManageTaxSettings','Configuration'),(34,'Admin area. Manage Shipping Settings','ManageShippingSettings','Configuration'),(35,'Admin area. Manage Currencies','ManageCurrencies','Configuration'),(36,'Admin area. Manage Activity Log','ManageActivityLog','Configuration'),(37,'Admin area. Manage ACL','ManageACL','Configuration'),(38,'Admin area. Manage Email Accounts','ManageEmailAccounts','Configuration'),(39,'Admin area. Manage Stores','ManageStores','Configuration'),(40,'Admin area. Manage Plugins','ManagePlugins','Configuration'),(41,'Admin area. Manage System Log','ManageSystemLog','Configuration'),(42,'Admin area. Manage Message Queue','ManageMessageQueue','Configuration'),(43,'Admin area. Manage Maintenance','ManageMaintenance','Configuration'),(44,'Admin area. HTML Editor. Manage pictures','HtmlEditor.ManagePictures','Configuration'),(45,'Admin area. Manage Schedule Tasks','ManageScheduleTasks','Configuration'),(46,'Public store. Display Prices','DisplayPrices','PublicStore'),(47,'Public store. Enable shopping cart','EnableShoppingCart','PublicStore'),(48,'Public store. Enable wishlist','EnableWishlist','PublicStore'),(49,'Public store. Allow navigation','PublicStoreAllowNavigation','PublicStore'),(50,'Public store. Access a closed store','AccessClosedStore','PublicStore');
/*!40000 ALTER TABLE `permissionrecord` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:14:55
