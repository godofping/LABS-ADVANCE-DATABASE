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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `birthinformations` */

insert  into `birthinformations`(`birthinformationid`,`residentid`,`birthplace`,`birthdate`) values (1,1,'Tacurong City','1997-12-23'),(2,2,'Midsayap','1997-05-25');

/*Table structure for table `citizenships` */

DROP TABLE IF EXISTS `citizenships`;

CREATE TABLE `citizenships` (
  `citizenshipid` int(6) NOT NULL AUTO_INCREMENT,
  `citizenship` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`citizenshipid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `citizenships` */

insert  into `citizenships`(`citizenshipid`,`citizenship`) values (1,'FILIPINO'),(2,'ALIEN');

/*Table structure for table `civilstatuses` */

DROP TABLE IF EXISTS `civilstatuses`;

CREATE TABLE `civilstatuses` (
  `civilstatusid` int(6) NOT NULL AUTO_INCREMENT,
  `civilstatus` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`civilstatusid`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `civilstatuses` */

insert  into `civilstatuses`(`civilstatusid`,`civilstatus`) values (1,'SINGLE'),(2,'MARRIED'),(3,'IN A CIVIL UNION'),(4,'ADOPTED'),(5,'DIVORCED');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `contactdetails` */

insert  into `contactdetails`(`contactdetailid`,`residentid`,`emailaddress`,`phonenumber`,`cellphonenumber`) values (1,1,'rexmicrosoft@yahoo.com.ph','none','09754363944'),(2,2,'clarity10@gmail.com','502-65-5044','09168545224');

/*Table structure for table `educationalattainments` */

DROP TABLE IF EXISTS `educationalattainments`;

CREATE TABLE `educationalattainments` (
  `educationalattainmentid` int(6) NOT NULL AUTO_INCREMENT,
  `educationalattainment` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`educationalattainmentid`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `educationalattainments` */

insert  into `educationalattainments`(`educationalattainmentid`,`educationalattainment`) values (1,'ELEMENTARY LEVEL'),(2,'ELEMENTARY GRADUATE'),(3,'HIGH SCHOOL LEVEL'),(4,'HIGH SCHOOL GRADUATE'),(5,'COLLEGE LEVEL'),(6,'COLLEGE GRADUATE'),(7,'MASTERAL GRADUATE'),(8,'DOCTORAL GRADUATE'),(9,'OUT OF SCHOOL YOUTH');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `educations` */

insert  into `educations`(`educationid`,`residentid`,`educationalattainmentid`,`course`,`yeargraduated`) values (1,1,6,'BACHELOR OF SCIENCE IN COMPUTER SCIENCE','2017'),(2,2,7,'BACHELOR OF SCIENCE IN NURSING','2018');

/*Table structure for table `filelocations` */

DROP TABLE IF EXISTS `filelocations`;

CREATE TABLE `filelocations` (
  `filelocationid` int(6) NOT NULL AUTO_INCREMENT,
  `accomplishmentid` int(6) DEFAULT NULL,
  `filelocation` text,
  PRIMARY KEY (`filelocationid`),
  KEY `FK_filelocations` (`accomplishmentid`),
  CONSTRAINT `FK_filelocations` FOREIGN KEY (`accomplishmentid`) REFERENCES `accomplishments` (`accomplishmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `filelocations` */

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `homeaddressess` */

insert  into `homeaddressess`(`homeaddressid`,`residentid`,`purokid`,`housenumber`,`street`,`subdivision`) values (1,1,3,'44','LEDESMA STREET','POBLACION'),(2,2,4,'44','Ledesma Street','none');

/*Table structure for table `householdmembers` */

DROP TABLE IF EXISTS `householdmembers`;

CREATE TABLE `householdmembers` (
  `householdmemberid` int(6) NOT NULL AUTO_INCREMENT,
  `householdmember` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`householdmemberid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `householdmembers` */

insert  into `householdmembers`(`householdmemberid`,`householdmember`) values (1,'HEAD'),(2,'HUSBAND'),(3,'WIFE'),(4,'SON'),(5,'DAUGHTER');

/*Table structure for table `households` */

DROP TABLE IF EXISTS `households`;

CREATE TABLE `households` (
  `householdid` int(6) NOT NULL AUTO_INCREMENT,
  `household` varchar(60) DEFAULT NULL,
  `householdnumber` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`householdid`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `households` */

insert  into `households`(`householdid`,`household`,`householdnumber`) values (1,'MORALES','M10-0021'),(3,'RONCESVALLES','M10-0022'),(4,'PARADERO','M10-0023'),(5,'JADRAQUE','M10-0024'),(6,'MALINAO','M10-0025');

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

/*Table structure for table `occupations` */

DROP TABLE IF EXISTS `occupations`;

CREATE TABLE `occupations` (
  `occupationid` int(6) NOT NULL AUTO_INCREMENT,
  `occupation` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`occupationid`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=latin1;

/*Data for the table `occupations` */

insert  into `occupations`(`occupationid`,`occupation`) values (1,'NONE'),(2,'ACTIVISTS'),(3,'ARCHITECTS'),(4,'ARTISANS'),(5,'ARTISTS'),(6,'AVIATORS'),(7,'BUSINESS PEOPLE'),(8,'CARDINALS'),(9,'CHEFS'),(10,'CHOREOGRAPHERS'),(11,'CIVIL SERVANTS'),(12,'CONSULTANTS'),(13,'CRICKETERS'),(14,'CRIMINAL'),(15,'DIPLOMATS'),(16,'DOMESTIC WORKERS'),(17,'EDITORS'),(18,'EDUCATORS'),(19,'ENGINEERS'),(20,'ENTERTAINERS'),(21,'EXPLORERS'),(22,'FARMERS'),(23,'FOUNDERS'),(24,'HEADS OF THE PHILIPPINES'),(25,'HEALTH PROFESSIONS'),(26,'INVENTORS'),(27,'JEWELLERS'),(28,'JURISTS'),(29,'LAW ENFORCEMENT OFFICIALS'),(30,'LIBRARIANS'),(31,'MAKE UP ARTISTS'),(32,'MARKETING PEOPLE'),(33,'MEDIA PEOPLE'),(34,'MIGRANT WORKERS'),(35,'MILITARY PERSONNEL'),(36,'MISSIONARIES'),(37,'MODELS'),(38,'MONKS'),(39,'MUSIC PEOPLE'),(40,'PHILANTHROPISTS'),(41,'PHILOSOPHERS'),(42,'POLICE OFFICERS'),(43,'POLITICAL PEOPLE'),(44,'PRODUCERS'),(45,'PSYCHICS'),(46,'PUBLIC RELATIONS PEOPLE'),(47,'FILIPINO REBELS'),(48,'RELIGIOUS LEADERS'),(49,'SAILORS'),(50,'SCIENTISTS'),(51,'SEX WORKERS'),(52,'SILVERSMITHS'),(53,'SLAVES'),(54,'SOCIALITIES'),(55,'SPIES'),(56,'PEOPLE IN SPORTS'),(57,'THEATRE PEOPLE'),(58,'OFFICIALS OF THE UNITED NATIONS'),(59,'VIDEO GAME INDUSTRY'),(60,'WRITERS');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `provincialaddresses` */

insert  into `provincialaddresses`(`provincialaddressid`,`residentid`,`municipality`,`province`) values (1,1,'TACURONG CITY','SULTAN KUDARAT'),(2,2,'Tacurong City','Sultan Kudarat');

/*Table structure for table `puroks` */

DROP TABLE IF EXISTS `puroks`;

CREATE TABLE `puroks` (
  `purokid` int(6) NOT NULL AUTO_INCREMENT,
  `purok` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`purokid`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `puroks` */

insert  into `puroks`(`purokid`,`purok`) values (1,'MALIGAYA'),(2,'MABUHAY'),(3,'BAGONG SILANG'),(4,'BAGONG SIKAT'),(5,'PAG-ASA'),(6,'MABUHAY'),(7,'TAGUMPAY'),(8,'MASAGANA'),(9,'KAUNLARAN'),(10,'SITIO EL-ULIT');

/*Table structure for table `religions` */

DROP TABLE IF EXISTS `religions`;

CREATE TABLE `religions` (
  `religionid` int(6) NOT NULL AUTO_INCREMENT,
  `religion` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`religionid`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `religions` */

insert  into `religions`(`religionid`,`religion`) values (1,'ROMAN CATHOLIC CHRISTIANITY'),(2,'PROTESTANT CHRISTIANITY'),(3,'ISLAM'),(4,'OTHER'),(5,'TRIBAL RELIGIONS'),(6,'NONE');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residents` */

insert  into `residents`(`residentid`,`barangayidnumber`,`lastname`,`firstname`,`middlename`,`height`,`precintnumber`,`ctcnumber`,`dateaccomplished`,`daterecorded`) values (1,'1010','RONCESVALLES','REX LOUIS','PARADERO','165','PRECINT-AB','5000-51-200','2018-12-24','2019-12-23'),(2,'1001-250-55','JADRAQUE','CLARIE JANE','SAGOLILI','165','AB','253623-5243542','2019-11-12','2019-12-23');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentscitizenship` */

insert  into `residentscitizenship`(`residentcitizenshipid`,`residentid`,`citizenshipid`) values (1,1,1),(2,2,1);

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentscivilstatus` */

insert  into `residentscivilstatus`(`residentcivilstatusid`,`residentid`,`civilstatusid`) values (1,1,1),(2,2,1);

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentshousehold` */

insert  into `residentshousehold`(`residenthouseholdid`,`residentid`,`householdid`) values (1,1,1),(2,2,3);

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentshouseholdmember` */

insert  into `residentshouseholdmember`(`residenthouseholdmemberid`,`residentid`,`householdmemberid`) values (1,1,1),(2,2,3);

/*Table structure for table `residentsoccupation` */

DROP TABLE IF EXISTS `residentsoccupation`;

CREATE TABLE `residentsoccupation` (
  `residentoccupationid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `occupationid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residentoccupationid`),
  KEY `FK_residentsoccupation` (`occupationid`),
  KEY `FK_residentsoccupation1` (`residentid`),
  CONSTRAINT `FK_residentsoccupation` FOREIGN KEY (`occupationid`) REFERENCES `occupations` (`occupationid`),
  CONSTRAINT `FK_residentsoccupation1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentsoccupation` */

insert  into `residentsoccupation`(`residentoccupationid`,`residentid`,`occupationid`) values (1,1,51),(2,2,37);

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentsreligion` */

insert  into `residentsreligion`(`residentreligionid`,`residentid`,`religionid`) values (1,1,1),(2,2,2);

/*Table structure for table `residentssex` */

DROP TABLE IF EXISTS `residentssex`;

CREATE TABLE `residentssex` (
  `residentsexid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `sexid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residentsexid`),
  KEY `FK_residentsex1` (`residentid`),
  KEY `FK_residentssex` (`sexid`),
  CONSTRAINT `FK_residentsex` FOREIGN KEY (`sexid`) REFERENCES `sexes` (`sexid`),
  CONSTRAINT `FK_residentsex1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`),
  CONSTRAINT `FK_residentssex` FOREIGN KEY (`sexid`) REFERENCES `sexes` (`sexid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `residentssex` */

insert  into `residentssex`(`residentsexid`,`residentid`,`sexid`) values (1,1,1),(2,2,2);

/*Table structure for table `sexes` */

DROP TABLE IF EXISTS `sexes`;

CREATE TABLE `sexes` (
  `sexid` int(6) NOT NULL AUTO_INCREMENT,
  `sex` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`sexid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `sexes` */

insert  into `sexes`(`sexid`,`sex`) values (1,'MALE'),(2,'FEMALE');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
