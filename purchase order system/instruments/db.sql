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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

/*Data for the table `categories` */

insert  into `categories`(`categoryid`,`category`) values (25,'GUITARS'),(26,'DRUMS AND PERCUSSION'),(27,'KEYBOARD'),(28,'ORCHESTRAL');

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(6) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(60) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`customerid`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`fullname`,`contactnumber`) values (2,'Rex Louis P. Roncesvalles','09754363944'),(3,'John Doe','09168575441'),(4,'Clarie Jane Sagolili Jadraque','09455269985'),(6,'Thea Marie Malinao','09253645858');

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `categoryid` int(6) DEFAULT NULL,
  `productname` varchar(250) DEFAULT NULL,
  `description` text,
  `price` float DEFAULT NULL,
  `stocks` int(11) DEFAULT NULL,
  PRIMARY KEY (`productid`),
  KEY `FK_products` (`categoryid`),
  CONSTRAINT `FK_products` FOREIGN KEY (`categoryid`) REFERENCES `categories` (`categoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `products` */

insert  into `products`(`productid`,`categoryid`,`productname`,`description`,`price`,`stocks`) values (2,25,'JACKSON JS11 DINKY (BLACK)','Swift, deadly and affordable, Jackson JS Series guitars take an epic leap forward, making it easier than ever to get classic Jackson tone, looks and playability without breaking the bank.',13600,19),(3,25,'JACKSON JS32T KELLY (SATIN BLACK)','Part of Jackson\'s J Series, the JS32T Kelly solidbody electric guitar packs a lot of value. A pair of high-output ceramic-magnet humbuckers hits your amplifier with huge tone - just what you need for an aggressive performance. ',23300,2),(4,25,'JACKSON JS32T RHOADS (WHITE)','Swift, deadly and affordable, Jackson JS Series guitars take an epic leap forward, making it easier than ever to get classic Jackson tone, looks and playability without breaking the bank. Upgraded features such as striking aesthetics, new high-output ceramic-magnet pickups, graphite-reinforced maple necks, bound fingerboards and headstocks, and black hardware deliver more for less.',22450,4),(5,25,'ACCENT CS-2 ACOUSTIC GUITAR','CS-2 Accent Guitar : Accent is the new name in affordable, quality-made, and traditionally inspired acoustic folk guitars from Saga. With a host of high-end features combined in true vintage style, Accent Folk guitars are sure to change the way that student guitars are viewed by all and raise the bar of quality and value to a whole new level.',2340,9),(6,25,'TAKAMINE ED1NC ACOUSTIC ELECTRIC GUITAR WITH PICKUP & TUNER','Takamine ED1NC ACOUSTIC ELECT.GTR WTUNER EQ\r\nED1NC comes with a dreadnought shape the sound in a wide dynamic range and deep in every tune. Spruce top and Mahogany wood back and sides. Satin finish with matte lamination comes with pre-amp and TP-E Preamp with built-in tuner.',15525,11),(7,26,'LUDWIG L26223TX3Q NEUSONIC SERIES DRUM SET','NeuSonic Series\r\n\r\nSonically rich for the working-professional\r\n\r\nElevating our sonic palette, Ludwig is proud to introduce a new line of USA drums crafted for the working professional! NeuSonic series drums by Ludwig offers yet another tonally rich option for the drummer looking for reliability and performance for every working professional setting.\r\n\r\nThey feature a cross-over shell de',158000,4),(8,26,'FERNANDO JUNIOR DRUM SET JBJ1045 (WINE RED)','Fernando Junior Drum Set JBJ1045 (Wine Red)\r\n•Fernando Junior Drum Set JBJ1045 (Wine Red)\r\n\r\n•Junior Drum Set\r\n\r\n•JBJ1045\r\n\r\n•Wine Red',13350,9),(9,27,'ARTURIA KEYLAB ESSENTIAL 61 KEYBOARD MIDI CONTROLLER','Arturia Keylab Essential 61 Keyboard Midi Controller\r\n\r\nCreating music in the digital world is sometimes a little challenging. So many distractions, so many new things to learn. KeyLab Essential lets you focus on what’s important…',16875,24),(10,27,'M-AUDIO DIGITAL PIANO 88 KEYS WEIGHTED ACCENT','Professional-level performance, versatility and features at an unexpected value!\r\n\r\nThe M-Audio Accent is an affordable full-sized 88-key digital piano that has the professional features, versatility, natural playing response and rich sound to meet any requirement. Easy to transport and set up, the Accent is ideal for piano students, stage and studio use, schools, theaters, and houses of worship. It has 20 built-in piano voices (such as Grand Piano, Electric Piano, Drawbar Organ, etc.) and the versatility to split or layer three voices simultaneously. The full range of built-in features enables you to play any music and sound great—from classical to jazz to hip-hop to religious. Designed with simplicity and ease of use in mind, the Accent is elegant and subtle, packed with elements that make it easy for you to be at your creative best.',15575,18),(11,28,'BACH TR710DIR TRUMPET','This trumpet is one of the best starters instruments, featuring a great sound and intonation that is expected from instruments of a much higher price tag. As well as that, the Prelude TR710 Trumpet includes a free gig bag, Bach 7C mouthpiece and extras.',21750,19),(12,28,'CONN CAS280 ALTO SAX','The Conn CAS280 Alto Saxophone\'s fluid keywork gives it a relaxed feeling, while its perfect intonation and warm sound make it a welcome instrument both in the concert band or the hands of a soloist. The Conn La Voix II sax\' traditional-sized bell helps saxophonists keep their tone focused and makes blending easy.\r\nIdeal for concert band and solo playing Professional key styling Includes trek-style case Conn mouthpiece Ligature and cap',115650,24),(13,28,'CERVINI HV-100 VIOLIN','Maple back & sides\r\nSpruce top\r\nSolid maple neck and finish\r\nOne-piece back pc\r\nDyed hardwood/standard chinrest\r\nDyed hardwood fingerboard\r\nDyed hardwood nut & saddle\r\nDyed hardwood/standard pegs\r\nAged maple bridge\r\nComposite / Four Built-in Finetuners tailpiece\r\nPainted purfling\r\nTraditional Red finish',4700,38);

/*Table structure for table `productsintransactions` */

DROP TABLE IF EXISTS `productsintransactions`;

CREATE TABLE `productsintransactions` (
  `productintransactionid` int(6) NOT NULL AUTO_INCREMENT,
  `transactionid` int(6) DEFAULT NULL,
  `productid` int(6) DEFAULT NULL,
  `soldprice` float DEFAULT NULL,
  `quantity` int(6) DEFAULT NULL,
  `amount` float DEFAULT NULL,
  PRIMARY KEY (`productintransactionid`),
  KEY `FK_productsintransactions` (`productid`),
  KEY `FK_productsintransactions1` (`transactionid`),
  CONSTRAINT `FK_productsintransactions` FOREIGN KEY (`productid`) REFERENCES `products` (`productid`),
  CONSTRAINT `FK_productsintransactions1` FOREIGN KEY (`transactionid`) REFERENCES `transactions` (`transactionid`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

/*Data for the table `productsintransactions` */

insert  into `productsintransactions`(`productintransactionid`,`transactionid`,`productid`,`soldprice`,`quantity`,`amount`) values (15,13,3,23300,2,46600),(16,14,4,22450,1,22450),(17,15,5,2340,1,2340),(18,16,3,23300,5,116500),(19,17,7,158000,1,158000),(20,17,8,13350,1,13350),(21,17,9,16875,1,16875),(22,17,10,15575,1,15575),(23,17,11,21750,1,21750),(24,17,12,115650,1,115650),(25,17,13,4700,1,4700),(26,17,2,13600,1,13600),(27,17,3,23300,1,23300),(28,17,4,22450,1,22450),(29,17,5,2340,1,2340),(30,17,6,15525,1,15525);

/*Table structure for table `transactions` */

DROP TABLE IF EXISTS `transactions`;

CREATE TABLE `transactions` (
  `transactionid` int(6) NOT NULL AUTO_INCREMENT,
  `customerid` int(6) DEFAULT NULL,
  `transactiondatetime` datetime DEFAULT NULL,
  `totalamount` float DEFAULT NULL,
  `amounttendered` float DEFAULT NULL,
  `changeamount` float DEFAULT NULL,
  `isvoid` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`transactionid`),
  KEY `FK_transactions` (`customerid`),
  CONSTRAINT `FK_transactions` FOREIGN KEY (`customerid`) REFERENCES `customers` (`customerid`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `transactions` */

insert  into `transactions`(`transactionid`,`customerid`,`transactiondatetime`,`totalamount`,`amounttendered`,`changeamount`,`isvoid`) values (13,2,'2019-12-16 13:59:15',46600,46600,0,0),(14,6,'2019-12-16 13:59:15',22450,22450,0,0),(15,2,'2019-12-16 13:58:37',2340,2340,0,0),(16,2,'2019-12-17 13:59:15',116500,116500,0,0),(17,4,'2019-12-16 14:04:37',423115,423115,0,0);

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
 `PRODUCT NAME` varchar(250) ,
 `DESCRIPTION` text ,
 `PRICE` float ,
 `STOCKS` int(11) ,
 `CATEGORY` varchar(60) ,
 `C` mediumtext 
)*/;

/*Table structure for table `productsintransactions_view` */

DROP TABLE IF EXISTS `productsintransactions_view`;

/*!50001 DROP VIEW IF EXISTS `productsintransactions_view` */;
/*!50001 DROP TABLE IF EXISTS `productsintransactions_view` */;

/*!50001 CREATE TABLE  `productsintransactions_view`(
 `PRODUCTS IN TRANSACTION ID` int(6) ,
 `TRANSACTION ID` int(6) ,
 `PRODUCT ID` int(6) ,
 `SOLD PRICE` float ,
 `QUANTITY` int(6) ,
 `AMOUNT` float ,
 `CUSTOMER ID` int(6) ,
 `TRANSACTION DATE AND TIME` datetime ,
 `TOTAL AMOUNT` float ,
 `AMOUNT TENDERED` float ,
 `CHANGE AMOUNT` float ,
 `IS VOID` tinyint(1) ,
 `FULL NAME` varchar(60) ,
 `CONTACT NUMBER` varchar(60) ,
 `CATEGORY ID` int(6) ,
 `PRODUCT NAME` varchar(250) ,
 `DESCRIPTION` text ,
 `PRICE` float ,
 `STOCKS` int(11) ,
 `CATEGORY` varchar(60) 
)*/;

/*Table structure for table `transactions_view` */

DROP TABLE IF EXISTS `transactions_view`;

/*!50001 DROP VIEW IF EXISTS `transactions_view` */;
/*!50001 DROP TABLE IF EXISTS `transactions_view` */;

/*!50001 CREATE TABLE  `transactions_view`(
 `TRANSACTION ID` int(6) ,
 `CUSTOMER ID` int(6) ,
 `TRANSACTION DATE AND TIME` datetime ,
 `TOTAL AMOUNT` float ,
 `AMOUNT TENDERED` float ,
 `CHANGE AMOUNT` float ,
 `IS VOID` tinyint(1) ,
 `FULL NAME` varchar(60) ,
 `CONTACT NUMBER` varchar(60) ,
 `C` varchar(126) 
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

/*View structure for view productsintransactions_view */

/*!50001 DROP TABLE IF EXISTS `productsintransactions_view` */;
/*!50001 DROP VIEW IF EXISTS `productsintransactions_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `productsintransactions_view` AS select `productsintransactions`.`productintransactionid` AS `PRODUCTS IN TRANSACTION ID`,`productsintransactions`.`transactionid` AS `TRANSACTION ID`,`productsintransactions`.`productid` AS `PRODUCT ID`,`productsintransactions`.`soldprice` AS `SOLD PRICE`,`productsintransactions`.`quantity` AS `QUANTITY`,`productsintransactions`.`amount` AS `AMOUNT`,`transactions`.`customerid` AS `CUSTOMER ID`,`transactions`.`transactiondatetime` AS `TRANSACTION DATE AND TIME`,`transactions`.`totalamount` AS `TOTAL AMOUNT`,`transactions`.`amounttendered` AS `AMOUNT TENDERED`,`transactions`.`changeamount` AS `CHANGE AMOUNT`,`transactions`.`isvoid` AS `IS VOID`,`customers`.`fullname` AS `FULL NAME`,`customers`.`contactnumber` AS `CONTACT NUMBER`,`products`.`categoryid` AS `CATEGORY ID`,`products`.`productname` AS `PRODUCT NAME`,`products`.`description` AS `DESCRIPTION`,`products`.`price` AS `PRICE`,`products`.`stocks` AS `STOCKS`,`categories`.`category` AS `CATEGORY` from ((((`productsintransactions` join `transactions` on((`productsintransactions`.`transactionid` = `transactions`.`transactionid`))) join `products` on((`productsintransactions`.`productid` = `products`.`productid`))) join `customers` on((`transactions`.`customerid` = `customers`.`customerid`))) join `categories` on((`products`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view transactions_view */

/*!50001 DROP TABLE IF EXISTS `transactions_view` */;
/*!50001 DROP VIEW IF EXISTS `transactions_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `transactions_view` AS select `transactions`.`transactionid` AS `TRANSACTION ID`,`transactions`.`customerid` AS `CUSTOMER ID`,`transactions`.`transactiondatetime` AS `TRANSACTION DATE AND TIME`,`transactions`.`totalamount` AS `TOTAL AMOUNT`,`transactions`.`amounttendered` AS `AMOUNT TENDERED`,`transactions`.`changeamount` AS `CHANGE AMOUNT`,`transactions`.`isvoid` AS `IS VOID`,`customers`.`fullname` AS `FULL NAME`,`customers`.`contactnumber` AS `CONTACT NUMBER`,concat(`transactions`.`transactionid`,`transactions`.`transactiondatetime`,`transactions`.`totalamount`,`transactions`.`amounttendered`,`transactions`.`changeamount`,`customers`.`fullname`) AS `C` from (`transactions` join `customers` on((`transactions`.`customerid` = `customers`.`customerid`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
