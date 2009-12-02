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
  `dni` varchar(9) NOT NULL,
  `fecha_nac` date NOT NULL,
  `telefono_carac` varchar(5) DEFAULT NULL,
  `telefono_numero` varchar(9) NOT NULL,
  `escuela_nombre` varchar(100) DEFAULT NULL,
  `escuela_año` int(1) unsigned DEFAULT NULL,
  `direccion` varchar(100) NOT NULL,
  `id_responsable` int(10) unsigned DEFAULT NULL,
  `activo` tinyint(1) unsigned DEFAULT '1',
  PRIMARY KEY (`id_alumno`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `alumno`
--

/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES  (3,'Nico','Nicolas','30501831','1983-11-06','0','2222','',0,'asdf 123',0,1),
 (4,'Matías','Milesi','31065760','1984-06-28','0','4550871','',0,'Pedro Ferré 1143',0,1),
 (5,'Marcos','Milesi','11111111','1989-11-18','0','4550871','',0,'pedro ferre 1143',2,0);
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;


--
-- Definition of table `curso`
--

DROP TABLE IF EXISTS `curso`;
CREATE TABLE `curso` (
  `id_curso` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) CHARACTER SET latin1 NOT NULL,
  `nivel` int(10) unsigned NOT NULL,
  `duracion` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_curso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `curso`
--

/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;


--
-- Definition of table `materia`
--

DROP TABLE IF EXISTS `materia`;
CREATE TABLE `materia` (
  `id_materia` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_profesorado` int(10) unsigned NOT NULL,
  `nivel` int(10) unsigned NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `cupo` int(10) unsigned NOT NULL,
  `turno` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_materia`,`id_profesorado`) USING BTREE,
  KEY `FK_materia_carrera` (`id_profesorado`) USING BTREE,
  CONSTRAINT `FK_materia_profesorado` FOREIGN KEY (`id_profesorado`) REFERENCES `profesorado` (`id_profesorado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `materia`
--

/*!40000 ALTER TABLE `materia` DISABLE KEYS */;
/*!40000 ALTER TABLE `materia` ENABLE KEYS */;


--
-- Definition of table `matricula`
--

DROP TABLE IF EXISTS `matricula`;
CREATE TABLE `matricula` (
  `id_matricula` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_carrera` int(10) unsigned DEFAULT NULL,
  `id_alumno` int(10) unsigned NOT NULL,
  `id_curso` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id_matricula`),
  KEY `FK_matricula_alumno` (`id_alumno`),
  KEY `FK_matricula_carrera` (`id_carrera`),
  CONSTRAINT `FK_matricula_alumno` FOREIGN KEY (`id_alumno`) REFERENCES `alumno` (`id_alumno`),
  CONSTRAINT `FK_matricula_carrera` FOREIGN KEY (`id_carrera`) REFERENCES `carrera` (`id_carrera`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `matricula`
--

/*!40000 ALTER TABLE `matricula` DISABLE KEYS */;
INSERT INTO `matricula` VALUES  (1,NULL,3,NULL),
 (2,NULL,4,NULL),
 (3,NULL,5,NULL);
/*!40000 ALTER TABLE `matricula` ENABLE KEYS */;


--
-- Definition of table `nivel`
--

DROP TABLE IF EXISTS `nivel`;
CREATE TABLE `nivel` (
  `nivel` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`nivel`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nivel`
--

/*!40000 ALTER TABLE `nivel` DISABLE KEYS */;
INSERT INTO `nivel` VALUES  (1,'inicial'),
 (2,'intermedio'),
 (3,'especialización');
/*!40000 ALTER TABLE `nivel` ENABLE KEYS */;


--
-- Definition of table `profesor`
--

DROP TABLE IF EXISTS `profesor`;
CREATE TABLE `profesor` (
  `id_profesor` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) CHARACTER SET latin1 NOT NULL,
  `apellido` varchar(50) CHARACTER SET latin1 NOT NULL,
  `dni` varchar(9) NOT NULL,
  `telefono_carac` varchar(5) NOT NULL,
  `telefono_numero` varchar(9) NOT NULL,
  `fecha_nac` date NOT NULL DEFAULT '2000-01-01',
  `direccion` varchar(100) CHARACTER SET latin1 NOT NULL,
  `email` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id_profesor`,`dni`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesor`
--

/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES  (1,'tito','chipolatti','12345678','789','963','1980-09-25','asdf','',0),
 (8,'juan','perez','45678912','342','156122789','2008-11-20','25 de mayo','perezjuan@hotmail.com',0),
 (10,'pedrito','guanca','32165487','342','156154789','1978-12-15','San Jeronimo','pedrito@gmail.com',0),
 (38,'nombre_prueba','apellido_prueba','11111111M','342','123456','1981-12-01','San martin 314 7º B','prueba@prueba.com',1),
 (39,'Diego','Iriarte','32165498','342','156122745','1986-05-01','Obispo Gelabert 2856 5ªB','diegoiriarte_18@hotmail.com',1);
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;


--
-- Definition of table `profesorado`
--

DROP TABLE IF EXISTS `profesorado`;
CREATE TABLE `profesorado` (
  `id_profesorado` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) CHARACTER SET latin1 NOT NULL,
  `niveles` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_profesorado`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesorado`
--

/*!40000 ALTER TABLE `profesorado` DISABLE KEYS */;
/*!40000 ALTER TABLE `profesorado` ENABLE KEYS */;


--
-- Definition of table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE `responsable` (
  `id_responsable` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre_respon` varchar(50) CHARACTER SET latin1 NOT NULL,
  `apellido_respon` varchar(50) CHARACTER SET latin1 NOT NULL,
  `fecha_nac` date NOT NULL,
  `direccion` varchar(100) CHARACTER SET latin1 NOT NULL,
  `telefono_carac` int(5) unsigned DEFAULT NULL,
  `telefono_numero` int(9) unsigned NOT NULL,
  `dni` int(8) unsigned NOT NULL,
  `activo` tinyint(1) unsigned DEFAULT '1',
  PRIMARY KEY (`id_responsable`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `responsable`
--

/*!40000 ALTER TABLE `responsable` DISABLE KEYS */;
INSERT INTO `responsable` VALUES  (1,'Nicolas','Mizerniuk','1111-11-11','aaaaaa 1111',0,111111,30501831,1),
 (2,'Otro','Mas responsable','1950-11-11','dire',342,123456,22222222,1);
/*!40000 ALTER TABLE `responsable` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
