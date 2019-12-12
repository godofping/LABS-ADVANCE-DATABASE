/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - barangay_profiling_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`barangay_profiling_db` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `barangay_profiling_db`;

/*Table structure for table `accomplishments` */

DROP TABLE IF EXISTS `accomplishments`;

CREATE TABLE `accomplishments` (
  `accomplishmentid` int(6) NOT NULL AUTO_INCREMENT,
  `title` varchar(200) DEFAULT NULL,
  `dateaccomplished` date DEFAULT NULL,
  `filelocation` text,
  PRIMARY KEY (`accomplishmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `accomplishments` */

/*Table structure for table `residents` */

DROP TABLE IF EXISTS `residents`;

CREATE TABLE `residents` (
  `residentid` int(6) NOT NULL AUTO_INCREMENT,
  `barangayid` varchar(20) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `citizenship` varchar(60) DEFAULT NULL,
  `religion` varchar(60) DEFAULT NULL,
  `birthplace` varchar(200) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `sex` varchar(60) DEFAULT NULL,
  `height` varchar(20) DEFAULT NULL,
  `civilstatus` varchar(60) DEFAULT NULL,
  `educationalattainment` varchar(60) DEFAULT NULL,
  `yeargraduated` date DEFAULT NULL,
  `course` varchar(100) DEFAULT NULL,
  `professionoroccupation` varchar(100) DEFAULT NULL,
  `houseno` varchar(60) DEFAULT NULL,
  `street` varchar(60) DEFAULT NULL,
  `subdivision` varchar(60) DEFAULT NULL,
  `purok` varchar(60) DEFAULT NULL,
  `cityortown` varchar(60) DEFAULT NULL,
  `province` varchar(60) DEFAULT NULL,
  `precintno` varchar(60) DEFAULT NULL,
  `emailaddress` varchar(60) DEFAULT NULL,
  `phonenumber` varchar(60) DEFAULT NULL,
  `cellphonenumber` varchar(60) DEFAULT NULL,
  `ctcnumber` varchar(60) DEFAULT NULL,
  `dateaccomplished` date DEFAULT NULL,
  PRIMARY KEY (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residents` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
