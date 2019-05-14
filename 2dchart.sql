-- phpMyAdmin SQL Dump
-- version 3.5.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 14, 2019 at 12:25 PM
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
  `Logo` text NOT NULL,
  `CreationDate` date NOT NULL,
  PRIMARY KEY (`ChartId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `cha_fun`
--

CREATE TABLE IF NOT EXISTS `cha_fun` (
  `ChaId` int(11) NOT NULL,
  `FunId` int(11) NOT NULL,
  KEY `FunId` (`FunId`),
  KEY `ChaId` (`ChaId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cha_rep`
--

CREATE TABLE IF NOT EXISTS `cha_rep` (
  `ChaId` int(11) NOT NULL,
  `RepId` int(11) NOT NULL,
  KEY `ChaId` (`ChaId`,`RepId`),
  KEY `RepId` (`RepId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `function`
--

CREATE TABLE IF NOT EXISTS `function` (
  `FunctionId` int(11) NOT NULL AUTO_INCREMENT,
  `Min` double NOT NULL,
  `Max` double NOT NULL,
  `Approximation` double NOT NULL,
  `Name` text NOT NULL,
  `CreationDate` date NOT NULL,
  PRIMARY KEY (`FunctionId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `fun_par`
--

CREATE TABLE IF NOT EXISTS `fun_par` (
  `FunId` int(11) NOT NULL,
  `ParId` int(11) NOT NULL,
  KEY `FunId` (`FunId`),
  KEY `ParId` (`ParId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `parameter`
--

CREATE TABLE IF NOT EXISTS `parameter` (
  `ParameterId` int(11) NOT NULL AUTO_INCREMENT,
  `Value` double NOT NULL,
  `Variable` text NOT NULL,
  PRIMARY KEY (`ParameterId`)
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
-- Constraints for table `cha_fun`
--
ALTER TABLE `cha_fun`
  ADD CONSTRAINT `cha_fun_ibfk_2` FOREIGN KEY (`FunId`) REFERENCES `function` (`FunctionId`),
  ADD CONSTRAINT `cha_fun_ibfk_1` FOREIGN KEY (`ChaId`) REFERENCES `chart` (`ChartId`);

--
-- Constraints for table `cha_rep`
--
ALTER TABLE `cha_rep`
  ADD CONSTRAINT `cha_rep_ibfk_2` FOREIGN KEY (`RepId`) REFERENCES `repository` (`RepositoryId`),
  ADD CONSTRAINT `cha_rep_ibfk_1` FOREIGN KEY (`ChaId`) REFERENCES `chart` (`ChartId`);

--
-- Constraints for table `fun_par`
--
ALTER TABLE `fun_par`
  ADD CONSTRAINT `fun_par_ibfk_2` FOREIGN KEY (`ParId`) REFERENCES `parameter` (`ParameterId`),
  ADD CONSTRAINT `fun_par_ibfk_1` FOREIGN KEY (`FunId`) REFERENCES `function` (`FunctionId`);

--
-- Constraints for table `use_rep`
--
ALTER TABLE `use_rep`
  ADD CONSTRAINT `use_rep_ibfk_2` FOREIGN KEY (`RepId`) REFERENCES `repository` (`RepositoryId`),
  ADD CONSTRAINT `use_rep_ibfk_1` FOREIGN KEY (`UseId`) REFERENCES `user` (`UserId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
