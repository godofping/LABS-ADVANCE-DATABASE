/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - water_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`water_db` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `water_db`;

/*Table structure for table `basicinformations` */

DROP TABLE IF EXISTS `basicinformations`;

CREATE TABLE `basicinformations` (
  `basicinformationid` int(6) NOT NULL AUTO_INCREMENT,
  `lastname` varchar(60) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `middleinitial` varchar(3) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `address` varchar(250) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  `emailaddress` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`basicinformationid`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `basicinformations` */

insert  into `basicinformations`(`basicinformationid`,`lastname`,`firstname`,`middleinitial`,`birthdate`,`address`,`contactnumber`,`emailaddress`) values (1,'LN_MANAGER','FN_MANAGER','MI_','1997-09-23','ST_MANAGER','CN_MANAGER','EA_MANAGER'),(2,'A','B','C','0000-00-00','A','A','A'),(3,'RONCESVALLES','REX LOUIS','P','0000-00-00','','',''),(4,'LN','FN','MI','0000-00-00','ADD','CN','EA'),(5,'A','AA','AA','0000-00-00','AAA','AAA','AAA'),(6,'RONCESVALLES','RONCESVALLES','P','1997-12-23','PUROK 3','09754363944','REXMICROSOFT@YAHOO.COM.PH'),(7,'ASD1','ASD1','AS2','1998-11-21','ASD3','ASD14','ASD15'),(8,'A','B','C','2019-05-07','ASDAS','AD','SDASD'),(9,'ASDASD','ASDASD','ASD','2019-11-26','ASD','ASD','asd'),(10,'ASD','ASD','ASD','2019-11-27','ASD','CN','asd'),(11,'','','','2019-11-26','','',''),(12,'LN','FN','MI','1998-11-11','ADDRESS','CN','ea'),(13,'A','A','ABB','2019-11-26','A','A','');

/*Table structure for table `containertypes` */

DROP TABLE IF EXISTS `containertypes`;

CREATE TABLE `containertypes` (
  `containertypeid` int(6) NOT NULL AUTO_INCREMENT,
  `containertype` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`containertypeid`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `containertypes` */

insert  into `containertypes`(`containertypeid`,`containertype`) values (1,'SLIM WATER CONTAINER WITH FAUCET (5 GALLONS CAPACITY)'),(2,'SLIM WATER CONTAINER WITH FAUCET (3 GALLONS CAPACITY)'),(3,'ROUND WATER CONTAINER (6 GALLONS CAPACITY)');

/*Table structure for table `customerorders` */

DROP TABLE IF EXISTS `customerorders`;

CREATE TABLE `customerorders` (
  `customerorderid` int(6) NOT NULL AUTO_INCREMENT,
  `orderid` int(6) DEFAULT NULL,
  `customerid` int(6) DEFAULT NULL,
  PRIMARY KEY (`customerorderid`),
  KEY `FK_customerorders` (`customerid`),
  KEY `FK_customerorders1` (`orderid`),
  CONSTRAINT `FK_customerorders` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`),
  CONSTRAINT `FK_customerorders1` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customerorders` */

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(6) NOT NULL AUTO_INCREMENT,
  `basicinformationid` int(6) DEFAULT NULL,
  `dateregistered` date DEFAULT NULL,
  PRIMARY KEY (`customerid`),
  KEY `FK_customers` (`basicinformationid`),
  CONSTRAINT `FK_customers` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`basicinformationid`,`dateregistered`) values (5,6,'2019-11-26'),(6,7,'2019-11-26'),(7,13,'2019-11-26');

/*Table structure for table `customertypes` */

DROP TABLE IF EXISTS `customertypes`;

CREATE TABLE `customertypes` (
  `customertypeid` int(6) NOT NULL AUTO_INCREMENT,
  `customertype` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`customertypeid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `customertypes` */

insert  into `customertypes`(`customertypeid`,`customertype`) values (1,'REGISTERED CUSTOMER'),(2,'WALK-IN CUSTOMER');

/*Table structure for table `deliverymodetypes` */

DROP TABLE IF EXISTS `deliverymodetypes`;

CREATE TABLE `deliverymodetypes` (
  `deliverymodetypeid` int(6) NOT NULL AUTO_INCREMENT,
  `modetype` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`deliverymodetypeid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `deliverymodetypes` */

insert  into `deliverymodetypes`(`deliverymodetypeid`,`modetype`) values (1,'DELIVERY'),(2,'PICKUP');

/*Table structure for table `designations` */

DROP TABLE IF EXISTS `designations`;

CREATE TABLE `designations` (
  `designationid` int(6) NOT NULL AUTO_INCREMENT,
  `designation` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`designationid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `designations` */

insert  into `designations`(`designationid`,`designation`) values (1,'MANAGER'),(2,'CASHIER'),(3,'LABOR'),(4,'DELIVERYY STAFF');

/*Table structure for table `orderdeliveries` */

DROP TABLE IF EXISTS `orderdeliveries`;

CREATE TABLE `orderdeliveries` (
  `orderdeliveryid` int(6) NOT NULL AUTO_INCREMENT,
  `orderid` int(6) DEFAULT NULL,
  `staffid` int(6) DEFAULT NULL,
  `deliveryaddress` varchar(250) DEFAULT NULL,
  `deliveryfee` float DEFAULT NULL,
  `datedelivered` date DEFAULT NULL,
  `deliverystatus` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`orderdeliveryid`),
  KEY `FK_orderdeliveries` (`orderid`),
  KEY `FK_orderdeliveries1` (`staffid`),
  CONSTRAINT `FK_orderdeliveries` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`),
  CONSTRAINT `FK_orderdeliveries1` FOREIGN KEY (`staffid`) REFERENCES `staffs` (`staffid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orderdeliveries` */

/*Table structure for table `orderdetails` */

DROP TABLE IF EXISTS `orderdetails`;

CREATE TABLE `orderdetails` (
  `orderdetailid` int(6) NOT NULL,
  `orderid` int(6) DEFAULT NULL,
  `productid` int(6) DEFAULT NULL,
  `amount` float DEFAULT NULL,
  `quantity` int(6) DEFAULT NULL,
  PRIMARY KEY (`orderdetailid`),
  KEY `FK_orderdetails` (`orderid`),
  KEY `FK_orderdetails1` (`productid`),
  CONSTRAINT `FK_orderdetails` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`),
  CONSTRAINT `FK_orderdetails1` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orderdetails` */

/*Table structure for table `orders` */

DROP TABLE IF EXISTS `orders`;

CREATE TABLE `orders` (
  `orderid` int(6) NOT NULL,
  `staffaccountid` int(6) DEFAULT NULL,
  `customertypeid` int(6) DEFAULT NULL,
  `deliverymodetypeid` int(6) DEFAULT NULL,
  `orderdatetime` datetime DEFAULT NULL,
  `totalamount` float DEFAULT NULL,
  `cashtendered` float DEFAULT NULL,
  `change` float DEFAULT NULL,
  `isvoid` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`orderid`),
  KEY `FK_orders2` (`deliverymodetypeid`),
  KEY `FK_orders4` (`customertypeid`),
  KEY `FK_orders` (`staffaccountid`),
  CONSTRAINT `FK_orders` FOREIGN KEY (`staffaccountid`) REFERENCES `staffsaccount` (`staffaccountid`),
  CONSTRAINT `FK_orders2` FOREIGN KEY (`deliverymodetypeid`) REFERENCES `deliverymodetypes` (`deliverymodetypeid`),
  CONSTRAINT `FK_orders4` FOREIGN KEY (`customertypeid`) REFERENCES `customertypes` (`customertypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orders` */

/*Table structure for table `particulars` */

DROP TABLE IF EXISTS `particulars`;

CREATE TABLE `particulars` (
  `particularid` int(6) NOT NULL AUTO_INCREMENT,
  `particular` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`particularid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `particulars` */

insert  into `particulars`(`particularid`,`particular`) values (1,'DISTILLED'),(2,'PURIFIED'),(3,'MINERAL');

/*Table structure for table `productcategories` */

DROP TABLE IF EXISTS `productcategories`;

CREATE TABLE `productcategories` (
  `productcategoryid` int(6) NOT NULL AUTO_INCREMENT,
  `productcategory` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`productcategoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `productcategories` */

insert  into `productcategories`(`productcategoryid`,`productcategory`) values (1,'REFILL ONLY'),(2,'CONTAINER ONLY'),(3,'REFILL AND CONTAINER');

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `productcategoryid` int(6) DEFAULT NULL,
  `particularid` int(6) DEFAULT NULL,
  `containertypeid` int(6) DEFAULT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`productid`),
  KEY `FK_products1` (`productcategoryid`),
  KEY `FK_products` (`particularid`),
  KEY `FK_products2` (`containertypeid`),
  CONSTRAINT `FK_products` FOREIGN KEY (`particularid`) REFERENCES `particulars` (`particularid`),
  CONSTRAINT `FK_products1` FOREIGN KEY (`productcategoryid`) REFERENCES `productcategories` (`productcategoryid`),
  CONSTRAINT `FK_products2` FOREIGN KEY (`containertypeid`) REFERENCES `containertypes` (`containertypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `products` */

/*Table structure for table `staffs` */

DROP TABLE IF EXISTS `staffs`;

CREATE TABLE `staffs` (
  `staffid` int(6) NOT NULL AUTO_INCREMENT,
  `basicinformationid` int(6) DEFAULT NULL,
  `designationid` int(6) DEFAULT NULL,
  `datehired` date DEFAULT NULL,
  PRIMARY KEY (`staffid`),
  KEY `FK_staffs2` (`designationid`),
  KEY `FK_staffs` (`basicinformationid`),
  CONSTRAINT `FK_staffs` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`) ON DELETE CASCADE,
  CONSTRAINT `FK_staffs2` FOREIGN KEY (`designationid`) REFERENCES `designations` (`designationid`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `staffs` */

insert  into `staffs`(`staffid`,`basicinformationid`,`designationid`,`datehired`) values (1,1,1,'2019-11-26'),(4,10,2,'2019-11-27');

/*Table structure for table `staffsaccount` */

DROP TABLE IF EXISTS `staffsaccount`;

CREATE TABLE `staffsaccount` (
  `staffaccountid` int(6) NOT NULL AUTO_INCREMENT,
  `staffid` int(6) DEFAULT NULL,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`staffaccountid`),
  KEY `FK_staffsaccount1` (`staffid`),
  CONSTRAINT `FK_staffsaccount1` FOREIGN KEY (`staffid`) REFERENCES `staffs` (`staffid`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `staffsaccount` */

insert  into `staffsaccount`(`staffaccountid`,`staffid`,`username`,`password`) values (1,1,'manager','manager'),(4,4,'cashier','cashier');

/*Table structure for table `view_customers` */

DROP TABLE IF EXISTS `view_customers`;

/*!50001 DROP VIEW IF EXISTS `view_customers` */;
/*!50001 DROP TABLE IF EXISTS `view_customers` */;

/*!50001 CREATE TABLE  `view_customers`(
 `CUSTOMER ID` int(6) ,
 `BASIC INFORMATION ID` int(6) ,
 `LAST NAME` varchar(60) ,
 `FIRST NAME` varchar(60) ,
 `MIDDLE INITIAL` varchar(3) ,
 `BIRTH DATE` date ,
 `ADDRESS` varchar(250) ,
 `CONTACT NUMBER` varchar(60) ,
 `EMAIL ADDRESS` varchar(60) ,
 `DATE REGISTERED` date 
)*/;

/*Table structure for table `view_products` */

DROP TABLE IF EXISTS `view_products`;

/*!50001 DROP VIEW IF EXISTS `view_products` */;
/*!50001 DROP TABLE IF EXISTS `view_products` */;

/*!50001 CREATE TABLE  `view_products`(
 `PRODUCT ID` int(6) ,
 `PRODUCT CATEGORY ID` int(6) ,
 `PARTICULAR ID` int(6) ,
 `CONTAINER TYPE ID` int(6) ,
 `PRICE` float ,
 `PARTICULAR` varchar(60) ,
 `CONTAINER TYPE` varchar(60) ,
 `PRODUCT CATEGORY` varchar(60) 
)*/;

/*Table structure for table `view_staffs` */

DROP TABLE IF EXISTS `view_staffs`;

/*!50001 DROP VIEW IF EXISTS `view_staffs` */;
/*!50001 DROP TABLE IF EXISTS `view_staffs` */;

/*!50001 CREATE TABLE  `view_staffs`(
 `STAFF ID` int(6) ,
 `BASIC INFORMATION ID` int(6) ,
 `DESIGNATION ID` int(6) ,
 `LAST NAME` varchar(60) ,
 `FIRST NAME` varchar(60) ,
 `MIDDLE INITIAL` varchar(3) ,
 `BIRTH DATE` date ,
 `ADDRESS` varchar(250) ,
 `CONTACT NUMBER` varchar(60) ,
 `EMAIL ADDRESS` varchar(60) ,
 `DESIGNATION` varchar(60) ,
 `DATE HIRED` date ,
 `FULL NAME` varchar(126) 
)*/;

/*Table structure for table `view_staffsaccount` */

DROP TABLE IF EXISTS `view_staffsaccount`;

/*!50001 DROP VIEW IF EXISTS `view_staffsaccount` */;
/*!50001 DROP TABLE IF EXISTS `view_staffsaccount` */;

/*!50001 CREATE TABLE  `view_staffsaccount`(
 `STAFF ACCOUNT ID` int(6) ,
 `BASIC INFORMATION ID` int(6) ,
 `DESIGNATION ID` int(6) ,
 `STAFF ID` int(6) ,
 `USERNAME` varchar(60) ,
 `PASSWORD` varchar(60) ,
 `LAST NAME` varchar(60) ,
 `FIRST NAME` varchar(60) ,
 `MIDDLE INITIAL` varchar(3) ,
 `BIRTH DATE` date ,
 `ADDRESS` varchar(250) ,
 `CONTACT NUMBER` varchar(60) ,
 `EMAIL ADDRESS` varchar(60) ,
 `DESIGNATION` varchar(60) ,
 `DATE HIRED` date ,
 `FULL NAME` varchar(126) 
)*/;

/*View structure for view view_customers */

/*!50001 DROP TABLE IF EXISTS `view_customers` */;
/*!50001 DROP VIEW IF EXISTS `view_customers` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_customers` AS select `customers`.`customerid` AS `CUSTOMER ID`,`customers`.`basicinformationid` AS `BASIC INFORMATION ID`,`basicinformations`.`lastname` AS `LAST NAME`,`basicinformations`.`firstname` AS `FIRST NAME`,`basicinformations`.`middleinitial` AS `MIDDLE INITIAL`,`basicinformations`.`birthdate` AS `BIRTH DATE`,`basicinformations`.`address` AS `ADDRESS`,`basicinformations`.`contactnumber` AS `CONTACT NUMBER`,`basicinformations`.`emailaddress` AS `EMAIL ADDRESS`,`customers`.`dateregistered` AS `DATE REGISTERED` from (`customers` join `basicinformations` on((`customers`.`basicinformationid` = `basicinformations`.`basicinformationid`))) */;

/*View structure for view view_products */

/*!50001 DROP TABLE IF EXISTS `view_products` */;
/*!50001 DROP VIEW IF EXISTS `view_products` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_products` AS select `products`.`productid` AS `PRODUCT ID`,`products`.`productcategoryid` AS `PRODUCT CATEGORY ID`,`products`.`particularid` AS `PARTICULAR ID`,`products`.`containertypeid` AS `CONTAINER TYPE ID`,`products`.`price` AS `PRICE`,`particulars`.`particular` AS `PARTICULAR`,`containertypes`.`containertype` AS `CONTAINER TYPE`,`productcategories`.`productcategory` AS `PRODUCT CATEGORY` from (((`products` join `containertypes` on((`products`.`containertypeid` = `containertypes`.`containertypeid`))) join `particulars` on((`products`.`particularid` = `particulars`.`particularid`))) join `productcategories` on((`products`.`productcategoryid` = `productcategories`.`productcategoryid`))) */;

/*View structure for view view_staffs */

/*!50001 DROP TABLE IF EXISTS `view_staffs` */;
/*!50001 DROP VIEW IF EXISTS `view_staffs` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_staffs` AS select `staffs`.`staffid` AS `STAFF ID`,`staffs`.`basicinformationid` AS `BASIC INFORMATION ID`,`staffs`.`designationid` AS `DESIGNATION ID`,`basicinformations`.`lastname` AS `LAST NAME`,`basicinformations`.`firstname` AS `FIRST NAME`,`basicinformations`.`middleinitial` AS `MIDDLE INITIAL`,`basicinformations`.`birthdate` AS `BIRTH DATE`,`basicinformations`.`address` AS `ADDRESS`,`basicinformations`.`contactnumber` AS `CONTACT NUMBER`,`basicinformations`.`emailaddress` AS `EMAIL ADDRESS`,`designations`.`designation` AS `DESIGNATION`,`staffs`.`datehired` AS `DATE HIRED`,concat(`basicinformations`.`lastname`,', ',`basicinformations`.`firstname`,' ',`basicinformations`.`middleinitial`) AS `FULL NAME` from ((`staffs` join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `designations` on((`staffs`.`designationid` = `designations`.`designationid`))) */;

/*View structure for view view_staffsaccount */

/*!50001 DROP TABLE IF EXISTS `view_staffsaccount` */;
/*!50001 DROP VIEW IF EXISTS `view_staffsaccount` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_staffsaccount` AS select `staffsaccount`.`staffaccountid` AS `STAFF ACCOUNT ID`,`staffs`.`basicinformationid` AS `BASIC INFORMATION ID`,`staffs`.`designationid` AS `DESIGNATION ID`,`staffsaccount`.`staffid` AS `STAFF ID`,`staffsaccount`.`username` AS `USERNAME`,`staffsaccount`.`password` AS `PASSWORD`,`basicinformations`.`lastname` AS `LAST NAME`,`basicinformations`.`firstname` AS `FIRST NAME`,`basicinformations`.`middleinitial` AS `MIDDLE INITIAL`,`basicinformations`.`birthdate` AS `BIRTH DATE`,`basicinformations`.`address` AS `ADDRESS`,`basicinformations`.`contactnumber` AS `CONTACT NUMBER`,`basicinformations`.`emailaddress` AS `EMAIL ADDRESS`,`designations`.`designation` AS `DESIGNATION`,`staffs`.`datehired` AS `DATE HIRED`,concat(`basicinformations`.`lastname`,', ',`basicinformations`.`firstname`,' ',`basicinformations`.`middleinitial`) AS `FULL NAME` from (((`staffs` join `designations` on((`staffs`.`designationid` = `designations`.`designationid`))) join `staffsaccount` on((`staffsaccount`.`staffid` = `staffs`.`staffid`))) join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) where ((`designations`.`designation` = 'MANAGER') or (`designations`.`designation` = 'CASHIER')) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
