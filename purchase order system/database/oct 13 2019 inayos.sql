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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

/*Data for the table `addresses` */

insert  into `addresses`(`addressid`,`address`,`city`,`zipcode`,`province`) values (12,'44 Ledesma St.','Tacurong City','9800','Sultan Kudarat'),(13,'Purok Pagibig','Midsayap','5800','North Cotabato'),(14,'Di Makita Street','Tacurong City','6000','Sultan Kudarat'),(15,'2','2','2','2'),(16,'addd','city','111111','pro'),(17,'44 Ledesma St., Purok 3 Poblacion','Tacurong City','9800','Sultan Kudarat'),(18,'44 Ledesma St. Tacurong City','Tacurong City','9800','Sultan Kudarat'),(19,'44 Ledesma St., Purok 3 Poblcaion','Tacurong City','9800','Sultan Kudarat'),(20,'sda','asd','123123','asd');

/*Table structure for table `basicinformations` */

DROP TABLE IF EXISTS `basicinformations`;

CREATE TABLE `basicinformations` (
  `basicinformationid` int(6) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `gender` varchar(60) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  PRIMARY KEY (`basicinformationid`),
  KEY `FK_basicinformations` (`gender`),
  KEY `FK_basicinfosrmations` (`birthdate`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `basicinformations` */

insert  into `basicinformations`(`basicinformationid`,`firstname`,`middlename`,`lastname`,`gender`,`birthdate`) values (9,'Rex Louis','Paradero','Roncesvalles','Male','2019-10-12'),(10,'Clarie Jane','Sagolili','Jadraque','Female','2019-10-17'),(11,'Thea Marie','Mali','Malinao','Female','1997-10-12'),(12,'2','1','1','Male','2019-10-12'),(13,'fn','mn','ln','Female','2019-10-13'),(14,'Rex Louis','Paradero','Roncesvalles','Male','1997-09-23'),(15,'Rex Louis','Paradero','Roncesvalles','Male','1997-10-23'),(16,'Rex Louis','Paradero','Roncesvalles','Male','1997-09-23'),(17,'tateasdasd','sd','sdasdasd','Male','2019-10-13');

/*Table structure for table `categories` */

DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
  `categoryid` int(6) NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(60) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `categories` */

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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `contactdetails` */

insert  into `contactdetails`(`contactdetailid`,`addressid`,`contactnumber`,`emailaddress`) values (9,12,'09754363944','rexmicrosoft@yahoo.com.ph'),(10,13,'09365412536','clarity10@gmail.com'),(11,14,'09734254142','thea@gmail.com'),(12,15,'2','2'),(13,16,'09754365565','asdasdasd@yahoo.com'),(14,17,'09754363944','rexmicrosoft@yahoo.com.ph'),(15,18,'09754363944','rexmicrosoft@yahoo.com.ph'),(16,19,'09754363944','rexmicrosoft@yahoo.com.ph'),(17,20,'asdasdasd','asd');

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(11) NOT NULL AUTO_INCREMENT,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`customerid`),
  KEY `FK_customers1` (`contactdetailid`),
  KEY `FK_customers` (`basicinformationid`),
  CONSTRAINT `FK_customers` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`),
  CONSTRAINT `FK_customers1` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`contactdetailid`,`basicinformationid`,`isdeleted`) values (16,9,9,0),(17,10,10,0),(18,11,11,0),(19,12,12,1);

/*Table structure for table `inventories` */

DROP TABLE IF EXISTS `inventories`;

CREATE TABLE `inventories` (
  `inventoryid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `quantityinstocks` int(6) DEFAULT NULL,
  `reorderlevel` int(6) DEFAULT NULL,
  `inventorylastupdated` date DEFAULT NULL,
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
  `orderdetailstatus` varchar(60) DEFAULT NULL,
  `orderdetailproductprice` float DEFAULT NULL,
  PRIMARY KEY (`orderdetailid`),
  KEY `FK_orderdetails` (`orderid`),
  KEY `FK_orderdetails1` (`productid`),
  KEY `FK_orderdetailsw` (`orderdetailstatus`),
  KEY `FK_ords89s8erdetails` (`orderdetailquantity`),
  KEY `FK_orderdd56etails` (`orderdetailproductprice`),
  CONSTRAINT `FK_orderdetails` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`),
  CONSTRAINT `FK_orderdetails1` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orderdetails` */

/*Table structure for table `orders` */

DROP TABLE IF EXISTS `orders`;

CREATE TABLE `orders` (
  `orderid` int(6) NOT NULL AUTO_INCREMENT,
  `customerid` int(6) DEFAULT NULL,
  `staffid` int(6) DEFAULT NULL,
  `orderstatus` varchar(60) DEFAULT NULL,
  `orderamountpaid` float DEFAULT NULL,
  `ordertotalamount` float DEFAULT NULL,
  `orderdate` date DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`orderid`),
  KEY `fkcustomerid` (`customerid`),
  KEY `FK_orders` (`staffid`),
  KEY `FK_orders56s` (`orderstatus`),
  KEY `FK_ordersd89` (`ordertotalamount`),
  KEY `FK_orders8s98` (`orderdate`),
  KEY `FK_o1rders` (`orderamountpaid`),
  CONSTRAINT `FK_orders` FOREIGN KEY (`staffid`) REFERENCES `staffs` (`staffid`),
  CONSTRAINT `fkcustomerid` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orders` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `productname` varchar(100) DEFAULT NULL,
  `productdescription` varchar(60) DEFAULT NULL,
  `subcategoryid` int(6) DEFAULT NULL,
  `productsku` varchar(60) DEFAULT NULL,
  `productprice` float DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`productid`),
  KEY `FK_items` (`subcategoryid`),
  KEY `FK_products` (`productprice`),
  CONSTRAINT `FK_items` FOREIGN KEY (`subcategoryid`) REFERENCES `subcategories` (`subcategoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `products` */

/*Table structure for table `purchaseorderdetails` */

DROP TABLE IF EXISTS `purchaseorderdetails`;

CREATE TABLE `purchaseorderdetails` (
  `purchaseorderdetailsid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `purchaseorderdetailquantity` int(6) DEFAULT NULL,
  `purchaseorderid` int(6) DEFAULT NULL,
  `purchaseorderdetailprice` float DEFAULT NULL,
  PRIMARY KEY (`purchaseorderdetailsid`),
  KEY `FK_purchaseorderdetails` (`purchaseorderid`),
  KEY `FK_purchaseorderdetails1` (`productid`),
  KEY `FK_purchaseordderdetails` (`purchaseorderdetailquantity`),
  KEY `FK_purchaseord2erdetails` (`purchaseorderdetailprice`),
  CONSTRAINT `FK_purchaseorderdetails` FOREIGN KEY (`purchaseorderid`) REFERENCES `purchaseorders` (`purchaseorderid`),
  CONSTRAINT `FK_purchaseorderdetails1` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorderdetails` */

/*Table structure for table `purchaseorders` */

DROP TABLE IF EXISTS `purchaseorders`;

CREATE TABLE `purchaseorders` (
  `purchaseorderid` int(6) NOT NULL AUTO_INCREMENT,
  `staffid` int(6) DEFAULT NULL,
  `supplierid` int(6) DEFAULT NULL,
  `purchaseorderstatus` varchar(60) DEFAULT NULL,
  `purchaseorderamountpaid` float DEFAULT NULL,
  `purchasetotalorderamount` float DEFAULT NULL,
  `purchaseorderdatedelivered` date DEFAULT NULL,
  `purchaseorderdaterequested` date DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`purchaseorderid`),
  KEY `FK_purchaseorders1` (`staffid`),
  KEY `FK_purchaseordersw` (`purchaseorderstatus`),
  KEY `FK_purc6565haseorders` (`purchasetotalorderamount`),
  KEY `FK_pus43rchaseorders` (`purchaseorderdatedelivered`),
  KEY `FK_purs4545chaseorders` (`purchaseorderdaterequested`),
  KEY `FK_purcha23seorders` (`purchaseorderamountpaid`),
  KEY `FK_p1urchaseorders` (`supplierid`),
  CONSTRAINT `FK_p1urchaseorders` FOREIGN KEY (`supplierid`) REFERENCES `suppliers` (`supplierid`),
  CONSTRAINT `FK_purchaseorders1` FOREIGN KEY (`staffid`) REFERENCES `staffs` (`staffid`),
  CONSTRAINT `FK_purchaseorders2` FOREIGN KEY (`supplierid`) REFERENCES `suppliers` (`supplierid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorders` */

/*Table structure for table `staffpositions` */

DROP TABLE IF EXISTS `staffpositions`;

CREATE TABLE `staffpositions` (
  `staffpositionid` int(6) NOT NULL AUTO_INCREMENT,
  `staffposition` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`staffpositionid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `staffpositions` */

insert  into `staffpositions`(`staffpositionid`,`staffposition`) values (1,'Manager'),(2,'Cashier');

/*Table structure for table `staffs` */

DROP TABLE IF EXISTS `staffs`;

CREATE TABLE `staffs` (
  `staffid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  `staffpositionid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`staffid`),
  KEY `FK_staffs` (`contactdetailid`),
  KEY `FK_staffsdff` (`basicinformationid`),
  KEY `FK_staf2fs` (`staffpositionid`),
  CONSTRAINT `FK_staf2fs` FOREIGN KEY (`staffpositionid`) REFERENCES `staffpositions` (`staffpositionid`),
  CONSTRAINT `FK_staffs` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`),
  CONSTRAINT `FK_staffsdff` FOREIGN KEY (`basicinformationid`) REFERENCES `basicinformations` (`basicinformationid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `staffs` */

insert  into `staffs`(`staffid`,`username`,`password`,`contactdetailid`,`basicinformationid`,`staffpositionid`,`isdeleted`) values (3,'admin','admin',16,16,1,0),(4,'ta','as',17,17,1,1);

/*Table structure for table `subcategories` */

DROP TABLE IF EXISTS `subcategories`;

CREATE TABLE `subcategories` (
  `subcategoryid` int(6) NOT NULL AUTO_INCREMENT,
  `subcategory` varchar(60) DEFAULT NULL,
  `categoryid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`subcategoryid`),
  KEY `FK_subcategories` (`categoryid`),
  CONSTRAINT `FK_subcategories` FOREIGN KEY (`categoryid`) REFERENCES `categories` (`categoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `subcategories` */

/*Table structure for table `supplierproducts` */

DROP TABLE IF EXISTS `supplierproducts`;

CREATE TABLE `supplierproducts` (
  `supplierproductid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `supplierid` int(6) DEFAULT NULL,
  PRIMARY KEY (`supplierproductid`),
  KEY `FK_vendorproducts` (`productid`),
  KEY `FK_ve1ndorproducts` (`supplierid`),
  CONSTRAINT `FK_ve1ndorproducts` FOREIGN KEY (`supplierid`) REFERENCES `suppliers` (`supplierid`),
  CONSTRAINT `FK_vendorproducts` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `supplierproducts` */

/*Table structure for table `suppliers` */

DROP TABLE IF EXISTS `suppliers`;

CREATE TABLE `suppliers` (
  `supplierid` int(6) NOT NULL AUTO_INCREMENT,
  `supplier` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`supplierid`),
  KEY `FK_vendors` (`contactdetailid`),
  CONSTRAINT `FK_vendors` FOREIGN KEY (`contactdetailid`) REFERENCES `contactdetails` (`contactdetailid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `suppliers` */

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

/*Table structure for table `basicinformations_view` */

DROP TABLE IF EXISTS `basicinformations_view`;

/*!50001 DROP VIEW IF EXISTS `basicinformations_view` */;
/*!50001 DROP TABLE IF EXISTS `basicinformations_view` */;

/*!50001 CREATE TABLE  `basicinformations_view`(
 `basicinformationid` int(6) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `lastname` varchar(60) ,
 `gender` varchar(60) ,
 `birthdate` date 
)*/;

/*Table structure for table `categories_view` */

DROP TABLE IF EXISTS `categories_view`;

/*!50001 DROP VIEW IF EXISTS `categories_view` */;
/*!50001 DROP TABLE IF EXISTS `categories_view` */;

/*!50001 CREATE TABLE  `categories_view`(
 `categoryid` int(6) ,
 `categoryname` varchar(60) 
)*/;

/*Table structure for table `contactdetails_view` */

DROP TABLE IF EXISTS `contactdetails_view`;

/*!50001 DROP VIEW IF EXISTS `contactdetails_view` */;
/*!50001 DROP TABLE IF EXISTS `contactdetails_view` */;

/*!50001 CREATE TABLE  `contactdetails_view`(
 `contactdetailid` int(6) ,
 `addressid` int(6) ,
 `contactnumber` varchar(60) ,
 `emailaddress` varchar(60) ,
 `address` varchar(60) ,
 `city` varchar(60) ,
 `zipcode` varchar(60) ,
 `province` varchar(60) 
)*/;

/*Table structure for table `customers_view` */

DROP TABLE IF EXISTS `customers_view`;

/*!50001 DROP VIEW IF EXISTS `customers_view` */;
/*!50001 DROP TABLE IF EXISTS `customers_view` */;

/*!50001 CREATE TABLE  `customers_view`(
 `Customer ID` int(11) ,
 `First Name` varchar(60) ,
 `Middle Name` varchar(60) ,
 `Last Name` varchar(60) ,
 `Gender` varchar(60) ,
 `Birth Date` date ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Province` varchar(60) ,
 `Zip Code` varchar(60) ,
 `contactdetailid` int(6) ,
 `basicinformationid` int(6) ,
 `addressid` int(6) ,
 `isdeleted` tinyint(1) 
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
 `productprice` float ,
 `subcategory` varchar(60) ,
 `categoryid` int(6) ,
 `categoryname` varchar(60) 
)*/;

/*Table structure for table `orders_view` */

DROP TABLE IF EXISTS `orders_view`;

/*!50001 DROP VIEW IF EXISTS `orders_view` */;
/*!50001 DROP TABLE IF EXISTS `orders_view` */;

/*!50001 CREATE TABLE  `orders_view`(
 `orderid` int(6) ,
 `customerid` int(6) ,
 `staffid` int(6) ,
 `orderstatus` varchar(60) ,
 `orderamountpaid` float ,
 `ordertotalamount` float ,
 `orderdate` date ,
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
 `gender` varchar(60) ,
 `birthdate` date ,
 `username` varchar(60) ,
 `password` varchar(60) ,
 `contactdetailidss` int(6) ,
 `basicinformationids` int(6) ,
 `staffpositionids` int(6) ,
 `firstnames` varchar(60) ,
 `middlenames` varchar(60) ,
 `lastnames` varchar(60) ,
 `genders` varchar(60) ,
 `birthdates` date ,
 `addressids` int(6) ,
 `contactnumbers` varchar(60) ,
 `emailaddresss` varchar(60) ,
 `addresss` varchar(60) ,
 `citys` varchar(60) ,
 `zipcodes` varchar(60) ,
 `provinces` varchar(60) 
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
 `productprice` float ,
 `subcategory` varchar(60) ,
 `categoryid` int(6) ,
 `categoryname` varchar(60) 
)*/;

/*Table structure for table `staffpositions_view` */

DROP TABLE IF EXISTS `staffpositions_view`;

/*!50001 DROP VIEW IF EXISTS `staffpositions_view` */;
/*!50001 DROP TABLE IF EXISTS `staffpositions_view` */;

/*!50001 CREATE TABLE  `staffpositions_view`(
 `staffpositionid` int(6) ,
 `staffposition` varchar(60) 
)*/;

/*Table structure for table `staffs_view` */

DROP TABLE IF EXISTS `staffs_view`;

/*!50001 DROP VIEW IF EXISTS `staffs_view` */;
/*!50001 DROP TABLE IF EXISTS `staffs_view` */;

/*!50001 CREATE TABLE  `staffs_view`(
 `Staff ID` int(6) ,
 `Username` varchar(60) ,
 `First Name` varchar(60) ,
 `Middle Name` varchar(60) ,
 `Last Name` varchar(60) ,
 `Gender` varchar(60) ,
 `Birth Date` date ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Province` varchar(60) ,
 `Zip Code` varchar(60) ,
 `Staff Position` varchar(60) ,
 `password` varchar(60) ,
 `contactdetailid` int(6) ,
 `basicinformationid` int(6) ,
 `staffpositionid` int(6) ,
 `addressid` int(6) ,
 `isdeleted` tinyint(4) 
)*/;

/*Table structure for table `subcategories_view` */

DROP TABLE IF EXISTS `subcategories_view`;

/*!50001 DROP VIEW IF EXISTS `subcategories_view` */;
/*!50001 DROP TABLE IF EXISTS `subcategories_view` */;

/*!50001 CREATE TABLE  `subcategories_view`(
 `subcategoryid` int(6) ,
 `subcategory` varchar(60) ,
 `categoryid` int(6) ,
 `categoryname` varchar(60) 
)*/;

/*Table structure for table `suppliers_view` */

DROP TABLE IF EXISTS `suppliers_view`;

/*!50001 DROP VIEW IF EXISTS `suppliers_view` */;
/*!50001 DROP TABLE IF EXISTS `suppliers_view` */;

/*!50001 CREATE TABLE  `suppliers_view`(
 `Supplier ID` int(6) ,
 `Supplier` varchar(60) ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Zip Code` varchar(60) ,
 `Province` varchar(60) ,
 `contactdetailid` int(6) ,
 `isdeleted` tinyint(1) ,
 `addressid` int(6) 
)*/;

/*View structure for view addresses_view */

/*!50001 DROP TABLE IF EXISTS `addresses_view` */;
/*!50001 DROP VIEW IF EXISTS `addresses_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `addresses_view` AS select `addresses`.`addressid` AS `addressid`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province` from `addresses` */;

/*View structure for view basicinformations_view */

/*!50001 DROP TABLE IF EXISTS `basicinformations_view` */;
/*!50001 DROP VIEW IF EXISTS `basicinformations_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `basicinformations_view` AS select `basicinformations`.`basicinformationid` AS `basicinformationid`,`basicinformations`.`firstname` AS `firstname`,`basicinformations`.`middlename` AS `middlename`,`basicinformations`.`lastname` AS `lastname`,`basicinformations`.`gender` AS `gender`,`basicinformations`.`birthdate` AS `birthdate` from `basicinformations` */;

/*View structure for view categories_view */

/*!50001 DROP TABLE IF EXISTS `categories_view` */;
/*!50001 DROP VIEW IF EXISTS `categories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `categories_view` AS select `categories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname` from `categories` */;

/*View structure for view contactdetails_view */

/*!50001 DROP TABLE IF EXISTS `contactdetails_view` */;
/*!50001 DROP VIEW IF EXISTS `contactdetails_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `contactdetails_view` AS select `contactdetails`.`contactdetailid` AS `contactdetailid`,`contactdetails`.`addressid` AS `addressid`,`contactdetails`.`contactnumber` AS `contactnumber`,`contactdetails`.`emailaddress` AS `emailaddress`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province` from (`contactdetails` join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) */;

/*View structure for view customers_view */

/*!50001 DROP TABLE IF EXISTS `customers_view` */;
/*!50001 DROP VIEW IF EXISTS `customers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customers_view` AS select `customers`.`customerid` AS `Customer ID`,`basicinformations`.`firstname` AS `First Name`,`basicinformations`.`middlename` AS `Middle Name`,`basicinformations`.`lastname` AS `Last Name`,`basicinformations`.`gender` AS `Gender`,`basicinformations`.`birthdate` AS `Birth Date`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`province` AS `Province`,`addresses`.`zipcode` AS `Zip Code`,`customers`.`contactdetailid` AS `contactdetailid`,`customers`.`basicinformationid` AS `basicinformationid`,`contactdetails`.`addressid` AS `addressid`,`customers`.`isdeleted` AS `isdeleted` from (((`customers` join `contactdetails` on((`customers`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `basicinformations` on((`customers`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) where (`customers`.`isdeleted` = 0) */;

/*View structure for view inventories_view */

/*!50001 DROP TABLE IF EXISTS `inventories_view` */;
/*!50001 DROP VIEW IF EXISTS `inventories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `inventories_view` AS select `inventories`.`inventoryid` AS `inventoryid`,`inventories`.`productid` AS `productid`,`inventories`.`quantityinstocks` AS `quantityinstocks`,`inventories`.`reorderlevel` AS `reorderlevel`,`products`.`productname` AS `productname`,`products`.`productdescription` AS `productdescription`,`products`.`subcategoryid` AS `subcategoryid`,`products`.`productsku` AS `productsku`,`products`.`productprice` AS `productprice`,`subcategories`.`subcategory` AS `subcategory`,`subcategories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname` from (((`inventories` join `products` on((`inventories`.`productid` = `products`.`productid`))) join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view orders_view */

/*!50001 DROP TABLE IF EXISTS `orders_view` */;
/*!50001 DROP VIEW IF EXISTS `orders_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `orders_view` AS select `orders`.`orderid` AS `orderid`,`orders`.`customerid` AS `customerid`,`orders`.`staffid` AS `staffid`,`orders`.`orderstatus` AS `orderstatus`,`orders`.`orderamountpaid` AS `orderamountpaid`,`orders`.`ordertotalamount` AS `ordertotalamount`,`orders`.`orderdate` AS `orderdate`,`customers`.`contactdetailid` AS `contactdetailid`,`customers`.`basicinformationid` AS `basicinformationid`,`contactdetails`.`addressid` AS `addressid`,`contactdetails`.`contactnumber` AS `contactnumber`,`contactdetails`.`emailaddress` AS `emailaddress`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province`,`basicinformations`.`firstname` AS `firstname`,`basicinformations`.`middlename` AS `middlename`,`basicinformations`.`lastname` AS `lastname`,`basicinformations`.`gender` AS `gender`,`basicinformations`.`birthdate` AS `birthdate`,`staffs`.`username` AS `username`,`staffs`.`password` AS `password`,`staffs`.`contactdetailid` AS `contactdetailidss`,`staffs`.`basicinformationid` AS `basicinformationids`,`staffs`.`staffpositionid` AS `staffpositionids`,`basicinformations_1`.`firstname` AS `firstnames`,`basicinformations_1`.`middlename` AS `middlenames`,`basicinformations_1`.`lastname` AS `lastnames`,`basicinformations_1`.`gender` AS `genders`,`basicinformations_1`.`birthdate` AS `birthdates`,`contactdetails_1`.`addressid` AS `addressids`,`contactdetails_1`.`contactnumber` AS `contactnumbers`,`contactdetails_1`.`emailaddress` AS `emailaddresss`,`addresses_1`.`address` AS `addresss`,`addresses_1`.`city` AS `citys`,`addresses_1`.`zipcode` AS `zipcodes`,`addresses_1`.`province` AS `provinces` from ((((((((`orders` join `customers` on((`orders`.`customerid` = `customers`.`customerid`))) join `staffs` on((`orders`.`staffid` = `staffs`.`staffid`))) join `contactdetails` on((`customers`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `basicinformations` on((`customers`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) join `basicinformations` `basicinformations_1` on((`staffs`.`basicinformationid` = `basicinformations_1`.`basicinformationid`))) join `contactdetails` `contactdetails_1` on((`staffs`.`contactdetailid` = `contactdetails_1`.`contactdetailid`))) join `addresses` `addresses_1` on((`contactdetails_1`.`addressid` = `addresses_1`.`addressid`))) */;

/*View structure for view products_view */

/*!50001 DROP TABLE IF EXISTS `products_view` */;
/*!50001 DROP VIEW IF EXISTS `products_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `products_view` AS select `products`.`productid` AS `productid`,`products`.`productname` AS `productname`,`products`.`productdescription` AS `productdescription`,`products`.`subcategoryid` AS `subcategoryid`,`products`.`productsku` AS `productsku`,`products`.`productprice` AS `productprice`,`subcategories`.`subcategory` AS `subcategory`,`subcategories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname` from ((`products` join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view staffpositions_view */

/*!50001 DROP TABLE IF EXISTS `staffpositions_view` */;
/*!50001 DROP VIEW IF EXISTS `staffpositions_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `staffpositions_view` AS select `staffpositions`.`staffpositionid` AS `staffpositionid`,`staffpositions`.`staffposition` AS `staffposition` from `staffpositions` */;

/*View structure for view staffs_view */

/*!50001 DROP TABLE IF EXISTS `staffs_view` */;
/*!50001 DROP VIEW IF EXISTS `staffs_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `staffs_view` AS select `staffs`.`staffid` AS `Staff ID`,`staffs`.`username` AS `Username`,`basicinformations`.`firstname` AS `First Name`,`basicinformations`.`middlename` AS `Middle Name`,`basicinformations`.`lastname` AS `Last Name`,`basicinformations`.`gender` AS `Gender`,`basicinformations`.`birthdate` AS `Birth Date`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`province` AS `Province`,`addresses`.`zipcode` AS `Zip Code`,`staffpositions`.`staffposition` AS `Staff Position`,`staffs`.`password` AS `password`,`staffs`.`contactdetailid` AS `contactdetailid`,`staffs`.`basicinformationid` AS `basicinformationid`,`staffs`.`staffpositionid` AS `staffpositionid`,`contactdetails`.`addressid` AS `addressid`,`staffs`.`isdeleted` AS `isdeleted` from ((((`staffs` join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `staffpositions` on((`staffs`.`staffpositionid` = `staffpositions`.`staffpositionid`))) join `contactdetails` on((`staffs`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) where (`staffs`.`isdeleted` = 0) */;

/*View structure for view subcategories_view */

/*!50001 DROP TABLE IF EXISTS `subcategories_view` */;
/*!50001 DROP VIEW IF EXISTS `subcategories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `subcategories_view` AS select `subcategories`.`subcategoryid` AS `subcategoryid`,`subcategories`.`subcategory` AS `subcategory`,`subcategories`.`categoryid` AS `categoryid`,`categories`.`categoryname` AS `categoryname` from (`subcategories` join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view suppliers_view */

/*!50001 DROP TABLE IF EXISTS `suppliers_view` */;
/*!50001 DROP VIEW IF EXISTS `suppliers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `suppliers_view` AS select `suppliers`.`supplierid` AS `Supplier ID`,`suppliers`.`supplier` AS `Supplier`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`zipcode` AS `Zip Code`,`addresses`.`province` AS `Province`,`suppliers`.`contactdetailid` AS `contactdetailid`,`suppliers`.`isdeleted` AS `isdeleted`,`contactdetails`.`addressid` AS `addressid` from ((`suppliers` join `contactdetails` on((`suppliers`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) where (`suppliers`.`isdeleted` = 0) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
