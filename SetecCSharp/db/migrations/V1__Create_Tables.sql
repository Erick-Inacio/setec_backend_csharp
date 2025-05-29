-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: setec
-- ------------------------------------------------------
-- Server version	8.4.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `activity`
--

DROP TABLE IF EXISTS `activity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `activity` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `fk_event` bigint NOT NULL,
  `fk_admin_approved` varchar(255) DEFAULT NULL,
  `fk_type_activity` bigint NOT NULL,
  `daysQuantity` int DEFAULT NULL,
  `hoursQuantity` int DEFAULT NULL,
  `qtdeVagas` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Event` (`fk_event`),
  KEY `fk_User` (`fk_admin_approved`),
  KEY `fk_type_activity` (`fk_type_activity`),
  CONSTRAINT `activity_ibfk_1` FOREIGN KEY (`fk_event`) REFERENCES `event` (`id`),
  CONSTRAINT `activity_ibfk_2` FOREIGN KEY (`fk_admin_approved`) REFERENCES `user` (`uid`),
  CONSTRAINT `activity_ibfk_3` FOREIGN KEY (`fk_type_activity`) REFERENCES `type_activity` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `attend`
--

DROP TABLE IF EXISTS `attend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attend` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `fk_subscription` bigint DEFAULT NULL,
  `fk_date` bigint NOT NULL,
  `fk_user` bigint DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_id_subscription` (`fk_subscription`),
  KEY `fk_date` (`fk_date`),
  KEY `fk_user` (`fk_user`),
  CONSTRAINT `attend_ibfk_1` FOREIGN KEY (`fk_subscription`) REFERENCES `subscription` (`id`),
  CONSTRAINT `attend_ibfk_2` FOREIGN KEY (`fk_date`) REFERENCES `date` (`id`),
  CONSTRAINT `attend_ibfk_3` FOREIGN KEY (`fk_user`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `commission`
--

DROP TABLE IF EXISTS `commission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commission` (
  `fk_event` bigint NOT NULL,
  `fk_user` bigint NOT NULL,
  `id` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_User_id_user` (`fk_user`),
  KEY `commission_ibfk_1_idx` (`fk_event`),
  CONSTRAINT `commission_ibfk_1` FOREIGN KEY (`fk_event`) REFERENCES `event` (`id`),
  CONSTRAINT `commission_ibfk_2` FOREIGN KEY (`fk_user`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `date`
--

DROP TABLE IF EXISTS `date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `date` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `date` date DEFAULT NULL,
  `fk_activity` bigint NOT NULL,
  `initialHour` time DEFAULT NULL,
  `finalHour` time DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_activity` (`fk_activity`),
  CONSTRAINT `dates_ibfk_1` FOREIGN KEY (`fk_activity`) REFERENCES `activity` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `startAt` datetime DEFAULT NULL,
  `endAt` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `social_media`
--

DROP TABLE IF EXISTS `social_media`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `social_media` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `platform` varchar(100) DEFAULT NULL,
  `url` varchar(255) DEFAULT NULL,
  `fk_Speaker` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Speaker` (`fk_Speaker`),
  CONSTRAINT `social_media_ibfk_1` FOREIGN KEY (`fk_Speaker`) REFERENCES `speaker` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `speaker`
--

DROP TABLE IF EXISTS `speaker`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `speaker` (
  `id` bigint NOT NULL,
  `company` varchar(100) DEFAULT NULL,
  `position` varchar(100) DEFAULT NULL,
  `bio` text,
  `approved` tinyint(1) DEFAULT NULL,
  `fk_admin` varchar(255) DEFAULT NULL,
  `dateFatecConclusion` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `speaker_ibfk_2_idx` (`fk_admin`),
  CONSTRAINT `speaker_ibfk_1` FOREIGN KEY (`id`) REFERENCES `user` (`id`),
  CONSTRAINT `speaker_ibfk_2` FOREIGN KEY (`fk_admin`) REFERENCES `user` (`uid`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `speaker_activity`
--

DROP TABLE IF EXISTS `speaker_activity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `speaker_activity` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `fk_Activity` bigint NOT NULL,
  `fk_Speaker` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Activity_id_activity` (`fk_Activity`),
  KEY `fk_Speaker_id_speaker` (`fk_Speaker`),
  CONSTRAINT `speaker_activity_ibfk_1` FOREIGN KEY (`fk_Activity`) REFERENCES `activity` (`id`),
  CONSTRAINT `speaker_activity_ibfk_2` FOREIGN KEY (`fk_Speaker`) REFERENCES `speaker` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sponsor`
--

DROP TABLE IF EXISTS `sponsor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sponsor` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `fk_event_commission` bigint NOT NULL,
  `isLegalEntity` tinyint(1) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `sponsorshipValue` decimal(10,2) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `obs` text,
  PRIMARY KEY (`id`),
  KEY `id_commission/sponsor_idx` (`fk_event_commission`),
  CONSTRAINT `id_commission/sponsor` FOREIGN KEY (`fk_event_commission`) REFERENCES `commission` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `subscription`
--

DROP TABLE IF EXISTS `subscription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscription` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `subscriptionStatus` varchar(50) DEFAULT NULL,
  `fk_Activity` bigint NOT NULL,
  `fk_User` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Activity` (`fk_Activity`),
  KEY `fk_User` (`fk_User`),
  CONSTRAINT `subscription_ibfk_1` FOREIGN KEY (`fk_Activity`) REFERENCES `activity` (`id`),
  CONSTRAINT `subscription_ibfk_2` FOREIGN KEY (`fk_User`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `type_activity`
--

DROP TABLE IF EXISTS `type_activity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_activity` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `needsSubscription` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `role` tinyint NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `relationship` tinyint NOT NULL,
  `ra` varchar(20) DEFAULT NULL,
  `uid` varchar(255) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uid_UNIQUE` (`uid`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-28 21:33:19
