CREATE DATABASE efcachetest

GO

USE efcachetest

CREATE TABLE Users (
Id int IDENTITY PRIMARY KEY,
Name nvarchar(255) NULL
)

INSERT INTO Users(Name) VALUES ('Bob')