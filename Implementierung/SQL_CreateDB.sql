if DB_ID('Tischreservierung-DB') IS NOT NULL
	DROP DATABASE [Tischreservierung-DB];

if OBJECT_ID('Restaurant') IS NOT NULL
	DROP TABLE Restaurant;

if OBJECT_ID('Tisch') IS NOT NULL
	DROP TABLE Tisch;

if OBJECT_ID('Reservation') IS NOT NULL
	DROP TABLE Reservation;

if OBJECT_ID('Customer') IS NOT NULL
	DROP TABLE Customer;



CREATE DATABASE "Tischreservierung-DB";

use [Tischreservierung-DB]
GO


CREATE TABLE Restaurant
(
	RestaurantID int PRIMARY KEY identity,
	Name nvarchar(50),
	OpenTime Time,
	CloseTime Time
);

CREATE TABLE Tisch
(
	TableID int PRIMARY KEY identity,
	TableSize int NOT NULL,
	RestaurantID int NOT NULL,
	CONSTRAINT FK_Table_Restaurant FOREIGN KEY (RestaurantID)
    REFERENCES Restaurant (RestaurantID)
	 ON DELETE CASCADE,
);


CREATE TABLE Customer
(
	CustomerID int PRIMARY KEY identity,
	Name nvarchar(50) NOT NULL,
	Phonenumber nvarchar(50) NOT NULL,
	Email nvarchar(50)
);

CREATE TABLE Reservation
(
	ReservationID int PRIMARY KEY identity,
	NumberOfPeople int NOT NULL,
	StartPoint datetime NOT NULL,
	EndePoint datetime NOT NULL,
	CustomerID int NOT NULL,
	CONSTRAINT FK_Reservation_Customer FOREIGN KEY (CustomerID)
    REFERENCES Customer (CustomerID)
	 ON DELETE CASCADE,

	TableID int NOT NULL,
	CONSTRAINT FK_Reservation_Table FOREIGN KEY (TableID)
    REFERENCES Tisch (TableID)
	ON DELETE NO ACTION
);


INSERT INTO Restaurant
VALUES('Restaurant Maus', '08:00:00', '20:00:00');

INSERT INTO Restaurant
VALUES('Restaurant Klaus', '08:00:00', '20:00:00');

INSERT INTO Restaurant
VALUES('Restaurant Hund', '08:00:00', '20:00:00');

INSERT INTO Restaurant
VALUES('Restaurant Katze', '08:00:00', '20:00:00');

INSERT INTO Tisch
VALUES(5, 1);

INSERT INTO Tisch
VALUES(5, 1);

INSERT INTO Tisch
VALUES(4, 1);

INSERT INTO Tisch
VALUES(10, 1);

INSERT INTO Tisch
VALUES(15, 1);

INSERT INTO Tisch
VALUES(10, 1);

INSERT INTO Tisch
VALUES(23, 1);

INSERT INTO Tisch
VALUES(5, 2);

INSERT INTO Tisch
VALUES(5, 2);

INSERT INTO Tisch
VALUES(4, 2);

INSERT INTO Tisch
VALUES(10,2);

INSERT INTO Tisch
VALUES(15, 3);

INSERT INTO Tisch
VALUES(10, 3);

INSERT INTO Tisch
VALUES(23, 3);

INSERT INTO Tisch
VALUES(5, 3);

INSERT INTO Tisch
VALUES(5, 3);

INSERT INTO Tisch
VALUES(4, 4);

INSERT INTO Tisch
VALUES(10, 4);

INSERT INTO Tisch
VALUES(15, 4);


INSERT INTO Customer
VALUES('Hans', '032405 2340', NULL);

INSERT INTO Customer
VALUES('Günter', '032405 2340', NULL);

INSERT INTO Customer
VALUES('Herbert', '032405 2340', NULL);

INSERT INTO Reservation
VALUES(3, GETDATE(), GETDATE(), 1, 1);

INSERT INTO Reservation
VALUES(3, GETDATE(), GETDATE(), 2, 2);

INSERT INTO Reservation
VALUES(3, GETDATE(), GETDATE(), 3, 3);

INSERT INTO Reservation
VALUES(3, GETDATE(), GETDATE(), 1, 4);

