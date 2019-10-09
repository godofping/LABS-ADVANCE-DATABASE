/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - pos
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pos` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `pos`;

/*Table structure for table `addresses` */

DROP TABLE IF EXISTS `addresses`;

CREATE TABLE `addresses` (
  `addressid` int(6) NOT NULL AUTO_INCREMENT,
  `address` varchar(60) DEFAULT NULL,
  `city` varchar(60) DEFAULT NULL,
  `zipcode` varchar(60) DEFAULT NULL,
  `province` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`addressid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `addresses` */

/*Table structure for table `amounts` */

DROP TABLE IF EXISTS `amounts`;

CREATE TABLE `amounts` (
  `amountid` int(6) NOT NULL AUTO_INCREMENT,
  `amount` float DEFAULT NULL,
  PRIMARY KEY (`amountid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `amounts` */

/*Table structure for table `basicinformations` */

DROP TABLE IF EXISTS `basicinformations`;

CREATE TABLE `basicinformations` (
  `basicinformationid` int(6) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `genderid` int(6) DEFAULT NULL,
  `birthdate` int(6) DEFAULT NULL,
  PRIMARY KEY (`basicinformationid`),
  KEY `FK_basicinformations` (`genderid`),
  KEY `FK_basicinfosrmations` (`birthdate`),
  CONSTRAINT `FK_basicinformations` FOREIGN KEY (`genderid`) REFERENCES `genders` (`genderid`),
  CONSTRAINT `FK_basicinfosrmations` FOREIGN KEY (`birthdate`) REFERENCES `dates` (`dateid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `basicinformations` */

/*Table structure for table `categories` */

DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
  `categoryid` int(6) NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `categories` */

insert  into `categories`(`categoryid`,`categoryname`) values (1,'asd');

/*Table structure for table `contactdetails` */

DROP TABLE IF EXISTS `contactdetails`;

CREATE TABLE `contactdetails` (
  `contactdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `addressid` int(6) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  `emailaddress` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`contactdetailid`),
  KEY `FK_contactdetails` (`addressid`),
  CONSTRAINT `FK_contactdetails` FOREIGN KEY (`addressid`) REFERENCES `addresses` (`addressid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `contactdetails` */

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(11) NOT NULL AUTO_INCREMENT,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  PRIMARY KEY (`customerid`),
  KEY `FK_customers1` (`contactdetailid`),
  KEY `FK_customers` (`basicinformationid`),
  CONSTRAINT `FK_customers` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`),
  CONSTRAINT `FK_customers1` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`contactdetailid`,`basicinformationid`) values (1,NULL,NULL),(2,NULL,NULL),(3,NULL,NULL),(4,NULL,NULL),(5,NULL,NULL),(8,NULL,NULL),(9,NULL,NULL),(10,NULL,NULL),(11,NULL,NULL);

/*Table structure for table `dates` */

DROP TABLE IF EXISTS `dates`;

CREATE TABLE `dates` (
  `dateid` int(6) NOT NULL AUTO_INCREMENT,
  `dates` date DEFAULT NULL,
  PRIMARY KEY (`dateid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `dates` */

/*Table structure for table `genders` */

DROP TABLE IF EXISTS `genders`;

CREATE TABLE `genders` (
  `genderid` int(6) NOT NULL AUTO_INCREMENT,
  `gender` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`genderid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `genders` */

/*Table structure for table `inventories` */

DROP TABLE IF EXISTS `inventories`;

CREATE TABLE `inventories` (
  `inventoryid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `quantityinstocks` int(6) DEFAULT NULL,
  `reorderlevel` int(6) DEFAULT NULL,
  PRIMARY KEY (`inventoryid`),
  KEY `FK_inventories` (`productid`),
  CONSTRAINT `FK_inventories` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `inventories` */

/*Table structure for table `orderdetails` */

DROP TABLE IF EXISTS `orderdetails`;

CREATE TABLE `orderdetails` (
  `orderdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `orderid` int(6) DEFAULT NULL,
  `productid` int(6) DEFAULT NULL,
  `orderdetailquantity` int(6) DEFAULT NULL,
  `orderdetailamount` int(6) DEFAULT NULL,
  `orderdetailstatus` int(6) DEFAULT NULL,
  `productprice` int(6) DEFAULT NULL,
  PRIMARY KEY (`orderdetailid`),
  KEY `FK_orderdetails` (`orderid`),
  KEY `FK_orderdetails1` (`productid`),
  KEY `FK_orderdetailsw` (`orderdetailstatus`),
  KEY `FK_orderdetailswasda` (`orderdetailamount`),
  KEY `FK_ords89s8erdetails` (`orderdetailquantity`),
  KEY `FK_orderdd56etails` (`productprice`),
  CONSTRAINT `FK_orderdd56etails` FOREIGN KEY (`productprice`) REFERENCES `prices` (`priceid`),
  CONSTRAINT `FK_orderdetails` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`),
  CONSTRAINT `FK_orderdetails1` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`),
  CONSTRAINT `FK_orderdetailsw` FOREIGN KEY (`orderdetailstatus`) REFERENCES `statuses` (`statusid`),
  CONSTRAINT `FK_orderdetailswasda` FOREIGN KEY (`orderdetailamount`) REFERENCES `amounts` (`amountid`),
  CONSTRAINT `FK_ords89s8erdetails` FOREIGN KEY (`orderdetailquantity`) REFERENCES `quantities` (`quantityid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orderdetails` */

/*Table structure for table `orders` */

DROP TABLE IF EXISTS `orders`;

CREATE TABLE `orders` (
  `orderid` int(6) NOT NULL AUTO_INCREMENT,
  `customerid` int(6) DEFAULT NULL,
  `staffid` int(6) DEFAULT NULL,
  `orderstatus` int(6) DEFAULT NULL,
  `ordertotalamount` int(6) DEFAULT NULL,
  `orderdate` int(6) DEFAULT NULL,
  PRIMARY KEY (`orderid`),
  KEY `fkcustomerid` (`customerid`),
  KEY `FK_orders` (`staffid`),
  KEY `FK_orders56s` (`orderstatus`),
  KEY `FK_ordersd89` (`ordertotalamount`),
  KEY `FK_orders8s98` (`orderdate`),
  CONSTRAINT `FK_orders` FOREIGN KEY (`staffid`) REFERENCES `staffs` (`staffid`),
  CONSTRAINT `FK_orders56s` FOREIGN KEY (`orderstatus`) REFERENCES `statuses` (`statusid`),
  CONSTRAINT `FK_orders8s98` FOREIGN KEY (`orderdate`) REFERENCES `dates` (`dateid`),
  CONSTRAINT `FK_ordersd89` FOREIGN KEY (`ordertotalamount`) REFERENCES `amounts` (`amountid`),
  CONSTRAINT `fkcustomerid` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `orders` */

insert  into `orders`(`orderid`,`customerid`,`staffid`,`orderstatus`,`ordertotalamount`,`orderdate`) values (1,1,NULL,NULL,NULL,NULL);

/*Table structure for table `prices` */

DROP TABLE IF EXISTS `prices`;

CREATE TABLE `prices` (
  `priceid` int(6) NOT NULL AUTO_INCREMENT,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`priceid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `prices` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `productname` varchar(100) DEFAULT NULL,
  `productdescription` varchar(60) DEFAULT NULL,
  `subcategoryid` int(6) DEFAULT NULL,
  `productsku` varchar(60) DEFAULT NULL,
  `productprice` int(6) DEFAULT NULL,
  PRIMARY KEY (`productid`),
  KEY `FK_items` (`subcategoryid`),
  KEY `FK_products` (`productprice`),
  CONSTRAINT `FK_items` FOREIGN KEY (`subcategoryid`) REFERENCES `subcategories` (`subcategoryid`),
  CONSTRAINT `FK_products` FOREIGN KEY (`productprice`) REFERENCES `prices` (`priceid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `products` */

/*Table structure for table `purchaseorderdetails` */

DROP TABLE IF EXISTS `purchaseorderdetails`;

CREATE TABLE `purchaseorderdetails` (
  `purchaseorderdetailsid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `purchaseorderquantity` int(6) DEFAULT NULL,
  `purchaseorderamount` int(6) DEFAULT NULL,
  `purchaseorderid` int(6) DEFAULT NULL,
  PRIMARY KEY (`purchaseorderdetailsid`),
  KEY `FK_purchaseorderdetails` (`purchaseorderid`),
  KEY `FK_purchaseorderdetails1` (`productid`),
  KEY `FK_purchaseorderdetails2` (`purchaseorderamount`),
  KEY `FK_purchaseordderdetails` (`purchaseorderquantity`),
  CONSTRAINT `FK_purchaseordderdetails` FOREIGN KEY (`purchaseorderquantity`) REFERENCES `quantities` (`quantityid`),
  CONSTRAINT `FK_purchaseorderdetails` FOREIGN KEY (`purchaseorderid`) REFERENCES `purchaseorders` (`purchaseorderid`),
  CONSTRAINT `FK_purchaseorderdetails1` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`),
  CONSTRAINT `FK_purchaseorderdetails2` FOREIGN KEY (`purchaseorderamount`) REFERENCES `amounts` (`amountid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorderdetails` */

/*Table structure for table `purchaseorders` */

DROP TABLE IF EXISTS `purchaseorders`;

CREATE TABLE `purchaseorders` (
  `purchaseorderid` int(6) NOT NULL AUTO_INCREMENT,
  `staffid` int(6) DEFAULT NULL,
  `vendorid` int(6) DEFAULT NULL,
  `purchaseorderstatus` int(6) DEFAULT NULL,
  `purchaseorderamount` int(6) DEFAULT NULL,
  `purchaseorderdatedelivered` int(6) DEFAULT NULL,
  `purchaseorderdaterequested` int(6) DEFAULT NULL,
  PRIMARY KEY (`purchaseorderid`),
  KEY `FK_purchaseorders2` (`vendorid`),
  KEY `FK_purchaseorders1` (`staffid`),
  KEY `FK_purchaseordersw` (`purchaseorderstatus`),
  KEY `FK_purc6565haseorders` (`purchaseorderamount`),
  KEY `FK_pus43rchaseorders` (`purchaseorderdatedelivered`),
  KEY `FK_purs4545chaseorders` (`purchaseorderdaterequested`),
  CONSTRAINT `FK_purc6565haseorders` FOREIGN KEY (`purchaseorderamount`) REFERENCES `amounts` (`amountid`),
  CONSTRAINT `FK_purchaseorders1` FOREIGN KEY (`staffid`) REFERENCES `staffs` (`staffid`),
  CONSTRAINT `FK_purchaseorders2` FOREIGN KEY (`vendorid`) REFERENCES `vendors` (`vendorid`),
  CONSTRAINT `FK_purchaseorderss` FOREIGN KEY (`purchaseorderstatus`) REFERENCES `statuses` (`statusid`),
  CONSTRAINT `FK_purchaseordersw` FOREIGN KEY (`purchaseorderstatus`) REFERENCES `statuses` (`statusid`),
  CONSTRAINT `FK_purs4545chaseorders` FOREIGN KEY (`purchaseorderdaterequested`) REFERENCES `dates` (`dateid`),
  CONSTRAINT `FK_pus43rchaseorders` FOREIGN KEY (`purchaseorderdatedelivered`) REFERENCES `dates` (`dateid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorders` */

/*Table structure for table `quantities` */

DROP TABLE IF EXISTS `quantities`;

CREATE TABLE `quantities` (
  `quantityid` int(6) NOT NULL AUTO_INCREMENT,
  `quantity` int(6) DEFAULT NULL,
  PRIMARY KEY (`quantityid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `quantities` */

/*Table structure for table `staffs` */

DROP TABLE IF EXISTS `staffs`;

CREATE TABLE `staffs` (
  `staffid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  PRIMARY KEY (`staffid`),
  KEY `FK_staffs` (`contactdetailid`),
  KEY `FK_staffsdff` (`basicinformationid`),
  CONSTRAINT `FK_staffs` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`),
  CONSTRAINT `FK_staffsdff` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `staffs` */

insert  into `staffs`(`staffid`,`username`,`password`,`contactdetailid`,`basicinformationid`) values (1,'admin','admin',NULL,NULL),(2,'totoy','totoy',NULL,NULL);

/*Table structure for table `statuses` */

DROP TABLE IF EXISTS `statuses`;

CREATE TABLE `statuses` (
  `statusid` int(6) NOT NULL AUTO_INCREMENT,
  `status` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`statusid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `statuses` */

/*Table structure for table `subcategories` */

DROP TABLE IF EXISTS `subcategories`;

CREATE TABLE `subcategories` (
  `subcategoryid` int(6) NOT NULL AUTO_INCREMENT,
  `subcategory` varchar(60) DEFAULT NULL,
  `categoryid` int(6) DEFAULT NULL,
  PRIMARY KEY (`subcategoryid`),
  KEY `FK_subcategories` (`categoryid`),
  CONSTRAINT `FK_subcategories` FOREIGN KEY (`categoryid`) REFERENCES `categories` (`categoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `subcategories` */

/*Table structure for table `vendorcategories` */

DROP TABLE IF EXISTS `vendorcategories`;

CREATE TABLE `vendorcategories` (
  `vendorcategoryid` int(6) NOT NULL AUTO_INCREMENT,
  `vendorcategory` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`vendorcategoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `vendorcategories` */

/*Table structure for table `vendors` */

DROP TABLE IF EXISTS `vendors`;

CREATE TABLE `vendors` (
  `vendorid` int(6) NOT NULL AUTO_INCREMENT,
  `vendor` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `vendorcategoryid` int(6) DEFAULT NULL,
  PRIMARY KEY (`vendorid`),
  KEY `FK_vendors` (`contactdetailid`),
  KEY `FK_vendors1` (`vendorcategoryid`),
  CONSTRAINT `FK_vendors` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`),
  CONSTRAINT `FK_vendors1` FOREIGN KEY (`vendorcategoryid`) REFERENCES `vendorcategories` (`vendorcategoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `vendors` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
