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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderGuid` varchar(64) NOT NULL,
  `StoreId` int(11) NOT NULL,
  `CustomerId` int(11) NOT NULL,
  `BillingAddressId` int(11) NOT NULL,
  `ShippingAddressId` int(11) DEFAULT NULL,
  `PickupAddressId` int(11) DEFAULT NULL,
  `PickupInStore` bit(1) NOT NULL,
  `OrderStatusId` int(11) NOT NULL,
  `ShippingStatusId` int(11) NOT NULL,
  `PaymentStatusId` int(11) NOT NULL,
  `PaymentMethodSystemName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CustomerCurrencyCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CurrencyRate` decimal(18,8) NOT NULL,
  `CustomerTaxDisplayTypeId` int(11) NOT NULL,
  `VatNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OrderSubtotalInclTax` decimal(18,4) NOT NULL,
  `OrderSubtotalExclTax` decimal(18,4) NOT NULL,
  `OrderSubTotalDiscountInclTax` decimal(18,4) NOT NULL,
  `OrderSubTotalDiscountExclTax` decimal(18,4) NOT NULL,
  `OrderShippingInclTax` decimal(18,4) NOT NULL,
  `OrderShippingExclTax` decimal(18,4) NOT NULL,
  `PaymentMethodAdditionalFeeInclTax` decimal(18,4) NOT NULL,
  `PaymentMethodAdditionalFeeExclTax` decimal(18,4) NOT NULL,
  `TaxRates` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OrderTax` decimal(18,4) NOT NULL,
  `OrderDiscount` decimal(18,4) NOT NULL,
  `OrderTotal` decimal(18,4) NOT NULL,
  `RefundedAmount` decimal(18,4) NOT NULL,
  `RewardPointsHistoryEntryId` int(11) DEFAULT NULL,
  `CheckoutAttributeDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CheckoutAttributesXml` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CustomerLanguageId` int(11) NOT NULL,
  `AffiliateId` int(11) NOT NULL,
  `CustomerIp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AllowStoringCreditCardNumber` bit(1) NOT NULL,
  `CardType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CardName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CardNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MaskedCreditCardNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CardCvv2` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CardExpirationMonth` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CardExpirationYear` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AuthorizationTransactionId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AuthorizationTransactionCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `AuthorizationTransactionResult` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CaptureTransactionId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CaptureTransactionResult` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SubscriptionTransactionId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PaidDateUtc` datetime(6) DEFAULT NULL,
  `ShippingMethod` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ShippingRateComputationMethodSystemName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CustomValuesXml` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Deleted` bit(1) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `CustomOrderNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `OrderGuid` (`OrderGuid`),
  UNIQUE KEY `IX_Order_RewardPointsHistoryEntryId` (`RewardPointsHistoryEntryId`),
  KEY `IX_Order_BillingAddressId` (`BillingAddressId`),
  KEY `IX_Order_CustomerId` (`CustomerId`),
  KEY `IX_Order_PickupAddressId` (`PickupAddressId`),
  KEY `IX_Order_ShippingAddressId` (`ShippingAddressId`),
  KEY `IX_Order_CreatedOnUtc` (`CreatedOnUtc` DESC),
  CONSTRAINT `FK_Order_Address_BillingAddressId` FOREIGN KEY (`BillingAddressId`) REFERENCES `address` (`Id`),
  CONSTRAINT `FK_Order_Address_PickupAddressId` FOREIGN KEY (`PickupAddressId`) REFERENCES `address` (`Id`),
  CONSTRAINT `FK_Order_Address_ShippingAddressId` FOREIGN KEY (`ShippingAddressId`) REFERENCES `address` (`Id`),
  CONSTRAINT `FK_Order_Customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Order_RewardPointsHistory_RewardPointsHistoryEntryId` FOREIGN KEY (`RewardPointsHistoryEntryId`) REFERENCES `rewardpointshistory` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'B06065E3-81CF-4133-8EC2-D14F695D31B5',1,4,10,11,NULL,0,20,20,30,'Payments.CheckMoneyOrder','USD',1.00000000,0,'',1855.0000,1855.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'0:0;',0.0000,0.0000,1855.0000,0.0000,NULL,'','',1,0,'127.0.0.1',0,'','','','','','','','','','','','','','2019-08-23 05:44:55.049116','Ground','Shipping.FixedByWeightByTotal','',0,'2019-08-23 05:44:55.050508','1'),(2,'5869BBD7-FBE1-433A-9842-EA489CCA87E5',1,5,12,13,NULL,0,10,20,10,'Payments.CheckMoneyOrder','USD',1.00000000,0,'',2460.0000,2460.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'0:0;',0.0000,0.0000,2460.0000,0.0000,NULL,'','',1,0,'127.0.0.1',0,'','','','','','','','','','','','','',NULL,'Next Day Air','Shipping.FixedByWeightByTotal','',0,'2019-08-23 05:44:56.140043','2'),(3,'E0E449BE-52BF-4FDC-8DA8-612523EEB3FA',1,6,14,NULL,NULL,0,10,10,10,'Payments.CheckMoneyOrder','USD',1.00000000,0,'',8.8000,8.8000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'0:0;',0.0000,0.0000,8.8000,0.0000,NULL,'','',1,0,'127.0.0.1',0,'','','','','','','','','','','','','',NULL,'','','',0,'2019-08-23 05:44:56.740738','3'),(4,'E17574AE-58AC-45A7-8CF5-9368F76DA27C',1,7,15,17,16,1,20,30,30,'Payments.CheckMoneyOrder','USD',1.00000000,0,'',102.0000,102.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'0:0;',0.0000,0.0000,102.0000,0.0000,NULL,'','',1,0,'127.0.0.1',0,'','','','','','','','','','','','','','2019-08-23 05:44:57.409044','Pickup in store','Pickup.PickupInStore','',0,'2019-08-23 05:44:57.409294','4'),(5,'16CF52D3-BDFD-4294-95FA-F38B285A468E',1,8,18,19,NULL,0,30,40,30,'Payments.CheckMoneyOrder','USD',1.00000000,0,'',43.5000,43.5000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'0:0;',0.0000,0.0000,43.5000,0.0000,NULL,'','',1,0,'127.0.0.1',0,'','','','','','','','','','','','','','2019-08-23 05:44:58.947282','Ground','Shipping.FixedByWeightByTotal','',0,'2019-08-23 05:44:58.947287','5');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:44
