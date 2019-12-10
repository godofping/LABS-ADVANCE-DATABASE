/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - early_students_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`early_students_db` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `early_students_db`;

/*Table structure for table `strands` */

DROP TABLE IF EXISTS `strands`;

CREATE TABLE `strands` (
  `strandid` int(6) NOT NULL AUTO_INCREMENT,
  `strand` varchar(60) DEFAULT NULL,
  `stranddescription` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`strandid`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

/*Data for the table `strands` */

insert  into `strands`(`strandid`,`strand`,`stranddescription`) values (1,'GAS','General Academic Strand'),(4,'HUMSS','Humanities and Social Sciences'),(5,'TVL ICT','Technical-Vocational-Livelihood - Information and Communication Technology'),(6,'TVL EIM','Technical-Vocational-Livelihood - Industrial Arts'),(7,'TVL H.E','Technical-Vocational-Livelihood - Home Economics'),(8,'TVL AFA','Technical-Vocational-Livelihood - Agri-Fishery Arts'),(9,'STEM','Science, Technology, Engineering, and Mathematics'),(10,'ABM','Accountancy, Business and Management');

/*Table structure for table `students` */

DROP TABLE IF EXISTS `students`;

CREATE TABLE `students` (
  `studentid` int(6) NOT NULL AUTO_INCREMENT,
  `strandid` int(6) DEFAULT NULL,
  `lrn` varchar(60) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `middleinitial` varchar(3) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `parentsorguardian` varchar(100) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  `lastschoolattended` varchar(200) DEFAULT NULL,
  `schoolyear` varchar(60) DEFAULT NULL,
  `yearlevel` varchar(60) DEFAULT NULL,
  `dateadded` date DEFAULT NULL,
  PRIMARY KEY (`studentid`),
  KEY `FK_students` (`strandid`),
  CONSTRAINT `FK_students` FOREIGN KEY (`strandid`) REFERENCES `strands` (`strandid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `students` */

insert  into `students`(`studentid`,`strandid`,`lrn`,`lastname`,`firstname`,`middleinitial`,`address`,`parentsorguardian`,`contactnumber`,`lastschoolattended`,`schoolyear`,`yearlevel`,`dateadded`) values (1,4,'202-55525','RONCESVALLES','REX LOUIS','P','44 LEDESMA ST.','MILYN RONCESVALLES','09754363944','NOTRE DAME OF TACURONG COLLEGE','2018','GRADE 11','0000-00-00'),(3,1,'SADASD','ASDADSA','ASD','ASD','ASDASD','ASDASD','ASD','ASD','ASD','GRADE 11','2019-12-09');

/*Table structure for table `strands_view` */

DROP TABLE IF EXISTS `strands_view`;

/*!50001 DROP VIEW IF EXISTS `strands_view` */;
/*!50001 DROP TABLE IF EXISTS `strands_view` */;

/*!50001 CREATE TABLE  `strands_view`(
 `STRAND ID` int(6) ,
 `STRAND` varchar(60) ,
 `DESCRIPTION` varchar(250) ,
 `C` varchar(321) 
)*/;

/*Table structure for table `students_view` */

DROP TABLE IF EXISTS `students_view`;

/*!50001 DROP VIEW IF EXISTS `students_view` */;
/*!50001 DROP TABLE IF EXISTS `students_view` */;

/*!50001 CREATE TABLE  `students_view`(
 `STUDENT ID` int(6) ,
 `STRAND ID` int(6) ,
 `LRN` varchar(60) ,
 `FULL NAME` varchar(126) ,
 `LAST NAME` varchar(60) ,
 `FIRST NAME` varchar(60) ,
 `MIDDLE INITIAL` varchar(3) ,
 `ADDRESS` varchar(200) ,
 `PARENTS OR GUARDIAN` varchar(100) ,
 `CONTACT NUMBER` varchar(60) ,
 `LAST SCHOOL ATTENDED` varchar(200) ,
 `SCHOOL YEAR` varchar(60) ,
 `STRAND` varchar(60) ,
 `YEAR LEVEL` varchar(60) ,
 `DESCRIPTION` varchar(250) ,
 `DATE ADDED` date ,
 `C` text 
)*/;

/*View structure for view strands_view */

/*!50001 DROP TABLE IF EXISTS `strands_view` */;
/*!50001 DROP VIEW IF EXISTS `strands_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `strands_view` AS select `strands`.`strandid` AS `STRAND ID`,`strands`.`strand` AS `STRAND`,`strands`.`stranddescription` AS `DESCRIPTION`,concat(`strands`.`strandid`,`strands`.`strand`,`strands`.`stranddescription`) AS `C` from `strands` */;

/*View structure for view students_view */

/*!50001 DROP TABLE IF EXISTS `students_view` */;
/*!50001 DROP VIEW IF EXISTS `students_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `students_view` AS select `students`.`studentid` AS `STUDENT ID`,`students`.`strandid` AS `STRAND ID`,`students`.`lrn` AS `LRN`,concat(`students`.`lastname`,', ',`students`.`firstname`,' ',`students`.`middleinitial`) AS `FULL NAME`,`students`.`lastname` AS `LAST NAME`,`students`.`firstname` AS `FIRST NAME`,`students`.`middleinitial` AS `MIDDLE INITIAL`,`students`.`address` AS `ADDRESS`,`students`.`parentsorguardian` AS `PARENTS OR GUARDIAN`,`students`.`contactnumber` AS `CONTACT NUMBER`,`students`.`lastschoolattended` AS `LAST SCHOOL ATTENDED`,`students`.`schoolyear` AS `SCHOOL YEAR`,`strands`.`strand` AS `STRAND`,`students`.`yearlevel` AS `YEAR LEVEL`,`strands`.`stranddescription` AS `DESCRIPTION`,`students`.`dateadded` AS `DATE ADDED`,concat(`students`.`studentid`,`students`.`strandid`,`students`.`lrn`,`students`.`lastname`,`students`.`firstname`,`students`.`middleinitial`,`students`.`address`,`students`.`parentsorguardian`,`students`.`contactnumber`,`students`.`lastschoolattended`,`students`.`schoolyear`,`students`.`yearlevel`,`strands`.`strand`,`strands`.`stranddescription`) AS `C` from (`students` join `strands` on((`students`.`strandid` = `strands`.`strandid`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
