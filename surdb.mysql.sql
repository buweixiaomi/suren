CREATE DATABASE IF NOT EXISTS surendata  DEFAULT CHARSET utf8 COLLATE utf8_general_ci;
use surendata;

CREATE TABLE `projects` (
   `ProjectId` int(11) NOT NULL auto_increment,
   `ProjectName` longtext,
   `Remark` longtext,
   `Status` int(11) NOT NULL default 0,
   PRIMARY KEY (`ProjectId`),
   UNIQUE KEY `ProjectId` (`ProjectId`)
 ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
 
 CREATE TABLE `targets` (
   `TargetId` int(11) NOT NULL auto_increment,
   `TargetName` longtext,
   `Remark` longtext,
   `Status` int(11) NOT NULL default 0,
   `ProjectId` int(11) NOT NULL,
   PRIMARY KEY (`TargetId`),
   UNIQUE KEY `TargetId` (`TargetId`)
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
 


CREATE TABLE `points` (
   `PointId` int(11) NOT NULL auto_increment,
   `PointName` longtext,
   `Remark` longtext,
   `Status` int(11) NOT NULL default 0,
   `ProjectId` int(11) NOT NULL,
   `TargetId` int(11) NOT NULL,
   PRIMARY KEY (`PointId`),
   UNIQUE KEY `PointId` (`PointId`)
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
 
 -- drop table surveyings;
 -- drop table surveyingdetails;
 
 CREATE TABLE `surveyings` (
   `SurveyingId` int(11) NOT NULL auto_increment,
   `SurveyingName` longtext,
   `SurveyingTime` datetime NOT NULL,
   `DayWeather` longtext NOT NULL,
   `SurveyingMan` longtext NOT NULL,
   `DataUnit` varchar(256) NOT NULL,
   `Remark` longtext,
   `ProjectId` int(11) NOT NULL,
   `TargetId` int(11) NOT NULL,
   `Status` int(11) NOT NULL default 0,
   PRIMARY KEY (`SurveyingId`),
   UNIQUE KEY `SurveyingId` (`SurveyingId`)
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
 
 CREATE TABLE `surveyingdetails` (
   `Id` int(11) NOT NULL AUTO_INCREMENT,
   `ProjectId` int(11) NOT NULL,
   `TargetId` int(11) NOT NULL,
   `SurveyingId` int(11) NOT NULL,
   `PointId` int(11) NOT NULL,
   `Data1` decimal(18,6) NOT NULL,
   `Data2` decimal(18,6) NOT NULL,
   `Data3` decimal(18,6) NOT NULL,
   `Data4` decimal(18,6) NOT NULL,
   `NoUseable` int(11) NOT NULL,
   `Remark` longtext,
   PRIMARY KEY (`Id`),
   UNIQUE KEY `Id` (`Id`)
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
 
  CREATE TABLE `surdatagen` (
   `ProjectId` int(11) NOT NULL,
   `TargetId` int(11) NOT NULL,
   `PointId` int(11) NOT NULL,
   `SurveyingId` int(11) NOT NULL,
   `SurveyingTime` datetime NOT NULL,
   `Data1` decimal(18,6) NULL
 ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
 
 
 
 
 
 
 
 
 