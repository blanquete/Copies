-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.6.4-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para todolist
CREATE DATABASE IF NOT EXISTS `todolist` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_spanish_ci */;
USE `todolist`;

-- Volcando estructura para tabla todolist.estat
CREATE TABLE IF NOT EXISTS `estat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) COLLATE latin1_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla todolist.estat: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `estat` DISABLE KEYS */;
INSERT IGNORE INTO `estat` (`id`, `nom`) VALUES
	(1, 'To do'),
	(2, 'Doing'),
	(3, 'Done');
/*!40000 ALTER TABLE `estat` ENABLE KEYS */;

-- Volcando estructura para tabla todolist.prioritat
CREATE TABLE IF NOT EXISTS `prioritat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom` (`nom`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla todolist.prioritat: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `prioritat` DISABLE KEYS */;
INSERT IGNORE INTO `prioritat` (`id`, `nom`) VALUES
	(1, 'Alta'),
	(3, 'Baixa'),
	(2, 'Mitja');
/*!40000 ALTER TABLE `prioritat` ENABLE KEYS */;

-- Volcando estructura para tabla todolist.responsable
CREATE TABLE IF NOT EXISTS `responsable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) COLLATE latin1_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla todolist.responsable: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `responsable` DISABLE KEYS */;
INSERT IGNORE INTO `responsable` (`id`, `nom`) VALUES
	(1, 'Usuari1'),
	(2, 'Usuari2'),
	(3, 'Usuari3');
/*!40000 ALTER TABLE `responsable` ENABLE KEYS */;

-- Volcando estructura para tabla todolist.tasca
CREATE TABLE IF NOT EXISTS `tasca` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) COLLATE latin1_spanish_ci DEFAULT NULL,
  `descripcio` varchar(255) COLLATE latin1_spanish_ci DEFAULT NULL,
  `dataInici` datetime DEFAULT NULL,
  `dataFinal` datetime DEFAULT NULL,
  `id_prioritat` int(11) DEFAULT NULL,
  `id_estat` int(11) DEFAULT NULL,
  `id_responsable` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_prioritat` (`id_prioritat`),
  KEY `id_estat` (`id_estat`),
  KEY `id_responsable` (`id_responsable`),
  CONSTRAINT `tasca_ibfk_1` FOREIGN KEY (`id_prioritat`) REFERENCES `prioritat` (`id`),
  CONSTRAINT `tasca_ibfk_2` FOREIGN KEY (`id_estat`) REFERENCES `estat` (`id`),
  CONSTRAINT `tasca_ibfk_3` FOREIGN KEY (`id_responsable`) REFERENCES `responsable` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla todolist.tasca: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `tasca` DISABLE KEYS */;
INSERT IGNORE INTO `tasca` (`id`, `nom`, `descripcio`, `dataInici`, `dataFinal`, `id_prioritat`, `id_estat`, `id_responsable`) VALUES
	(1, 'Tasca 1', 'Hola', '2021-11-19 16:57:05', '2021-11-19 00:00:00', 1, 1, 1),
	(2, 'Tasca 2', 'Hola', '2021-11-24 15:31:21', '2021-11-24 15:31:23', 1, 2, 1),
	(3, 'Tasca 3', 'Hola', '2021-11-25 16:51:54', '2021-11-25 16:51:55', 1, 3, 3);
/*!40000 ALTER TABLE `tasca` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
