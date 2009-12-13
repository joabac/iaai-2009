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
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_alumno`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `alumno`
--

/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES  (3,'Nico','Nicolas','30501831','1891-12-01','0','2222','',0,'asdf 123',0,1,NULL),
 (4,'Matías','Milesi','31065760','1984-06-28','0','4550871','',0,'Pedro Ferré 1143',0,1,NULL),
 (5,'Diego','Iriarte','28956734','1981-05-25','1234','123454','',0,'Obispo 345',0,1,NULL),
 (9,'juan','perez','12345674','1980-12-25','1234','45673','',0,'pazo 1234',0,1,NULL),
 (10,'juan','calvo','33333333','2000-11-11','','4343434','',0,'ads 34',1,1,NULL),
 (11,'moncho','aranda','66666666','2000-11-11','','3434344','',0,'lkñlkj 444',1,1,NULL),
 (12,'omar','prieto','55555555','1985-11-11','','334343','',0,'ñlj 33',0,1,'pirucho@gmail.com'),
 (13,'manuel','mendez','88888888','1983-11-11','','334322','',0,'dlfk3  33 ',0,1,NULL),
 (14,'martin','consta','16232323','2000-11-11','','32323','',0,'lj2l3j23',22,1,NULL),
 (15,'marti','caso','83838383','2000-11-11','','3423232','',0,'ñlkjdj',23,1,NULL),
 (16,'luis','quinta','82322322','2000-11-11','','322323','',0,'ñldfj',26,1,NULL),
 (17,'pepito','andrada','34443344','2000-11-22','','23432432','',0,'ljljdf',27,1,NULL);
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;


--
-- Definition of table `area`
--

DROP TABLE IF EXISTS `area`;
CREATE TABLE `area` (
  `id_area` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id_area`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `area`
--

/*!40000 ALTER TABLE `area` DISABLE KEYS */;
INSERT INTO `area` VALUES  (1,'Idioma'),
 (2,'Arte'),
 (3,'Danza');
