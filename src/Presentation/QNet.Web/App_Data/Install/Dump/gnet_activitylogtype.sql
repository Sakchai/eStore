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
-- Table structure for table `activitylogtype`
--

DROP TABLE IF EXISTS `activitylogtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activitylogtype` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SystemKeyword` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Enabled` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activitylogtype`
--

LOCK TABLES `activitylogtype` WRITE;
/*!40000 ALTER TABLE `activitylogtype` DISABLE KEYS */;
INSERT INTO `activitylogtype` VALUES (1,'AddNewAddressAttribute','Add a new address attribute',_binary ''),(2,'EditManufacturer','Edit a manufacturer',_binary ''),(3,'EditMeasureDimension','Edit a measure dimension',_binary ''),(4,'EditMeasureWeight','Edit a measure weight',_binary ''),(5,'EditMessageTemplate','Edit a message template',_binary ''),(6,'EditNews','Edit a news',_binary ''),(7,'EditOrder','Edit an order',_binary ''),(8,'EditLanguage','Edit a language',_binary ''),(9,'EditPlugin','Edit a plugin',_binary ''),(10,'EditProductAttribute','Edit a product attribute',_binary ''),(11,'EditProductReview','Edit a product review',_binary ''),(12,'EditPromotionProviders','Edit promotion providers',_binary ''),(13,'EditReturnRequest','Edit a return request',_binary ''),(14,'EditReviewType','Edit a review type',_binary ''),(15,'EditSettings','Edit setting(s)',_binary ''),(16,'EditProduct','Edit a product',_binary ''),(17,'EditGiftCard','Edit a gift card',_binary ''),(18,'EditEmailAccount','Edit an email account',_binary ''),(19,'EditDiscount','Edit a discount',_binary ''),(20,'DeleteWidget','Delete a widget',_binary ''),(21,'EditActivityLogTypes','Edit activity log types',_binary ''),(22,'EditAddressAttribute','Edit an address attribute',_binary ''),(23,'EditAddressAttributeValue','Edit an address attribute value',_binary ''),(24,'EditAffiliate','Edit an affiliate',_binary ''),(25,'EditBlogPost','Edit a blog post',_binary ''),(26,'EditCampaign','Edit a campaign',_binary ''),(27,'EditCategory','Edit category',_binary ''),(28,'EditCheckoutAttribute','Edit a checkout attribute',_binary ''),(29,'EditCountry','Edit a country',_binary ''),(30,'EditCurrency','Edit a currency',_binary ''),(31,'EditCustomer','Edit a customer',_binary ''),(32,'EditCustomerAttribute','Edit a customer attribute',_binary ''),(33,'EditCustomerAttributeValue','Edit a customer attribute value',_binary ''),(34,'EditCustomerRole','Edit a customer role',_binary ''),(35,'EditStateProvince','Edit a state or province',_binary ''),(36,'EditStore','Edit a store',_binary ''),(37,'EditTask','Edit a task',_binary ''),(38,'EditSpecAttribute','Edit a specification attribute',_binary ''),(39,'PublicStore.ContactUs','Public store. Use contact us form',_binary '\0'),(40,'PublicStore.AddToCompareList','Public store. Add to compare list',_binary '\0'),(41,'PublicStore.AddToShoppingCart','Public store. Add to shopping cart',_binary '\0'),(42,'PublicStore.AddToWishlist','Public store. Add to wishlist',_binary '\0'),(43,'PublicStore.Login','Public store. Login',_binary '\0'),(44,'PublicStore.Logout','Public store. Logout',_binary '\0'),(45,'PublicStore.AddProductReview','Public store. Add product review',_binary '\0'),(46,'PublicStore.AddNewsComment','Public store. Add news comment',_binary '\0'),(47,'PublicStore.AddBlogComment','Public store. Add blog comment',_binary '\0'),(48,'PublicStore.AddForumTopic','Public store. Add forum topic',_binary '\0'),(49,'PublicStore.EditForumTopic','Public store. Edit forum topic',_binary '\0'),(50,'PublicStore.DeleteForumTopic','Public store. Delete forum topic',_binary '\0'),(51,'PublicStore.AddForumPost','Public store. Add forum post',_binary '\0'),(52,'PublicStore.EditForumPost','Public store. Edit forum post',_binary '\0'),(53,'PublicStore.DeleteForumPost','Public store. Delete forum post',_binary '\0'),(54,'PublicStore.SendPM','Public store. Send PM',_binary '\0'),(55,'DeleteWarehouse','Delete a warehouse',_binary ''),(56,'PublicStore.PlaceOrder','Public store. Place an order',_binary '\0'),(57,'PublicStore.ViewManufacturer','Public store. View a manufacturer',_binary '\0'),(58,'EditVendor','Edit a vendor',_binary ''),(59,'EditVendorAttribute','Edit a vendor attribute',_binary ''),(60,'EditVendorAttributeValue','Edit a vendor attribute value',_binary ''),(61,'EditWarehouse','Edit a warehouse',_binary ''),(62,'EditTopic','Edit a topic',_binary ''),(63,'EditWidget','Edit a widget',_binary ''),(64,'Impersonation.Started','Customer impersonation session. Started',_binary ''),(65,'Impersonation.Finished','Customer impersonation session. Finished',_binary ''),(66,'ImportCategories','Categories were imported',_binary ''),(67,'ImportManufacturers','Manufacturers were imported',_binary ''),(68,'ImportProducts','Products were imported',_binary ''),(69,'ImportStates','States were imported',_binary ''),(70,'InstallNewPlugin','Install a new plugin',_binary ''),(71,'UninstallPlugin','Uninstall a plugin',_binary ''),(72,'PublicStore.ViewCategory','Public store. View a category',_binary '\0'),(73,'PublicStore.ViewProduct','Public store. View a product',_binary '\0'),(74,'UploadNewPlugin','Upload a plugin',_binary ''),(75,'DeleteVendorAttributeValue','Delete a vendor attribute value',_binary ''),(76,'DeleteVendor','Delete a vendor',_binary ''),(77,'AddNewNews','Add a new news',_binary ''),(78,'AddNewProduct','Add a new product',_binary ''),(79,'AddNewProductAttribute','Add a new product attribute',_binary ''),(80,'AddNewSetting','Add a new setting',_binary ''),(81,'AddNewSpecAttribute','Add a new specification attribute',_binary ''),(82,'AddNewStateProvince','Add a new state or province',_binary ''),(83,'AddNewMeasureWeight','Add a new measure weight',_binary ''),(84,'AddNewStore','Add a new store',_binary ''),(85,'AddNewReviewType','Add a new review type',_binary ''),(86,'AddNewVendor','Add a new vendor',_binary ''),(87,'AddNewVendorAttribute','Add a new vendor attribute',_binary ''),(88,'AddNewVendorAttributeValue','Add a new vendor attribute value',_binary ''),(89,'AddNewWarehouse','Add a new warehouse',_binary ''),(90,'AddNewWidget','Add a new widget',_binary ''),(91,'AddNewTopic','Add a new topic',_binary ''),(92,'AddNewMeasureDimension','Add a new measure dimension',_binary ''),(93,'AddNewManufacturer','Add a new manufacturer',_binary ''),(94,'AddNewLanguage','Add a new language',_binary ''),(95,'AddNewAddressAttributeValue','Add a new address attribute value',_binary ''),(96,'AddNewAffiliate','Add a new affiliate',_binary ''),(97,'AddNewBlogPost','Add a new blog post',_binary ''),(98,'AddNewCampaign','Add a new campaign',_binary ''),(99,'AddNewCategory','Add a new category',_binary ''),(100,'AddNewCheckoutAttribute','Add a new checkout attribute',_binary ''),(101,'AddNewCountry','Add a new country',_binary ''),(102,'AddNewCurrency','Add a new currency',_binary ''),(103,'AddNewCustomer','Add a new customer',_binary ''),(104,'AddNewCustomerAttribute','Add a new customer attribute',_binary ''),(105,'AddNewCustomerAttributeValue','Add a new customer attribute value',_binary ''),(106,'AddNewCustomerRole','Add a new customer role',_binary ''),(107,'AddNewDiscount','Add a new discount',_binary ''),(108,'AddNewEmailAccount','Add a new email account',_binary ''),(109,'AddNewGiftCard','Add a new gift card',_binary ''),(110,'DeleteActivityLog','Delete activity log',_binary ''),(111,'DeleteAddressAttribute','Delete an address attribute',_binary ''),(112,'DeleteAddressAttributeValue','Delete an address attribute value',_binary ''),(113,'DeleteAffiliate','Delete an affiliate',_binary ''),(114,'DeleteNews','Delete a news',_binary ''),(115,'DeleteNewsComment','Delete a news comment',_binary ''),(116,'DeleteOrder','Delete an order',_binary ''),(117,'DeletePlugin','Delete a plugin',_binary ''),(118,'DeleteProduct','Delete a product',_binary ''),(119,'DeleteProductAttribute','Delete a product attribute',_binary ''),(120,'DeleteProductReview','Delete a product review',_binary ''),(121,'DeleteReturnRequest','Delete a return request',_binary ''),(122,'DeleteReviewType','Delete a review type',_binary ''),(123,'DeleteSetting','Delete a setting',_binary ''),(124,'DeleteSpecAttribute','Delete a specification attribute',_binary ''),(125,'DeleteStateProvince','Delete a state or province',_binary ''),(126,'DeleteStore','Delete a store',_binary ''),(127,'DeleteSystemLog','Delete system log',_binary ''),(128,'DeleteTopic','Delete a topic',_binary ''),(129,'DeleteMessageTemplate','Delete a message template',_binary ''),(130,'DeleteVendorAttribute','Delete a vendor attribute',_binary ''),(131,'DeleteMeasureWeight','Delete a measure weight',_binary ''),(132,'DeleteManufacturer','Delete a manufacturer',_binary ''),(133,'DeleteBlogPost','Delete a blog post',_binary ''),(134,'DeleteBlogPostComment','Delete a blog post comment',_binary ''),(135,'DeleteCampaign','Delete a campaign',_binary ''),(136,'DeleteCategory','Delete category',_binary ''),(137,'DeleteCheckoutAttribute','Delete a checkout attribute',_binary ''),(138,'DeleteCountry','Delete a country',_binary ''),(139,'DeleteCurrency','Delete a currency',_binary ''),(140,'DeleteCustomer','Delete a customer',_binary ''),(141,'DeleteCustomerAttribute','Delete a customer attribute',_binary ''),(142,'DeleteCustomerAttributeValue','Delete a customer attribute value',_binary ''),(143,'DeleteCustomerRole','Delete a customer role',_binary ''),(144,'DeleteDiscount','Delete a discount',_binary ''),(145,'DeleteEmailAccount','Delete an email account',_binary ''),(146,'DeleteGiftCard','Delete a gift card',_binary ''),(147,'DeleteLanguage','Delete a language',_binary ''),(148,'DeleteMeasureDimension','Delete a measure dimension',_binary ''),(149,'UploadNewTheme','Upload a theme',_binary '');
/*!40000 ALTER TABLE `activitylogtype` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:40