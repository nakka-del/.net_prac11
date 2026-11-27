CREATE DATABASE SmartCampusDB;
GO

USE SmartCampusDB;
GO

CREATE TABLE Students
(
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Email VARCHAR(100),
    Department VARCHAR(100)
);

CREATE TABLE Complaints
(
    ComplaintId INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT,
    Title VARCHAR(100),
    Description VARCHAR(500),
    Status VARCHAR(50) DEFAULT 'Pending',

    FOREIGN KEY (StudentId)
    REFERENCES Students(StudentId)
);

CREATE TABLE Notices
(
    NoticeId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100),
    Description VARCHAR(500),
    PostedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Events
(
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName VARCHAR(100),
    EventDate DATETIME,
    Venue VARCHAR(100)
);
