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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `accomplishments` */

/*Table structure for table `accounts` */

DROP TABLE IF EXISTS `accounts`;

CREATE TABLE `accounts` (
  `accountid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`accountid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `accounts` */

insert  into `accounts`(`accountid`,`username`,`password`) values (1,'admin','admin'),(2,'ivy','ivy'),(3,'marianne','marianne');

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

/*Table structure for table `certifications` */

DROP TABLE IF EXISTS `certifications`;

CREATE TABLE `certifications` (
  `certificationid` int(6) NOT NULL AUTO_INCREMENT,
  `certification` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`certificationid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `certifications` */

insert  into `certifications`(`certificationid`,`certification`) values (1,'Residency Certification'),(2,'Land Ownership Certification'),(3,'Indigent Certification'),(4,'Death Certification');

/*Table structure for table `citizenships` */

DROP TABLE IF EXISTS `citizenships`;

CREATE TABLE `citizenships` (
  `citizenshipid` int(6) NOT NULL AUTO_INCREMENT,
  `citizenship` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`citizenshipid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `citizenships` */

insert  into `citizenships`(`citizenshipid`,`citizenship`) values (1,'Filipino'),(2,'Alien');

/*Table structure for table `civilstatuses` */

DROP TABLE IF EXISTS `civilstatuses`;

CREATE TABLE `civilstatuses` (
  `civilstatusid` int(6) NOT NULL AUTO_INCREMENT,
  `civilstatus` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`civilstatusid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `civilstatuses` */

insert  into `civilstatuses`(`civilstatusid`,`civilstatus`) values (1,'Single'),(2,'Married'),(3,'Widow/Widower/Legally Separated'),(4,'Divorced');

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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

/*Data for the table `educationalattainments` */

insert  into `educationalattainments`(`educationalattainmentid`,`educationalattainment`) values (1,'Elementary Level'),(2,'Elementary Graduate'),(3,'High School Level'),(4,'High School Graduate'),(5,'College Level'),(6,'College Graduate'),(7,'Master Graduate'),(8,'Doctor Graduate'),(9,'Vocational Graduate'),(11,'None');

/*Table structure for table `educations` */

DROP TABLE IF EXISTS `educations`;

CREATE TABLE `educations` (
  `educationid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `educationalattainmentid` int(6) NOT NULL,
  `course` varchar(100) DEFAULT NULL,
  `yeargraduated` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`educationid`),
  KEY `FK_educations` (`educationalattainmentid`),
  KEY `FK_educations1` (`residentid`),
  CONSTRAINT `FK_educations` FOREIGN KEY (`educationalattainmentid`) REFERENCES `educationalattainments` (`educationalattainmentid`),
  CONSTRAINT `FK_educations1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `educations` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `homeaddressess` */

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

/*Table structure for table `issuances` */

DROP TABLE IF EXISTS `issuances`;

CREATE TABLE `issuances` (
  `issuanceid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `certificationid` int(6) DEFAULT NULL,
  `issuancedateandtime` datetime DEFAULT NULL,
  PRIMARY KEY (`issuanceid`),
  KEY `FK_issuances` (`certificationid`),
  KEY `FK_issuances1` (`residentid`),
  CONSTRAINT `FK_issuances` FOREIGN KEY (`certificationid`) REFERENCES `certifications` (`certificationid`),
  CONSTRAINT `FK_issuances1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `issuances` */

/*Table structure for table `occupations` */

DROP TABLE IF EXISTS `occupations`;

CREATE TABLE `occupations` (
  `occupationid` int(6) NOT NULL AUTO_INCREMENT,
  `occupation` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`occupationid`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `occupations` */

insert  into `occupations`(`occupationid`,`occupation`) values (1,'None'),(2,'Agriculture, Food and Natural Resources'),(3,'Architecture and Construction'),(4,'Arts, Audio/Video Technology and Communications'),(5,'Business Management and Administration'),(6,'Education and Training'),(7,'Finance'),(8,'Government and Public Administration'),(9,'Health Science'),(10,'Hospitality and Tourism'),(11,'Human Services'),(12,'Information Technology'),(13,'Law, Public Safety, Corrections and Security'),(14,'Manufacturing'),(15,'Marketing, Sales and Service'),(16,'Science, Technology, Engineering and Mathematics'),(17,'Transportation, Distribution and Logistics');

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `puroks` */

insert  into `puroks`(`purokid`,`purok`) values (1,'Maligaya'),(2,'Mabuhay'),(3,'Bagong Silang'),(4,'Bagong Sikat'),(5,'Pag-asa'),(6,'Mabuhay'),(7,'Tagumpay'),(8,'Masagana'),(9,'Kaunlaran'),(10,'Sitio El-Ulit');

/*Table structure for table `religions` */

DROP TABLE IF EXISTS `religions`;

CREATE TABLE `religions` (
  `religionid` int(6) NOT NULL AUTO_INCREMENT,
  `religion` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`religionid`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;

/*Data for the table `religions` */

insert  into `religions`(`religionid`,`religion`) values (1,'Roman Catholic Church'),(2,'Islam'),(3,'Evangelicals'),(4,'Iglesia Ni Cristo'),(5,'Other Religious Affiliations'),(6,'Non-Catholic and Protestant (NCCP)'),(7,'Aglipayan'),(8,'Seventh-day Adventist'),(9,'Bible Baptist Church'),(10,'United Church of Christ in the Philippines'),(11,'Jehovah\'s Witnesses'),(12,'Other Protestants'),(13,'Church of Christ'),(14,'Jesus Is Lord Church Worldwide'),(15,'Tribal Religions'),(16,'United Pentecostal Church (Philippines) Inc.'),(17,'Other Baptists'),(18,'Philippine Independent Catholic Church'),(19,'Unión Espiritista Cristiana de Filipinas, Inc.'),(20,'The Church of Jesus Christ of Latter-day Saints'),(21,'Association of Fundamental Baptist Churches in the Philippin'),(22,'Evangelical Christian Outreach Foundation'),(23,'None'),(24,'Convention of the Philippine Baptist Church'),(25,'Crusaders of the Divine Church of Christ Inc.'),(26,'Buddhist'),(27,'Lutheran Church in the Philippines'),(28,'Iglesia sa Dios Espiritu Santo Inc.'),(29,'Philippine Benevolent Missionaries Association'),(30,'Faith Tabernacle Church (Living Rock Ministries)'),(31,'Others');

/*Table structure for table `residents` */

DROP TABLE IF EXISTS `residents`;

CREATE TABLE `residents` (
  `residentid` int(6) NOT NULL AUTO_INCREMENT,
  `barangayidnumber` varchar(20) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `height` varchar(4) DEFAULT NULL,
  `weight` varchar(4) DEFAULT NULL,
  `precintnumber` varchar(10) DEFAULT NULL,
  `ctcnumber` varchar(20) DEFAULT NULL,
  `dateaccomplished` date DEFAULT NULL,
  `daterecorded` date DEFAULT NULL,
  `ispwd` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`residentid`)
) ENGINE=InnoDB AUTO_INCREMENT=12024 DEFAULT CHARSET=latin1;

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
  CONSTRAINT `FK_residentscitizenship1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`) ON DELETE CASCADE
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

/*Table structure for table `residentshousehold` */

DROP TABLE IF EXISTS `residentshousehold`;

CREATE TABLE `residentshousehold` (
  `residenthouseholdid` int(6) NOT NULL AUTO_INCREMENT,
  `residentid` int(6) DEFAULT NULL,
  `householdid` int(6) DEFAULT NULL,
  `householdmemberid` int(6) DEFAULT NULL,
  PRIMARY KEY (`residenthouseholdid`),
  KEY `FK_residentshousehold` (`householdid`),
  KEY `FK_residentshousehold1` (`residentid`),
  KEY `FK_residentshousehold2` (`householdmemberid`),
  CONSTRAINT `FK_residentshousehold` FOREIGN KEY (`householdid`) REFERENCES `households` (`householdid`),
  CONSTRAINT `FK_residentshousehold1` FOREIGN KEY (`residentid`) REFERENCES `residents` (`residentid`),
  CONSTRAINT `FK_residentshousehold2` FOREIGN KEY (`householdmemberid`) REFERENCES `householdmembers` (`householdmemberid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentshousehold` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentsoccupation` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `residentssex` */

/*Table structure for table `sexes` */

DROP TABLE IF EXISTS `sexes`;

CREATE TABLE `sexes` (
  `sexid` int(6) NOT NULL AUTO_INCREMENT,
  `sex` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`sexid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `sexes` */

insert  into `sexes`(`sexid`,`sex`) values (1,'Male'),(2,'Female');

/*Table structure for table `householdsperpurok_view` */

DROP TABLE IF EXISTS `householdsperpurok_view`;

/*!50001 DROP VIEW IF EXISTS `householdsperpurok_view` */;
/*!50001 DROP TABLE IF EXISTS `householdsperpurok_view` */;

/*!50001 CREATE TABLE  `householdsperpurok_view`(
 `householdid` int(6) ,
 `purokid` int(6) 
)*/;

/*Table structure for table `identificationcard_view` */

DROP TABLE IF EXISTS `identificationcard_view`;

/*!50001 DROP VIEW IF EXISTS `identificationcard_view` */;
/*!50001 DROP TABLE IF EXISTS `identificationcard_view` */;

/*!50001 CREATE TABLE  `identificationcard_view`(
 `residentid` int(6) ,
 `lastname` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `height` varchar(4) ,
 `weight` varchar(4) ,
 `civilstatus` varchar(60) ,
 `cellphonenumber` varchar(60) ,
 `barangayidnumber` varchar(20) ,
 `ctcnumber` varchar(20) ,
 `householdnumber` varchar(60) ,
 `birthplace` varchar(60) ,
 `birthdate` date ,
 `sex` varchar(15) ,
 `purok` varchar(60) ,
 `housenumber` varchar(60) ,
 `street` varchar(60) ,
 `subdivision` varchar(60) 
)*/;

/*Table structure for table `issuances_view` */

DROP TABLE IF EXISTS `issuances_view`;

/*!50001 DROP VIEW IF EXISTS `issuances_view` */;
/*!50001 DROP TABLE IF EXISTS `issuances_view` */;

/*!50001 CREATE TABLE  `issuances_view`(
 `issuanceid` int(6) ,
 `residentid` int(6) ,
 `certificationid` int(6) ,
 `lastname` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `certification` varchar(60) ,
 `issuancedateandtime` datetime 
)*/;

/*Table structure for table `issuancesreports_view` */

DROP TABLE IF EXISTS `issuancesreports_view`;

/*!50001 DROP VIEW IF EXISTS `issuancesreports_view` */;
/*!50001 DROP TABLE IF EXISTS `issuancesreports_view` */;

/*!50001 CREATE TABLE  `issuancesreports_view`(
 `issuanceid` int(6) ,
 `residentid` int(6) ,
 `certificationid` int(6) ,
 `issuancedateandtime` datetime ,
 `certification` varchar(60) ,
 `lastname` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `barangayidnumber` varchar(20) ,
 `householdnumber` varchar(60) 
)*/;

/*Table structure for table `populationsummary_view` */

DROP TABLE IF EXISTS `populationsummary_view`;

/*!50001 DROP VIEW IF EXISTS `populationsummary_view` */;
/*!50001 DROP TABLE IF EXISTS `populationsummary_view` */;

/*!50001 CREATE TABLE  `populationsummary_view`(
 `Household` bigint(21) ,
 `Population` bigint(21) ,
 `Male` bigint(21) ,
 `female` bigint(21) ,
 `PWD` bigint(21) ,
 `Out of School Youth` bigint(21) 
)*/;

/*Table structure for table `purokspopulation_view` */

DROP TABLE IF EXISTS `purokspopulation_view`;

/*!50001 DROP VIEW IF EXISTS `purokspopulation_view` */;
/*!50001 DROP TABLE IF EXISTS `purokspopulation_view` */;

/*!50001 CREATE TABLE  `purokspopulation_view`(
 `purok` varchar(60) ,
 `Household` bigint(21) ,
 `Populations` bigint(21) ,
 `Male` bigint(21) ,
 `Female` bigint(21) 
)*/;

/*Table structure for table `purokspopulationfemale_view` */

DROP TABLE IF EXISTS `purokspopulationfemale_view`;

/*!50001 DROP VIEW IF EXISTS `purokspopulationfemale_view` */;
/*!50001 DROP TABLE IF EXISTS `purokspopulationfemale_view` */;

/*!50001 CREATE TABLE  `purokspopulationfemale_view`(
 `purokid` int(6) ,
 `sex` varchar(15) ,
 `total` bigint(21) 
)*/;

/*Table structure for table `purokspopulationmale_view` */

DROP TABLE IF EXISTS `purokspopulationmale_view`;

/*!50001 DROP VIEW IF EXISTS `purokspopulationmale_view` */;
/*!50001 DROP TABLE IF EXISTS `purokspopulationmale_view` */;

/*!50001 CREATE TABLE  `purokspopulationmale_view`(
 `purokid` int(6) ,
 `sex` varchar(15) ,
 `total` bigint(21) 
)*/;

/*Table structure for table `residency_view` */

DROP TABLE IF EXISTS `residency_view`;

/*!50001 DROP VIEW IF EXISTS `residency_view` */;
/*!50001 DROP TABLE IF EXISTS `residency_view` */;

/*!50001 CREATE TABLE  `residency_view`(
 `residentid` int(6) ,
 `lastname` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `ctcnumber` varchar(20) ,
 `civilstatus` varchar(60) ,
 `purok` varchar(60) ,
 `birthdate` date ,
 `age` bigint(21) 
)*/;

/*Table structure for table `residents_view` */

DROP TABLE IF EXISTS `residents_view`;

/*!50001 DROP VIEW IF EXISTS `residents_view` */;
/*!50001 DROP TABLE IF EXISTS `residents_view` */;

/*!50001 CREATE TABLE  `residents_view`(
 `residentid` int(6) ,
 `householdnumber` varchar(60) ,
 `householdmember` varchar(60) ,
 `lastname` varchar(60) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `ispwd` tinyint(1) ,
 `educationalattainment` varchar(60) ,
 `birthdate` date ,
 `age` bigint(21) ,
 `sex` varchar(15) ,
 `household` varchar(60) ,
 `purok` varchar(60) ,
 `householdid` int(6) 
)*/;

/*View structure for view householdsperpurok_view */

/*!50001 DROP TABLE IF EXISTS `householdsperpurok_view` */;
/*!50001 DROP VIEW IF EXISTS `householdsperpurok_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `householdsperpurok_view` AS select `households`.`householdid` AS `householdid`,`puroks`.`purokid` AS `purokid` from ((((`residentshousehold` join `households` on((`residentshousehold`.`householdid` = `households`.`householdid`))) join `residents` on((`residentshousehold`.`residentid` = `residents`.`residentid`))) join `homeaddressess` on((`homeaddressess`.`residentid` = `residents`.`residentid`))) join `puroks` on((`homeaddressess`.`purokid` = `puroks`.`purokid`))) group by `households`.`householdid`,`puroks`.`purokid` */;

/*View structure for view identificationcard_view */

/*!50001 DROP TABLE IF EXISTS `identificationcard_view` */;
/*!50001 DROP VIEW IF EXISTS `identificationcard_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `identificationcard_view` AS select `residents`.`residentid` AS `residentid`,`residents`.`lastname` AS `lastname`,`residents`.`firstname` AS `firstname`,`residents`.`middlename` AS `middlename`,`residents`.`height` AS `height`,`residents`.`weight` AS `weight`,`civilstatuses`.`civilstatus` AS `civilstatus`,`contactdetails`.`cellphonenumber` AS `cellphonenumber`,`residents`.`barangayidnumber` AS `barangayidnumber`,`residents`.`ctcnumber` AS `ctcnumber`,`households`.`householdnumber` AS `householdnumber`,`birthinformations`.`birthplace` AS `birthplace`,`birthinformations`.`birthdate` AS `birthdate`,`sexes`.`sex` AS `sex`,`puroks`.`purok` AS `purok`,`homeaddressess`.`housenumber` AS `housenumber`,`homeaddressess`.`street` AS `street`,`homeaddressess`.`subdivision` AS `subdivision` from ((((((((((`residentscivilstatus` join `civilstatuses` on((`residentscivilstatus`.`civilstatusid` = `civilstatuses`.`civilstatusid`))) join `residents` on((`residentscivilstatus`.`residentid` = `residents`.`residentid`))) join `contactdetails` on((`contactdetails`.`residentid` = `residents`.`residentid`))) join `residentshousehold` on((`residentshousehold`.`residentid` = `residents`.`residentid`))) join `households` on((`residentshousehold`.`householdid` = `households`.`householdid`))) join `birthinformations` on((`birthinformations`.`residentid` = `residents`.`residentid`))) join `residentssex` on((`residentssex`.`residentid` = `residents`.`residentid`))) join `sexes` on((`residentssex`.`sexid` = `sexes`.`sexid`))) join `homeaddressess` on((`homeaddressess`.`residentid` = `residents`.`residentid`))) join `puroks` on((`homeaddressess`.`purokid` = `puroks`.`purokid`))) */;

/*View structure for view issuances_view */

/*!50001 DROP TABLE IF EXISTS `issuances_view` */;
/*!50001 DROP VIEW IF EXISTS `issuances_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `issuances_view` AS select `issuances`.`issuanceid` AS `issuanceid`,`issuances`.`residentid` AS `residentid`,`issuances`.`certificationid` AS `certificationid`,`residents`.`lastname` AS `lastname`,`residents`.`firstname` AS `firstname`,`residents`.`middlename` AS `middlename`,`certifications`.`certification` AS `certification`,`issuances`.`issuancedateandtime` AS `issuancedateandtime` from ((`issuances` join `residents` on((`issuances`.`residentid` = `residents`.`residentid`))) join `certifications` on((`issuances`.`certificationid` = `certifications`.`certificationid`))) order by `issuances`.`issuanceid` */;

/*View structure for view issuancesreports_view */

/*!50001 DROP TABLE IF EXISTS `issuancesreports_view` */;
/*!50001 DROP VIEW IF EXISTS `issuancesreports_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `issuancesreports_view` AS select `issuances`.`issuanceid` AS `issuanceid`,`issuances`.`residentid` AS `residentid`,`issuances`.`certificationid` AS `certificationid`,`issuances`.`issuancedateandtime` AS `issuancedateandtime`,`certifications`.`certification` AS `certification`,`residents`.`lastname` AS `lastname`,`residents`.`firstname` AS `firstname`,`residents`.`middlename` AS `middlename`,`residents`.`barangayidnumber` AS `barangayidnumber`,`households`.`householdnumber` AS `householdnumber` from ((((`issuances` join `certifications` on((`issuances`.`certificationid` = `certifications`.`certificationid`))) join `residents` on((`issuances`.`residentid` = `residents`.`residentid`))) join `residentshousehold` on((`residentshousehold`.`residentid` = `residents`.`residentid`))) join `households` on((`residentshousehold`.`householdid` = `households`.`householdid`))) */;

/*View structure for view populationsummary_view */

/*!50001 DROP TABLE IF EXISTS `populationsummary_view` */;
/*!50001 DROP VIEW IF EXISTS `populationsummary_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `populationsummary_view` AS select (select count(0) from `households`) AS `Household`,(select count(0) from `residents_view`) AS `Population`,(select count(0) from `residents_view` where (`residents_view`.`sex` = 'Male')) AS `Male`,(select count(0) from `residents_view` where (`residents_view`.`sex` = 'Female')) AS `female`,(select count(0) from `residents_view` where (`residents_view`.`ispwd` = '1')) AS `PWD`,(select count(0) from `residents_view` where (((`residents_view`.`educationalattainment` = 'none') or (`residents_view`.`educationalattainment` = 'Elementary Level') or (`residents_view`.`educationalattainment` = 'Elementary Graduate') or (`residents_view`.`educationalattainment` = 'High School Level') or (`residents_view`.`educationalattainment` = 'High School Graduate') or (`residents_view`.`educationalattainment` = 'College Level')) and (`residents_view`.`age` <= 24) and (`residents_view`.`age` >= 12))) AS `Out of School Youth` from `residents_view` limit 1 */;

/*View structure for view purokspopulation_view */

/*!50001 DROP TABLE IF EXISTS `purokspopulation_view` */;
/*!50001 DROP VIEW IF EXISTS `purokspopulation_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purokspopulation_view` AS select `puroks`.`purok` AS `purok`,coalesce((select count(0) from `householdsperpurok_view` where (`householdsperpurok_view`.`purokid` = `puroks`.`purokid`)),0) AS `Household`,(select count(0) from `homeaddressess` where (`homeaddressess`.`purokid` = `puroks`.`purokid`)) AS `Populations`,coalesce((select `purokspopulationmale_view`.`total` from `purokspopulationmale_view` where (`purokspopulationmale_view`.`purokid` = `puroks`.`purokid`)),0) AS `Male`,coalesce((select `purokspopulationfemale_view`.`total` from `purokspopulationfemale_view` where (`purokspopulationfemale_view`.`purokid` = `puroks`.`purokid`)),0) AS `Female` from `puroks` */;

/*View structure for view purokspopulationfemale_view */

/*!50001 DROP TABLE IF EXISTS `purokspopulationfemale_view` */;
/*!50001 DROP VIEW IF EXISTS `purokspopulationfemale_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purokspopulationfemale_view` AS select `puroks`.`purokid` AS `purokid`,`sexes`.`sex` AS `sex`,count(0) AS `total` from ((((((`residentshousehold` join `households` on((`residentshousehold`.`householdid` = `households`.`householdid`))) join `residents` on((`residentshousehold`.`residentid` = `residents`.`residentid`))) join `homeaddressess` on((`homeaddressess`.`residentid` = `residents`.`residentid`))) join `puroks` on((`homeaddressess`.`purokid` = `puroks`.`purokid`))) join `residentssex` on((`residentssex`.`residentid` = `residents`.`residentid`))) join `sexes` on((`residentssex`.`sexid` = `sexes`.`sexid`))) where (`sexes`.`sex` = 'Female') group by `puroks`.`purokid` */;

/*View structure for view purokspopulationmale_view */

/*!50001 DROP TABLE IF EXISTS `purokspopulationmale_view` */;
/*!50001 DROP VIEW IF EXISTS `purokspopulationmale_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purokspopulationmale_view` AS select `puroks`.`purokid` AS `purokid`,`sexes`.`sex` AS `sex`,count(0) AS `total` from ((((((`residentshousehold` join `households` on((`residentshousehold`.`householdid` = `households`.`householdid`))) join `residents` on((`residentshousehold`.`residentid` = `residents`.`residentid`))) join `homeaddressess` on((`homeaddressess`.`residentid` = `residents`.`residentid`))) join `puroks` on((`homeaddressess`.`purokid` = `puroks`.`purokid`))) join `residentssex` on((`residentssex`.`residentid` = `residents`.`residentid`))) join `sexes` on((`residentssex`.`sexid` = `sexes`.`sexid`))) where (`sexes`.`sex` = 'Male') group by `puroks`.`purokid` */;

/*View structure for view residency_view */

/*!50001 DROP TABLE IF EXISTS `residency_view` */;
/*!50001 DROP VIEW IF EXISTS `residency_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `residency_view` AS select `residents`.`residentid` AS `residentid`,`residents`.`lastname` AS `lastname`,`residents`.`firstname` AS `firstname`,`residents`.`middlename` AS `middlename`,`residents`.`ctcnumber` AS `ctcnumber`,`civilstatuses`.`civilstatus` AS `civilstatus`,`puroks`.`purok` AS `purok`,`birthinformations`.`birthdate` AS `birthdate`,timestampdiff(YEAR,`birthinformations`.`birthdate`,curdate()) AS `age` from (((((`residentscivilstatus` join `civilstatuses` on((`residentscivilstatus`.`civilstatusid` = `civilstatuses`.`civilstatusid`))) join `residents` on((`residentscivilstatus`.`residentid` = `residents`.`residentid`))) join `homeaddressess` on((`homeaddressess`.`residentid` = `residents`.`residentid`))) join `puroks` on((`homeaddressess`.`purokid` = `puroks`.`purokid`))) join `birthinformations` on((`birthinformations`.`residentid` = `residents`.`residentid`))) */;

/*View structure for view residents_view */

/*!50001 DROP TABLE IF EXISTS `residents_view` */;
/*!50001 DROP VIEW IF EXISTS `residents_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `residents_view` AS select `residents`.`residentid` AS `residentid`,`households`.`householdnumber` AS `householdnumber`,`householdmembers`.`householdmember` AS `householdmember`,`residents`.`lastname` AS `lastname`,`residents`.`firstname` AS `firstname`,`residents`.`middlename` AS `middlename`,`residents`.`ispwd` AS `ispwd`,`educationalattainments`.`educationalattainment` AS `educationalattainment`,`birthinformations`.`birthdate` AS `birthdate`,timestampdiff(YEAR,`birthinformations`.`birthdate`,curdate()) AS `age`,`sexes`.`sex` AS `sex`,`households`.`household` AS `household`,`puroks`.`purok` AS `purok`,`households`.`householdid` AS `householdid` from ((((((((((`educations` join `educationalattainments` on((`educations`.`educationalattainmentid` = `educationalattainments`.`educationalattainmentid`))) join `residents` on((`educations`.`residentid` = `residents`.`residentid`))) join `birthinformations` on((`birthinformations`.`residentid` = `residents`.`residentid`))) join `residentshousehold` on((`residentshousehold`.`residentid` = `residents`.`residentid`))) join `households` on((`residentshousehold`.`householdid` = `households`.`householdid`))) join `residentssex` on((`residentssex`.`residentid` = `residents`.`residentid`))) join `sexes` on((`residentssex`.`sexid` = `sexes`.`sexid`))) join `householdmembers` on((`residentshousehold`.`householdmemberid` = `householdmembers`.`householdmemberid`))) join `homeaddressess` on((`homeaddressess`.`residentid` = `residents`.`residentid`))) join `puroks` on((`homeaddressess`.`purokid` = `puroks`.`purokid`))) order by `residents`.`residentid` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
