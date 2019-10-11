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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `addresses` */

insert  into `addresses`(`addressid`,`address`,`city`,`zipcode`,`province`) values (1,'44 Ledesma','Tacurong City','9800','Sultan Kudarat');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `basicinformations` */

insert  into `basicinformations`(`basicinformationid`,`firstname`,`middlename`,`lastname`,`genderid`,`birthdate`) values (1,'Rex Louis','Paradero','Roncesvalles',1,1);

/*Table structure for table `categories` */

DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
  `categoryid` int(6) NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `categories` */

insert  into `categories`(`categoryid`,`categoryname`) values (1,'Components'),(2,'Laptops'),(3,'Peripherals'),(4,'Smartphones and Tablets'),(5,'Software');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `contactdetails` */

insert  into `contactdetails`(`contactdetailid`,`addressid`,`contactnumber`,`emailaddress`) values (1,1,'09754363944','rexmicrosoft@yahoo.com.ph');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `dates` */

insert  into `dates`(`dateid`,`dates`) values (1,'1997-09-23');

/*Table structure for table `genders` */

DROP TABLE IF EXISTS `genders`;

CREATE TABLE `genders` (
  `genderid` int(6) NOT NULL AUTO_INCREMENT,
  `gender` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`genderid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `genders` */

insert  into `genders`(`genderid`,`gender`) values (1,'Male'),(2,'Female');

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
  `orderdetailproductprice` int(6) DEFAULT NULL,
  PRIMARY KEY (`orderdetailid`),
  KEY `FK_orderdetails` (`orderid`),
  KEY `FK_orderdetails1` (`productid`),
  KEY `FK_orderdetailsw` (`orderdetailstatus`),
  KEY `FK_orderdetailswasda` (`orderdetailamount`),
  KEY `FK_ords89s8erdetails` (`orderdetailquantity`),
  KEY `FK_orderdd56etails` (`orderdetailproductprice`),
  CONSTRAINT `FK_orderdd56etails` FOREIGN KEY (`orderdetailproductprice`) REFERENCES `prices` (`priceid`),
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
  `purchaseorderdetailquantity` int(6) DEFAULT NULL,
  `purchaseorderdetailamount` int(6) DEFAULT NULL,
  `purchaseorderid` int(6) DEFAULT NULL,
  `purchaseorderdetailstatus` int(6) DEFAULT NULL,
  `purchaseorderdetailprice` int(6) DEFAULT NULL,
  PRIMARY KEY (`purchaseorderdetailsid`),
  KEY `FK_purchaseorderdetails` (`purchaseorderid`),
  KEY `FK_purchaseorderdetails1` (`productid`),
  KEY `FK_purchaseorderdetails2` (`purchaseorderdetailamount`),
  KEY `FK_purchaseordderdetails` (`purchaseorderdetailquantity`),
  KEY `FK_purchaseorde1rdetails` (`purchaseorderdetailstatus`),
  KEY `FK_purchaseord2erdetails` (`purchaseorderdetailprice`),
  CONSTRAINT `FK_purchaseord2erdetails` FOREIGN KEY (`purchaseorderdetailprice`) REFERENCES `prices` (`priceid`),
  CONSTRAINT `FK_purchaseordderdetails` FOREIGN KEY (`purchaseorderdetailquantity`) REFERENCES `quantities` (`quantityid`),
  CONSTRAINT `FK_purchaseorde1rdetails` FOREIGN KEY (`purchaseorderdetailstatus`) REFERENCES `statuses` (`statusid`),
  CONSTRAINT `FK_purchaseorderdetails` FOREIGN KEY (`purchaseorderid`) REFERENCES `purchaseorders` (`purchaseorderid`),
  CONSTRAINT `FK_purchaseorderdetails1` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`),
  CONSTRAINT `FK_purchaseorderdetails2` FOREIGN KEY (`purchaseorderdetailamount`) REFERENCES `amounts` (`amountid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorderdetails` */

/*Table structure for table `purchaseorders` */

DROP TABLE IF EXISTS `purchaseorders`;

CREATE TABLE `purchaseorders` (
  `purchaseorderid` int(6) NOT NULL AUTO_INCREMENT,
  `staffid` int(6) DEFAULT NULL,
  `vendorid` int(6) DEFAULT NULL,
  `purchaseorderstatus` int(6) DEFAULT NULL,
  `purchasetotalorderamount` int(6) DEFAULT NULL,
  `purchaseorderdatedelivered` int(6) DEFAULT NULL,
  `purchaseorderdaterequested` int(6) DEFAULT NULL,
  PRIMARY KEY (`purchaseorderid`),
  KEY `FK_purchaseorders2` (`vendorid`),
  KEY `FK_purchaseorders1` (`staffid`),
  KEY `FK_purchaseordersw` (`purchaseorderstatus`),
  KEY `FK_purc6565haseorders` (`purchasetotalorderamount`),
  KEY `FK_pus43rchaseorders` (`purchaseorderdatedelivered`),
  KEY `FK_purs4545chaseorders` (`purchaseorderdaterequested`),
  CONSTRAINT `FK_purc6565haseorders` FOREIGN KEY (`purchasetotalorderamount`) REFERENCES `amounts` (`amountid`),
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

/*Table structure for table `staffpositions` */

DROP TABLE IF EXISTS `staffpositions`;

CREATE TABLE `staffpositions` (
  `staffpositionid` int(6) NOT NULL AUTO_INCREMENT,
  `staffposition` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`staffpositionid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `staffpositions` */

/*Table structure for table `staffs` */

DROP TABLE IF EXISTS `staffs`;

CREATE TABLE `staffs` (
  `staffid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  `staffpositionid` int(6) DEFAULT NULL,
  PRIMARY KEY (`staffid`),
  KEY `FK_staffs` (`contactdetailid`),
  KEY `FK_staffsdff` (`basicinformationid`),
  KEY `FK_staf2fs` (`staffpositionid`),
  CONSTRAINT `FK_staf2fs` FOREIGN KEY (`staffpositionid`) REFERENCES `staffpositions` (`staffpositionid`),
  CONSTRAINT `FK_staffs` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`),
  CONSTRAINT `FK_staffsdff` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `staffs` */

insert  into `staffs`(`staffid`,`username`,`password`,`contactdetailid`,`basicinformationid`,`staffpositionid`) values (1,'admin','admin',1,1,NULL),(2,'totoy','totoy',NULL,NULL,NULL);

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

/*Table structure for table `vendorproducts` */

DROP TABLE IF EXISTS `vendorproducts`;

CREATE TABLE `vendorproducts` (
  `vendorproductid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `vendorid` int(6) DEFAULT NULL,
  PRIMARY KEY (`vendorproductid`),
  KEY `FK_vendorproducts` (`productid`),
  KEY `FK_ve1ndorproducts` (`vendorid`),
  CONSTRAINT `FK_ve1ndorproducts` FOREIGN KEY (`vendorid`) REFERENCES `vendors` (`vendorid`),
  CONSTRAINT `FK_vendorproducts` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `vendorproducts` */

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

/*Table structure for table `addresses_view` */

DROP TABLE IF EXISTS `addresses_view`;

/*!50001 DROP VIEW IF EXISTS `addresses_view` */;
/*!50001 DROP TABLE IF EXISTS `addresses_view` */;

/*!50001 CREATE TABLE  `addresses_view`(
 `addressid` int(6) ,
 `address` varchar(60) ,
 `city` varchar(60) ,
 `zipcode` varchar(60) ,
 `province` varchar(60) 
)*/;

/*Table structure for table `amounts_view` */

DROP TABLE IF EXISTS `amounts_view`;

/*!50001 DROP VIEW IF EXISTS `amounts_view` */;
/*!50001 DROP TABLE IF EXISTS `amounts_view` */;

/*!50001 CREATE TABLE  `amounts_view`(
 `amountid` int(6) ,
 `amount` float 
)*/;

/*Table structure for table `basicinformations_view` */

DROP TABLE IF EXISTS `basicinformations_view`;

/*!50001 DROP VIEW IF EXISTS `basicinformations_view` */;
/*!50001 DROP TABLE IF EXISTS `basicinformations_view` */;

/*!50001 CREATE TABLE  `basicinformations_view`(
 `basicinformationid` int(6) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `lastname` varchar(60) ,
 `genderid` int(6) ,
 `birthdate` int(6) ,
 `gender` varchar(60) ,
 `dates` date 
)*/;

/*Table structure for table `categories_view` */

DROP TABLE IF EXISTS `categories_view`;

/*!50001 DROP VIEW IF EXISTS `categories_view` */;
/*!50001 DROP TABLE IF EXISTS `categories_view` */;

/*!50001 CREATE TABLE  `categories_view`(
 `categoryid` int(6) ,
 `categoryname` varchar(60) 
)*/;

/*Table structure for table `customers_view` */

DROP TABLE IF EXISTS `customers_view`;

/*!50001 DROP VIEW IF EXISTS `customers_view` */;
/*!50001 DROP TABLE IF EXISTS `customers_view` */;

/*!50001 CREATE TABLE  `customers_view`(
 `customerid` int(11) ,
 `contactdetailid` int(6) ,
 `basicinformationid` int(6) ,
 `addressid` int(6) ,
 `contactnumber` varchar(60) ,
 `emailaddress` varchar(60) ,
 `address` varchar(60) ,
 `city` varchar(60) ,
 `zipcode` varchar(60) ,
 `province` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `lastname` varchar(60) ,
 `genderid` int(6) ,
 `birthdate` int(6) ,
 `gender` varchar(60) 
)*/;

/*Table structure for table `dates_view` */

DROP TABLE IF EXISTS `dates_view`;

/*!50001 DROP VIEW IF EXISTS `dates_view` */;
/*!50001 DROP TABLE IF EXISTS `dates_view` */;

/*!50001 CREATE TABLE  `dates_view`(
 `dateid` int(6) ,
 `dates` date 
)*/;

/*Table structure for table `genders_view` */

DROP TABLE IF EXISTS `genders_view`;

/*!50001 DROP VIEW IF EXISTS `genders_view` */;
/*!50001 DROP TABLE IF EXISTS `genders_view` */;

/*!50001 CREATE TABLE  `genders_view`(
 `genderid` int(6) ,
 `gender` varchar(60) 
)*/;

/*Table structure for table `inventories_view` */

DROP TABLE IF EXISTS `inventories_view`;

/*!50001 DROP VIEW IF EXISTS `inventories_view` */;
/*!50001 DROP TABLE IF EXISTS `inventories_view` */;

/*!50001 CREATE TABLE  `inventories_view`(
 `inventoryid` int(6) ,
 `productid` int(6) ,
 `quantityinstocks` int(6) ,
 `reorderlevel` int(6) ,
 `productname` varchar(100) ,
 `productdescription` varchar(60) ,
 `subcategoryid` int(6) ,
 `productsku` varchar(60) ,
 `productprice` int(6) ,
 `subcategory` varchar(60) ,
 `categoryid` int(6) ,
 `categoryname` varchar(60) ,
 `price` float 
)*/;

/*Table structure for table `products_view` */

DROP TABLE IF EXISTS `products_view`;

/*!50001 DROP VIEW IF EXISTS `products_view` */;
/*!50001 DROP TABLE IF EXISTS `products_view` */;

/*!50001 CREATE TABLE  `products_view`(
 `productid` int(6) ,
 `productname` varchar(100) ,
 `productdescription` varchar(60) ,
 `subcategoryid` int(6) ,
 `productsku` varchar(60) ,
 `productprice` int(6) ,
 `subcategory` varchar(60) ,
 `categoryid` int(6) ,
 `categoryname` varchar(60) ,
 `price` float 
)*/;

/*Table structure for table `staffs_view` */

DROP TABLE IF EXISTS `staffs_view`;

/*!50001 DROP VIEW IF EXISTS `staffs_view` */;
/*!50001 DROP TABLE IF EXISTS `staffs_view` */;

/*!50001 CREATE TABLE  `staffs_view`(
 `staffid` int(6) ,
 `username` varchar(60) ,
 `password` varchar(60) ,
 `contactdetailid` int(6) ,
 `basicinformationid` int(6) ,
 `addressid` int(6) ,
 `contactnumber` varchar(60) ,
 `emailaddress` varchar(60) ,
 `address` varchar(60) ,
 `city` varchar(60) ,
 `zipcode` varchar(60) ,
 `province` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `lastname` varchar(60) ,
 `genderid` int(6) ,
 `birthdate` int(6) ,
 `gender` varchar(60) 
)*/;

/*View structure for view addresses_view */

/*!50001 DROP TABLE IF EXISTS `addresses_view` */;
/*!50001 DROP VIEW IF EXISTS `addresses_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `addresses_view` AS select `addresses`.`addressid` AS `addressid`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province` from `addresses` */;

/*View structure for view amounts_view */

/*!50001 DROP TABLE IF EXISTS `amounts_view` */;
/*!50001 DROP VIEW IF EXISTS `amounts_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `amounts_view` AS select `amounts`.`amountid` AS `amountid`,`amounts`.`amount` AS `amount` from `amounts` */;

/*View structure for view basicinformations_view */

/*!50001 DROP TABLE IF EXISTS `basicinformations_view` */;
/*!50001 DROP VIEW IF EXISTS `basicinformations_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `basicinformations_view` AS select `basicinformations`.`basicinformationid` AS `basicinformationid`,`basicinformations`.`firstname` AS `firstname`,`basicinformations`.`middlename` AS `middlename`,`basicinformations`.`lastname` AS `lastname`,`basicinformations`.`genderid` AS `genderid`,`basicinformations`.`birthdate` AS `birthdate`,`genders`.`gender` AS `gender`,`dates`.`dates` AS `dates` from ((`basicinformations` join `genders` on((`basicinformations`.`genderid` = `genders`.`genderid`))) join `dates` on((`basicinformations`.`birthdate` = `dates`.`dateid`))) */;

/*View structure for view categories_view */

/*!50001 DROP TABLE IF EXISTS `categories_view` */;
/*!50001 DROP VIEW IF EXISTS `categories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `categories_view` AS select `categories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname` from `categories` */;

/*View structure for view customers_view */

/*!50001 DROP TABLE IF EXISTS `customers_view` */;
/*!50001 DROP VIEW IF EXISTS `customers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customers_view` AS select `customers`.`customerid` AS `customerid`,`customers`.`contactdetailid` AS `contactdetailid`,`customers`.`basicinformationid` AS `basicinformationid`,`contactdetails`.`addressid` AS `addressid`,`contactdetails`.`contactnumber` AS `contactnumber`,`contactdetails`.`emailaddress` AS `emailaddress`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province`,`basicinformations`.`firstname` AS `firstname`,`basicinformations`.`middlename` AS `middlename`,`basicinformations`.`lastname` AS `lastname`,`basicinformations`.`genderid` AS `genderid`,`basicinformations`.`birthdate` AS `birthdate`,`genders`.`gender` AS `gender` from ((((`customers` join `basicinformations` on((`customers`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `genders` on((`basicinformations`.`genderid` = `genders`.`genderid`))) join `contactdetails` on((`customers`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) */;

/*View structure for view dates_view */

/*!50001 DROP TABLE IF EXISTS `dates_view` */;
/*!50001 DROP VIEW IF EXISTS `dates_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `dates_view` AS select `dates`.`dateid` AS `dateid`,`dates`.`dates` AS `dates` from `dates` */;

/*View structure for view genders_view */

/*!50001 DROP TABLE IF EXISTS `genders_view` */;
/*!50001 DROP VIEW IF EXISTS `genders_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `genders_view` AS select `genders`.`genderid` AS `genderid`,`genders`.`gender` AS `gender` from `genders` */;

/*View structure for view inventories_view */

/*!50001 DROP TABLE IF EXISTS `inventories_view` */;
/*!50001 DROP VIEW IF EXISTS `inventories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `inventories_view` AS select `inventories`.`inventoryid` AS `inventoryid`,`inventories`.`productid` AS `productid`,`inventories`.`quantityinstocks` AS `quantityinstocks`,`inventories`.`reorderlevel` AS `reorderlevel`,`products`.`productname` AS `productname`,`products`.`productdescription` AS `productdescription`,`products`.`subcategoryid` AS `subcategoryid`,`products`.`productsku` AS `productsku`,`products`.`productprice` AS `productprice`,`subcategories`.`subcategory` AS `subcategory`,`subcategories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname`,`prices`.`price` AS `price` from ((((`inventories` join `products` on((`inventories`.`productid` = `products`.`productid`))) join `prices` on((`products`.`productprice` = `prices`.`priceid`))) join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view products_view */

/*!50001 DROP TABLE IF EXISTS `products_view` */;
/*!50001 DROP VIEW IF EXISTS `products_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `products_view` AS select `products`.`productid` AS `productid`,`products`.`productname` AS `productname`,`products`.`productdescription` AS `productdescription`,`products`.`subcategoryid` AS `subcategoryid`,`products`.`productsku` AS `productsku`,`products`.`productprice` AS `productprice`,`subcategories`.`subcategory` AS `subcategory`,`subcategories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname`,`prices`.`price` AS `price` from (((`products` join `prices` on((`products`.`productprice` = `prices`.`priceid`))) join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view staffs_view */

/*!50001 DROP TABLE IF EXISTS `staffs_view` */;
/*!50001 DROP VIEW IF EXISTS `staffs_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `staffs_view` AS select `staffs`.`staffid` AS `staffid`,`staffs`.`username` AS `username`,`staffs`.`password` AS `password`,`staffs`.`contactdetailid` AS `contactdetailid`,`staffs`.`basicinformationid` AS `basicinformationid`,`contactdetails`.`addressid` AS `addressid`,`contactdetails`.`contactnumber` AS `contactnumber`,`contactdetails`.`emailaddress` AS `emailaddress`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province`,`basicinformations`.`firstname` AS `firstname`,`basicinformations`.`middlename` AS `middlename`,`basicinformations`.`lastname` AS `lastname`,`basicinformations`.`genderid` AS `genderid`,`basicinformations`.`birthdate` AS `birthdate`,`genders`.`gender` AS `gender` from ((((`staffs` join `contactdetails` on((`staffs`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `genders` on((`basicinformations`.`genderid` = `genders`.`genderid`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
