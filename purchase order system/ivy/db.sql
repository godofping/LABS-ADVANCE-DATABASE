/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - sandandgravel
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`sandandgravel` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `sandandgravel`;

/*Table structure for table `accounts` */

DROP TABLE IF EXISTS `accounts`;

CREATE TABLE `accounts` (
  `accountid` int(6) NOT NULL AUTO_INCREMENT,
  `accountusername` varchar(60) DEFAULT NULL,
  `accountpassword` varchar(60) DEFAULT NULL,
  `accountfullname` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`accountid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `accounts` */

insert  into `accounts`(`accountid`,`accountusername`,`accountpassword`,`accountfullname`) values (1,'admin','admin','admin1');

/*Table structure for table `purhcaseorderdetails` */

DROP TABLE IF EXISTS `purhcaseorderdetails`;

CREATE TABLE `purhcaseorderdetails` (
  `purchaseorderdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `purchaseorderid` int(6) DEFAULT NULL,
  `supplyid` int(6) DEFAULT NULL,
  `purhcaseorderdetailquantity` int(6) DEFAULT NULL,
  `purhcaseorderdetailunitprice` float DEFAULT NULL,
  PRIMARY KEY (`purchaseorderdetailid`),
  KEY `FK_PurhcaseOrderDetails` (`supplyid`),
  KEY `FK_PurhcaseOrder2Details` (`purchaseorderid`),
  CONSTRAINT `FK_PurhcaseOrder2Details` FOREIGN KEY (`purchaseorderid`) REFERENCES `purhcaseorders` (`purchaseorderid`),
  CONSTRAINT `FK_PurhcaseOrderDetails` FOREIGN KEY (`supplyid`) REFERENCES `supplies` (`supplyid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purhcaseorderdetails` */

/*Table structure for table `purhcaseorders` */

DROP TABLE IF EXISTS `purhcaseorders`;

CREATE TABLE `purhcaseorders` (
  `purchaseorderid` int(6) NOT NULL AUTO_INCREMENT,
  `supplierid` int(6) DEFAULT NULL,
  `accountid` int(6) DEFAULT NULL,
  `purchaseordername` varchar(60) DEFAULT NULL,
  `purhcaseorderrequestdate` date DEFAULT NULL,
  `purhcaseorderdeliverydate` date DEFAULT NULL,
  `purchaseorderstatus` varchar(60) DEFAULT NULL,
  `purhcaseordertotalamount` float DEFAULT NULL,
  PRIMARY KEY (`purchaseorderid`),
  KEY `FK_PurhcaseOrders` (`supplierid`),
  KEY `FK_Purh1caseOrders` (`accountid`),
  CONSTRAINT `FK_Purh1caseOrders` FOREIGN KEY (`accountid`) REFERENCES `accounts` (`accountid`),
  CONSTRAINT `FK_PurhcaseOrders` FOREIGN KEY (`supplierid`) REFERENCES `suppliers` (`supplierid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purhcaseorders` */

/*Table structure for table `suppliers` */

DROP TABLE IF EXISTS `suppliers`;

CREATE TABLE `suppliers` (
  `supplierid` int(6) NOT NULL AUTO_INCREMENT,
  `suppliername` varchar(60) DEFAULT NULL,
  `suppliercontactnumber` varchar(60) DEFAULT NULL,
  `supplieraddress` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`supplierid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `suppliers` */

insert  into `suppliers`(`supplierid`,`suppliername`,`suppliercontactnumber`,`supplieraddress`) values (1,'Clarie Jane Construction Supply Supplier','09754363944','Midsayap, North Cotabato'),(2,'Thea Giant Incorporated','09168545225','Tacurong City, Sultan Kudarat'),(3,'Supplier 2','032-6565-562','Davao City');

/*Table structure for table `supplies` */

DROP TABLE IF EXISTS `supplies`;

CREATE TABLE `supplies` (
  `supplyid` int(6) NOT NULL AUTO_INCREMENT,
  `supplyname` varchar(60) DEFAULT NULL,
  `supplyunit` varchar(60) DEFAULT NULL,
  `supplyunitprice` float DEFAULT NULL,
  `supplystocks` int(6) DEFAULT NULL,
  PRIMARY KEY (`supplyid`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

/*Data for the table `supplies` */

insert  into `supplies`(`supplyid`,`supplyname`,`supplyunit`,`supplyunitprice`,`supplystocks`) values (3,'Conduit, PVC, D-25mm ','pcs',78,15),(4,'Flexible conduit, D-25mm','roll',900,10),(5,'THHN electrical wire, 12mm2','box',2970,5),(6,'THHN electrical wire, 14mm2','box',2025,4),(7,'Utility box, PVC, deep type ','pcs',30,40),(8,'Junction box, PVC, deep type','pcs',35,50),(9,'Electrical tape, big','roll',38,50),(10,'Convenience outlet, 2-gang','set',185,20),(11,'LED flourescent lamp, recessed, with housing & diffusers','set',1450,26),(12,'Sand ','cu m ',1200,25),(13,'Gravel','cu m ',100,26),(14,'Fine pea washout','cans',310,200),(15,'Primer paint/red oxide','gals',290,14);

/*Table structure for table `accounts_view` */

DROP TABLE IF EXISTS `accounts_view`;

/*!50001 DROP VIEW IF EXISTS `accounts_view` */;
/*!50001 DROP TABLE IF EXISTS `accounts_view` */;

/*!50001 CREATE TABLE  `accounts_view`(
 `Account ID` int(6) ,
 `Account Username` varchar(60) ,
 `Account Password` varchar(60) ,
 `Account Full Name` varchar(60) 
)*/;

/*Table structure for table `purchaseorders_view` */

DROP TABLE IF EXISTS `purchaseorders_view`;

/*!50001 DROP VIEW IF EXISTS `purchaseorders_view` */;
/*!50001 DROP TABLE IF EXISTS `purchaseorders_view` */;

/*!50001 CREATE TABLE  `purchaseorders_view`(
 `Purchase Order ID` int(6) ,
 `Supplier ID` int(6) ,
 `Account ID` int(6) ,
 `Purchase Order Name` varchar(60) ,
 `Purchase Order Request Date` date ,
 `Purchase Order Delivery Date` date ,
 `Purchase Order Status` varchar(60) ,
 `Purchase Order Total Amount` float ,
 `Supplier Name` varchar(60) ,
 `Supplier Contact Number` varchar(60) ,
 `Supplier Address` varchar(200) ,
 `Account Username` varchar(60) ,
 `Account Password` varchar(60) ,
 `Account Full Name` varchar(60) 
)*/;

/*Table structure for table `purhcaseorderdetails_view` */

DROP TABLE IF EXISTS `purhcaseorderdetails_view`;

/*!50001 DROP VIEW IF EXISTS `purhcaseorderdetails_view` */;
/*!50001 DROP TABLE IF EXISTS `purhcaseorderdetails_view` */;

/*!50001 CREATE TABLE  `purhcaseorderdetails_view`(
 `Account ID` int(6) ,
 `Purchase Order Name` varchar(60) ,
 `Purchase Order Request Date` date ,
 `Purchase Order Delivery Date` date ,
 `Purchase Order Status` varchar(60) ,
 `Purchase Order Total Amount` float ,
 `Supplier Name` varchar(60) ,
 `Supplier Contact Number` varchar(60) ,
 `Supplier Address` varchar(200) ,
 `Account Username` varchar(60) ,
 `Account Password` varchar(60) ,
 `Account Full Name` varchar(60) ,
 `Purchase Order Detail ID` int(6) ,
 `Purchase Order ID` int(6) ,
 `Supply ID` int(6) ,
 `Purchase Order Detail Quantity` int(6) ,
 `Purchase Order Detail Unit Price` float ,
 `Supply Name` varchar(60) ,
 `Supply Unit` varchar(60) ,
 `Supply Unit Price` float ,
 `Supply Stocks` int(6) ,
 `Supplier ID` int(6) 
)*/;

/*Table structure for table `suppliers_view` */

DROP TABLE IF EXISTS `suppliers_view`;

/*!50001 DROP VIEW IF EXISTS `suppliers_view` */;
/*!50001 DROP TABLE IF EXISTS `suppliers_view` */;

/*!50001 CREATE TABLE  `suppliers_view`(
 `Supplier ID` int(6) ,
 `Supplier Name` varchar(60) ,
 `Supplier Contact Number` varchar(60) ,
 `Supplier Address` varchar(200) 
)*/;

/*Table structure for table `supplies_view` */

DROP TABLE IF EXISTS `supplies_view`;

/*!50001 DROP VIEW IF EXISTS `supplies_view` */;
/*!50001 DROP TABLE IF EXISTS `supplies_view` */;

/*!50001 CREATE TABLE  `supplies_view`(
 `Supply ID` int(6) ,
 `Supply Name` varchar(60) ,
 `Supply Unit` varchar(60) ,
 `Supply Unit Price` float ,
 `Supply Stocks` int(6) 
)*/;

/*View structure for view accounts_view */

/*!50001 DROP TABLE IF EXISTS `accounts_view` */;
/*!50001 DROP VIEW IF EXISTS `accounts_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `accounts_view` AS select `accounts`.`accountid` AS `Account ID`,`accounts`.`accountusername` AS `Account Username`,`accounts`.`accountpassword` AS `Account Password`,`accounts`.`accountfullname` AS `Account Full Name` from `accounts` */;

/*View structure for view purchaseorders_view */

/*!50001 DROP TABLE IF EXISTS `purchaseorders_view` */;
/*!50001 DROP VIEW IF EXISTS `purchaseorders_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purchaseorders_view` AS select `purhcaseorders`.`purchaseorderid` AS `Purchase Order ID`,`purhcaseorders`.`supplierid` AS `Supplier ID`,`purhcaseorders`.`accountid` AS `Account ID`,`purhcaseorders`.`purchaseordername` AS `Purchase Order Name`,`purhcaseorders`.`purhcaseorderrequestdate` AS `Purchase Order Request Date`,`purhcaseorders`.`purhcaseorderdeliverydate` AS `Purchase Order Delivery Date`,`purhcaseorders`.`purchaseorderstatus` AS `Purchase Order Status`,`purhcaseorders`.`purhcaseordertotalamount` AS `Purchase Order Total Amount`,`suppliers`.`suppliername` AS `Supplier Name`,`suppliers`.`suppliercontactnumber` AS `Supplier Contact Number`,`suppliers`.`supplieraddress` AS `Supplier Address`,`accounts`.`accountusername` AS `Account Username`,`accounts`.`accountpassword` AS `Account Password`,`accounts`.`accountfullname` AS `Account Full Name` from ((`purhcaseorders` join `suppliers` on((`purhcaseorders`.`supplierid` = `suppliers`.`supplierid`))) join `accounts` on((`purhcaseorders`.`accountid` = `accounts`.`accountid`))) */;

/*View structure for view purhcaseorderdetails_view */

/*!50001 DROP TABLE IF EXISTS `purhcaseorderdetails_view` */;
/*!50001 DROP VIEW IF EXISTS `purhcaseorderdetails_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purhcaseorderdetails_view` AS select `purhcaseorders`.`accountid` AS `Account ID`,`purhcaseorders`.`purchaseordername` AS `Purchase Order Name`,`purhcaseorders`.`purhcaseorderrequestdate` AS `Purchase Order Request Date`,`purhcaseorders`.`purhcaseorderdeliverydate` AS `Purchase Order Delivery Date`,`purhcaseorders`.`purchaseorderstatus` AS `Purchase Order Status`,`purhcaseorders`.`purhcaseordertotalamount` AS `Purchase Order Total Amount`,`suppliers`.`suppliername` AS `Supplier Name`,`suppliers`.`suppliercontactnumber` AS `Supplier Contact Number`,`suppliers`.`supplieraddress` AS `Supplier Address`,`accounts`.`accountusername` AS `Account Username`,`accounts`.`accountpassword` AS `Account Password`,`accounts`.`accountfullname` AS `Account Full Name`,`purhcaseorderdetails`.`purchaseorderdetailid` AS `Purchase Order Detail ID`,`purhcaseorderdetails`.`purchaseorderid` AS `Purchase Order ID`,`purhcaseorderdetails`.`supplyid` AS `Supply ID`,`purhcaseorderdetails`.`purhcaseorderdetailquantity` AS `Purchase Order Detail Quantity`,`purhcaseorderdetails`.`purhcaseorderdetailunitprice` AS `Purchase Order Detail Unit Price`,`supplies`.`supplyname` AS `Supply Name`,`supplies`.`supplyunit` AS `Supply Unit`,`supplies`.`supplyunitprice` AS `Supply Unit Price`,`supplies`.`supplystocks` AS `Supply Stocks`,`purhcaseorders`.`supplierid` AS `Supplier ID` from ((((`purhcaseorders` join `suppliers` on((`purhcaseorders`.`supplierid` = `suppliers`.`supplierid`))) join `accounts` on((`purhcaseorders`.`accountid` = `accounts`.`accountid`))) join `purhcaseorderdetails` on((`purhcaseorderdetails`.`purchaseorderid` = `purhcaseorders`.`purchaseorderid`))) join `supplies` on((`purhcaseorderdetails`.`supplyid` = `supplies`.`supplyid`))) */;

/*View structure for view suppliers_view */

/*!50001 DROP TABLE IF EXISTS `suppliers_view` */;
/*!50001 DROP VIEW IF EXISTS `suppliers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `suppliers_view` AS select `suppliers`.`supplierid` AS `Supplier ID`,`suppliers`.`suppliername` AS `Supplier Name`,`suppliers`.`suppliercontactnumber` AS `Supplier Contact Number`,`suppliers`.`supplieraddress` AS `Supplier Address` from `suppliers` */;

/*View structure for view supplies_view */

/*!50001 DROP TABLE IF EXISTS `supplies_view` */;
/*!50001 DROP VIEW IF EXISTS `supplies_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `supplies_view` AS select `supplies`.`supplyid` AS `Supply ID`,`supplies`.`supplyname` AS `Supply Name`,`supplies`.`supplyunit` AS `Supply Unit`,`supplies`.`supplyunitprice` AS `Supply Unit Price`,`supplies`.`supplystocks` AS `Supply Stocks` from `supplies` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;