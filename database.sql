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
-- Table structure for table `cha_fun`
--

DROP TABLE IF EXISTS `cha_fun`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cha_fun` (
  `ChaId` char(36) NOT NULL,
  `FunId` char(36) NOT NULL,
  PRIMARY KEY (`ChaId`,`FunId`),
  KEY `FunId` (`FunId`),
  KEY `ChaId` (`ChaId`),
  CONSTRAINT `cha_fun_ibfk_1` FOREIGN KEY (`ChaId`) REFERENCES `chart` (`ChartId`),
  CONSTRAINT `cha_fun_ibfk_2` FOREIGN KEY (`FunId`) REFERENCES `function` (`FunctionId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cha_fun`
--

LOCK TABLES `cha_fun` WRITE;
/*!40000 ALTER TABLE `cha_fun` DISABLE KEYS */;
/*!40000 ALTER TABLE `cha_fun` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cha_rep`
--

DROP TABLE IF EXISTS `cha_rep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cha_rep` (
  `ChaId` char(36) NOT NULL,
  `RepId` char(36) NOT NULL,
  PRIMARY KEY (`ChaId`,`RepId`),
  KEY `ChaId` (`ChaId`,`RepId`),
  KEY `RepId` (`RepId`),
  CONSTRAINT `cha_rep_ibfk_1` FOREIGN KEY (`ChaId`) REFERENCES `chart` (`ChartId`),
  CONSTRAINT `cha_rep_ibfk_2` FOREIGN KEY (`RepId`) REFERENCES `repository` (`RepositoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cha_rep`
--

LOCK TABLES `cha_rep` WRITE;
/*!40000 ALTER TABLE `cha_rep` DISABLE KEYS */;
/*!40000 ALTER TABLE `cha_rep` ENABLE KEYS */;
UNLOCK TABLES;

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
  PRIMARY KEY (`ChartId`)
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
-- Table structure for table `fun_par`
--

DROP TABLE IF EXISTS `fun_par`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `fun_par` (
  `FunId` char(36) NOT NULL,
  `ParId` char(36) NOT NULL,
  PRIMARY KEY (`FunId`,`ParId`),
  KEY `FunId` (`FunId`),
  KEY `ParId` (`ParId`),
  CONSTRAINT `fun_par_ibfk_1` FOREIGN KEY (`FunId`) REFERENCES `function` (`FunctionId`),
  CONSTRAINT `fun_par_ibfk_2` FOREIGN KEY (`ParId`) REFERENCES `parameter` (`ParameterId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fun_par`
--

LOCK TABLES `fun_par` WRITE;
/*!40000 ALTER TABLE `fun_par` DISABLE KEYS */;
/*!40000 ALTER TABLE `fun_par` ENABLE KEYS */;
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
  PRIMARY KEY (`FunctionId`)
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
  PRIMARY KEY (`ParameterId`)
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

-- Dump completed on 2019-05-17 14:54:58
