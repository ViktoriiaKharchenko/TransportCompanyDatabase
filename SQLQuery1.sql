use [TransportCompanyDatabase];


SET IDENTITY_INSERT TrailerTypes OFF;
SET IDENTITY_INSERT Drivers OFF;
SET IDENTITY_INSERT CustomerCompanies OFF;
SET IDENTITY_INSERT Loads OFF;
SET IDENTITY_INSERT Trailers OFF;
SET IDENTITY_INSERT DriversWagons OFF;
SET IDENTITY_INSERT Deliveries OFF;
SET IDENTITY_INSERT Wagons OFF;
SET IDENTITY_INSERT Wagons OFF;

delete from TrailerTypes;
delete from CustomerCompanies;
delete from Loads;
delete from Trailers;
delete from Wagons;
delete from Drivers;
delete from DriversWagons;
delete from Deliveries;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.TrailerTypes ON;
insert into TrailerTypes (Id, Type) values
(1, 'Flatbed Trailers'),
(2, 'Refrigerated Trailers'),
(3, 'Lowboy Trailers'),
(4, 'Step Deck Trailers'),
(5, 'Stretch Single Drop Deck Trailers'),
(6, 'Removable Gooseneck Trailer (RGN)'),
(7, 'Specialty Trailers'),
(8, 'Trailers for Transport of Hazardous Materials'),
(9, 'Medical Trailers'),
(10, 'Event Marketing Trailers or Display Trailers'),
(11, 'Food Services Trailers'),
(12, 'Vending Trailers'),
(13, 'Side-kit Trailers'),
(14, 'Extendable Double Drop Trailers'),
(15, 'Stretch RGN Trailers'),
(16, 'Conestoga Trailer'),
(17, 'Power-Only Trailers'),
(18, 'Multi-Car Trailer')
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.TrailerTypes OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.CustomerCompanies ON;
insert into CustomerCompanies (Id, CompanyName, DocumentNum) values
(1, 'Toyota', 'doc num 1'),
(2, 'not toyota', 'doc num 2'),
(3, 'Karrito', 'doc num 3'),
(4, 'Boss corp', 'doc num 4'),
(5, 'YuCorp', 'doc num 5'),
(6, 'Ziaomi', 'doc num 6'),
(7, 'ZakBrossCorp', 'doc num 7'),
(8, 'CoCaCorp', 'doc num 8')
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.CustomerCompanies OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Loads ON;
insert into Loads (Id, UploadDate, Address, CargoName, RequireADR) values
(1, '2020-04-01 12:12:00', 'Fisk street 7a', 'Food ', 0),
(2, '2020-04-11 09:33:32', 'Karasin street 18', 'Fuel ', 1),
(3, '2020-04-19 15:09:45', 'Fisk street 7a', 'Vegetables ', 0),
(4, '2020-05-02 01:54:10', 'Karasin street 18', 'Gas ', 1)
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Loads OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Trailers ON;
insert into Trailers (Id, Volume, CarryingCapacity, TrailerTypeId) values
(1, 25, 15, 8),
(2, 20, 10, 2),
(3, 30, 15, 1),
(4, 20, 10, 8)
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Trailers OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Wagons ON;
insert into Wagons (Id, TrailerId) values
(1, 1),
(2, 2),
(3, 3),
(4, 4)
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Wagons OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Drivers ON;
insert into Drivers (Id, FullName, PassportNum, DriverLicenseNum, ADRCertificate) values
(1, 'Pupkin Vasyl Ivanovich', 'AB123456', 'K12lk31233AA', 1),
(2, 'John Trevis', 'KSA12345678', 'K22221233AA', 0),
(3, 'Grigoriev Inokentyi Pavlovich', 'AB760760', 'K13lk31233AB', 0),
(4, 'Miziakina Alla Valentynivna', 'AC808678', 'K34lL31267AA', 1),
(5, 'Koramovich Olga Igorevna', 'AB123331', 'K77lk31544AA', 0),
(6, 'Bruse Wayne', '000000000', 'k00k000001a', 1)
;
SET IDENTITY_INSERT Drivers OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.DriversWagons ON;
Insert into DriversWagons (Id, DriverId, WagonId) values
(10, 1, 3),
(20, 6, 4),
(30, 3, 2),
(40, 4, 1)
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.DriversWagons OFF;

SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Deliveries ON;
insert into Deliveries (Id, DriverWagonId, CustomerCompanyId, LoadId, UnloadDate, Address) values
(200, 10,1,2,'2020-04-12 00:33:32','Samsoneko street 1'),
(201, 20,2,1,'2020-04-03 12:00:10','Miska street 23/2'),
(202, 30,3,3,'2020-04-03 12:00:10','Samsoneko street 2'),
(203, 40,4,4,'2020-04-03 12:00:10','Miska street 23/3')
;
SET IDENTITY_INSERT TransportCompanyDatabase.dbo.Deliveries OFF;

