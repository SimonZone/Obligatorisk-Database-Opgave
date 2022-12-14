CREATE TABLE PostalCodeT( Postal int NOT NULL PRIMARY KEY, City varchar(30) NOT NULL);

CREATE TABLE FacilityT( FacilityId int IDENTITY(1,1) PRIMARY KEY, FacilityType varchar(30) NOT NULL DEFAULT 'Non');

CREATE TABLE HotelT( HotelId int NOT NULL PRIMARY KEY, HotelName VARCHAR(30) NOT NULL, AddressName VARCHAR(50) NOT NULL,  
Postal int NOT NULL, FOREIGN KEY (Postal) REFERENCES PostalCodeT(Postal));

CREATE TABLE FacilityListT( FacilityListId int IDENTITY(1,1), HotelId int NOT NULL, FacilityID int NOT NULL, PRIMARY KEY(FacilityListID, HotelId), FOREIGN KEY(FacilityID) REFERENCES FacilityT(FacilityID), FOREIGN KEY(HotelId) REFERENCES HotelT(HotelId));

CREATE TABLE RoomT( RoomId int NOT NULL, HotelId int NOT NULL, RoomType varchar(50) DEFAULT 'Single', Price FLOAT, IsBooked BIT NULL DEFAULT 0,
CONSTRAINT checkType CHECK (RoomType IN ('Single','Double','Family') OR RoomType IS NULL), 
CONSTRAINT checkPrice CHECK (price BETWEEN 0 AND 9999), 
FOREIGN KEY (HotelId) REFERENCES HotelT (HotelId) ON UPDATE CASCADE ON DELETE NO ACTION, Primary KEY (RoomId, HotelId) ); 

CREATE TABLE GuestT ( GuestId int NOT NULL PRIMARY KEY, Name VARCHAR(30) NOT NULL, Email VARCHAR(50) NOT NULL, GuestCount int NOT NULL, PhoneNo int NOT NULL);

CREATE TABLE BookingT( BookingId int IDENTITY(1,1) NOT NULL PRIMARY KEY, HotelId int NOT NULL, GuestId int NOT NULL, 
 DateBooked DATE NOT NULL, BookingEnd DATE NOT NULL, RoomId int NOT NULL, FOREIGN KEY(GuestId) REFERENCES GuestT(GuestId), 
FOREIGN KEY(RoomId, HotelId) REFERENCES RoomT(RoomId, HotelId), 
CONSTRAINT incorrectDates CHECK (BookingEnd > DateBooked));
