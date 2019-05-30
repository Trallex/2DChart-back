-- phpMyAdmin SQL Dump
-- version 3.5.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 30, 2019 at 09:20 PM
-- Server version: 5.5.21-log
-- PHP Version: 5.3.20

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `2dchart`
--

-- --------------------------------------------------------

--
-- Table structure for table `chart`
--

CREATE TABLE IF NOT EXISTS `chart` (
  `ChartId` int(11) NOT NULL AUTO_INCREMENT,
  `RepositoryId` int(11) NOT NULL,
  `Logo` text NOT NULL,
  `CreationDate` date NOT NULL,
  PRIMARY KEY (`ChartId`),
  KEY `RepositoryId` (`RepositoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `function`
--

CREATE TABLE IF NOT EXISTS `function` (
  `FunctionId` int(11) NOT NULL AUTO_INCREMENT,
  `ChartId` int(11) NOT NULL,
  `Min` double NOT NULL,
  `Max` double NOT NULL,
  `Approximation` double NOT NULL,
  `Name` text NOT NULL,
  `CreationDate` date NOT NULL,
  PRIMARY KEY (`FunctionId`),
  KEY `ChartId` (`ChartId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `parameter`
--

CREATE TABLE IF NOT EXISTS `parameter` (
  `ParameterId` int(11) NOT NULL AUTO_INCREMENT,
  `FunctionId` int(11) NOT NULL,
  `Value` double NOT NULL,
  `Variable` text NOT NULL,
  PRIMARY KEY (`ParameterId`),
  KEY `FunctionId` (`FunctionId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `repository`
--

CREATE TABLE IF NOT EXISTS `repository` (
  `RepositoryId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Description` text NOT NULL,
  `CreationDate` date NOT NULL,
  PRIMARY KEY (`RepositoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Mail` text NOT NULL,
  `Password` text NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `use_rep`
--

CREATE TABLE IF NOT EXISTS `use_rep` (
  `UseId` int(11) NOT NULL,
  `RepId` int(11) NOT NULL,
  `IsOwner` tinyint(1) NOT NULL,
  KEY `UseId` (`UseId`),
  KEY `RepId` (`RepId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chart`
--
ALTER TABLE `chart`
  ADD CONSTRAINT `chart_ibfk_1` FOREIGN KEY (`RepositoryId`) REFERENCES `repository` (`RepositoryId`);

--
-- Constraints for table `function`
--
ALTER TABLE `function`
  ADD CONSTRAINT `function_ibfk_1` FOREIGN KEY (`ChartId`) REFERENCES `chart` (`ChartId`);

--
-- Constraints for table `parameter`
--
ALTER TABLE `parameter`
  ADD CONSTRAINT `parameter_ibfk_1` FOREIGN KEY (`FunctionId`) REFERENCES `function` (`FunctionId`);

--
-- Constraints for table `use_rep`
--
ALTER TABLE `use_rep`
  ADD CONSTRAINT `use_rep_ibfk_1` FOREIGN KEY (`UseId`) REFERENCES `user` (`UserId`),
  ADD CONSTRAINT `use_rep_ibfk_2` FOREIGN KEY (`RepId`) REFERENCES `repository` (`RepositoryId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
