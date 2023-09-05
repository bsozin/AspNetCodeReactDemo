USE master
GO

CREATE DATABASE Cars
GO

CREATE TABLE Cars.dbo.Brand (
	Id int IDENTITY CONSTRAINT PK_Brand PRIMARY KEY CLUSTERED
   ,Name nvarchar(32) NOT NULL
)
GO

CREATE TABLE Cars.dbo.BodyType (
	Id int IDENTITY CONSTRAINT PK_BodyType PRIMARY KEY CLUSTERED (Id)
   ,Name nvarchar(32) NOT NULL
)
GO

CREATE TABLE Cars.dbo.Cars (
	Id int IDENTITY CONSTRAINT PK_Cars PRIMARY KEY CLUSTERED (Id)
   ,BrandId int NOT NULL CONSTRAINT FK_Cars_Brand_BrandId FOREIGN KEY REFERENCES dbo.Brand (Id) ON DELETE NO ACTION
   ,BodyTypeId int NOT NULL CONSTRAINT FK_Cars_BodyType_BodyTypeId FOREIGN KEY REFERENCES dbo.BodyType (Id) ON DELETE NO ACTION
   ,Name nvarchar(1000) NOT NULL
   ,SeatsCount int NOT NULL
   ,DealerUrl nvarchar(1000) NULL
   ,CreationDate datetimeoffset NOT NULL DEFAULT SYSDATETIMEOFFSET()
)
GO

INSERT INTO Cars.dbo.Brand (Name)
VALUES
    (N'Audi'),
    (N'Ford'),
    (N'Jeep'),
    (N'Nissan'),
    (N'Toyota')
GO

INSERT INTO Cars.dbo.BodyType (Name)
VALUES
    (N'Седан'),
    (N'Хэтчбек'),
    (N'Универсал'),
    (N'Минивэн'),
    (N'Внедорожник'),
    (N'Купе')
GO