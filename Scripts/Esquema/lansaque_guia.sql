CREATE DATABASE  IF NOT EXISTS `lansaque` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish2_ci */;
USE `lansaque`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: lansaque
-- ------------------------------------------------------
-- Server version	8.0.15

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
-- Table structure for table `guia`
--

DROP TABLE IF EXISTS `guia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `guia` (
  `id_guia` int(11) NOT NULL,
  `marca` varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  `modelo` varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  `formula_ancho_dos_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `formula_ancho_tres_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `formula_ancho_cuatro_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `formula_ancho_cinco_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `formula_ancho_seis_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `formula_ancho_siete_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `formula_ancho_ocho_puertas` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `milimetros_resta_altura_puerta` int(11) NOT NULL,
  `milimetros_resta_ancho_perfil_u_puerta` int(11) NOT NULL,
  `ancho_guia` int(11) NOT NULL,
  `alto_guia` int(11) NOT NULL,
  `tipo_guia` varchar(100) COLLATE utf8_spanish2_ci DEFAULT NULL,
  `fecha_creacion` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_guia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guia`
--

LOCK TABLES `guia` WRITE;
/*!40000 ALTER TABLE `guia` DISABLE KEYS */;
INSERT INTO `guia` VALUES (1,'adinor','kit s-80 rts 10mm','a-39/2','a-44/3','a-49/4','a-54/5','a-59/6','a-64/7','a-69/8',30,24,75,40,'a-descontar/puertas','2020-12-09 18:33:30'),(2,'bidebieta','10mm','a/2-24','a/3-18','a/4-24','a/5-18','a/6-24','a/7-18','a/8-24',44,24,80,0,'a/puertas-descontar','2020-05-12 20:21:23');
/*!40000 ALTER TABLE `guia` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-09 19:40:06
