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
  PRIMARY KEY (`id_alumno`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `alumno`
--

/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` (`id_alumno`,`nombre`,`apellido`,`dni`,`fecha_nac`,`telefono_carac`,`telefono_numero`,`escuela_nombre`,`escuela_año`,`direccion`,`id_responsable`) VALUES 
 (3,'Nico','Nicolas','30501831','1891-12-01','0','2222','',0,'asdf 123',0),
 (4,'Matías','Milesi','31065760','1984-06-28','0','4550871','',0,'Pedro Ferré 1143',0);
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;


--
-- Definition of table `asistencia_profesor_curso`
--

DROP TABLE IF EXISTS `asistencia_profesor_curso`;
CREATE TABLE `asistencia_profesor_curso` (
  `id_asistencia_profesor` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_curso` int(10) unsigned NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `fecha` date NOT NULL,
  `hora_ingreso` time NOT NULL,
  `hora_egreso` time NOT NULL,
  PRIMARY KEY (`id_asistencia_profesor`),
  KEY `FK_asistencia_profesor_curso` (`id_profesor`),
  KEY `FK_asistencia_curso` (`id_curso`),
  CONSTRAINT `FK_asistencia_curso` FOREIGN KEY (`id_curso`) REFERENCES `curso` (`id_curso`),
  CONSTRAINT `FK_asistencia_profesor_curso` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `asistencia_profesor_curso`
--

/*!40000 ALTER TABLE `asistencia_profesor_curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `asistencia_profesor_curso` ENABLE KEYS */;


--
-- Definition of table `asistencia_profesor_curso_especial`
--

DROP TABLE IF EXISTS `asistencia_profesor_curso_especial`;
CREATE TABLE `asistencia_profesor_curso_especial` (
  `id_asistencia_curso_especial` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_curso_especial` int(10) unsigned NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `fecha` date NOT NULL,
  `hora_ingreso` time NOT NULL,
  `hora_egreso` time NOT NULL,
  PRIMARY KEY (`id_asistencia_curso_especial`),
  KEY `FK_asistencia_curso_esp` (`id_curso_especial`),
  KEY `FK_asist_prof_cur_esp` (`id_profesor`),
  CONSTRAINT `FK_asistencia_curso_esp` FOREIGN KEY (`id_curso_especial`) REFERENCES `curso_especial` (`id_curso_especial`),
  CONSTRAINT `FK_asist_prof_cur_esp` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `asistencia_profesor_curso_especial`
--

/*!40000 ALTER TABLE `asistencia_profesor_curso_especial` DISABLE KEYS */;
/*!40000 ALTER TABLE `asistencia_profesor_curso_especial` ENABLE KEYS */;


--
-- Definition of table `asistencia_profesor_materia`
--

DROP TABLE IF EXISTS `asistencia_profesor_materia`;
CREATE TABLE `asistencia_profesor_materia` (
  `id_asistencia_profesor_materia` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_materia` int(10) unsigned NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `fecha` date NOT NULL,
  `hora_ingreso` time NOT NULL,
  `hora_egreso` time NOT NULL,
  PRIMARY KEY (`id_asistencia_profesor_materia`),
  KEY `FK_asistencia_materia` (`id_materia`),
  KEY `FK_asistencia_profesor_materia` (`id_profesor`),
  CONSTRAINT `FK_asistencia_materia` FOREIGN KEY (`id_materia`) REFERENCES `materia` (`id_materia`),
  CONSTRAINT `FK_asistencia_profesor_materia` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `asistencia_profesor_materia`
--

/*!40000 ALTER TABLE `asistencia_profesor_materia` DISABLE KEYS */;
/*!40000 ALTER TABLE `asistencia_profesor_materia` ENABLE KEYS */;


--
-- Definition of table `curso`
--

DROP TABLE IF EXISTS `curso`;
CREATE TABLE `curso` (
  `id_curso` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) CHARACTER SET latin1 NOT NULL,
  `nivel` int(10) unsigned NOT NULL,
  `duracion` int(10) unsigned NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `cupo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_curso`),
  KEY `FK_curso_profesor` (`id_profesor`),
  CONSTRAINT `FK_curso_profesor` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `curso`
--

/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;


--
-- Definition of table `curso_especial`
--

DROP TABLE IF EXISTS `curso_especial`;
CREATE TABLE `curso_especial` (
  `id_curso_especial` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `horas_curso` time NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `cupo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_curso_especial`),
  KEY `FK_curso_especial_profesor` (`id_profesor`),
  CONSTRAINT `FK_curso_especial_profesor` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `curso_especial`
--

/*!40000 ALTER TABLE `curso_especial` DISABLE KEYS */;
/*!40000 ALTER TABLE `curso_especial` ENABLE KEYS */;


--
-- Definition of table `materia`
--

DROP TABLE IF EXISTS `materia`;
CREATE TABLE `materia` (
  `id_materia` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_profesorado` int(10) unsigned NOT NULL,
  `nivel` int(10) unsigned NOT NULL,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`id_materia`,`id_profesorado`) USING BTREE,
  KEY `FK_materia_carrera` (`id_profesorado`) USING BTREE,
  CONSTRAINT `FK_materia_profesorado` FOREIGN KEY (`id_profesorado`) REFERENCES `profesorado` (`id_profesorado`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `materia`
--

/*!40000 ALTER TABLE `materia` DISABLE KEYS */;
INSERT INTO `materia` (`id_materia`,`id_profesorado`,`nivel`,`nombre`) VALUES 
 (1,1,1,'LENGUA INGLESA I'),
 (2,1,1,'GRAMÁTICA INGLESA II'),
 (3,1,2,'LENGUA INGLESA II'),
 (4,1,2,'TEORÍA Y PRÁCTICA DE LA TRADUCCIÓN'),
 (5,1,2,'FONOLOGÍA II PRÁCTICA DE LABORATORIO ');
/*!40000 ALTER TABLE `materia` ENABLE KEYS */;


--
-- Definition of table `matricula`
--

DROP TABLE IF EXISTS `matricula`;
CREATE TABLE `matricula` (
  `id_matricula` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_profesorado` int(10) unsigned NOT NULL DEFAULT '0',
  `id_alumno` int(10) unsigned NOT NULL,
  `id_curso` int(10) unsigned NOT NULL DEFAULT '0',
  `id_curso_especial` int(10) unsigned NOT NULL DEFAULT '0',
  `condicion` varchar(15) DEFAULT 'condicional',
  PRIMARY KEY (`id_matricula`,`id_profesorado`,`id_curso`,`id_curso_especial`) USING BTREE,
  KEY `FK_matricula_alumno` (`id_alumno`),
  KEY `FK_matricula_cur_esp` (`id_curso_especial`),
  KEY `FK_matricula_carrera` (`id_profesorado`) USING BTREE,
  KEY `FK_matricula_curso` (`id_curso`),
  CONSTRAINT `FK_matricula_profesorado` FOREIGN KEY (`id_profesorado`) REFERENCES `profesorado` (`id_profesorado`),
  CONSTRAINT `FK_matricula_curso` FOREIGN KEY (`id_curso`) REFERENCES `curso` (`id_curso`),
  CONSTRAINT `FK_matricula_alumno` FOREIGN KEY (`id_alumno`) REFERENCES `alumno` (`id_alumno`),
  CONSTRAINT `FK_matricula_cur_esp` FOREIGN KEY (`id_curso_especial`) REFERENCES `curso_especial` (`id_curso_especial`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `matricula`
--

/*!40000 ALTER TABLE `matricula` DISABLE KEYS */;
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
INSERT INTO `nivel` (`nivel`,`nombre`) VALUES 
 (1,'inicial'),
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
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesor`
--

/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` (`id_profesor`,`nombre`,`apellido`,`dni`,`telefono_carac`,`telefono_numero`,`fecha_nac`,`direccion`,`email`,`activo`) VALUES 
 (1,'tito','chipolatti','12345678','789','963','1980-09-25','asdf','',1),
 (8,'juan','perez','45678912','342','156122789','2008-11-20','25 de mayo','perezjuan@hotmail.com',1),
 (10,'pedrito','guanca','32165487','342','156154789','1978-12-15','San Jeronimo','pedrito@gmail.com',1),
 (39,'Diego','Iriarte','32165498','342','156122745','1986-05-01','Obispo Gelabert 2856 5ªB','diegoiriarte_18@hotmail.com',1),
 (40,'jose','Iriarte','12345675M','1234','123456789','1980-12-25','urquiza 324','j@j.com',1),
 (41,'jose','iriartes','45673213M','123','12344','1980-08-25','qwe 123','jo@jo.com',1),
 (42,'josefina','irialorna','23456738F','123','124533','1980-12-23','asdaf 3','j@j.com',1),
 (43,'roberto','perezuti','03457635','123','312455','1975-08-13','peraez 1234','roberto@peraez.com.ar',1),
 (49,'nombre_modificado','apellido_prueba','11111111M','342','123456','2000-01-01','San martin 314 7º B','prueba@prueba.com',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesorado`
--

/*!40000 ALTER TABLE `profesorado` DISABLE KEYS */;
INSERT INTO `profesorado` (`id_profesorado`,`nombre`,`niveles`) VALUES 
 (1,'Traductorado',5),
 (2,'Profesorado Ingles',4);
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
  PRIMARY KEY (`id_responsable`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `responsable`
--

/*!40000 ALTER TABLE `responsable` DISABLE KEYS */;
INSERT INTO `responsable` (`id_responsable`,`nombre_respon`,`apellido_respon`,`fecha_nac`,`direccion`,`telefono_carac`,`telefono_numero`,`dni`) VALUES 
 (1,'Nicolas','Mizerniuk','1111-11-11','aaaaaa 1111',0,111111,30501831);
/*!40000 ALTER TABLE `responsable` ENABLE KEYS */;


--
-- Definition of table `turno`
--

DROP TABLE IF EXISTS `turno`;
CREATE TABLE `turno` (
  `id_turno` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_profesor` int(10) unsigned NOT NULL,
  `turno` varchar(15) NOT NULL,
  `cupo` int(10) unsigned NOT NULL,
  `id_materia` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_turno`,`id_materia`) USING BTREE,
  KEY `FK_turno_materia` (`id_materia`),
  CONSTRAINT `FK_turno_materia` FOREIGN KEY (`id_materia`) REFERENCES `materia` (`id_materia`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `turno`
--

/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
INSERT INTO `turno` (`id_turno`,`id_profesor`,`turno`,`cupo`,`id_materia`) VALUES 
 (1,1,'mañana',25,1),
 (2,1,'tarde',30,2),
 (3,41,'mañana',25,3),
 (4,41,'tarde',30,4),
 (5,43,'mañana',25,5),
 (6,42,'noche',25,3);
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
