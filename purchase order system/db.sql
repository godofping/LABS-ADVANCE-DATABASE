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

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(11) NOT NULL AUTO_INCREMENT,
  `lastname` text NOT NULL,
  `firstname` text NOT NULL,
  `middleinitial` text NOT NULL,
  `age` int(2) DEFAULT NULL,
  `address` text,
  `tribe` text,
  PRIMARY KEY (`customerid`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`lastname`,`firstname`,`middleinitial`,`age`,`address`,`tribe`) values (1,'Jadraque','Clarie Jane','S',23,'Midsayap, North Cotabato','Bisaya'),(2,'Masukat','Rasol','N',22,'Isulan, Sultan Kudarat','Maguindanaon'),(3,'Ancheta','Vince Lev French','L',22,'Tacurong City, Sultan Kudarat','Ilokano'),(4,'Yale','Albert','T',21,'Tacurong City, Sultan Kudarat','Ilonggo'),(5,'Malinao','Thea Marie','R',22,'Midsayap, North Cotabato','Bisaya'),(8,'3','3','3',3,'3','3'),(9,'4','4','4',4,'4','4'),(10,'2','2','2',2,'2','2');

/*Table structure for table `items` */

DROP TABLE IF EXISTS `items`;

CREATE TABLE `items` (
  `itemid` int(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`itemid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `items` */

/*Table structure for table `orderdetails` */

DROP TABLE IF EXISTS `orderdetails`;

CREATE TABLE `orderdetails` (
  `orderdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `orderid` int(6) DEFAULT NULL,
  `itemid` int(6) DEFAULT NULL,
  `description` text,
  `unitprice` float DEFAULT NULL,
  `qty` int(6) DEFAULT NULL,
  `amount` float DEFAULT NULL,
  `status` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`orderdetailid`),
  KEY `FK_orderdetails` (`orderid`),
  KEY `FK_orderdetails1` (`itemid`),
  CONSTRAINT `FK_orderdetails` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`),
  CONSTRAINT `FK_orderdetails1` FOREIGN KEY (`itemid`) REFERENCES `items` (`itemid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orderdetails` */

/*Table structure for table `orders` */

DROP TABLE IF EXISTS `orders`;

CREATE TABLE `orders` (
  `orderid` int(11) NOT NULL AUTO_INCREMENT,
  `customerid` int(11) NOT NULL,
  `date` tinytext NOT NULL,
  `amountpaid` decimal(10,0) NOT NULL,
  `chargeamount` decimal(10,0) NOT NULL,
  `status` tinytext NOT NULL,
  PRIMARY KEY (`orderid`),
  KEY `fkcustomerid` (`customerid`),
  CONSTRAINT `fkcustomerid` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `orders` */

insert  into `orders`(`orderid`,`customerid`,`date`,`amountpaid`,`chargeamount`,`status`) values (1,1,'10-10-2019','2000','100','Success');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
