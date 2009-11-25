-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.36-community-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema iaai
--

CREATE DATABASE IF NOT EXISTS iaai;
USE iaai;

--
-- Definition of table `alumno`
--

DROP TABLE IF EXISTS `alumno`;
CREATE TABLE `alumno` (
  `id_alumno` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `dni` int(8) unsigned NOT NULL,
  `fecha_nac` date NOT NULL,
  `telefono_carac` int(5) unsigned NOT NULL,
  `telefono_numero` int(9) unsigned NOT NULL,
  `escuela_nombre` varchar(100) NOT NULL,
  `escuela_año` int(1) unsigned NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `id_responsable` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id_alumno`) USING BTREE,
  KEY `FK_alumno_responsable` (`id_responsable`),
  CONSTRAINT `FK_alumno_responsable` FOREIGN KEY (`id_responsable`) REFERENCES `responsable` (`id_responsable`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `alumno`
--

/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;


--
-- Definition of table `profesor`
--

DROP TABLE IF EXISTS `profesor`;
CREATE TABLE `profesor` (
  `id_profesor` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `dni` int(8) unsigned NOT NULL,
  `telefono_carac` int(5) unsigned NOT NULL,
  `telefono_numero` int(9) unsigned NOT NULL,
  `fecha_nac` date NOT NULL DEFAULT '2000-01-01',
  `direccion` varchar(100) NOT NULL,
  PRIMARY KEY (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `profesor`
--

/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;


--
-- Definition of table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE `responsable` (
  `id_responsable` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre_respon` varchar(50) NOT NULL,
  `apellido_respon` varchar(50) NOT NULL,
  `fecha_nac` date NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `telefono_carac` int(5) unsigned NOT NULL,
  `telefono_numero` int(9) unsigned NOT NULL,
  PRIMARY KEY (`id_responsable`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `responsable`
--

/*!40000 ALTER TABLE `responsable` DISABLE KEYS */;
/*!40000 ALTER TABLE `responsable` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
