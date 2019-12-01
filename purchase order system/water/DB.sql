/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - waterrefillingstation
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`waterrefillingstation` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `waterrefillingstation`;

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(6) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  `address` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`customerid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`firstname`,`middlename`,`lastname`,`contactnumber`,`address`) values (3,'rex','para','ronc','0975455','asd5a4d5a4sd5');

/*Table structure for table `orderdetails` */

DROP TABLE IF EXISTS `orderdetails`;

CREATE TABLE `orderdetails` (
  `orderdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `orderid` int(6) DEFAULT NULL,
  `productid` int(6) DEFAULT NULL,
  `quantity` int(6) DEFAULT NULL,
  `price` int(6) DEFAULT NULL,
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
  `orderid` int(6) NOT NULL AUTO_INCREMENT,
  `customerid` int(6) DEFAULT NULL,
  `totalamount` float DEFAULT NULL,
  `dateandtime` datetime DEFAULT NULL,
  PRIMARY KEY (`orderid`),
  KEY `FK_orders` (`customerid`),
  CONSTRAINT `FK_orders` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orders` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `productcode` varchar(60) DEFAULT NULL,
  `productname` varchar(60) DEFAULT NULL,
  `price` float DEFAULT NULL,
  `stock` int(6) DEFAULT NULL,
  PRIMARY KEY (`productid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `products` */

insert  into `products`(`productid`,`productcode`,`productname`,`price`,`stock`) values (1,'aa11','aa asdasd11',23.95,0),(2,'aa','asdasdasd',23,51);

/*Table structure for table `view_customers` */

DROP TABLE IF EXISTS `view_customers`;

/*!50001 DROP VIEW IF EXISTS `view_customers` */;
/*!50001 DROP TABLE IF EXISTS `view_customers` */;

/*!50001 CREATE TABLE  `view_customers`(
 `CUSTOMER ID` int(6) ,
 `FIRST NAME` varchar(60) ,
 `MIDDLE NAME` varchar(60) ,
 `LAST NAME` varchar(60) ,
 `CONTACT NUMBER` varchar(60) ,
 `ADDRESS` varchar(60) ,
 `C` varchar(311) 
)*/;

/*Table structure for table `view_products` */

DROP TABLE IF EXISTS `view_products`;

/*!50001 DROP VIEW IF EXISTS `view_products` */;
/*!50001 DROP TABLE IF EXISTS `view_products` */;

/*!50001 CREATE TABLE  `view_products`(
 `PRODUCT ID` int(6) ,
 `PRODUCT CODE` varchar(60) ,
 `PRODUCT NAME` varchar(60) ,
 `PRICE` float ,
 `STOCK` int(6) ,
 `C` varchar(154) 
)*/;

/*View structure for view view_customers */

/*!50001 DROP TABLE IF EXISTS `view_customers` */;
/*!50001 DROP VIEW IF EXISTS `view_customers` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_customers` AS select `customers`.`customerid` AS `CUSTOMER ID`,`customers`.`firstname` AS `FIRST NAME`,`customers`.`middlename` AS `MIDDLE NAME`,`customers`.`lastname` AS `LAST NAME`,`customers`.`contactnumber` AS `CONTACT NUMBER`,`customers`.`address` AS `ADDRESS`,concat(`customers`.`customerid`,`customers`.`firstname`,`customers`.`middlename`,`customers`.`lastname`,`customers`.`contactnumber`,`customers`.`address`) AS `C` from `customers` */;

/*View structure for view view_products */

/*!50001 DROP TABLE IF EXISTS `view_products` */;
/*!50001 DROP VIEW IF EXISTS `view_products` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_products` AS select `products`.`productid` AS `PRODUCT ID`,`products`.`productcode` AS `PRODUCT CODE`,`products`.`productname` AS `PRODUCT NAME`,`products`.`price` AS `PRICE`,`products`.`stock` AS `STOCK`,concat(`products`.`productid`,`products`.`productcode`,`products`.`productname`,`products`.`price`,`products`.`stock`) AS `C` from `products` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
