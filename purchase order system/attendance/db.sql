/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - students_attendance_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`students_attendance_db` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `students_attendance_db`;

/*Table structure for table `attendances` */

DROP TABLE IF EXISTS `attendances`;

CREATE TABLE `attendances` (
  `attendanceid` int(6) NOT NULL AUTO_INCREMENT,
  `subjectsscheduleid` int(6) DEFAULT NULL,
  `roomeatcomputerassignmentid` int(6) DEFAULT NULL,
  `attendancedatetime` datetime DEFAULT NULL,
  `inorout` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`attendanceid`),
  KEY `FK_attendances` (`subjectsscheduleid`),
  KEY `FK_attendances1` (`roomeatcomputerassignmentid`),
  CONSTRAINT `FK_attendances` FOREIGN KEY (`subjectsscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`),
  CONSTRAINT `FK_attendances1` FOREIGN KEY (`roomeatcomputerassignmentid`) REFERENCES `roomseatcomputersassignment` (`roomeatcomputerassignmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `attendances` */

/*Table structure for table `commondetails` */

DROP TABLE IF EXISTS `commondetails`;

CREATE TABLE `commondetails` (
  `commondetailid` int(6) NOT NULL AUTO_INCREMENT,
  `addressid` int(6) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `gender` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`commondetailid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `commondetails` */

/*Table structure for table `computers` */

DROP TABLE IF EXISTS `computers`;

CREATE TABLE `computers` (
  `computerid` int(6) NOT NULL AUTO_INCREMENT,
  `computer` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`computerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `computers` */

/*Table structure for table `courses` */

DROP TABLE IF EXISTS `courses`;

CREATE TABLE `courses` (
  `courseid` int(6) NOT NULL AUTO_INCREMENT,
  `coursecode` varchar(20) DEFAULT NULL,
  `coursedescription` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`courseid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `courses` */

/*Table structure for table `enrollments` */

DROP TABLE IF EXISTS `enrollments`;

CREATE TABLE `enrollments` (
  `enrollmentid` int(6) NOT NULL AUTO_INCREMENT,
  `studentid` int(6) DEFAULT NULL,
  `schoolyearid` int(6) DEFAULT NULL,
  `semesterid` int(6) DEFAULT NULL,
  `yearlevelid` int(6) DEFAULT NULL,
  `courseid` int(6) DEFAULT NULL,
  PRIMARY KEY (`enrollmentid`),
  KEY `FK_enrollments` (`semesterid`),
  KEY `FK_enrollments1` (`yearlevelid`),
  KEY `FK_enrollments3` (`schoolyearid`),
  KEY `FK_enrollments2` (`studentid`),
  KEY `FK_enrollments4` (`courseid`),
  CONSTRAINT `FK_enrollments` FOREIGN KEY (`semesterid`) REFERENCES `semesters` (`semesterid`),
  CONSTRAINT `FK_enrollments1` FOREIGN KEY (`yearlevelid`) REFERENCES `yearlevels` (`yearlevelid`),
  CONSTRAINT `FK_enrollments2` FOREIGN KEY (`studentid`) REFERENCES `students` (`studentid`),
  CONSTRAINT `FK_enrollments3` FOREIGN KEY (`schoolyearid`) REFERENCES `schoolyears` (`schoolyearid`),
  CONSTRAINT `FK_enrollments4` FOREIGN KEY (`courseid`) REFERENCES `courses` (`courseid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `enrollments` */

/*Table structure for table `rooms` */

DROP TABLE IF EXISTS `rooms`;

CREATE TABLE `rooms` (
  `roomid` int(6) NOT NULL AUTO_INCREMENT,
  `room` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`roomid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `rooms` */

/*Table structure for table `roomseatcomputersassignment` */

DROP TABLE IF EXISTS `roomseatcomputersassignment`;

CREATE TABLE `roomseatcomputersassignment` (
  `roomeatcomputerassignmentid` int(6) NOT NULL AUTO_INCREMENT,
  `roomid` int(6) DEFAULT NULL,
  `seatid` int(6) DEFAULT NULL,
  `computerid` int(6) DEFAULT NULL,
  PRIMARY KEY (`roomeatcomputerassignmentid`),
  KEY `FK_roomseatcomputersassignment` (`roomid`),
  KEY `FK_roomseatcomputersassignment1` (`seatid`),
  KEY `FK_roomseatcomputersassignment2` (`computerid`),
  CONSTRAINT `FK_roomseatcomputersassignment` FOREIGN KEY (`roomid`) REFERENCES `rooms` (`roomid`),
  CONSTRAINT `FK_roomseatcomputersassignment1` FOREIGN KEY (`seatid`) REFERENCES `seats` (`seatid`),
  CONSTRAINT `FK_roomseatcomputersassignment2` FOREIGN KEY (`computerid`) REFERENCES `computers` (`computerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `roomseatcomputersassignment` */

/*Table structure for table `schoolyears` */

DROP TABLE IF EXISTS `schoolyears`;

CREATE TABLE `schoolyears` (
  `schoolyearid` int(6) NOT NULL AUTO_INCREMENT,
  `schoolyear` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`schoolyearid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `schoolyears` */

/*Table structure for table `seatassignments` */

DROP TABLE IF EXISTS `seatassignments`;

CREATE TABLE `seatassignments` (
  `seatassignmentid` int(6) NOT NULL AUTO_INCREMENT,
  `seatid` int(6) DEFAULT NULL,
  `studentsubjectenrolledid` int(6) DEFAULT NULL,
  PRIMARY KEY (`seatassignmentid`),
  KEY `FK_seatassignments1` (`seatid`),
  KEY `FK_seatassignments` (`studentsubjectenrolledid`),
  CONSTRAINT `FK_seatassignments` FOREIGN KEY (`studentsubjectenrolledid`) REFERENCES `studentsubjectsenrolled` (`studentsubjectenrolledid`),
  CONSTRAINT `FK_seatassignments1` FOREIGN KEY (`seatid`) REFERENCES `seats` (`seatid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `seatassignments` */

/*Table structure for table `seats` */

DROP TABLE IF EXISTS `seats`;

CREATE TABLE `seats` (
  `seatid` int(6) NOT NULL AUTO_INCREMENT,
  `seat` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`seatid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `seats` */

/*Table structure for table `semesters` */

DROP TABLE IF EXISTS `semesters`;

CREATE TABLE `semesters` (
  `semesterid` int(6) NOT NULL AUTO_INCREMENT,
  `semester` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`semesterid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `semesters` */

/*Table structure for table `students` */

DROP TABLE IF EXISTS `students`;

CREATE TABLE `students` (
  `studentid` int(6) NOT NULL AUTO_INCREMENT,
  `commondetailid` int(6) DEFAULT NULL,
  `studentidnumber` varchar(20) DEFAULT NULL,
  `rfid` varchar(200) DEFAULT NULL,
  `imagelocation` text,
  PRIMARY KEY (`studentid`),
  KEY `FK_students` (`commondetailid`),
  CONSTRAINT `FK_students` FOREIGN KEY (`commondetailid`) REFERENCES `commondetails` (`commondetailid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `students` */

/*Table structure for table `studentsubjectsenrolled` */

DROP TABLE IF EXISTS `studentsubjectsenrolled`;

CREATE TABLE `studentsubjectsenrolled` (
  `studentsubjectenrolledid` int(6) NOT NULL AUTO_INCREMENT,
  `enrollmentid` int(6) DEFAULT NULL,
  `subjectscheduleid` int(6) DEFAULT NULL,
  PRIMARY KEY (`studentsubjectenrolledid`),
  KEY `FK_studentsubjectsenrolled` (`subjectscheduleid`),
  KEY `FK_studentsubjectsenrolled1` (`enrollmentid`),
  CONSTRAINT `FK_studentsubjectsenrolled` FOREIGN KEY (`subjectscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`),
  CONSTRAINT `FK_studentsubjectsenrolled1` FOREIGN KEY (`enrollmentid`) REFERENCES `enrollments` (`enrollmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `studentsubjectsenrolled` */

/*Table structure for table `subjects` */

DROP TABLE IF EXISTS `subjects`;

CREATE TABLE `subjects` (
  `subjectid` int(6) NOT NULL AUTO_INCREMENT,
  `subjectcode` varchar(20) DEFAULT NULL,
  `subjectdescription` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`subjectid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `subjects` */

/*Table structure for table `subjectsschedules` */

DROP TABLE IF EXISTS `subjectsschedules`;

CREATE TABLE `subjectsschedules` (
  `subjectscheduleid` int(6) NOT NULL AUTO_INCREMENT,
  `subjectid` int(6) DEFAULT NULL,
  `teacherid` int(6) DEFAULT NULL,
  `roomid` int(6) DEFAULT NULL,
  `start` datetime DEFAULT NULL,
  `end` datetime DEFAULT NULL,
  `Monday` tinyint(1) DEFAULT NULL,
  `Tuesday` tinyint(1) DEFAULT NULL,
  `Wednesday` tinyint(1) DEFAULT NULL,
  `Thursday` tinyint(1) DEFAULT NULL,
  `Friday` tinyint(1) DEFAULT NULL,
  `Saturday` tinyint(1) DEFAULT NULL,
  `Sunday` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`subjectscheduleid`),
  KEY `FK_subjects` (`teacherid`),
  KEY `FK_subjectsschedules1` (`subjectid`),
  KEY `FK_subjectsschedules3` (`roomid`),
  CONSTRAINT `FK_subjects` FOREIGN KEY (`teacherid`) REFERENCES `teachers` (`teacherid`),
  CONSTRAINT `FK_subjectsschedules1` FOREIGN KEY (`subjectid`) REFERENCES `subjects` (`subjectid`),
  CONSTRAINT `FK_subjectsschedules3` FOREIGN KEY (`roomid`) REFERENCES `rooms` (`roomid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `subjectsschedules` */

/*Table structure for table `teachers` */

DROP TABLE IF EXISTS `teachers`;

CREATE TABLE `teachers` (
  `teacherid` int(6) NOT NULL AUTO_INCREMENT,
  `commondetailid` int(6) DEFAULT NULL,
  PRIMARY KEY (`teacherid`),
  KEY `FK_teachers` (`commondetailid`),
  CONSTRAINT `FK_teachers` FOREIGN KEY (`commondetailid`) REFERENCES `commondetails` (`commondetailid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `teachers` */

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `userid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `users` */

/*Table structure for table `yearlevels` */

DROP TABLE IF EXISTS `yearlevels`;

CREATE TABLE `yearlevels` (
  `yearlevelid` int(6) NOT NULL AUTO_INCREMENT,
  `yearlevel` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`yearlevelid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `yearlevels` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
