DELIMITER $$

USE `pos`$$

DROP VIEW IF EXISTS `purchaseorders_view`$$

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `purchaseorders_view` AS 
SELECT 
`purchaseorders`.`purchaseorderid` AS `Purchase Order ID`,
`purchaseorders`.`purchaseordername` AS `Purchase Order Name`,
`purchaseorders`.`purchaseordercomment` AS `Purchase Order Comment`,
`purchaseorders`.`purchaseorderamountpaid` AS `Purchase Order Amount Paid`,
`purchaseorders`.`purchasetotalorderamount` AS `Purchase Order Total Amount`,
`purchaseorders`.`purchaseorderstatus` AS `Purchase Order Status`,
`purchaseorders`.`purchaseorderdatedelivered` AS `Purchase Order Date Delivered`,
`purchaseorders`.`purchaseorderdaterequested` AS `Purchase Order Date Requested`,
`suppliers`.`supplier` AS `Supplier`,
CONCAT(`basicinformations`.`firstname`, " " , `basicinformations`.`middlename`, " ", `basicinformations`.`lastname`) AS `Purchase Order By`,


`basicinformations`.`firstname` AS `Staff First Name`,
`basicinformations`.`middlename` AS `Staff Middle Name`,
`basicinformations`.`lastname` AS `Staff Last Name`,
`purchaseorders`.`staffid` AS `Purchase Order Staff ID`,
`purchaseorders`.`supplierid` AS `Purchase Order Supplier ID`,
`purchaseorders`.`paymentmethodid` AS `Purchase Order Payment Method ID`,
`purchaseorders`.`shippingmethodid` AS `Purchase Order Shipping Method ID`,
`purchaseorders`.`isdeleted` AS `Purchase Order Is Deleted`,
`suppliers`.`contactdetailid` AS `Supplier Contact Detail ID`,
`suppliers`.`isdeleted` AS `Supplier Is Deleted`,
`contactdetails_1`.`addressid` AS `Supplier Address ID`,
`contactdetails_1`.`contactnumber` AS `Supplier Contact Number`,
`contactdetails_1`.`emailaddress` AS `Supplier Email Address`,
`addresses_1`.`address` AS `Supplier Address`,
`addresses_1`.`city` AS `Supplier City`,
`addresses_1`.`zipcode` AS `Supplier Zip Code`,
`addresses_1`.`province` AS `Supplier Province`,
`paymentmethods`.`paymentmethod` AS `Payment Method`,
`shippingmethods`.`shippingmethod` AS `Shipping Method`,
`staffs`.`username` AS `Staff Username`,
`staffs`.`password` AS `Staff Password`,
`staffs`.`contactdetailid` AS `Staff Contact Detail ID`,
`staffs`.`basicinformationid` AS `Staff Basic Information ID`,
`staffs`.`staffpositionid` AS `Staff Position ID`,
`staffs`.`isdeleted` AS `Staff Is Deleted`,
`staffpositions`.`staffposition` AS `Staff Position`,

`basicinformations`.`gender` AS `Staff Gender`,
`basicinformations`.`birthdate` AS `Staff Birth Date`,
`contactdetails`.`addressid` AS `Staff Address ID`,
`contactdetails`.`contactnumber` AS `Staff Contact Number`,
`contactdetails`.`emailaddress` AS `Staff Email Address`,
`addresses`.`address` AS `Staff Address`,
`addresses`.`city` AS `Staff City`,
`addresses`.`zipcode` AS `Staff Zip Code`,
`addresses`.`province` AS `Staff Province` 

FROM ((((((((((`purchaseorders` JOIN `suppliers` ON((`purchaseorders`.`supplierid` = `suppliers`.`supplierid`))) JOIN `paymentmethods` ON((`purchaseorders`.`paymentmethodid` = `paymentmethods`.`paymentmethodid`))) JOIN `shippingmethods` ON((`purchaseorders`.`shippingmethodid` = `shippingmethods`.`shippingmethodid`))) JOIN `staffs` ON((`purchaseorders`.`staffid` = `staffs`.`staffid`))) JOIN `contactdetails` `contactdetails_1` ON((`suppliers`.`contactdetailid` = `contactdetails_1`.`contactdetailid`))) JOIN `basicinformations` ON((`staffs`.`basicinformationid` = `basicinformations`.`basicinformationid`))) JOIN `contactdetails` ON((`staffs`.`contactdetailid` = `contactdetails`.`contactdetailid`))) JOIN `addresses` ON((`contactdetails`.`addressid` = `addresses`.`addressid`))) JOIN `addresses` `addresses_1` ON((`contactdetails_1`.`addressid` = `addresses_1`.`addressid`))) JOIN `staffpositions` ON((`staffs`.`staffpositionid` = `staffpositions`.`staffpositionid`))) WHERE ((`purchaseorders`.`isdeleted` = 0) AND (`suppliers`.`isdeleted` = 0) AND (`staffs`.`isdeleted` = 0))$$

DELIMITER ;