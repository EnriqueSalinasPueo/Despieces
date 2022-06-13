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
-- Table structure for table `holguras_gruesos`
--

DROP TABLE IF EXISTS `holguras_gruesos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `holguras_gruesos` (
  `id_holgurasGruesos` int(11) NOT NULL,
  `h_techo` decimal(10,0) DEFAULT NULL,
  `h_fondo` decimal(10,0) DEFAULT NULL,
  `h_pared` decimal(10,0) DEFAULT NULL,
  `h_puertas` decimal(10,0) DEFAULT NULL,
  `h_cajones` decimal(10,0) DEFAULT NULL,
  `h_guia` decimal(10,0) DEFAULT NULL,
  `h_baldas` decimal(10,0) DEFAULT NULL,
  `m_rodapie` decimal(10,0) DEFAULT NULL,
  `m_tapajuntas` decimal(10,0) DEFAULT NULL,
  `m_rodapie_guia` decimal(10,0) DEFAULT NULL,
  `m_jacena` decimal(10,0) DEFAULT NULL,
  `descolgar_cornisa` decimal(10,0) DEFAULT NULL,
  `g_traseras` decimal(10,0) DEFAULT NULL,
  `g_costados` decimal(10,0) DEFAULT NULL,
  `g_puertas` decimal(10,0) DEFAULT NULL,
  `g_correderas` decimal(10,0) DEFAULT NULL,
  `g_guia` decimal(10,0) DEFAULT NULL,
  `g_apoyo_barra` decimal(10,0) DEFAULT NULL,
  `g_tapeta` decimal(10,0) DEFAULT NULL,
  `g_tapajuntas` decimal(10,0) DEFAULT NULL,
  `g_cornisa` decimal(10,0) DEFAULT NULL,
  `g_rodapie` decimal(10,0) DEFAULT NULL,
  `max_puertas` decimal(10,0) DEFAULT NULL,
  `max_correderas` decimal(10,0) DEFAULT NULL,
  `fecha_creacion` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_holgurasGruesos`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `holguras_gruesos`
--

LOCK TABLES `holguras_gruesos` WRITE;
/*!40000 ALTER TABLE `holguras_gruesos` DISABLE KEYS */;
INSERT INTO `holguras_gruesos` VALUES (1,20,10,20,3,3,5,5,5,5,3,25,5,10,19,19,10,40,3,10,10,10,10,600,900,'2020-12-09 18:33:38');
/*!40000 ALTER TABLE `holguras_gruesos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-09 19:40:05
