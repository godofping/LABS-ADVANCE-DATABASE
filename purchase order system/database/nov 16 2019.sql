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

/*Table structure for table `addresses` */

DROP TABLE IF EXISTS `addresses`;

CREATE TABLE `addresses` (
  `addressid` int(6) NOT NULL AUTO_INCREMENT,
  `address` varchar(60) DEFAULT NULL,
  `city` varchar(60) DEFAULT NULL,
  `zipcode` varchar(60) DEFAULT NULL,
  `province` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`addressid`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `addresses` */

insert  into `addresses`(`addressid`,`address`,`city`,`zipcode`,`province`) values (1,'25 Ledesma St. Purok Poblacion','Tacurong City','9800','Sultan Kudarat'),(2,'25 Ledesma St. Purok Poblacion','Tacurong City','9800','Sultan Kudarat'),(3,'Purok Ilang Ilang','Tacurong City','9800','Sultan Kudarat'),(4,'27 Roxas Ave, Poblacion District','Davao City','8000','Davao del Sur'),(5,'742, Door 4, Diajade Building, Near USEP, Corner Iñigo St., ','Davao City','8000','Davao del Sur'),(6,'Padre Gomez St, Poblacion District','Davao City','8000','Davao del Sur'),(7,'Sales Jaltan Building, Calinan District','Davao City','8000','Davao del Sur'),(8,'7 Nicasio Torres St, Agdao','Davao City','8000',' Davao del Sur');

/*Table structure for table `basicinformations` */

DROP TABLE IF EXISTS `basicinformations`;

CREATE TABLE `basicinformations` (
  `basicinformationid` int(6) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(60) DEFAULT NULL,
  `middlename` varchar(60) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `gender` varchar(60) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  PRIMARY KEY (`basicinformationid`),
  KEY `FK_basicinformations` (`gender`),
  KEY `FK_basicinfosrmations` (`birthdate`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `basicinformations` */

insert  into `basicinformations`(`basicinformationid`,`firstname`,`middlename`,`lastname`,`gender`,`birthdate`) values (1,'Rex Louis','Paradero','Roncesvalles','Male','1997-09-23'),(2,'Romano','Liwag','Mercado','Male','1980-11-12');

/*Table structure for table `categories` */

DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
  `categoryid` int(6) NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(60) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `categories` */

insert  into `categories`(`categoryid`,`categoryname`,`isdeleted`) values (1,'Components',0),(3,'Laptops',0),(4,'Peripherals',0),(5,'Phones and Tablets',0),(6,'Software',0);

/*Table structure for table `contactdetails` */

DROP TABLE IF EXISTS `contactdetails`;

CREATE TABLE `contactdetails` (
  `contactdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `addressid` int(6) DEFAULT NULL,
  `contactnumber` varchar(60) DEFAULT NULL,
  `emailaddress` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`contactdetailid`),
  KEY `FK_contactdetails` (`addressid`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `contactdetails` */

insert  into `contactdetails`(`contactdetailid`,`addressid`,`contactnumber`,`emailaddress`) values (1,1,'09754363944','rexmicrosoft@yahoo.com.ph'),(2,2,'09754363944','rexmicrosoft@yahoo.com.ph'),(3,3,'0945213622','romano@gmail.com'),(4,4,'(082) 222 4059','computerworldsuperstore@gmail.com'),(5,5,'(082) 225 3542','davaocomputer@gmail.com'),(6,6,'(082) 222 2245','rasicomputer@gmail.com'),(7,7,'(082) 222 4059','computerworldmarketing@gmail.com'),(8,8,'(082) 321 1882','wei@gmail.com');

/*Table structure for table `customers` */

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `customerid` int(11) NOT NULL AUTO_INCREMENT,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`customerid`),
  KEY `FK_customers1` (`contactdetailid`),
  KEY `FK_customers` (`basicinformationid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `customers` */

insert  into `customers`(`customerid`,`contactdetailid`,`basicinformationid`,`isdeleted`) values (1,3,2,0);

/*Table structure for table `inventories` */

DROP TABLE IF EXISTS `inventories`;

CREATE TABLE `inventories` (
  `inventoryid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `quantityinstocks` int(6) DEFAULT NULL,
  `reorderlevel` int(6) DEFAULT NULL,
  `inventorylastupdated` date DEFAULT NULL,
  PRIMARY KEY (`inventoryid`),
  KEY `FK_inventories` (`productid`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=latin1;

/*Data for the table `inventories` */

insert  into `inventories`(`inventoryid`,`productid`,`quantityinstocks`,`reorderlevel`,`inventorylastupdated`) values (1,1,0,0,'2019-11-15'),(2,31,0,0,'2019-11-15'),(3,32,0,0,'2019-11-15'),(4,33,0,0,'2019-11-15'),(5,34,0,0,'2019-11-15'),(6,39,0,0,'2019-11-15'),(7,40,0,0,'2019-11-15'),(8,41,0,0,'2019-11-15'),(9,42,0,0,'2019-11-15'),(10,20,0,0,'2019-11-15'),(11,21,0,0,'2019-11-15'),(12,22,0,0,'2019-11-15'),(13,23,0,0,'2019-11-15'),(14,24,0,0,'2019-11-15'),(15,25,0,0,'2019-11-15'),(16,26,0,0,'2019-11-15'),(17,27,0,0,'2019-11-15'),(18,28,0,0,'2019-11-15'),(19,29,0,0,'2019-11-15'),(20,30,0,0,'2019-11-15'),(21,35,0,0,'2019-11-15'),(22,36,0,0,'2019-11-15'),(23,4,0,0,'2019-11-15'),(24,5,0,0,'2019-11-15'),(25,6,0,0,'2019-11-15'),(26,7,0,0,'2019-11-15'),(27,8,0,0,'2019-11-15'),(28,9,0,0,'2019-11-15'),(29,10,0,0,'2019-11-15'),(30,11,0,0,'2019-11-15'),(31,12,0,0,'2019-11-15'),(32,13,0,0,'2019-11-15'),(33,14,0,0,'2019-11-15'),(34,15,0,0,'2019-11-15'),(35,16,0,0,'2019-11-15'),(36,17,0,0,'2019-11-15'),(37,18,0,0,'2019-11-15'),(38,19,0,0,'2019-11-15'),(39,37,0,0,'2019-11-15'),(40,38,0,0,'2019-11-15'),(41,107,0,0,'2019-11-15'),(42,108,0,0,'2019-11-15'),(43,109,0,0,'2019-11-15'),(44,52,0,0,'2019-11-15'),(45,53,0,0,'2019-11-15'),(46,54,0,0,'2019-11-15'),(47,46,0,0,'2019-11-15'),(48,47,0,0,'2019-11-15'),(49,48,0,0,'2019-11-15'),(50,110,0,0,'2019-11-15'),(51,111,0,0,'2019-11-15'),(52,43,0,0,'2019-11-15'),(53,44,0,0,'2019-11-15'),(54,45,0,0,'2019-11-15'),(55,55,0,0,'2019-11-15'),(56,56,0,0,'2019-11-15'),(57,49,0,0,'2019-11-15'),(58,50,0,0,'2019-11-15'),(59,51,0,0,'2019-11-15'),(60,57,0,0,'2019-11-15'),(61,58,0,0,'2019-11-15'),(62,59,0,0,'2019-11-15'),(63,60,0,0,'2019-11-15'),(64,61,0,0,'2019-11-15'),(65,62,0,0,'2019-11-15'),(66,63,0,0,'2019-11-15'),(67,64,0,0,'2019-11-15'),(68,65,0,0,'2019-11-15'),(69,66,0,0,'2019-11-15'),(70,67,0,0,'2019-11-15'),(71,68,0,0,'2019-11-15'),(72,69,0,0,'2019-11-15'),(73,70,0,0,'2019-11-15'),(74,71,0,0,'2019-11-15'),(75,72,0,0,'2019-11-15'),(76,73,0,0,'2019-11-15'),(77,74,0,0,'2019-11-15'),(78,75,0,0,'2019-11-15'),(79,76,0,0,'2019-11-15'),(80,77,0,0,'2019-11-15'),(81,78,0,0,'2019-11-15'),(82,79,0,0,'2019-11-15'),(83,80,0,0,'2019-11-15'),(84,81,0,0,'2019-11-15'),(85,82,0,0,'2019-11-15'),(86,83,0,0,'2019-11-15'),(87,84,0,0,'2019-11-15'),(88,85,0,0,'2019-11-15'),(89,86,0,0,'2019-11-15'),(90,87,0,0,'2019-11-15'),(91,88,0,0,'2019-11-15'),(92,89,0,0,'2019-11-15'),(93,90,0,0,'2019-11-15'),(94,91,0,0,'2019-11-15'),(95,92,0,0,'2019-11-15'),(96,93,0,0,'2019-11-15'),(97,94,0,0,'2019-11-15'),(98,95,0,0,'2019-11-15'),(99,96,0,0,'2019-11-15'),(100,97,0,0,'2019-11-15'),(101,98,0,0,'2019-11-15'),(102,99,0,0,'2019-11-15');

/*Table structure for table `orderdetails` */

DROP TABLE IF EXISTS `orderdetails`;

CREATE TABLE `orderdetails` (
  `orderdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `orderid` int(6) DEFAULT NULL,
  `productid` int(6) DEFAULT NULL,
  `orderdetailquantity` int(6) DEFAULT NULL,
  `orderdetailstatus` varchar(60) DEFAULT NULL,
  `orderdetailproductprice` float DEFAULT NULL,
  PRIMARY KEY (`orderdetailid`),
  KEY `FK_orderdetails` (`orderid`),
  KEY `FK_orderdetails1` (`productid`),
  KEY `FK_orderdetailsw` (`orderdetailstatus`),
  KEY `FK_ords89s8erdetails` (`orderdetailquantity`),
  KEY `FK_orderdd56etails` (`orderdetailproductprice`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orderdetails` */

/*Table structure for table `orders` */

DROP TABLE IF EXISTS `orders`;

CREATE TABLE `orders` (
  `orderid` int(6) NOT NULL AUTO_INCREMENT,
  `customerid` int(6) DEFAULT NULL,
  `staffid` int(6) DEFAULT NULL,
  `paymentmethodid` int(6) DEFAULT NULL,
  `shippingmethodid` int(6) DEFAULT NULL,
  `ordertypeid` int(6) DEFAULT NULL,
  `orderstatus` varchar(60) DEFAULT NULL,
  `orderamountpaid` float DEFAULT NULL,
  `ordertotalamount` float DEFAULT NULL,
  `orderdatedelivered` date DEFAULT NULL,
  `orderdaterequested` date DEFAULT NULL,
  `ordercomment` varchar(250) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`orderid`),
  KEY `fkcustomerid` (`customerid`),
  KEY `FK_orders` (`staffid`),
  KEY `FK_orders56s` (`orderstatus`),
  KEY `FK_ordersd89` (`ordertotalamount`),
  KEY `FK_orders8s98` (`orderdaterequested`),
  KEY `FK_o1rders` (`orderamountpaid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `orders` */

/*Table structure for table `ordertypes` */

DROP TABLE IF EXISTS `ordertypes`;

CREATE TABLE `ordertypes` (
  `ordertypeid` int(6) NOT NULL AUTO_INCREMENT,
  `ordertype` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`ordertypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `ordertypes` */

/*Table structure for table `paymentmethods` */

DROP TABLE IF EXISTS `paymentmethods`;

CREATE TABLE `paymentmethods` (
  `paymentmethodid` int(6) NOT NULL AUTO_INCREMENT,
  `paymentmethod` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`paymentmethodid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `paymentmethods` */

insert  into `paymentmethods`(`paymentmethodid`,`paymentmethod`) values (1,'Cash'),(2,'Check'),(3,'Bank Transfer'),(4,'Online Payment'),(5,'Money Orders');

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `productid` int(6) NOT NULL AUTO_INCREMENT,
  `productname` varchar(100) DEFAULT NULL,
  `productdescription` varchar(60) DEFAULT NULL,
  `subcategoryid` int(6) DEFAULT NULL,
  `productsku` varchar(60) DEFAULT NULL,
  `productprice` float DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`productid`),
  KEY `FK_products` (`productprice`),
  KEY `FK_items` (`subcategoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=latin1;

/*Data for the table `products` */

insert  into `products`(`productid`,`productname`,`productdescription`,`subcategoryid`,`productsku`,`productprice`,`isdeleted`) values (1,'SilverStone Tundra SST-TD02-E 2X120mm All-in-One CPU Liquid Cooler','Easy installation with aluminum clips and steel back-plate\r\n',1,'FAN-SILVERSTONE TUNDRA TD02-E',5500.05,0),(4,'The NVIDIA® GeForce® RTX 2080 SUPER™ is powered by the award','The NVIDIA® GeForce® RTX 2080 SUPER™ is powered by the award',9,'VC-INNO3D RTX2080 SUPER OC X3 8GB DDR6 256BIT',46760,0),(5,'INNO3D GeForce RTX 2070 SUPER TWIN X2 OC 8GB GDDR6 256-bit Graphics Card (N207S2-08D6X-11801167)','The NVIDIA® GeForce® RTX 2070 SUPER™ is powered by the award',9,'VC-INNO3D RTX2070 SUPER TWIN X2 8GB GDDR6 256B',32940,0),(6,'INNO3D GeForce RTX 2070 TWIN X2 8GB GDDR6 256-bit Graphics Card (N20702-08D6-1160VA22)','The powerful new GeForce RTX™ 2070 takes advantage of the cu',9,'VC-INNO3D RTX2070 OC8G OC 8GB GDDR6 256BIT',29270,0),(7,'INNO3D GeForce RTX 2060 TWIN X2 6GB GDDR6 192-bit Graphics Card (N20602-06D6-1710VA23)','The GeForce RTX™ 2060 is powered by the NVIDIA Turing™ archi',9,'VC-INNO3D RTX2060 TWIN X2 6GB GDDR6 192BIT',21060,0),(8,'INNO3D GeForce RTX 2060 SUPER TWIN X2 OC 8GB GDDR6 256-bit Graphics Card (N206S2-08D6X-1710VA15L)','The NVIDIA® GeForce® RTX 2060 SUPER™ is powered by the award',9,'VC-INNO3D RTX2060 SUPER 8G TWIN X2 OC DDR6 256B',25540,0),(9,'INNO3D GeForce GTX 1660 Ti TWIN X2 6GB GDDR6 192-bit Graphics Card (N166T2-06D6-1710VA15)','The GeForce® GTX 1660 Ti is built with the breakthrough grap',9,'VC-INNO3D GTX1660TI TWIN X2 6GB DDR6 192BIT',16690,0),(10,'Gigabyte GeForce RTX 2070 SUPER GAMING OC 8G Graphics Card (GV-N207SGAMING-OC-8GC)','Powered by GeForce® RTX 2070 SUPER™\r\nIntegrated with 8GB GDD',9,'VC-GIGABYTE RTX2070 SUPER GAMING OC 8GB GDDR6 256B',31400,0),(11,'Gigabyte GeForce RTX 2060 SUPER WINDFORCE OC 8G Graphics Card (GV-N206SWF2OC-8GD)','Powered by GeForce® RTX 2060 SUPER™\r\nIntegrated with 8GB GDD',9,'VC-GIGABYTE RTX2060 SUPER WINDFORCE OC 8G GDDR6 25',24750,0),(12,'Gigabyte GeForce GTX 1660 Ti WINDFORCE OC 6G Graphics Card (GV-N166TWF2OC-6GD)','The 3D Active Fan provides semi-passive cooling, and the fan',9,'VC-GIGABYTE GTX1660TI WINDFORCE OC 6GB DDR6 192BIT',17600,0),(13,'ASUS Phoenix PH-GTX1660-O6G GeForce GTX 1660 OC edition 6GB GDDR5 Graphics Card','The ASUS Phoenix GeForce® GTX 1660 OC edition 6GB GDDR5 rock',9,'VC-ASUS GTX1660 PHOENIX O6G 6GB DDR5 192BIT',14200,0),(14,'ASUS DUAL-GTX1650-O4G GeForce GTX 1650 OC Edition 4GB GDDR5 Graphics Card','The ASUS Dual GeForce® GTX 1650 is built with the breakthrou',9,'VC-ASUS GTX1650 DUAL O4G 4GB DDR5 128BIT',9900,0),(15,'GALAX GeForce RTX 2070 EX OC 8GB GDDR6 256bit Graphics Card','GALAX GeForce® RTX 2070 EX OC\r\n8GB GDDR6 256-bit DP*3/HDMI',9,'VC-GALAX RTX2070 EXOC 8GB GDDR6 256BIT',23400,0),(16,'GALAX GeForce RTX 2080 OC 8GB GDDR6 256-bit Graphics Card','The “Xrystlic” double-layered surface graphic card is taking',9,'VC-GALAX RTX2080 OC RGB 8GB DDR6 256BIT',36500,0),(17,'MSI GeForce RTX 2070 ARMOR 8G OC 256-bit 8GB GDDR6 Graphics Card','GeForce RTX™ gaming GPUs come loaded with next-generation GD',9,'VC-MSI RTX2070 ARMOR RGB 8GB GDDR6 256BIT',29200,0),(18,'MSI GeForce RTX 2070 GAMING Z 8GB GDDR6 Graphics Card','Core/Memory\r\n\r\nBoost Clock / Memory Speed\r\n1830 MHz / 14Gbps',9,'VC-MSI RTX2070 GAMING Z OC RGB 8GB GDDR6 256BIT',34900,0),(19,'MSI GeForce RTX 2060 VENTUS 6G OC Graphics Card','Boost Clock / Memory Speed\r\n1710 MHz / 14 Gbps\r\n6GB GDDR6\r\nD',9,'VC-MSI RTX2060 VENTUS OC 6GB GDDR6 192BIT',22300,0),(20,'ASROCK H110M-HDV H110 LGA1151 mATX MOTHERBOARD','ASRock Super Alloy\r\nSupports 6th Generation Intel® Core™ Pro',6,'MB-ASROCK H110M-HDV',3050,0),(21,'ASUS TUF X570-PLUS GAMING WI-FI Motherboard','AMD AM4 X570 ATX gaming motherboard with PCIe 4.0, dual M.2,',6,'MB-ASUS TUF X570-PLUS GAMING WI-FI',12200,0),(22,'ASUS STRIX Z370-F GAMING Motherboard','none',6,'MB-ASUS STRIX Z370-F GAMING',11250,0),(23,'ASUS STRIX X570-E GAMING Motherboard','AMD X570 ATX gaming motherboard with PCIe 4.0, 2.5 Gbps and ',6,'MB-ASUS STRIX X570-E GAMING',19300,0),(24,'Kingston ValueRAM 16GB DDR4 2666MHZ SODIMM (KVR26S19D8/16)','Competitively priced ValueRAM memory delivers award-winning ',7,'RAM-KINGSTON 16GB DDR4 PC2666MHZ SODIMM',3600,0),(25,'Kingston ValueRAM 16GB DDR4 2400MHZ SODIMM (KVR24S17D8/16)','Competitively priced ValueRAM memory delivers award-winning ',7,'RAM-KINGSTON 16GB DDR4 PC2400MHZ SODIMM',3600,0),(26,'Kingston ValueRAM 8GB DDR4 2666MHZ SODIMM (KVR26S19S8/8)','Competitively priced ValueRAM memory delivers award-winning ',7,'RAM-KINGSTON 8GB DDR4 PC2666MHZ SODIMM',1800,0),(27,'Crucial 8GB DDR4-2400 Memory Module','Crucial 8GB DDR4-2400 Memory Module',7,'RAM-CRUCIAL 8GB DDR4 PC2400MHZ',1750,0),(28,'Crucial 4GB DDR4-2400 Memory Module','Crucial 4GB DDR4-2400 Memory Module',7,'RAM-CRUCIAL 4GB DDR4 PC2400MHZ',995,0),(29,'G.Skill Ripjaws V 16GB (1X16GB) DDR4-2400MHZ F4-2400C15S-16GVR Memory Module','Series: Ripjaws V\r\nMemory Type: DDR4\r\nCapacity: 16GB (16GBx1',7,'RAM-GSKILLS RIPJAWSV16GB F4-2400C15S-16GVR',3850,0),(30,'G.Skill Trident Z RGB 16GB (8GBx2) 3200MHz DDR4 Dual Channel RGB Memory Kit (F4-3200C16D-16GTZR)','Featuring a completely exposed light bar with vibrant RGB LE',7,'RAM-GSKILLS TRIDENT Z 16GB 2X8G F4-3200C16D-16GTZR',6200,0),(31,'ASUS TUF Gaming GT501 ATX Mid Tower Case','Supports up to EATX with metal front panel, tempered-glass s',1,'CASE-ASUS TUF GAMING GT501 RGB TG',6400,0),(32,'Vikings VKS-30 Shield Tempered Glass Gaming Case with 3 RGB Fans','Vikings VKS-30 Shield Tempered Glass Gaming Case with 3 RGB ',1,'CASE-VIKINGS SHIELD VKS-30 RGB TG',2100,0),(33,'SilverStone Tundra SST-TD02-E 2X120mm All-in-One CPU Liquid Cooler','Easy installation with aluminum clips and steel back-plate\r\n',3,'FAN-SILVERSTONE TUNDRA TD02-E',5500,0),(34,'Cooler Master X Dream i117 CPU Cooler','Low profile aluminum extrusion fin with only 60mm height\r\nUn',3,'FAN-COOLER MASTER X DREAM I117 CPU COOLER',680,0),(35,'INTEL 512GB 660P M.2 PCIE NVME 3.0 X4 (6GBPS) (SSDPEKNW512G8X1) SOLID STATE DRIVE','none',8,'SSD-INTEL 512GB 660P NVME M.2',3800,0),(36,'Seagate 512GB Barracuda 510 PCIE NVME M.2 (ZP512CM30041) Solid State Drive','The BarraCuda SSD is a dependable and cost-effective way to ',8,'SSD-SGTE 512GB BARRACUDA 510 PCIE NVME M.2',5900,0),(37,'Silverstone Strider Essential Series SST-ST50F-ES230 500W 80 PLUS Power Supply','The Strider Essential series is a line of power supplies des',10,'PS-SILVERSTONE SST-ST50F-ES230 500W 80+',2350,0),(38,'Cooler Master MasterWatt Lite 600W 80+ Power Supply','Advanced Circuit Design\r\nEntirely Upgrade Quality\r\nExclusive',10,'PS-COOLER MASTER MASTERWATT LITE 600W 80+',3100,0),(39,'AMD Ryzen 7 3700X','none',5,'CPU-AMD RYZEN 7 3700X (3.6GHZ) UNLOCKED',18700,0),(40,'AMD Ryzen 5 3600X','Serious High-Definition Gaming\r\nEveryone deserves a powerful',5,'CPU-AMD RYZEN 5 3600X (3.8GHZ) UNLOCKED',14200,0),(41,'Intel Celeron G4900 Processor (2M Cache, 3.10 GHz)','Intel Celeron G4900 Processor (2M Cache, 3.10 GHz)',5,'CPU-INTEL CELERON G4900 DUAL CORE(3.10CGHZ)',2300,0),(42,'Intel Core i5-9400 Processor (9M Cache, up to 4.10 GHz)','With the power and responsiveness of Intel® Turbo Boost Tech',5,'CPU-INTEL CORE I5-9400 (2.90GHZ)',10350,0),(43,'HP Pavilion x360 – 14-cd0068tx (4QK23PA) Intel Core i5 14-inch 2-in-1 Convertible Laptop (Gold Metal','Be free to create, connect and share with the new Pavilion x',16,'LT-HP PAVILION 14-CD0068TX X360(4QK23PA) I5 NVIDIA',48990,0),(44,'Dell Inspiron 13 7373 13.3-inch Intel Core i7 2-in-1 Convertible Windows Laptop (Era Gray)','13-inch 2-in-1 with expansive views on a thin-bezel screen. ',16,'LT-DELL INSPIRON 13 7373-I78550U TOUCH 2 IN 1 GREY',68990,0),(45,'Lenovo Yoga Book ZA150149PH Intel Intel Atom x5 10.1? Windows 10 Pro 2-in-1 Tablet (Carbon Black)','Explore Yoga Book with Windows, a groundbreaking 2-in-1 prod',16,'LT-LENOVO YOGA BOOK (ZA150149PH) CARBON BLACK',34999,0),(46,'Acer Aspire E ES1-432-P0KC Intel Quad Core 14-inch Windows 10 Laptop with Office 365 (Midnight Black','Aspire ES series notebooks inject a fresh blast of color1 an',14,'LT-ACER ASPIRE ES1-432-P0KC 365 PQC MIDNIGHT BLACK',20999,0),(47,'Lenovo Ideapad 320-14IAP 80XQ003KPH Intel Pentium Quad Core N4200 14? Windows 10 Laptop (Black)','Everything about the Ideapad 320 is designed to simplify you',14,'LT-LENOVO 320-14IAP (80XQ003KPH) PQC BLACK',19495,0),(48,'Lenovo Ideapad 320-14IAP 80XQ003JPH Intel Pentium Quad Core N4200 14? Windows 10 Laptop (Gray)','Everything about the Ideapad 320 is designed to simplify you',14,'LT-LENOVO 320-14IAP (80XQ003JPH) PQC GREY',19495,0),(49,'ASUS ZENBOOK UX533FD-A9110T Intel Core I5 GeForce GTX 1050 15.6-inch Windows 10 Laptop (ROYAL BLUE)','Creativity. Style. Innovation. These are the qualities that ',18,'LT-ASUS ZENBOOK UX533FD-A9110T I5 BLUE',74995,0),(50,'ASUS ROG ZEPHYRUS S GX531GX-ES005T Intel Core I7 GeForce RTX 2080 15.6-inch Windows 10 Laptop (BLACK','After redefining ultra-slim gaming laptops with the original',18,'LT-ASUS ROG ZEPHYRUS S GX531GX-ES005T BLACK',189995,0),(51,'ASUS ROG ZEPHYRUS GM501GS-EI002T Intel Core I7 GTX 1070 15.6-inch Windows 10 Laptop (BLACK METAL)','ROG Zephyrus M picks up where its predecessor, ROG Zephyrus,',18,'LT-ASUS ROG ZEPHYRUS GM501GS-EI002T BLACK METAL',139995,0),(52,'HP ENVY 13-AD038TX (2GD27PA) 13-Inch Intel Core I5 GeForce MX150 Windows 10 Laptop (SILVER)','This is an all-aluminium laptop aside from the glass coverin',13,'LT-HP ENVY 13-AD038TX (2GD27PA) SILVER',51390,0),(53,'HP ENVY 13-AD037TX (2GD26PA) 13-inch Intel Core I5 GeForce MX150 Windows 10 Laptop (GOLD)','Elegance and durability are crafted in a thin and light, all',13,'LT-HP ENVY 13-AD037TX (2GD26PA) GOLD',51390,0),(54,'Lenovo IdeaPad 330-15ICH 81DC00D2PH Intel Core I3-7130U 4GB DDR4 Intel HD Graphics 620 Windows 10 La','Lenovo IdeaPad 330-15ICH 81DC00D2PH Intel Core I3-7130U 4GB ',13,'LT-LENOVO 330-15IKB (81DC00D2PH) I3 GREY',27995,0),(55,'HP ENVY 13 AD111TX-2LS51PA Intel Core I5 GeForce MX 150 Intel HD Graphics 13-inch Windows 10 Laptop ','HP ENVY 13 AD111TX-2LS51PA Intel Core I5 GeForce MX 150 Inte',17,'LT-HP ENVY 13-AD111TX (2LS51PA) SILVER',58990,0),(56,'MSI PS42 MODERN 8RA-204PH Intel Core I7 GeForce MX 250 Windows 10 Laptop (SILVER)','Crafted in ultra-light chassis with hair-brushed aluminum, c',17,'LT-MSI PS42 MODERN 8RA-204PH I7 512GB SSD SILVER',74995,0),(57,'SECURE 3000VA UPS (BLACK)','Input Voltage: 220VAC\r\nFrequency: 50hz – 60hz\r\nOutput Voltag',19,'UPS-SECURE 3000VA BLK',5200,0),(58,'SECURE 2000VA UPS (BLACK)','Input Voltage: 220VAC\r\nFrequency: 50hz – 60hz\r\nOutput Voltag',19,'UPS-SECURE 2000VA BLK',4050,0),(59,'A4TECH PK-635G ANTI-GLARE 16MP W/MIC USB WEBCAM','• CMOS 640×480 350K Pixels, Auto White Balance, Focus Range ',20,'CAM-A4TECH PK-635G 16MP W/MIC USB',600,0),(60,'TRANSCEND DRIVEPRO 50 CAR CAMCORDER','Introducing Transcend’s most compact dash camera yet–the Dri',20,'DIGICAM-TRANSCEND DRIVEPRO 50 CAR CAMCORDER',4699,0),(61,'DIGICAM-TRANSCEND DRIVEPRO 50 CAR CAMCORDER','4.5mm diameter OFC wire core\r\n2.4A fast charging and data tr',21,'CI-ACC-RECCI VELOCITY RCT-N120 TYPE-C CAB',395,0),(62,'RECCI Velocity RCM-N120 Micro USB Data Cable','4.5mm diameter OFC wire core\r\n2.4A fast charging and data tr',21,'CI-ACC-RECCI VELOCITY RCM-N120 MICRO USB CAB',395,0),(63,'WACOM INTUOS PHOTO CTH-490/K2 GRAPHIC TABLET','Create memorable images and beautiful photo books with the e',22,'PENTABLET-INTUOS PHOTO CTH-490/K2 SMALL BLACK',5750,0),(64,'WACOM INTUOS MEDIUM CTH-690K0 GRAPHIC TABLET','Tablet Size: 275 x 222 x 10 mm (10.8 x 8.7 x 0.4 in)\r\nErgono',22,'PENTABLET-INTUOS ART MEDIUM CTH-690K0 BLK',10600,0),(65,'SteelSeries Arctis Pro with GameDAC Hi-Res Gaming Audio System','Each component of the Arctis Pro + GameDAC Hi-Res gaming aud',23,'HS-STEELSERIES ARCTIS PRO WITH GAMDAC',12100,0),(66,'SteelSeries ARCTIS PRO Wireless Gaming Headset (Black)','Dual Wireless: 2.4G lossless + Bluetooth\r\nIndustry-leading h',23,'HS-STEELSERIES ARCTIS PRO WIRELESS BLK',17150,0),(67,'SteelSeries Apex M750 Gaming Mechanical Keyboard','The Apex M750 combines showstopping lighting effects and cru',24,'KB-STEELSERIES APEX M750 PRISM RGB MECH',7100,0),(68,'HyperX Alloy Core RGB Membrane Gaming Keyboard','HyperX’s signature radiant light bar and smooth, dynamic RGB',24,'KB-KINGSTON HYPERX ALLOY CORE RGB',3100,0),(69,'Viewsonic VX2458-mhd 24-inch Full HD Monitor with FreeSync','The ViewSonic® VX2458-mhd is a 24” (23.6” Viewable) Full HD ',25,'MN-VSONIC 23.6\" VX2458-MHD FREESYNC LED BLK',9995,0),(70,'Philips 31.5-inch Full HD Curved VA LCD monitor with FreeSync (328E9QJAB/71)','Experience real immersion with Philips 31.5-inch Full HD Cur',25,'MN-PHILIPS 31.5 328E9QJAB BLK',14900,0),(71,'SteelSeries RIVAL 710 RGB Gaming Mouse with OLED screen','(Prices are subject to change without any prior notice and a',26,'MOUSE-STEELSERIES RIVAL 710 RGB BLK',4150,0),(72,'SteelSeries RIVAL 310 PUBG Edition Gaming Mouse','The Limited-Edition Rival 310 PUBG Edition featuring the ico',26,'MOUSE-STEELSERIES RIVAL 310 PUBG ED.',2900,0),(73,'SteelSeries QcK Prism Dota 2 Edition RGB Gaming Mousepad','Official Dota 2 RGB gaming mousepad\r\n2-zone RGB for in-game ',27,'MOUSE PAD-STEELSERIES QCK PRISM DOTA 2 RGB',2250,0),(74,'D.Va Razer Goliathus Gaming Mouse Pad','Soft gaming mouse mat designed for hardcore gamers featuring',27,'MOUSE PAD-RAZER GOLIATHUS M D.VA EDITION',1100,0),(75,'Ubiquiti Unifi 802.11ac PRO Access Point (UAP-AC-PRO)','The UniFi AC Pro AP features the latest Wi-Fi 802.11ac, 3×3 ',28,'NET-UBIQUITI UNIFI ACCESS POINT AC (UAP-AC-PRO)',9000,0),(76,'D-Link COVR-C1203 Dual Band Whole Home Mesh Wi-Fi System','Introducing Covr, the seamless Wi-Fi solution that’s the per',28,'NET-DLINK COVR-C1203',10995,0),(77,'ASUS ZENPOWER PINK 10050MAH POWERBANK W/ BUMPER CASE','Battery Type : Lithium-ion rechargeable cell\r\nInput Power : ',29,'ACC-TABLET-ASUS ZENPOWER PINK W/ BUMPER CASE',950,0),(78,'ASUS ZENPOWER BLUE 10050mAh POWERBANK W/ BUMPER CASE','Battery Type : Lithium-ion rechargeable cell\r\nInput Power : ',29,'ACC-TABLET-ASUS ZENPOWER BLUE W/ BUMPER CASE',950,0),(79,'HP OJ 7110 WIDE FORMAT Printer','Widen your printing possibilities with an affordable, reliab',30,'PRNTR-HP OJ 7110 WIDE FORMAT',9000,0),(80,'HP LJ PRO M130A Printer','Print professional documents from a range of mobile devices,',30,'PRNTR-HP LJ PRO M130A',7670,0),(81,'InFocus IN114v XGA DLP Projector','Confidently beam your content with the big power and unbeata',31,'PRJCTR-INFOCUS IN114V XGA HDMI',23850,0),(82,'InFocus IN112xv DLP Projector','none',31,'RJCTR-INFOCUS IN112XV 3800 ANSI LUMENS W/ BAG',16950,0),(83,'LEAD 3D 5.1 USB Sound Card Green','Optimizes the sound according to the style of music (such as',32,'SC-LEAD 3D 5.1 USB GREEN',195,0),(84,'LEAD 3D 5.1 USB Sound Card Blue','Optimizes the sound according to the style of music (such as',32,'SC-LEAD 3D 5.1 USB BLUE',195,0),(85,'SC-LEAD 3D 5.1 USB BLUE','Logitech G560 LIGHTSYNC gaming speakers immerse you in the a',33,'SP-LOGITECH G560 LIGHTSYNC GAMING 2.1 BLK',10100,0),(86,'Edifier MP100 Mini Bluetooth Speaker (Yellow)','Bluetooth 4.0 and microSD functionality\r\n20 hour battery lif',33,'SP-EDIFIER MP100 PORTABLE YLW BLUETOOTH',2080,0),(87,'SP-EDIFIER MP100 PORTABLE YLW BLUETOOTH','The simple way to add extra, high-speed storage to your devi',34,'UD-SANDISK 64GB ULTRA FIT USB3.0/3.1',600,0),(88,'SANDISK 64GB ULTRA DUAL DRIVE M3.0/OTG (SDDD3-064G-G46) TRANSPARENT FLASH DRIVE','The SanDisk Ultra® Dual Drive m3.0 makes it easy to transfer',34,'UD-SANDISK 64GB ULTRA DUAL USB DRIVE M3.0/OTG',600,0),(89,'RECCI Caesar RC-K01 iPhone X Case','Premium PC material, solid and durable\r\nLeather-like texture',35,'CI-ACC-RECCI CAESAR RC-K01 IPHONE X CASE',1195,0),(90,'RECCI Duke RC-L01 iPhone X Phone Case','Fashion & practical mobile stander\r\nTPU material with comfor',35,'CI-ACC-RECCI DUKE RC-L01 IPHONE X CASE',1195,0),(91,'APPLE IPHONE XS MAX SPACE GREY 256GB','none',36,'CEL-APPLE IPHONE XS MAX S.GRAY 256GB',84990,0),(92,'APPLE IPHONE XS Gold 256GB','none',36,'CEL-APPLE IPHONE XS GOLD 256GB',77490,0),(93,'Huawei MediaPad T2 7.0 Tablet','The MediaPad T2 7.0’s powerful quad-core 1.5 GHz A7 processo',37,'TABLET-HUAWEI MEDIAPAD T2 7.0',7490,0),(94,'Kaspersky Internet Security 2019 3 Devices 2 Years Protection','Whatever you do online – on your PC, Mac & Android devices –',38,'SOFT-KASPERSKY INTERNET SECURITY 2019',1600,0),(95,'Office Home & Business 2019 for PC or Mac','For families and small businesses who want classic Office ap',38,'OS-MS OFFICE HOME AND BUSINESS 2019 PC/MAC',14500,0),(96,'WINDOWS 10 PROFESSIONAL 64-BIT','With Windows 10 Pro, you’ve got a great business partner. It',39,'OS-WINDOWS 10 PRO 64BIT FPP',12400,0),(97,'WINDOWS 10 PROFESSIONAL 64-BIT ENG INTERNATIONAL 1PK DVD (FQC-08929)','With Windows 10 Pro, you’ve got a great business partner. It',39,'OS-WINDOWS 10 PRO 64BIT OEM',8300,0),(98,'Kaspersky Internet Security 2019 3 Devices 2 Years Protection','Whatever you do online – on your PC, Mac & Android devices –',40,'SOFT-KASPERSKY INTERNET SECURITY 2019',1600,0),(99,'Kaspersky Antivirus 2019 3 Devices 2 Years Protection','Blocks the latest viruses, ransomware, spyware, cryptolocker',40,'SOFT-KASPERSKY ANTIVIRUS 2019',1200,0),(107,'TP-LINK TL-WN881ND 300MBPS WIRELESS N PCI EXPRESS ADAPTER','Wireless N speed up to 300Mbps makes it ideal for video stre',11,'NET-TP-LINK TL-WN881ND',700,0),(108,'TP-LINK TG-3468 LAN CARD','10/100/1000Mbps PCIe Adapter\r\n32-bit PCIe interface, saving ',11,'NET-TP-LINK TG-3468',570,0),(109,'LITE-ON IHAS-124 24X SATA BLK W/ BOX','24X DVD+R 8X DVD+RW 12X DVD+R DL 24X DVD-R 6X DVD-RW 48X CD-',12,'DVDRW-LITEON IHAS-124 24X SATA BLK W/ BOX',800,0),(110,'Acer Aspire Spin 7 SP714-51-M4E5 Intel Core i7 14? Convertible 2-in-1 Windows 10 Laptop (Black)','Processor: Intel® Core™ I7-7Y75\r\nOperating System: Windows 1',15,'LT-ACER ASPIRE SPIN 7 SP714-51-M4E5',61999,0),(111,'Acer Aspire Swift 5 SF514-51-50SQ Intel Core i5 14? Windows 10 Laptop (Black)','Processor: Intel® Core™ I5-7200U\r\nOperating System: Windows ',15,'LT-ACER ASPIRE SWIFT 5 SF514-51-50SQ BLACK',45900,0);

/*Table structure for table `purchaseorderdetails` */

DROP TABLE IF EXISTS `purchaseorderdetails`;

CREATE TABLE `purchaseorderdetails` (
  `purchaseorderdetailid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `purchaseorderdetailquantity` int(6) DEFAULT NULL,
  `purchaseorderid` int(6) DEFAULT NULL,
  `purchaseorderdetailprice` float DEFAULT NULL,
  PRIMARY KEY (`purchaseorderdetailid`),
  KEY `FK_purchaseorderdetails` (`purchaseorderid`),
  KEY `FK_purchaseorderdetails1` (`productid`),
  KEY `FK_purchaseordderdetails` (`purchaseorderdetailquantity`),
  KEY `FK_purchaseord2erdetails` (`purchaseorderdetailprice`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorderdetails` */

/*Table structure for table `purchaseorders` */

DROP TABLE IF EXISTS `purchaseorders`;

CREATE TABLE `purchaseorders` (
  `purchaseorderid` int(6) NOT NULL AUTO_INCREMENT,
  `staffid` int(6) DEFAULT NULL,
  `purchaseordername` varchar(60) DEFAULT NULL,
  `supplierid` int(6) DEFAULT NULL,
  `paymentmethodid` int(6) DEFAULT NULL,
  `shippingmethodid` int(6) DEFAULT NULL,
  `purchaseorderstatus` varchar(60) DEFAULT NULL,
  `purchaseorderamountpaid` float DEFAULT NULL,
  `purchasetotalorderamount` float DEFAULT NULL,
  `purchaseorderdatereceived` date DEFAULT NULL,
  `purchaseorderdaterequested` date DEFAULT NULL,
  `purchaseordercomment` varchar(250) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`purchaseorderid`),
  KEY `FK_purchaseorders1` (`staffid`),
  KEY `FK_purchaseordersw` (`purchaseorderstatus`),
  KEY `FK_purc6565haseorders` (`purchasetotalorderamount`),
  KEY `FK_pus43rchaseorders` (`purchaseorderdatereceived`),
  KEY `FK_purs4545chaseorders` (`purchaseorderdaterequested`),
  KEY `FK_purcha23seorders` (`purchaseorderamountpaid`),
  KEY `FK_p1urchaseorders` (`supplierid`),
  KEY `FK_pu3rchaseorders` (`shippingmethodid`),
  KEY `FK_purch1aseorders` (`paymentmethodid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purchaseorders` */

/*Table structure for table `shippingmethods` */

DROP TABLE IF EXISTS `shippingmethods`;

CREATE TABLE `shippingmethods` (
  `shippingmethodid` int(6) NOT NULL AUTO_INCREMENT,
  `shippingmethod` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`shippingmethodid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `shippingmethods` */

insert  into `shippingmethods`(`shippingmethodid`,`shippingmethod`) values (1,'Method 1'),(2,'Method 2'),(3,'Method 3');

/*Table structure for table `staffpositions` */

DROP TABLE IF EXISTS `staffpositions`;

CREATE TABLE `staffpositions` (
  `staffpositionid` int(6) NOT NULL AUTO_INCREMENT,
  `staffposition` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`staffpositionid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `staffpositions` */

insert  into `staffpositions`(`staffpositionid`,`staffposition`) values (1,'Manager'),(2,'Staff');

/*Table structure for table `staffs` */

DROP TABLE IF EXISTS `staffs`;

CREATE TABLE `staffs` (
  `staffid` int(6) NOT NULL AUTO_INCREMENT,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `basicinformationid` int(6) DEFAULT NULL,
  `staffpositionid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`staffid`),
  KEY `FK_staffs` (`contactdetailid`),
  KEY `FK_staffsdff` (`basicinformationid`),
  KEY `FK_staf2fs` (`staffpositionid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `staffs` */

insert  into `staffs`(`staffid`,`username`,`password`,`contactdetailid`,`basicinformationid`,`staffpositionid`,`isdeleted`) values (1,'admin','admin',2,1,1,0);

/*Table structure for table `storeinformation` */

DROP TABLE IF EXISTS `storeinformation`;

CREATE TABLE `storeinformation` (
  `storename` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  KEY `FK_storeinformation` (`contactdetailid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `storeinformation` */

insert  into `storeinformation`(`storename`,`contactdetailid`) values ('Rex Computer Store',1);

/*Table structure for table `subcategories` */

DROP TABLE IF EXISTS `subcategories`;

CREATE TABLE `subcategories` (
  `subcategoryid` int(6) NOT NULL AUTO_INCREMENT,
  `subcategoryname` varchar(60) DEFAULT NULL,
  `categoryid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`subcategoryid`),
  KEY `FK_subcategories` (`categoryid`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;

/*Data for the table `subcategories` */

insert  into `subcategories`(`subcategoryid`,`subcategoryname`,`categoryid`,`isdeleted`) values (1,'Casing',1,0),(2,'tae1',1,1),(3,'CPU Fan',1,0),(4,'Mouse',4,1),(5,'Processor',1,0),(6,'Motherboard',1,0),(7,'Memory Modules',1,0),(8,'Internal Storage',1,0),(9,'Graphic Card',1,0),(10,'Power Supply',1,0),(11,'NIC Cards',1,0),(12,'Optical Drive',1,0),(13,'Mainstream',3,0),(14,'Entry',3,0),(15,'Modern PC',3,0),(16,'2 - in 1 Laptops',3,0),(17,'Premium',3,0),(18,'Gaming Laptop',3,0),(19,'AVR and UPS',4,0),(20,'Camera',4,0),(21,'Data Cable',4,0),(22,'Graphic Tablet',4,0),(23,'Head set',4,0),(24,'Keyboard',4,0),(25,'Monitor',4,0),(26,'Mouse',4,0),(27,'Mouse pad',4,0),(28,'Networking Peripherals',4,0),(29,'Powerbank',4,0),(30,'Printers and Scanners',4,0),(31,'Projector',4,0),(32,'Sound Card',4,0),(33,'Speaker',4,0),(34,'Storage Devices',4,0),(35,'Phone Cases',5,0),(36,'Smartphone',5,0),(37,'Tablet',5,0),(38,'Office Applications',6,0),(39,'Operating Systems',6,0),(40,'Security Applications',6,0),(41,'1',3,1);

/*Table structure for table `supplierproducts` */

DROP TABLE IF EXISTS `supplierproducts`;

CREATE TABLE `supplierproducts` (
  `supplierproductid` int(6) NOT NULL AUTO_INCREMENT,
  `productid` int(6) DEFAULT NULL,
  `supplierid` int(6) DEFAULT NULL,
  PRIMARY KEY (`supplierproductid`),
  KEY `FK_vendorproducts` (`productid`),
  KEY `FK_ve1ndorproducts` (`supplierid`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=latin1;

/*Data for the table `supplierproducts` */

insert  into `supplierproducts`(`supplierproductid`,`productid`,`supplierid`) values (1,1,1),(2,31,1),(3,32,1),(4,33,1),(5,34,1),(6,39,1),(7,40,1),(8,41,1),(9,42,1),(10,20,1),(11,21,1),(12,22,1),(13,23,1),(14,24,1),(15,25,1),(16,26,1),(17,27,1),(18,28,1),(19,29,1),(20,30,1),(21,35,1),(22,36,1),(23,4,1),(24,5,1),(25,6,1),(26,7,1),(27,8,1),(28,9,1),(29,10,1),(30,11,1),(31,12,1),(32,13,1),(33,14,1),(34,15,1),(35,16,1),(36,17,1),(37,18,1),(38,19,1),(39,37,1),(40,38,1),(41,107,1),(42,108,1),(43,109,1),(44,52,2),(45,53,2),(46,54,2),(47,46,2),(48,47,2),(49,48,2),(50,110,2),(51,111,2),(52,43,2),(53,44,2),(54,45,2),(55,55,2),(56,56,2),(57,49,2),(58,50,2),(59,51,2),(60,57,3),(61,58,3),(62,59,3),(63,60,3),(64,61,3),(65,62,3),(66,63,3),(67,64,3),(68,65,3),(69,66,3),(70,67,3),(71,68,3),(72,69,3),(73,70,3),(74,71,3),(75,72,3),(76,73,3),(77,74,3),(78,75,3),(79,76,3),(80,77,3),(81,78,3),(82,79,3),(83,80,3),(84,81,3),(85,82,3),(86,83,3),(87,84,3),(88,85,3),(89,86,3),(90,87,3),(91,88,3),(92,89,4),(93,90,4),(94,91,4),(95,92,4),(96,93,4),(97,94,5),(98,95,5),(99,96,5),(100,97,5),(101,98,5),(102,99,5);

/*Table structure for table `suppliers` */

DROP TABLE IF EXISTS `suppliers`;

CREATE TABLE `suppliers` (
  `supplierid` int(6) NOT NULL AUTO_INCREMENT,
  `supplier` varchar(60) DEFAULT NULL,
  `contactdetailid` int(6) DEFAULT NULL,
  `isdeleted` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`supplierid`),
  KEY `FK_vendors` (`contactdetailid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `suppliers` */

insert  into `suppliers`(`supplierid`,`supplier`,`contactdetailid`,`isdeleted`) values (1,'Computer World Superstore',4,0),(2,'Davao Computer',5,0),(3,'RASI Computer, Inc.',6,0),(4,'Computer World Marketing',7,0),(5,'Wei Dynamic Technology Trading',8,0);

/*Table structure for table `addresses_view` */

DROP TABLE IF EXISTS `addresses_view`;

/*!50001 DROP VIEW IF EXISTS `addresses_view` */;
/*!50001 DROP TABLE IF EXISTS `addresses_view` */;

/*!50001 CREATE TABLE  `addresses_view`(
 `addressid` int(6) ,
 `address` varchar(60) ,
 `city` varchar(60) ,
 `zipcode` varchar(60) ,
 `province` varchar(60) 
)*/;

/*Table structure for table `basicinformations_view` */

DROP TABLE IF EXISTS `basicinformations_view`;

/*!50001 DROP VIEW IF EXISTS `basicinformations_view` */;
/*!50001 DROP TABLE IF EXISTS `basicinformations_view` */;

/*!50001 CREATE TABLE  `basicinformations_view`(
 `basicinformationid` int(6) ,
 `firstname` varchar(60) ,
 `middlename` varchar(60) ,
 `lastname` varchar(60) ,
 `gender` varchar(60) ,
 `birthdate` date 
)*/;

/*Table structure for table `categories_view` */

DROP TABLE IF EXISTS `categories_view`;

/*!50001 DROP VIEW IF EXISTS `categories_view` */;
/*!50001 DROP TABLE IF EXISTS `categories_view` */;

/*!50001 CREATE TABLE  `categories_view`(
 `Category ID` int(6) ,
 `Category Name` varchar(60) ,
 `isdeleted` tinyint(1) 
)*/;

/*Table structure for table `contactdetails_view` */

DROP TABLE IF EXISTS `contactdetails_view`;

/*!50001 DROP VIEW IF EXISTS `contactdetails_view` */;
/*!50001 DROP TABLE IF EXISTS `contactdetails_view` */;

/*!50001 CREATE TABLE  `contactdetails_view`(
 `contactdetailid` int(6) ,
 `addressid` int(6) ,
 `contactnumber` varchar(60) ,
 `emailaddress` varchar(60) ,
 `address` varchar(60) ,
 `city` varchar(60) ,
 `zipcode` varchar(60) ,
 `province` varchar(60) 
)*/;

/*Table structure for table `customers_view` */

DROP TABLE IF EXISTS `customers_view`;

/*!50001 DROP VIEW IF EXISTS `customers_view` */;
/*!50001 DROP TABLE IF EXISTS `customers_view` */;

/*!50001 CREATE TABLE  `customers_view`(
 `Customer ID` int(11) ,
 `First Name` varchar(60) ,
 `Middle Name` varchar(60) ,
 `Last Name` varchar(60) ,
 `Gender` varchar(60) ,
 `Birth Date` date ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Province` varchar(60) ,
 `Zip Code` varchar(60) ,
 `contactdetailid` int(6) ,
 `basicinformationid` int(6) ,
 `addressid` int(6) ,
 `isdeleted` tinyint(1) 
)*/;

/*Table structure for table `inventories_view` */

DROP TABLE IF EXISTS `inventories_view`;

/*!50001 DROP VIEW IF EXISTS `inventories_view` */;
/*!50001 DROP TABLE IF EXISTS `inventories_view` */;

/*!50001 CREATE TABLE  `inventories_view`(
 `Inventory ID` int(6) ,
 `Product SKU` varchar(60) ,
 `Product Name` varchar(100) ,
 `Product Description` varchar(60) ,
 `Product Price` float ,
 `Category Name` varchar(60) ,
 `Sub Category Name` varchar(60) ,
 `Quantity In Stocks` int(6) ,
 `Reorder Level` int(6) ,
 `Inventory Last Updated` date ,
 `subcategoryid` int(6) ,
 `Product Id` int(6) ,
 `isdeleted` tinyint(1) ,
 `categoryid` int(6) ,
 `subcategoriesisdeleted` tinyint(1) ,
 `categoriesisdeleted` tinyint(1) 
)*/;

/*Table structure for table `ordertypes_view` */

DROP TABLE IF EXISTS `ordertypes_view`;

/*!50001 DROP VIEW IF EXISTS `ordertypes_view` */;
/*!50001 DROP TABLE IF EXISTS `ordertypes_view` */;

/*!50001 CREATE TABLE  `ordertypes_view`(
 `ordertypeid` int(6) ,
 `ordertype` varchar(60) 
)*/;

/*Table structure for table `paymentmethods_view` */

DROP TABLE IF EXISTS `paymentmethods_view`;

/*!50001 DROP VIEW IF EXISTS `paymentmethods_view` */;
/*!50001 DROP TABLE IF EXISTS `paymentmethods_view` */;

/*!50001 CREATE TABLE  `paymentmethods_view`(
 `Payment Method ID` int(6) ,
 `Payment Method` varchar(60) 
)*/;

/*Table structure for table `products_view` */

DROP TABLE IF EXISTS `products_view`;

/*!50001 DROP VIEW IF EXISTS `products_view` */;
/*!50001 DROP TABLE IF EXISTS `products_view` */;

/*!50001 CREATE TABLE  `products_view`(
 `Product ID` int(6) ,
 `Product Name` varchar(100) ,
 `Product Description` varchar(60) ,
 `Product SKU` varchar(60) ,
 `Product Price` float ,
 `Category Name` varchar(60) ,
 `Sub Category Name` varchar(60) ,
 `categoryid` int(6) ,
 `subcategoryid` int(6) ,
 `subcategoriesisdeleted` tinyint(1) ,
 `isdeleted` tinyint(1) ,
 `categoriesisdeleted` tinyint(1) 
)*/;

/*Table structure for table `purchaseorderdetails_view` */

DROP TABLE IF EXISTS `purchaseorderdetails_view`;

/*!50001 DROP VIEW IF EXISTS `purchaseorderdetails_view` */;
/*!50001 DROP TABLE IF EXISTS `purchaseorderdetails_view` */;

/*!50001 CREATE TABLE  `purchaseorderdetails_view`(
 `Product ID` int(6) ,
 `Product Name` varchar(100) ,
 `Price` float ,
 `Quantity` int(6) ,
 `Amount` double ,
 `Purchase Order Detail ID` int(6) ,
 `Purchase Order ID` int(6) ,
 `Product Description` varchar(60) ,
 `Sub Category ID` int(6) ,
 `Produck SKU` varchar(60) ,
 `Product Price` float ,
 `Product Is Deleted` tinyint(1) ,
 `Sub Category Name` varchar(60) ,
 `Category ID` int(6) ,
 `Sub Categories Is Deleted` tinyint(1) ,
 `Category Is Deleted` tinyint(1) ,
 `Staff ID` int(6) ,
 `Purchase Order Name` varchar(60) ,
 `Purchase Order Supplier ID` int(6) ,
 `Payment Method ID` int(6) ,
 `Shipping Method ID` int(6) ,
 `Purchase Order Status` varchar(60) ,
 `Purchase Order Amount Paid` float ,
 `Purchase Total Order Amount` float ,
 `Date Received` date ,
 `Date Requested` date ,
 `Purchase Order Comment` varchar(250) ,
 `Purchase Order Is Deleted` tinyint(1) ,
 `Supplier` varchar(60) ,
 `Supplier Contact Detail ID` int(6) ,
 `Supplier Is Deleted` tinyint(1) ,
 `Staff Username` varchar(60) ,
 `Staff Password` varchar(60) ,
 `Staff Contact Detail ID` int(6) ,
 `Staff Basic Information ID` int(6) ,
 `Staff Position ID` int(6) ,
 `Staff Position` varchar(60) ,
 `First Name` varchar(60) ,
 `Middle Name` varchar(60) ,
 `Last Name` varchar(60) ,
 `Gender` varchar(60) ,
 `Birth Date` date ,
 `Payment Method` varchar(60) ,
 `Shipping Method` varchar(60) 
)*/;

/*Table structure for table `purchaseorders_view` */

DROP TABLE IF EXISTS `purchaseorders_view`;

/*!50001 DROP VIEW IF EXISTS `purchaseorders_view` */;
/*!50001 DROP TABLE IF EXISTS `purchaseorders_view` */;

/*!50001 CREATE TABLE  `purchaseorders_view`(
 `Purchase Order ID` int(6) ,
 `Supplier` varchar(60) ,
 `Purchase Order Name` varchar(60) ,
 `Payment Method` varchar(60) ,
 `Shipping Method` varchar(60) ,
 `Date Requested` date ,
 `Date Received` date ,
 `Comment` varchar(250) ,
 `Total Amount` float ,
 `Amount Paid` float ,
 `Purchase Order Status` varchar(60) ,
 `Purchase Order By` varchar(182) ,
 `Staff First Name` varchar(60) ,
 `Staff Middle Name` varchar(60) ,
 `Staff Last Name` varchar(60) ,
 `Purchase Order Staff ID` int(6) ,
 `Purchase Order Supplier ID` int(6) ,
 `Purchase Order Payment Method ID` int(6) ,
 `Purchase Order Shipping Method ID` int(6) ,
 `Purchase Order Is Deleted` tinyint(1) ,
 `Supplier Contact Detail ID` int(6) ,
 `Supplier Is Deleted` tinyint(1) ,
 `Supplier Address ID` int(6) ,
 `Supplier Contact Number` varchar(60) ,
 `Supplier Email Address` varchar(60) ,
 `Supplier Address` varchar(60) ,
 `Supplier City` varchar(60) ,
 `Supplier Zip Code` varchar(60) ,
 `Supplier Province` varchar(60) ,
 `Staff Username` varchar(60) ,
 `Staff Password` varchar(60) ,
 `Staff Contact Detail ID` int(6) ,
 `Staff Basic Information ID` int(6) ,
 `Staff Position ID` int(6) ,
 `Staff Is Deleted` tinyint(4) ,
 `Staff Position` varchar(60) ,
 `Staff Gender` varchar(60) ,
 `Staff Birth Date` date ,
 `Staff Address ID` int(6) ,
 `Staff Contact Number` varchar(60) ,
 `Staff Email Address` varchar(60) ,
 `Staff Address` varchar(60) ,
 `Staff City` varchar(60) ,
 `Staff Zip Code` varchar(60) ,
 `Staff Province` varchar(60) 
)*/;

/*Table structure for table `shippingmethods_view` */

DROP TABLE IF EXISTS `shippingmethods_view`;

/*!50001 DROP VIEW IF EXISTS `shippingmethods_view` */;
/*!50001 DROP TABLE IF EXISTS `shippingmethods_view` */;

/*!50001 CREATE TABLE  `shippingmethods_view`(
 `Shipping Method ID` int(6) ,
 `Shipping Method` varchar(60) 
)*/;

/*Table structure for table `staffpositions_view` */

DROP TABLE IF EXISTS `staffpositions_view`;

/*!50001 DROP VIEW IF EXISTS `staffpositions_view` */;
/*!50001 DROP TABLE IF EXISTS `staffpositions_view` */;

/*!50001 CREATE TABLE  `staffpositions_view`(
 `staffpositionid` int(6) ,
 `staffposition` varchar(60) 
)*/;

/*Table structure for table `staffs_view` */

DROP TABLE IF EXISTS `staffs_view`;

/*!50001 DROP VIEW IF EXISTS `staffs_view` */;
/*!50001 DROP TABLE IF EXISTS `staffs_view` */;

/*!50001 CREATE TABLE  `staffs_view`(
 `Staff ID` int(6) ,
 `Username` varchar(60) ,
 `First Name` varchar(60) ,
 `Middle Name` varchar(60) ,
 `Last Name` varchar(60) ,
 `Gender` varchar(60) ,
 `Birth Date` date ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Province` varchar(60) ,
 `Zip Code` varchar(60) ,
 `Staff Position` varchar(60) ,
 `password` varchar(60) ,
 `contactdetailid` int(6) ,
 `basicinformationid` int(6) ,
 `staffpositionid` int(6) ,
 `addressid` int(6) ,
 `isdeleted` tinyint(4) 
)*/;

/*Table structure for table `storeinformation_view` */

DROP TABLE IF EXISTS `storeinformation_view`;

/*!50001 DROP VIEW IF EXISTS `storeinformation_view` */;
/*!50001 DROP TABLE IF EXISTS `storeinformation_view` */;

/*!50001 CREATE TABLE  `storeinformation_view`(
 `Store Name` varchar(60) ,
 `contactdetailid` int(6) ,
 `addressid` int(6) ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Zip Code` varchar(60) ,
 `Province` varchar(60) 
)*/;

/*Table structure for table `subcategories_view` */

DROP TABLE IF EXISTS `subcategories_view`;

/*!50001 DROP VIEW IF EXISTS `subcategories_view` */;
/*!50001 DROP TABLE IF EXISTS `subcategories_view` */;

/*!50001 CREATE TABLE  `subcategories_view`(
 `Sub Category ID` int(6) ,
 `Sub Category Name` varchar(60) ,
 `Category Name` varchar(60) ,
 `categoryid` int(6) ,
 `isdeleted` tinyint(1) ,
 `categoriesisdeleted` tinyint(1) 
)*/;

/*Table structure for table `supplierproducts_view` */

DROP TABLE IF EXISTS `supplierproducts_view`;

/*!50001 DROP VIEW IF EXISTS `supplierproducts_view` */;
/*!50001 DROP TABLE IF EXISTS `supplierproducts_view` */;

/*!50001 CREATE TABLE  `supplierproducts_view`(
 `Supplier Product ID` int(6) ,
 `Supplier` varchar(60) ,
 `Product Name` varchar(100) ,
 `Product Description` varchar(60) ,
 `Product SKU` varchar(60) ,
 `Product Price` float ,
 `Category Name` varchar(60) ,
 `Sub Category Name` varchar(60) ,
 `subcategoryid` int(6) ,
 `contactdetailid` int(6) ,
 `productsisdeleted` tinyint(1) ,
 `isdeleted` tinyint(1) ,
 `productid` int(6) ,
 `supplierid` int(6) ,
 `categoryid` int(6) ,
 `subcategoriesisdeleted` tinyint(1) ,
 `categoriesisdeleted` tinyint(1) 
)*/;

/*Table structure for table `suppliers_view` */

DROP TABLE IF EXISTS `suppliers_view`;

/*!50001 DROP VIEW IF EXISTS `suppliers_view` */;
/*!50001 DROP TABLE IF EXISTS `suppliers_view` */;

/*!50001 CREATE TABLE  `suppliers_view`(
 `Supplier ID` int(6) ,
 `Supplier` varchar(60) ,
 `Contact Number` varchar(60) ,
 `Email Address` varchar(60) ,
 `Address` varchar(60) ,
 `City` varchar(60) ,
 `Zip Code` varchar(60) ,
 `Province` varchar(60) ,
 `contactdetailid` int(6) ,
 `isdeleted` tinyint(1) ,
 `addressid` int(6) 
)*/;

/*View structure for view addresses_view */

/*!50001 DROP TABLE IF EXISTS `addresses_view` */;
/*!50001 DROP VIEW IF EXISTS `addresses_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `addresses_view` AS select `addresses`.`addressid` AS `addressid`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province` from `addresses` */;

/*View structure for view basicinformations_view */

/*!50001 DROP TABLE IF EXISTS `basicinformations_view` */;
/*!50001 DROP VIEW IF EXISTS `basicinformations_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `basicinformations_view` AS select `basicinformations`.`basicinformationid` AS `basicinformationid`,`basicinformations`.`firstname` AS `firstname`,`basicinformations`.`middlename` AS `middlename`,`basicinformations`.`lastname` AS `lastname`,`basicinformations`.`gender` AS `gender`,`basicinformations`.`birthdate` AS `birthdate` from `basicinformations` */;

/*View structure for view categories_view */

/*!50001 DROP TABLE IF EXISTS `categories_view` */;
/*!50001 DROP VIEW IF EXISTS `categories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `categories_view` AS select `categories`.`categoryid` AS `Category ID`,`categories`.`categoryname` AS `Category Name`,`categories`.`isdeleted` AS `isdeleted` from `categories` where (`categories`.`isdeleted` = 0) */;

/*View structure for view contactdetails_view */

/*!50001 DROP TABLE IF EXISTS `contactdetails_view` */;
/*!50001 DROP VIEW IF EXISTS `contactdetails_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `contactdetails_view` AS select `contactdetails`.`contactdetailid` AS `contactdetailid`,`contactdetails`.`addressid` AS `addressid`,`contactdetails`.`contactnumber` AS `contactnumber`,`contactdetails`.`emailaddress` AS `emailaddress`,`addresses`.`address` AS `address`,`addresses`.`city` AS `city`,`addresses`.`zipcode` AS `zipcode`,`addresses`.`province` AS `province` from (`contactdetails` join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) */;

/*View structure for view customers_view */

/*!50001 DROP TABLE IF EXISTS `customers_view` */;
/*!50001 DROP VIEW IF EXISTS `customers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customers_view` AS select `customers`.`customerid` AS `Customer ID`,`basicinformations`.`firstname` AS `First Name`,`basicinformations`.`middlename` AS `Middle Name`,`basicinformations`.`lastname` AS `Last Name`,`basicinformations`.`gender` AS `Gender`,`basicinformations`.`birthdate` AS `Birth Date`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`province` AS `Province`,`addresses`.`zipcode` AS `Zip Code`,`customers`.`contactdetailid` AS `contactdetailid`,`customers`.`basicinformationid` AS `basicinformationid`,`contactdetails`.`addressid` AS `addressid`,`customers`.`isdeleted` AS `isdeleted` from (((`customers` join `contactdetails` on((`customers`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `basicinformations` on((`customers`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) where (`customers`.`isdeleted` = 0) */;

/*View structure for view inventories_view */

/*!50001 DROP TABLE IF EXISTS `inventories_view` */;
/*!50001 DROP VIEW IF EXISTS `inventories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `inventories_view` AS select `inventories`.`inventoryid` AS `Inventory ID`,`products`.`productsku` AS `Product SKU`,`products`.`productname` AS `Product Name`,`products`.`productdescription` AS `Product Description`,`products`.`productprice` AS `Product Price`,`categories`.`categoryname` AS `Category Name`,`subcategories`.`subcategoryname` AS `Sub Category Name`,`inventories`.`quantityinstocks` AS `Quantity In Stocks`,`inventories`.`reorderlevel` AS `Reorder Level`,`inventories`.`inventorylastupdated` AS `Inventory Last Updated`,`products`.`subcategoryid` AS `subcategoryid`,`inventories`.`productid` AS `Product Id`,`products`.`isdeleted` AS `isdeleted`,`subcategories`.`categoryid` AS `categoryid`,`subcategories`.`isdeleted` AS `subcategoriesisdeleted`,`categories`.`isdeleted` AS `categoriesisdeleted` from (((`inventories` join `products` on((`inventories`.`productid` = `products`.`productid`))) join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) where ((`products`.`isdeleted` = 0) and (`subcategories`.`isdeleted` = 0) and (`categories`.`isdeleted` = 0)) */;

/*View structure for view ordertypes_view */

/*!50001 DROP TABLE IF EXISTS `ordertypes_view` */;
/*!50001 DROP VIEW IF EXISTS `ordertypes_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ordertypes_view` AS select `ordertypes`.`ordertypeid` AS `ordertypeid`,`ordertypes`.`ordertype` AS `ordertype` from `ordertypes` */;

/*View structure for view paymentmethods_view */

/*!50001 DROP TABLE IF EXISTS `paymentmethods_view` */;
/*!50001 DROP VIEW IF EXISTS `paymentmethods_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `paymentmethods_view` AS select `paymentmethods`.`paymentmethodid` AS `Payment Method ID`,`paymentmethods`.`paymentmethod` AS `Payment Method` from `paymentmethods` */;

/*View structure for view products_view */

/*!50001 DROP TABLE IF EXISTS `products_view` */;
/*!50001 DROP VIEW IF EXISTS `products_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `products_view` AS select `products`.`productid` AS `Product ID`,`products`.`productname` AS `Product Name`,`products`.`productdescription` AS `Product Description`,`products`.`productsku` AS `Product SKU`,`products`.`productprice` AS `Product Price`,`categories`.`categoryname` AS `Category Name`,`subcategories`.`subcategoryname` AS `Sub Category Name`,`subcategories`.`categoryid` AS `categoryid`,`products`.`subcategoryid` AS `subcategoryid`,`subcategories`.`isdeleted` AS `subcategoriesisdeleted`,`products`.`isdeleted` AS `isdeleted`,`categories`.`isdeleted` AS `categoriesisdeleted` from ((`subcategories` join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) join `products` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) where ((`products`.`isdeleted` = 0) and (`subcategories`.`isdeleted` = 0) and (`categories`.`isdeleted` = 0)) */;

/*View structure for view purchaseorderdetails_view */

/*!50001 DROP TABLE IF EXISTS `purchaseorderdetails_view` */;
/*!50001 DROP VIEW IF EXISTS `purchaseorderdetails_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purchaseorderdetails_view` AS select `purchaseorderdetails`.`productid` AS `Product ID`,`products`.`productname` AS `Product Name`,`purchaseorderdetails`.`purchaseorderdetailprice` AS `Price`,`purchaseorderdetails`.`purchaseorderdetailquantity` AS `Quantity`,(`purchaseorderdetails`.`purchaseorderdetailquantity` * `purchaseorderdetails`.`purchaseorderdetailprice`) AS `Amount`,`purchaseorderdetails`.`purchaseorderdetailid` AS `Purchase Order Detail ID`,`purchaseorderdetails`.`purchaseorderid` AS `Purchase Order ID`,`products`.`productdescription` AS `Product Description`,`products`.`subcategoryid` AS `Sub Category ID`,`products`.`productsku` AS `Produck SKU`,`products`.`productprice` AS `Product Price`,`products`.`isdeleted` AS `Product Is Deleted`,`subcategories`.`subcategoryname` AS `Sub Category Name`,`subcategories`.`categoryid` AS `Category ID`,`subcategories`.`isdeleted` AS `Sub Categories Is Deleted`,`categories`.`isdeleted` AS `Category Is Deleted`,`purchaseorders`.`staffid` AS `Staff ID`,`purchaseorders`.`purchaseordername` AS `Purchase Order Name`,`purchaseorders`.`supplierid` AS `Purchase Order Supplier ID`,`purchaseorders`.`paymentmethodid` AS `Payment Method ID`,`purchaseorders`.`shippingmethodid` AS `Shipping Method ID`,`purchaseorders`.`purchaseorderstatus` AS `Purchase Order Status`,`purchaseorders`.`purchaseorderamountpaid` AS `Purchase Order Amount Paid`,`purchaseorders`.`purchasetotalorderamount` AS `Purchase Total Order Amount`,`purchaseorders`.`purchaseorderdatereceived` AS `Date Received`,`purchaseorders`.`purchaseorderdaterequested` AS `Date Requested`,`purchaseorders`.`purchaseordercomment` AS `Purchase Order Comment`,`purchaseorders`.`isdeleted` AS `Purchase Order Is Deleted`,`suppliers`.`supplier` AS `Supplier`,`suppliers`.`contactdetailid` AS `Supplier Contact Detail ID`,`suppliers`.`isdeleted` AS `Supplier Is Deleted`,`staffs`.`username` AS `Staff Username`,`staffs`.`password` AS `Staff Password`,`staffs`.`contactdetailid` AS `Staff Contact Detail ID`,`staffs`.`basicinformationid` AS `Staff Basic Information ID`,`staffs`.`staffpositionid` AS `Staff Position ID`,`staffpositions`.`staffposition` AS `Staff Position`,`basicinformations`.`firstname` AS `First Name`,`basicinformations`.`middlename` AS `Middle Name`,`basicinformations`.`lastname` AS `Last Name`,`basicinformations`.`gender` AS `Gender`,`basicinformations`.`birthdate` AS `Birth Date`,`paymentmethods`.`paymentmethod` AS `Payment Method`,`shippingmethods`.`shippingmethod` AS `Shipping Method` from ((((((((((`purchaseorderdetails` join `purchaseorders` on((`purchaseorderdetails`.`purchaseorderid` = `purchaseorders`.`purchaseorderid`))) join `products` on((`purchaseorderdetails`.`productid` = `products`.`productid`))) join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) join `suppliers` on((`purchaseorders`.`supplierid` = `suppliers`.`supplierid`))) join `staffs` on((`purchaseorders`.`staffid` = `staffs`.`staffid`))) join `staffpositions` on((`staffs`.`staffpositionid` = `staffpositions`.`staffpositionid`))) join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `paymentmethods` on((`purchaseorders`.`paymentmethodid` = `paymentmethods`.`paymentmethodid`))) join `shippingmethods` on((`purchaseorders`.`shippingmethodid` = `shippingmethods`.`shippingmethodid`))) */;

/*View structure for view purchaseorders_view */

/*!50001 DROP TABLE IF EXISTS `purchaseorders_view` */;
/*!50001 DROP VIEW IF EXISTS `purchaseorders_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purchaseorders_view` AS select `purchaseorders`.`purchaseorderid` AS `Purchase Order ID`,`suppliers`.`supplier` AS `Supplier`,`purchaseorders`.`purchaseordername` AS `Purchase Order Name`,`paymentmethods`.`paymentmethod` AS `Payment Method`,`shippingmethods`.`shippingmethod` AS `Shipping Method`,`purchaseorders`.`purchaseorderdaterequested` AS `Date Requested`,`purchaseorders`.`purchaseorderdatereceived` AS `Date Received`,`purchaseorders`.`purchaseordercomment` AS `Comment`,`purchaseorders`.`purchasetotalorderamount` AS `Total Amount`,`purchaseorders`.`purchaseorderamountpaid` AS `Amount Paid`,`purchaseorders`.`purchaseorderstatus` AS `Purchase Order Status`,concat(`basicinformations`.`firstname`,' ',`basicinformations`.`middlename`,' ',`basicinformations`.`lastname`) AS `Purchase Order By`,`basicinformations`.`firstname` AS `Staff First Name`,`basicinformations`.`middlename` AS `Staff Middle Name`,`basicinformations`.`lastname` AS `Staff Last Name`,`purchaseorders`.`staffid` AS `Purchase Order Staff ID`,`purchaseorders`.`supplierid` AS `Purchase Order Supplier ID`,`purchaseorders`.`paymentmethodid` AS `Purchase Order Payment Method ID`,`purchaseorders`.`shippingmethodid` AS `Purchase Order Shipping Method ID`,`purchaseorders`.`isdeleted` AS `Purchase Order Is Deleted`,`suppliers`.`contactdetailid` AS `Supplier Contact Detail ID`,`suppliers`.`isdeleted` AS `Supplier Is Deleted`,`contactdetails_1`.`addressid` AS `Supplier Address ID`,`contactdetails_1`.`contactnumber` AS `Supplier Contact Number`,`contactdetails_1`.`emailaddress` AS `Supplier Email Address`,`addresses_1`.`address` AS `Supplier Address`,`addresses_1`.`city` AS `Supplier City`,`addresses_1`.`zipcode` AS `Supplier Zip Code`,`addresses_1`.`province` AS `Supplier Province`,`staffs`.`username` AS `Staff Username`,`staffs`.`password` AS `Staff Password`,`staffs`.`contactdetailid` AS `Staff Contact Detail ID`,`staffs`.`basicinformationid` AS `Staff Basic Information ID`,`staffs`.`staffpositionid` AS `Staff Position ID`,`staffs`.`isdeleted` AS `Staff Is Deleted`,`staffpositions`.`staffposition` AS `Staff Position`,`basicinformations`.`gender` AS `Staff Gender`,`basicinformations`.`birthdate` AS `Staff Birth Date`,`contactdetails`.`addressid` AS `Staff Address ID`,`contactdetails`.`contactnumber` AS `Staff Contact Number`,`contactdetails`.`emailaddress` AS `Staff Email Address`,`addresses`.`address` AS `Staff Address`,`addresses`.`city` AS `Staff City`,`addresses`.`zipcode` AS `Staff Zip Code`,`addresses`.`province` AS `Staff Province` from ((((((((((`purchaseorders` join `suppliers` on((`purchaseorders`.`supplierid` = `suppliers`.`supplierid`))) join `paymentmethods` on((`purchaseorders`.`paymentmethodid` = `paymentmethods`.`paymentmethodid`))) join `shippingmethods` on((`purchaseorders`.`shippingmethodid` = `shippingmethods`.`shippingmethodid`))) join `staffs` on((`purchaseorders`.`staffid` = `staffs`.`staffid`))) join `contactdetails` `contactdetails_1` on((`suppliers`.`contactdetailid` = `contactdetails_1`.`contactdetailid`))) join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `contactdetails` on((`staffs`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) join `addresses` `addresses_1` on((`contactdetails_1`.`addressid` = `addresses_1`.`addressid`))) join `staffpositions` on((`staffs`.`staffpositionid` = `staffpositions`.`staffpositionid`))) where ((`purchaseorders`.`isdeleted` = 0) and (`suppliers`.`isdeleted` = 0) and (`staffs`.`isdeleted` = 0)) */;

/*View structure for view shippingmethods_view */

/*!50001 DROP TABLE IF EXISTS `shippingmethods_view` */;
/*!50001 DROP VIEW IF EXISTS `shippingmethods_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `shippingmethods_view` AS select `shippingmethods`.`shippingmethodid` AS `Shipping Method ID`,`shippingmethods`.`shippingmethod` AS `Shipping Method` from `shippingmethods` */;

/*View structure for view staffpositions_view */

/*!50001 DROP TABLE IF EXISTS `staffpositions_view` */;
/*!50001 DROP VIEW IF EXISTS `staffpositions_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `staffpositions_view` AS select `staffpositions`.`staffpositionid` AS `staffpositionid`,`staffpositions`.`staffposition` AS `staffposition` from `staffpositions` */;

/*View structure for view staffs_view */

/*!50001 DROP TABLE IF EXISTS `staffs_view` */;
/*!50001 DROP VIEW IF EXISTS `staffs_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `staffs_view` AS select `staffs`.`staffid` AS `Staff ID`,`staffs`.`username` AS `Username`,`basicinformations`.`firstname` AS `First Name`,`basicinformations`.`middlename` AS `Middle Name`,`basicinformations`.`lastname` AS `Last Name`,`basicinformations`.`gender` AS `Gender`,`basicinformations`.`birthdate` AS `Birth Date`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`province` AS `Province`,`addresses`.`zipcode` AS `Zip Code`,`staffpositions`.`staffposition` AS `Staff Position`,`staffs`.`password` AS `password`,`staffs`.`contactdetailid` AS `contactdetailid`,`staffs`.`basicinformationid` AS `basicinformationid`,`staffs`.`staffpositionid` AS `staffpositionid`,`contactdetails`.`addressid` AS `addressid`,`staffs`.`isdeleted` AS `isdeleted` from ((((`staffs` join `basicinformations` on((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) join `staffpositions` on((`staffs`.`staffpositionid` = `staffpositions`.`staffpositionid`))) join `contactdetails` on((`staffs`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) where (`staffs`.`isdeleted` = 0) */;

/*View structure for view storeinformation_view */

/*!50001 DROP TABLE IF EXISTS `storeinformation_view` */;
/*!50001 DROP VIEW IF EXISTS `storeinformation_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `storeinformation_view` AS select `storeinformation`.`storename` AS `Store Name`,`storeinformation`.`contactdetailid` AS `contactdetailid`,`contactdetails`.`addressid` AS `addressid`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`zipcode` AS `Zip Code`,`addresses`.`province` AS `Province` from ((`contactdetails` join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) join `storeinformation` on((`storeinformation`.`contactdetailid` = `contactdetails`.`contactdetailid`))) */;

/*View structure for view subcategories_view */

/*!50001 DROP TABLE IF EXISTS `subcategories_view` */;
/*!50001 DROP VIEW IF EXISTS `subcategories_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `subcategories_view` AS select `subcategories`.`subcategoryid` AS `Sub Category ID`,`subcategories`.`subcategoryname` AS `Sub Category Name`,`categories`.`categoryname` AS `Category Name`,`subcategories`.`categoryid` AS `categoryid`,`subcategories`.`isdeleted` AS `isdeleted`,`categories`.`isdeleted` AS `categoriesisdeleted` from (`subcategories` join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) where ((`subcategories`.`isdeleted` = 0) and (`categories`.`isdeleted` = 0)) */;

/*View structure for view supplierproducts_view */

/*!50001 DROP TABLE IF EXISTS `supplierproducts_view` */;
/*!50001 DROP VIEW IF EXISTS `supplierproducts_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `supplierproducts_view` AS select `supplierproducts`.`supplierproductid` AS `Supplier Product ID`,`suppliers`.`supplier` AS `Supplier`,`products`.`productname` AS `Product Name`,`products`.`productdescription` AS `Product Description`,`products`.`productsku` AS `Product SKU`,`products`.`productprice` AS `Product Price`,`categories`.`categoryname` AS `Category Name`,`subcategories`.`subcategoryname` AS `Sub Category Name`,`products`.`subcategoryid` AS `subcategoryid`,`suppliers`.`contactdetailid` AS `contactdetailid`,`products`.`isdeleted` AS `productsisdeleted`,`suppliers`.`isdeleted` AS `isdeleted`,`supplierproducts`.`productid` AS `productid`,`supplierproducts`.`supplierid` AS `supplierid`,`subcategories`.`categoryid` AS `categoryid`,`subcategories`.`isdeleted` AS `subcategoriesisdeleted`,`categories`.`isdeleted` AS `categoriesisdeleted` from ((((`supplierproducts` join `products` on((`supplierproducts`.`productid` = `products`.`productid`))) join `suppliers` on((`supplierproducts`.`supplierid` = `suppliers`.`supplierid`))) join `subcategories` on((`products`.`subcategoryid` = `subcategories`.`subcategoryid`))) join `categories` on((`subcategories`.`categoryid` = `categories`.`categoryid`))) */;

/*View structure for view suppliers_view */

/*!50001 DROP TABLE IF EXISTS `suppliers_view` */;
/*!50001 DROP VIEW IF EXISTS `suppliers_view` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `suppliers_view` AS select `suppliers`.`supplierid` AS `Supplier ID`,`suppliers`.`supplier` AS `Supplier`,`contactdetails`.`contactnumber` AS `Contact Number`,`contactdetails`.`emailaddress` AS `Email Address`,`addresses`.`address` AS `Address`,`addresses`.`city` AS `City`,`addresses`.`zipcode` AS `Zip Code`,`addresses`.`province` AS `Province`,`suppliers`.`contactdetailid` AS `contactdetailid`,`suppliers`.`isdeleted` AS `isdeleted`,`contactdetails`.`addressid` AS `addressid` from ((`suppliers` join `contactdetails` on((`suppliers`.`contactdetailid` = `contactdetails`.`contactdetailid`))) join `addresses` on((`contactdetails`.`addressid` = `addresses`.`addressid`))) where (`suppliers`.`isdeleted` = 0) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