/*!40000 ALTER TABLE `area` ENABLE KEYS */;


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
  `id_area` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_curso`),
  KEY `FK_curso_profesor` (`id_profesor`),
  CONSTRAINT `FK_curso_profesor` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `curso`
--

/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
INSERT INTO `curso` VALUES  (1,'Inglés Inicial',1,3,1,15,1),
 (2,'Inglés Medio',2,3,40,15,1),
 (3,'Inglés Especiallización',3,2,41,15,1),
 (4,'Francés Inicial',1,3,42,15,1),
 (5,'Francés Medio',2,3,3,15,1),
 (6,'Francés Especialización',3,2,3,15,1),
 (7,'Portugués Inicial',1,3,4,15,1),
 (8,'Portugués Medio',2,3,5,15,1),
 (9,'Portugués Especialización',3,2,6,15,1),
 (10,'Artes Visuales Inicial',1,3,7,25,2),
 (11,'Artes Visuales Especialización',3,6,8,25,2),
 (12,'Danzas Clá¡sicas Inicial',1,3,9,25,3),
 (13,'Danzas Clá¡sicas Especialización',3,6,9,25,3),
 (14,'Danzas Españolas Inicial',1,3,10,25,3),
 (15,'Danzas Españolas Especialización',3,6,10,25,3),
 (16,'Danzas Folkloricas Inicial',1,3,11,25,3),
 (17,'Danzas Folkloricas Especialización',3,6,11,25,3);
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;


--
-- Definition of table `curso_especial`
--

DROP TABLE IF EXISTS `curso_especial`;
CREATE TABLE `curso_especial` (
  `id_curso_especial` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `horas_curso` int(10) unsigned NOT NULL,
  `id_profesor` int(10) unsigned NOT NULL,
  `cupo` int(10) unsigned NOT NULL,
  `id_area` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_curso_especial`),
  KEY `FK_curso_especial_profesor` (`id_profesor`),
  CONSTRAINT `FK_curso_especial_profesor` FOREIGN KEY (`id_profesor`) REFERENCES `profesor` (`id_profesor`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `curso_especial`
--

/*!40000 ALTER TABLE `curso_especial` DISABLE KEYS */;
INSERT INTO `curso_especial` VALUES  (1,'Ingles Tecnico (Medicina)',50,40,25,1),
 (2,'Ingles Tecnico (Leyes)',60,40,20,1),
 (3,'Pintura al oleo',250,10,5,2),
 (4,'Grabado en Madera',150,41,1,2);
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
INSERT INTO `materia` VALUES  (1,1,1,'LENGUA INGLESA I'),
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
  PRIMARY KEY (`id_matricula`,`id_profesorado`,`id_curso`,`id_curso_especial`) USING BTREE,
  KEY `FK_matricula_alumno` (`id_alumno`),
  KEY `FK_matricula_cur_esp` (`id_curso_especial`),
  KEY `FK_matricula_carrera` (`id_profesorado`) USING BTREE,
  KEY `FK_matricula_curso` (`id_curso`),
  CONSTRAINT `FK_matricula_alumno` FOREIGN KEY (`id_alumno`) REFERENCES `alumno` (`id_alumno`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `matricula`
--

/*!40000 ALTER TABLE `matricula` DISABLE KEYS */;
INSERT INTO `matricula` VALUES  (8,1,3,0,0),
 (14,0,3,0,3),
 (15,0,3,0,4),
 (16,0,3,0,2),
 (17,0,3,0,1),
 (3,1,5,0,0),
 (18,0,5,0,3),
 (30,0,5,0,4),
 (34,0,5,0,1),
 (40,0,5,4,0),
 (41,0,5,7,0),
 (35,0,9,0,3),
 (37,0,9,0,4),
 (38,0,9,0,1),
 (39,0,9,0,2);
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
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profesor`
--

/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES  (1,'tito','chipolatti','12345678','789','963','1980-09-25','asdf','',1),
 (3,'Miguel','Austur','65498745','342','456987','1977-02-03','9 de Julio 4567','tito@tito.com',1),
 (4,'Julio','Peter','32165496','342','456321','1975-05-06','1 de Mayo 9875','pipo@pipo.com',1),
 (5,'Arturo','Beacon','65198848','342','423651','1960-05-04','4 de Enero 6541','arturo@arturo.com',1),
 (6,'Diego','Mito','21365498','342','426584','1955-05-08','Urquiza 6548','mic@mic.com',1),
 (7,'Pedro','Picap','21654987','342','436598','1968-06-08','Saavedra 9875','tit@tit.com',1),
 (8,'juan','perez','45678912','342','156122789','2008-11-20','25 de mayo','perezjuan@hotmail.com',1),
 (9,'Nicolas','Tituo','11654987','342','433335','1965-09-05','San Lorenzo 456','yiy@yiy.com',1),
 (10,'pedrito','guanca','32165487','342','156154789','1978-12-15','San Jeronimo','pedrito@gmail.com',1),
 (11,'Augusto','Ramos','11654987','343','432659','1981-08-09','Francia 987','pop@pop.com',1),
 (12,'Mirta','Flores','12654987','343','456987','1982-08-01','Rivadavia 852','pip@pip.com',1),
 (13,'Zulma','Lobat','13654987','342','456789','1980-08-05','Marcial Candioti 852','tit@tit.com',1),
 (14,'Susana','Romero','14654856','342','456853','1979-05-07','Catamarca 845','tut@tut.com',1),
 (39,'Diego','Iriarte','32165498','342','156122745','1986-05-01','Obispo Gelabert 2856 5ÂªB','diegoiriarte_18@hotmail.com',1),
 (40,'jose','Iriarte','12345675M','1234','123456789','1980-12-25','urquiza 324','j@j.com',1),
 (41,'jose','iriartes','45673213M','123','12344','1980-08-25','qwe 123','jo@jo.com',1),
 (42,'josefina','irialorna','23456738F','123','124533','1980-12-23','asdaf 3','j@j.com',1),
 (75,'nombre_modificado','apellido_prueba','11111111M','342','123456','2000-01-01','San martin 314 7º B','prueba@prueba.com',1);
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
INSERT INTO `profesorado` VALUES  (1,'Traductorado',5),
 (2,'Profesorado Ingles',4);
/*!40000 ALTER TABLE `profesorado` ENABLE KEYS */;


--
-- Definition of table `registro_curso`
--

DROP TABLE IF EXISTS `registro_curso`;
CREATE TABLE `registro_curso` (
  `id_registro_curso` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_matricula` int(10) unsigned NOT NULL,
  `id_curso` int(10) unsigned NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `condicion` varchar(45) NOT NULL DEFAULT 'condicional',
  PRIMARY KEY (`id_registro_curso`),
  KEY `FK_registro_curso_matricula` (`id_matricula`),
  CONSTRAINT `FK_registro_curso_matricula` FOREIGN KEY (`id_matricula`) REFERENCES `matricula` (`id_matricula`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `registro_curso`
--

/*!40000 ALTER TABLE `registro_curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `registro_curso` ENABLE KEYS */;


--
-- Definition of table `registro_curso_especial`
--

DROP TABLE IF EXISTS `registro_curso_especial`;
CREATE TABLE `registro_curso_especial` (
  `id_registro_curso_especial` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_matricula` int(10) unsigned NOT NULL,
  `id_curso_especial` int(10) unsigned NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `condicion` varchar(45) NOT NULL DEFAULT 'condicional',
  PRIMARY KEY (`id_registro_curso_especial`),
  KEY `FK_reg_curso_esp_matricula` (`id_matricula`),
  CONSTRAINT `FK_reg_curso_esp_matricula` FOREIGN KEY (`id_matricula`) REFERENCES `matricula` (`id_matricula`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `registro_curso_especial`
--

/*!40000 ALTER TABLE `registro_curso_especial` DISABLE KEYS */;
INSERT INTO `registro_curso_especial` VALUES  (2,14,3,'2009-12-07','23:33:03','inscripto'),
 (3,15,4,'2009-12-07','23:55:10','inscripto'),
 (4,16,2,'2009-12-08','00:02:54','inscripto'),
 (5,17,1,'2009-12-08','00:04:23','inscripto'),
 (6,18,3,'2009-12-08','00:20:18','inscripto'),
 (8,30,4,'2009-12-08','00:46:14','condicional'),
 (9,34,1,'2009-12-08','01:32:07','inscripto'),
 (10,35,3,'2009-12-08','08:40:56','inscripto'),
 (11,37,4,'2009-12-08','08:51:42','condicional'),
 (12,38,1,'2009-12-08','08:52:07','inscripto'),
 (13,39,2,'2009-12-08','08:52:07','inscripto');
/*!40000 ALTER TABLE `registro_curso_especial` ENABLE KEYS */;


--
-- Definition of table `registro_materia`
--

DROP TABLE IF EXISTS `registro_materia`;
CREATE TABLE `registro_materia` (
  `id_inscripcion_materia` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_matricula` int(10) unsigned NOT NULL,
  `id_materia` int(10) unsigned NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `id_turno` int(10) unsigned NOT NULL,
  `regular` tinyint(1) NOT NULL DEFAULT '0',
  `aprobada` tinyint(1) NOT NULL DEFAULT '0',
  `libre` tinyint(1) NOT NULL DEFAULT '0',
  `condicion` varchar(45) NOT NULL DEFAULT 'condicional',
  PRIMARY KEY (`id_inscripcion_materia`),
  KEY `FK_insc_mat_matricula` (`id_matricula`),
  KEY `FK_insc_mat_materia` (`id_materia`),
  KEY `FK_insc_mat_turno` (`id_turno`,`id_materia`),
  CONSTRAINT `FK_insc_mat_materia` FOREIGN KEY (`id_materia`) REFERENCES `materia` (`id_materia`),
  CONSTRAINT `FK_insc_mat_matricula` FOREIGN KEY (`id_matricula`) REFERENCES `matricula` (`id_matricula`),
  CONSTRAINT `FK_insc_mat_turno` FOREIGN KEY (`id_turno`, `id_materia`) REFERENCES `turno` (`id_turno`, `id_materia`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `registro_materia`
--

/*!40000 ALTER TABLE `registro_materia` DISABLE KEYS */;
INSERT INTO `registro_materia` VALUES  (39,3,3,'2009-12-07','05:51:00',3,0,0,0,'inscripto'),
 (40,3,5,'2009-12-07','05:51:00',5,0,0,0,'inscripto'),
 (42,8,5,'2009-12-08','01:01:48',5,0,0,0,'inscripto'),
 (43,3,4,'2009-12-08','01:29:43',4,0,0,0,'inscripto');
/*!40000 ALTER TABLE `registro_materia` ENABLE KEYS */;


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
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_responsable`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `responsable`
--

/*!40000 ALTER TABLE `responsable` DISABLE KEYS */;
INSERT INTO `responsable` VALUES  (1,'Nicolas','Mizerniuk','1111-11-11','aaaaaa 1111',0,111111,30501831,1,'nico.sf@gmail.com'),
 (26,'jil','de estopa','1983-11-11','ñflk',0,23234,39929922,1,NULL),
 (27,'maria','de las nieves','1093-11-11','ñlkjlñ',0,343434,87878787,1,NULL),
 (32,'mimi','maura','1900-11-11','dfldkfj',0,33433,45444444,1,NULL);
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
INSERT INTO `turno` VALUES  (1,1,'mañana',25,1),
 (2,1,'tarde',30,2),
 (3,41,'mañana',1,3),
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
