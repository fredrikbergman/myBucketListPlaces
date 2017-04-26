ALTER DATABASE [blpDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE

USE master

DROP DATABASE blpDB

CREATE DATABASE blpDB

USE blpDB

--CREATE SCHEMA blp --Kan inte köras i script. Måste exekveras separat..

CREATE TABLE [blp].[User]
(
	[Id]		INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
	[FirstName] NVARCHAR(50) NOT NULL, 
	[LastName]	NVARCHAR(50) NOT NULL, 
	[Email]		NVARCHAR(50) NOT NULL, 
	[Password]	NVARCHAR(50) NOT NULL --Password will be stored in readable format HASHTYPES & SALT
)

CREATE TABLE [blp].[Place] (
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
	[UserId]      INT            NOT NULL,
	[Name]        NVARCHAR (50)  NOT NULL,
	[Country]     NVARCHAR (50)  NOT NULL,
	[Description] NVARCHAR (MAX) NULL,
	[Lat]		FLOAT (53)     NULL,
	[Long]      FLOAT (53)     NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC), 
	CONSTRAINT [FK_Place_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
);

CREATE TABLE [blp].[Link] (
	[Id]		INT IDENTITY (1, 1) NOT NULL,
	[PlaceId]	INT NOT NULL,
	[Link]		NVARCHAR (MAX) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Link_ToPlace] FOREIGN KEY ([PlaceId]) REFERENCES [dbo].[Place] ([Id])
);

CREATE TABLE [blp].[Image] (
	[Id]		INT IDENTITY (1, 1) NOT NULL,
	[ImageId]	INT NOT NULL,
	[ImageName]		NVARCHAR (MAX) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Image_ToPlace] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Place] ([Id])
);

--Testdata
INSERT INTO [dbo].[User]
VALUES ('Fredrik','Bergman','f.b@gmail.se','abc123')

INSERT INTO [dbo].[User]
VALUES ('Linus','Bergman','l.b@gmail.se','def456')

INSERT INTO Place
VALUES ('1','Positano','Italien','Fint ställe!',40.627656,14.487620)

INSERT INTO Place
VALUES ('2','Träslövsläge','Sverige','Hemma!',57.058939, 12.275009)

INSERT INTO Place
VALUES ('1','Borås Djurpark','Sverige','Spännande!',57.740977, 12.941493)