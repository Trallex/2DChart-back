-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: graphdb
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chart`
--

DROP TABLE IF EXISTS `chart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chart` (
  `ChartId` char(36) NOT NULL,
  `Logo` text NOT NULL,
  `CreationDate` date NOT NULL,
  `RepositoryId` char(36) NOT NULL,
  PRIMARY KEY (`ChartId`),
  KEY `chart_ibfk_1_idx` (`RepositoryId`),
  CONSTRAINT `chart_ibfk_1` FOREIGN KEY (`RepositoryId`) REFERENCES `repository` (`RepositoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chart`
--

LOCK TABLES `chart` WRITE;
/*!40000 ALTER TABLE `chart` DISABLE KEYS */;
/*!40000 ALTER TABLE `chart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `function`
--

DROP TABLE IF EXISTS `function`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `function` (
  `FunctionId` char(36) NOT NULL,
  `Min` double NOT NULL,
  `Max` double NOT NULL,
  `Approximation` double NOT NULL,
  `Name` text NOT NULL,
  `CreationDate` date NOT NULL,
  `ChartId` char(36) NOT NULL,
  PRIMARY KEY (`FunctionId`),
  KEY `function_ibfk_1_idx` (`ChartId`),
  CONSTRAINT `function_ibfk_1` FOREIGN KEY (`ChartId`) REFERENCES `chart` (`ChartId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `function`
--

LOCK TABLES `function` WRITE;
/*!40000 ALTER TABLE `function` DISABLE KEYS */;
/*!40000 ALTER TABLE `function` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parameter`
--

DROP TABLE IF EXISTS `parameter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `parameter` (
  `ParameterId` char(36) NOT NULL,
  `Value` double NOT NULL,
  `Variable` text NOT NULL,
  `FunctionId` char(36) NOT NULL,
  PRIMARY KEY (`ParameterId`),
  KEY `parameter_ibfk_1_idx` (`FunctionId`),
  CONSTRAINT `parameter_ibfk_1` FOREIGN KEY (`FunctionId`) REFERENCES `function` (`FunctionId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parameter`
--

LOCK TABLES `parameter` WRITE;
/*!40000 ALTER TABLE `parameter` DISABLE KEYS */;
/*!40000 ALTER TABLE `parameter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repository`
--

DROP TABLE IF EXISTS `repository`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `repository` (
  `RepositoryId` char(36) NOT NULL,
  `Name` text NOT NULL,
  `Description` text NOT NULL,
  `CreationDate` date NOT NULL,
  PRIMARY KEY (`RepositoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repository`
--

LOCK TABLES `repository` WRITE;
/*!40000 ALTER TABLE `repository` DISABLE KEYS */;
/*!40000 ALTER TABLE `repository` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `use_rep`
--

DROP TABLE IF EXISTS `use_rep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `use_rep` (
  `UseId` char(36) NOT NULL,
  `RepId` char(36) NOT NULL,
  `IsOwner` tinyint(1) NOT NULL,
  PRIMARY KEY (`UseId`,`RepId`),
  KEY `UseId` (`UseId`),
  KEY `RepId` (`RepId`),
  CONSTRAINT `use_rep_ibfk_1` FOREIGN KEY (`UseId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `use_rep_ibfk_2` FOREIGN KEY (`RepId`) REFERENCES `repository` (`RepositoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `use_rep`
--

LOCK TABLES `use_rep` WRITE;
/*!40000 ALTER TABLE `use_rep` DISABLE KEYS */;
/*!40000 ALTER TABLE `use_rep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user` (
  `UserId` char(36) NOT NULL,
  `Name` text NOT NULL,
  `Mail` text NOT NULL,
  `PasswordHash` varbinary(64) NOT NULL,
  `PasswordSalt` varbinary(128) NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('08d6d939-fb82-d7ce-a8ad-a6b3410df452','root','admin@adminakademia.pl',_binary '¸f±·\Î}HH;Eý\Ë\Õ_›R	>£[\ê½\n6§$Ú¼w\ÌMg«C®\Æ\ÕN®®bs\èw›ü®­*–‘ô',_binary 'u¹2!iž`\Â\nOG3TŽU^Pÿ\çz¢²9šŸ`\î!ý)Y\í`X!\Æñ³–H}“\'4z\åaÍ¸…p•›\Î8ÿE4:•Â–¶Žx\Ì\ëC\Ù\à\Ì\0\î\æ\ç)SA\Ô?rCo¤\Èû(%$‰KÄ\ß\Õ^µ²\Õ?FÈ‘\\¥¼');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-30 21:52:28
