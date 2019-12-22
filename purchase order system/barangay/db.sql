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

/*Table structure for table `accounts` */

DROP TABLE IF EXISTS `accounts`;

CREATE TABLE `accounts` (
  `accountid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`accountid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `accounts` */

/*Table structure for table `birthinformations` */

DROP TABLE IF EXISTS `birthinformations`;

CREATE TABLE `birthinformations` (
  `birthinformationid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `birthplace` varchar(60) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  PRIMARY KEY (`birthinformationid`),
  KEY `FK_birthinformations` (`residentid`),
  CONSTRAINT `FK_birthinformations` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `birthinformations` */

/*Table structure for table `citizenships` */

DROP TABLE IF EXISTS `citizenships`;

CREATE TABLE `citizenships` (
  `citizenshipid` int(6) NOT NULL AUTO_INCREMENT,
  `citizenship` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`citizenshipid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `citizenships` */

/*Table structure for table `civilstatuses` */

DROP TABLE IF EXISTS `civilstatuses`;

CREATE TABLE `civilstatuses` (
  `civilstatusid` int(6) NOT NULL AUTO_INCREMENT,
  `civilstatus` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`civilstatusid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `civilstatuses` */

/*Table structure for table `contactdetails` */

DROP TABLE IF EXISTS `contactdetails`;

CREATE TABLE `contactdetails` (
  `contactdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `emailaddress` varchar(60) DEFAULT NULL,
  `phonenumber` varchar(60) DEFAULT NULL,
  `cellphonenumber` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`contactdetailid`),
  KEY `FK_contactdetails` (`residentid`),
  CONSTRAINT `FK_contactdetails` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `contactdetails` */

/*Table structure for table `educationalattainments` */

DROP TABLE IF EXISTS `educationalattainments`;

CREATE TABLE `educationalattainments` (
  `educationalattainmentid` int(6) NOT NULL AUTO_INCREMENT,
  `educationalattainment` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`educationalattainmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `educationalattainments` */

/*Table structure for table `educations` */

DROP TABLE IF EXISTS `educations`;

CREATE TABLE `educations` (
  `educationid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `educationalattainmentid` int(6) NOT NULL,
  `course` varchar(100) DEFAULT NULL,
  `yeargraduated` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`educationid`),
  KEY `FK_educations` (`educationalattainmentid`),
  KEY `FK_educations1` (`residentid`),
  CONSTRAINT `FK_educations` FOREIGN KEY (`educationalattainmentid`) REFERENCES `educationalattainments` (`educationalattainmentid`),
  CONSTRAINT `FK_educations1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `educations` */

/*Table structure for table `homeaddressess` */

DROP TABLE IF EXISTS `homeaddressess`;

CREATE TABLE `homeaddressess` (
  `homeaddressid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `purokid` int(6) DEFAULT NULL,
  `housenumber` varchar(60) DEFAULT NULL,
  `street` varchar(60) DEFAULT NULL,
  `subdivision` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`homeaddressid`),
  KEY `FK_homeaddressess` (`purokid`),
  KEY `FK_homeaddressess1` (`residentid`),
  CONSTRAINT `FK_homeaddressess` FOREIGN KEY (`purokid`) REFERENCES `puroks` (`purokid`),
  CONSTRAINT `FK_homeaddressess1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `homeaddressess` */

/*Table structure for table `householdmembers` */

DROP TABLE IF EXISTS `householdmembers`;

CREATE TABLE `householdmembers` (
  `householdmemberid` int(6) NOT NULL AUTO_INCREMENT,
  `householdmember` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`householdmemberid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `householdmembers` */

/*Table structure for table `households` */

DROP TABLE IF EXISTS `households`;

CREATE TABLE `households` (
  `householdid` int(6) NOT NULL AUTO_INCREMENT,
  `household` varchar(60) DEFAULT NULL,
  `householdnumber` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`householdid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `households` */

/*Table structure for table `imagelocations` */

DROP TABLE IF EXISTS `imagelocations`;

CREATE TABLE `imagelocations` (
  `imagelocationid` int(6) NOT NULL,
  `residentid` int(6) DEFAULT NULL,
  `imagelocation` text,
  PRIMARY KEY (`imagelocationid`),
  KEY `FK_imagelocations` (`residentid`),
  CONSTRAINT `FK_imagelocations` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `imagelocations` */

/*Table structure for table `provincialaddresses` */

DROP TABLE IF EXISTS `provincialaddresses`;

CREATE TABLE `provincialaddresses` (
  `provincialaddressid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `municipality` varchar(60) DEFAULT NULL,
  `province` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`provincialaddressid`),
  KEY `FK_provincialaddresses` (`residentid`),
  CONSTRAINT `FK_provincialaddresses` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `provincialaddresses` */

/*Table structure for table `puroks` */

DROP TABLE IF EXISTS `puroks`;

CREATE TABLE `puroks` (
  `purokid` int(6) NOT NULL AUTO_INCREMENT,
  `purok` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`purokid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `puroks` */

/*Table structure for table `religions` */

DROP TABLE IF EXISTS `religions`;

CREATE TABLE `religions` (
  `religionid` int(6) NOT NULL AUTO_INCREMENT,
  `religion` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`religionid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `religions` */

/*Table structure for table `residents` */

DROP TABLE IF EXISTS `residents`;

CREATE TABLE `residents` (
  `residentid` int(6) NOT NULL AUTO_INCREMENT,
  `barangayidnumber` varchar(20) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `height` varchar(20) DEFAULT NULL,
  `precintnumber` varchar(60) DEFAULT NULL,
  `ctcnumber` varchar(60) DEFAULT NULL,
  `dateaccomplished` date DEFAULT NULL,
  `daterecorded` date DEFAULT NULL,
  PRIMARY KEY (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residents` */

/*Table structure for table `residentscitizenship` */

DROP TABLE IF EXISTS `residentscitizenship`;

CREATE TABLE `residentscitizenship` (
  `residentcitizenshipid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `citizenshipid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residentcitizenshipid`),
  KEY `FK_residentscitizenship` (`citizenshipid`),
  KEY `FK_residentscitizenship1` (`residentid`),
  CONSTRAINT `FK_residentscitizenship` FOREIGN KEY (`citizenshipid`) REFERENCES `citizenships` (`citizenshipid`),
  CONSTRAINT `FK_residentscitizenship1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentscitizenship` */

/*Table structure for table `residentscivilstatus` */

DROP TABLE IF EXISTS `residentscivilstatus`;

CREATE TABLE `residentscivilstatus` (
  `residentcivilstatusid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `civilstatusid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residentcivilstatusid`),
  KEY `FK_residentscivilstatus` (`civilstatusid`),
  KEY `FK_residentscivilstatus1` (`residentid`),
  CONSTRAINT `FK_residentscivilstatus` FOREIGN KEY (`civilstatusid`) REFERENCES `civilstatuses` (`civilstatusid`),
  CONSTRAINT `FK_residentscivilstatus1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentscivilstatus` */

/*Table structure for table `residentsex` */

DROP TABLE IF EXISTS `residentsex`;

CREATE TABLE `residentsex` (
  `residentsexid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `sexid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residentsexid`),
  KEY `FK_residentsex` (`sexid`),
  KEY `FK_residentsex1` (`residentid`),
  CONSTRAINT `FK_residentsex` FOREIGN KEY (`sexid`) REFERENCES `sex` (`sexid`),
  CONSTRAINT `FK_residentsex1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentsex` */

/*Table structure for table `residentshousehold` */

DROP TABLE IF EXISTS `residentshousehold`;

CREATE TABLE `residentshousehold` (
  `residenthouseholdid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `householdid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residenthouseholdid`),
  KEY `FK_residentshousehold` (`householdid`),
  KEY `FK_residentshousehold1` (`residentid`),
  CONSTRAINT `FK_residentshousehold` FOREIGN KEY (`householdid`) REFERENCES `households` (`householdid`),
  CONSTRAINT `FK_residentshousehold1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentshousehold` */

/*Table structure for table `residentshouseholdmember` */

DROP TABLE IF EXISTS `residentshouseholdmember`;

CREATE TABLE `residentshouseholdmember` (
  `residenthouseholdmemberid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `householdmemberid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residenthouseholdmemberid`),
  KEY `FK_residenthouseholdsmembers` (`householdmemberid`),
  KEY `FK_residentshouseholdmember` (`residentid`),
  CONSTRAINT `FK_residenthouseholdsmembers` FOREIGN KEY (`householdmemberid`) REFERENCES `householdmembers` (`householdmemberid`),
  CONSTRAINT `FK_residentshouseholdmember` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentshouseholdmember` */

/*Table structure for table `residentsreligion` */

DROP TABLE IF EXISTS `residentsreligion`;

CREATE TABLE `residentsreligion` (
  `residentreligionid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `religionid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residentreligionid`),
  KEY `FK_residentsreligion` (`religionid`),
  KEY `FK_residentsreligion1` (`residentid`),
  CONSTRAINT `FK_residentsreligion` FOREIGN KEY (`religionid`) REFERENCES `religions` (`religionid`),
  CONSTRAINT `FK_residentsreligion1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentsreligion` */

/*Table structure for table `sex` */

DROP TABLE IF EXISTS `sex`;

CREATE TABLE `sex` (
  `sexid` int(6) NOT NULL AUTO_INCREMENT,
  `sex` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`sexid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `sex` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
