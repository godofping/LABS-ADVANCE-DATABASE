/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - pos_musical_instruments_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pos_musical_instruments_db` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `pos_musical_instruments_db`;

/*Table structure for table `categories` */

DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
  `categoryid` int(6) NOT NULL AUTO_INCREMENT,
  `category` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `categories` */

insert  into `categories`(`categoryid`,`category`) values (1,'A'),(2,'B');

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(6) NOT NULL,
  `fullname` varchar(60) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `categoryid` int(6) DEFAULT NULL,
  `productname` varchar(60) DEFAULT NULL,
  `description` varchar(250) DEFAULT NULL,
  `price` float DEFAULT NULL,
  `stocks` int(11) DEFAULT NULL,
  PRIMARY KEY (`productid`),
  KEY `FK_products` (`categoryid`),
  CONSTRAINT `FK_products` FOREIGN KEY (`categoryid`) REFERENCES `categories` (`categoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `products` */

/*Table structure for table `productsintransactions` */

DROP TABLE IF EXISTS `productsintransactions`;

CREATE TABLE `productsintransactions` (
  `productintransactionid` int(6) NOT NULL AUTO_INCREMENT,
  `transactionid` int(6) DEFAULT NULL,
  `productid` int(6) DEFAULT NULL,
  `soldprice` float DEFAULT NULL,
  `quantity` int(6) DEFAULT NULL,
  `amount` float DEFAULT NULL,
  `cashtendered` float DEFAULT NULL,
  `change` float DEFAULT NULL,
  PRIMARY KEY (`productintransactionid`),
  KEY `FK_productsintransactions` (`productid`),
  KEY `FK_productsintransactions1` (`transactionid`),
  CONSTRAINT `FK_productsintransactions` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`),
  CONSTRAINT `FK_productsintransactions1` FOREIGN KEY (`transactionid`) REFERENCES `transactions` (`transactionid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `productsintransactions` */

/*Table structure for table `transactions` */

DROP TABLE IF EXISTS `transactions`;

CREATE TABLE `transactions` (
  `transactionid` int(6) NOT NULL AUTO_INCREMENT,
  `customerid` int(6) DEFAULT NULL,
  `transactiondatetime` datetime DEFAULT NULL,
  `totalamount` float DEFAULT NULL,
  PRIMARY KEY (`transactionid`),
  KEY `FK_transactions` (`customerid`),
  CONSTRAINT `FK_transactions` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `transactions` */

/*Table structure for table `categories_view` */

DROP TABLE IF EXISTS `categories_view`;

/*!50001 DROP VIEW IF EXISTS `categories_view` */;
/*!50001 DROP TABLE IF EXISTS `categories_view` */;

/*!50001 CREATE TABLE  `categories_view`(
 `CATEGORY ID` int(6) ,
 `CATEGORY` varchar(60) ,
 `C` varchar(71) 
)*/;

/*Table structure for table `customers_view` */

DROP TABLE IF EXISTS `customers_view`;

/*!50001 DROP VIEW IF EXISTS `customers_view` */;
/*!50001 DROP TABLE IF EXISTS `customers_view` */;

/*!50001 CREATE TABLE  `customers_view`(
 `CUSTOMER ID` int(6) ,
 `FULL NAME` varchar(60) ,
 `CONTACT NUMBER` varchar(60) ,
 `C` varchar(131) 
)*/;

/*Table structure for table `products_view` */

DROP TABLE IF EXISTS `products_view`;

/*!50001 DROP VIEW IF EXISTS `products_view` */;
/*!50001 DROP TABLE IF EXISTS `products_view` */;

/*!50001 CREATE TABLE  `products_view`(
 `PRODUCT ID` int(6) ,
 `CATEGORY ID` int(6) ,
 `PRODUCT NAME` varchar(60) ,
 `DESCRIPTION` varchar(250) ,
 `PRICE` float ,
 `STOCKS` int(11) ,
 `CATEGORY` varchar(60) ,
 `C` varchar(404) 
)*/;

/*View structure for view categories_view */

/*!50001 DROP TABLE IF EXISTS `categories_view` */;
/*!50001 DROP VIEW IF EXISTS `categories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `categories_view` AS select `categories`.`categoryid` AS `CATEGORY ID`,`categories`.`category` AS `CATEGORY`,concat(`categories`.`categoryid`,`categories`.`category`) AS `C` from `categories` */;

/*View structure for view customers_view */

/*!50001 DROP TABLE IF EXISTS `customers_view` */;
/*!50001 DROP VIEW IF EXISTS `customers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customers_view` AS select `customers`.`customerid` AS `CUSTOMER ID`,`customers`.`fullname` AS `FULL NAME`,`customers`.`contactnumber` AS `CONTACT NUMBER`,concat(`customers`.`customerid`,`customers`.`fullname`,`customers`.`contactnumber`) AS `C` from `customers` */;

/*View structure for view products_view */

/*!50001 DROP TABLE IF EXISTS `products_view` */;
/*!50001 DROP VIEW IF EXISTS `products_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `products_view` AS select `products`.`productid` AS `PRODUCT ID`,`products`.`categoryid` AS `CATEGORY ID`,`products`.`productname` AS `PRODUCT NAME`,`products`.`description` AS `DESCRIPTION`,`products`.`price` AS `PRICE`,`products`.`stocks` AS `STOCKS`,`categories`.`category` AS `CATEGORY`,concat(`products`.`productid`,`products`.`productname`,`products`.`description`,`products`.`price`,`products`.`stocks`,`categories`.`category`) AS `C` from (`products` join `categories` on((`products`.`categoryid` = `categories`.`categoryid`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
