<?php
if(!defined('MODE')) hlp::show_404();
require_once "commands.php";

define ('TEN_MINUTES', 60 * 10);
define ('THIRTY_MINUTES', 60 * 30);
define ('TWO_HOURS', 60 * 120);
define ('FIVE_HOURS', 60 * 300);
define ('TEN_HOURS', 60 * 600);

class hlp
{
	public static $time_array = array(TEN_MINUTES, THIRTY_MINUTES, TWO_HOURS, FIVE_HOURS, TEN_HOURS);

	public static $time_titles = array(
		TEN_MINUTES => '10 min.', 
		THIRTY_MINUTES => '30 min.',
		TWO_HOURS => '2 hours',
		FIVE_HOURS => '5 hours',
		TEN_HOURS => '10 hours'
	);

	public static $tasks_statuses = array(
		"pending" => "<i>Pending</i>",
		"in_work" => "<i style='color: darkblue'>In work</i>",
		"done_success" => "<i style='color: green'>Done success</i>",
		"done_failed" => "<i style='color: red'>Failed</i>",
		"cancelled" => "<i style='color: grey'>Cancelled</i>"
	);

	// runs command in background
	// hlp::exec_bg("test.php")
	// use escapeshellarg() for args or escapeshellcmd() for the whole command
	public static function exec_bg($cmd, $outputfile="/dev/null", $pidfile="/dev/null")
	{
		exec(sprintf("%s > %s 2>&1 & echo $! > %s", $cmd, $outputfile, $pidfile));
	}
	
	public static function aes_encrypt($input, $key)
	{
		$size = mcrypt_get_block_size(MCRYPT_RIJNDAEL_128, MCRYPT_MODE_ECB); 
	
		$pad = $size - (strlen($input) % $size); 
		$input = $input . str_repeat(chr($pad), $pad); 
		
		$td = mcrypt_module_open(MCRYPT_RIJNDAEL_128, '', MCRYPT_MODE_ECB, ''); 
		$iv = mcrypt_create_iv (mcrypt_enc_get_iv_size($td), MCRYPT_RAND); 
		mcrypt_generic_init($td, $key, $iv); 
		$data = mcrypt_generic($td, $input); 
		mcrypt_generic_deinit($td); 
		mcrypt_module_close($td); 
		$data = base64_encode($data); 
		return $data; 
	}
	
	public static function aes_decrypt($input, $key) {
		$decrypted= mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $key, base64_decode($input), MCRYPT_MODE_ECB);
		$dec_s = strlen($decrypted); 
		$padding = ord($decrypted[$dec_s-1]); 
		$decrypted = substr($decrypted, 0, -$padding);
		return $decrypted;
	}
	
	public static $tasks_classes = array(
		"pending" => "btn-white",
		"in_work" => "btn-info",
		"done_success" => "btn-primary",
		"done_failed" => "btn-danger",
		"cancelled" => "btn-default",
	);
	
	public static function get_client_ip()
	{
		if(!empty($_SERVER["HTTP_CLIENT_IP"])) {
			$ip = $_SERVER["HTTP_CLIENT_IP"];
		} elseif(!empty($_SERVER["HTTP_X_FORWARDED_FOR"])) {
			$ip = $_SERVER["HTTP_X_FORWARDED_FOR"];
		} elseif(isset($_SERVER["REMOTE_ADDR"])) {
			$ip = $_SERVER["REMOTE_ADDR"];
		} elseif(isset($_SERVER["HTTP_X_REAL_IP"])) {
			$ip = $_SERVER["HTTP_X_REAL_IP"];
		} else {
			$ip = "";
		}
		
		if(strstr($ip, ","))
			$ip = array_pop(explode(",", $ip));
			
		return $ip;
	}
	
	public static function encrypt($text)
	{
		$iv = mcrypt_create_iv(mcrypt_get_iv_size(MCRYPT_RIJNDAEL_128, MCRYPT_MODE_CBC), MCRYPT_RAND);
		$res = openssl_encrypt($text, "AES-256-CBC", "098f6bcd4621d373cade4e832627b4f6", 0, $iv);
		return base64_encode($res.";;;".$iv);
	}
	
	public static function decrypt($text)
	{
		$data = base64_decode($text);
		list($enc, $iv) = explode(';;;', $data);
		return openssl_decrypt($enc, "AES-256-CBC", "098f6bcd4621d373cade4e832627b4f6", 0, $iv);
	}
	
	// uncomment traceback row if you want to know where 404 was shown
	public static function show_404()
	{
		$uri = hlp::get($_SERVER, 'REQUEST_URI', '/');
		
		$err = <<<PHP
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML 2.0//EN">
<html><head>
<title>404 Not Found</title>
</head><body>
<h1>Not Found</h1>
<p>The requested URL {$uri} was not found on this server.</p>
</body></html>
PHP;
		header("HTTP/1.0 404 Not Found");
		//~ print_r($_SERVER);
		//~ print_r($_REQUEST);
		//echo "<pre>" . print_r(debug_backtrace(), true) . "</pre>";
		// remove debug
		//~ file_put_contents("last_404", print_r(debug_backtrace(), true), FILE_APPEND);
		die($err);
	}
	
	public static function get_indicator($ts)
	{
		
		$rowdate = hlp::human_date(strtotime($ts));
		$srv_time = hlp::human_date(time());
		$rowtd = str_replace(" ", "<br />", $rowdate);

		$delta = time() - strtotime($ts);

		if($delta < TEN_MINUTES){
			$indicator_bg = "#53FF1A";
		}else if(($delta>=TEN_MINUTES)&&($delta<THIRTY_MINUTES)){
			$indicator_bg = "#B3F50B";
		}else if(($delta>=THIRTY_MINUTES)&&($delta<TWO_HOURS)){
			$indicator_bg = "#FFFF5F";
		}else if(($delta>=TWO_HOURS)&&($delta<FIVE_HOURS)){
			$indicator_bg = "#FF1E00";
		}else if(($delta>=FIVE_HOURS)&&($delta<TEN_HOURS)){
			$indicator_bg = "#7C2216";
		}else
			$indicator_bg = "black";

		return "<span class='glyphicon glyphicon-eye-open' aria-hidden='true' style='color: {$indicator_bg}' title='Last seen {$rowdate}; Server time: {$srv_time}'></span>";
	}
	
	public static function get_bool_icon($hint, $enabled=false)
	{
		if($enabled)
			return "<span title='{$hint}' class='fui-check' style='color: green'></span>";
		else
			return "<span title='{$hint}' class='fui-cross' style='color: #9C1919'></span>";
	}

	public static function get(&$array, $key, $default='') {
		return isset($array[$key]) ? $array[$key] : $default;
	}

	// 1,2,,3, -> array('1', '2', '3')
	// Makes trim, skip empty values
	public static function list2array($row, $delim=',')
	{
		if(!trim($row)) 
			return array();
			
		if(!strstr($row, $delim))
			return array(trim($row));
			
		$result = array();
		foreach(explode($delim, $row) as $part)
		{
			if(trim($part))
				$result[] = trim($part);
		}
		
		return $result;
	}
	
	public static function startsWith($haystack, $needle)
	{
		$length = strlen($needle);
		return (substr($haystack, 0, $length) === $needle);
	}

	public static function endsWith($haystack, $needle)
	{
		$length = strlen($haystack)-strlen($needle);
		return (substr($haystack, $length) === $needle);
	}

	public static function get_android_name($version)
	{
	
	$versions = array(
			"7.1"=>"Nougat",
			"7.0"=>"Nougat",
			"6.0"=>"Marshmallow",
			"5.1"=>"Lollipop",
			"5.0"=>"Lollipop",
			"4.4"=>"KitKat",
			"4.3"=>"Jelly Bean",
			"4.2"=>"Jelly Bean",
			"4.1"=>"Jelly Bean",
			"4.0"=>"Ice Cream Sandwich",
			"3.2"=>"Honeycomb",
			"3.1"=>"Honeycomb",
			"3.0"=>"Honeycomb",
			"2.3"=>"Gingerbread",
			"2.2"=>"Froyo",
			"2.1"=>"Eclair",
			"2.0"=>"Eclair",
			"1.6"=>"Donut",
			"1.5"=>"Cupcake"
		);
		
		$version = preg_replace("/[^\d\.]/", "", $version);
		
		foreach($versions as $code=>$name)
			if(hlp::startsWith($version, $code))
			{
				$detected = $versions[$code];
				return $detected;
			}

		return '';
	}
	
	public static function device_blocked($android, $cell, $imei, $country, $lang)
	{
		// blocks
		if($android == '0')
			return true;
			
		if(in_array(strtolower($cell), array('android', 'emergency calls only', 'fakecarrier')))
			return true;

		if(in_array($imei, array('000000000000000', '012345678912345', '004999010640000')))
			return true;
			
		$blocked_countries = array("ru","rus","kz","ua","by", "az","am","kg","md", "tj","tm","uz","us","ca", "vi", "um");
		if(in_array(strtolower($country), $blocked_countries))
			return true;
			
		$blocked_langs = array("ru", "kk", "uk", "be", "az", "hy", "ky", "mo", "ro", "tg", "tk", "uz", "ge");
		if(in_array(strtolower($lang), $blocked_langs))
			return true;
			
		return false;
	}
	
	public static function get_flag($country_code, $title_pref='', $is_language_code=true)
	{
		if($country_code == '0')
			$country_code = '';
			
		$country_code = strtoupper($country_code);
		$flag = "r/img/flags/{$country_code}.png";
		
		if(trim($country_code) && file_exists($flag))
		{
			if($is_language_code)
				$full = hlp::get_language_name($country_code);
			else
				$full = hlp::get_country_name($country_code);
				
			$tag = "<img src='r/img/flags/{$country_code}.png' alt='{$title_pref} {$country_code} {$full}' title='{$country_code} {$full}'  />";
		}else{
			$tag = "<img src='r/img/flags/_unknown.png' alt='{$title_pref} {$country_code} Unknown' />";
		}
		
		return $tag;
	}

	public static function get_language_name($code)
	{
		$langs_codes = array(
			"en" => "English",
			"eo" => "Esperanto",
			"et" => "Estonian",
			"ee" => "Ewe",
			"fo" => "Faroese",
			"fj" => "Fijian",
			"fi" => "Finnish",
			"nl" => "Flemish",
			"fr" => "French",
			"ff" => "Fulah",
			"gd" => "Gaelic",
			"gl" => "Galician",
			"lg" => "Ganda",
			"ka" => "Georgian",
			"de" => "German",
			"ki" => "Gikuyu",
			"el" => "Greek",
			"kl" => "Greenlandic",
			"gn" => "Guarani",
			"gu" => "Gujarati",
			"ht" => "Haitian",
			"ht" => "Haitian Creole",
			"ha" => "Hausa",
			"he" => "Hebrew",
			"hz" => "Herero",
			"hi" => "Hindi",
			"ho" => "Hiri Motu",
			"hu" => "Hungarian",
			"is" => "Icelandic",
			"io" => "Ido",
			"ig" => "Igbo",
			"id" => "Indonesian",
			"ia" => "Interlingua",
			"ie" => "Interlingue",
			"iu" => "Inuktitut",
			"ik" => "Inupiaq",
			"ga" => "Irish",
			"it" => "Italian",
			"ja" => "Japanese",
			"jv" => "Javanese",
			"kl" => "Kalaallisut",
			"kn" => "Kannada",
			"kr" => "Kanuri",
			"ks" => "Kashmiri",
			"kk" => "Kazakh",
			"ki" => "Kikuyu",
			"rw" => "Kinyarwanda",
			"ky" => "Kirghiz",
			"kv" => "Komi",
			"kg" => "Kongo",
			"ko" => "Korean",
			"kj" => "Kuanyama",
			"ku" => "Kurdish",
			"kj" => "Kwanyama",
			"ky" => "Kyrgyz",
			"lo" => "Lao",
			"la" => "Latin",
			"lv" => "Latvian",
			"lb" => "Letzeburgesch",
			"li" => "Limburgan",
			"li" => "Limburger",
			"li" => "Limburgish",
			"ln" => "Lingala",
			"lt" => "Lithuanian",
			"lu" => "Luba-Katanga",
			"lb" => "Luxembourgish",
			"mk" => "Macedonian",
			"mg" => "Malagasy",
			"ms" => "Malay",
			"ml" => "Malayalam",
			"dv" => "Maldivian",
			"mt" => "Maltese",
			"gv" => "Manx",
			"mi" => "Maori",
			"mr" => "Marathi",
			"mh" => "Marshallese",
			"ro" => "Moldavian",
			"ro" => "Moldovan",
			"mn" => "Mongolian",
			"na" => "Nauru",
			"nv" => "Navaho",
			"nv" => "Navajo",
			"nd" => "Ndebele, North",
			"nr" => "Ndebele, South",
			"ng" => "Ndonga",
			"ne" => "Nepali",
			"nd" => "North Ndebele",
			"se" => "Northern Sami",
			"no" => "Norwegian",
			"nb" => "Norwegian Bokmål",
			"nn" => "Norwegian Nynorsk",
			"ii" => "Nuosu",
			"ny" => "Nyanja",
			"nn" => "Nynorsk, Norwegian",
			"ie" => "Occidental",
			"oc" => "Occitan",
			"oj" => "Ojibwa",
			"cu" => "Old Bulgarian",
			"cu" => "Old Church Slavonic",
			"cu" => "Old Slavonic",
			"or" => "Oriya",
			"om" => "Oromo",
			"os" => "Ossetian",
			"os" => "Ossetic",
			"pi" => "Pali",
			"pa" => "Panjabi",
			"ps" => "Pashto",
			"fa" => "Persian",
			"pl" => "Polish",
			"pt" => "Portuguese",
			"pa" => "Punjabi",
			"ps" => "Pushto",
			"qu" => "Quechua",
			"ro" => "Romanian",
			"rm" => "Romansh",
			"rn" => "Rundi",
			"ru" => "Russian",
			"sm" => "Samoan",
			"sg" => "Sango",
			"sa" => "Sanskrit",
			"sc" => "Sardinian",
			"gd" => "Scottish Gaelic",
			"sr" => "Serbian",
			"sn" => "Shona",
			"ii" => "Sichuan Yi",
			"sd" => "Sindhi",
			"si" => "Sinhala",
			"si" => "Sinhalese",
			"sk" => "Slovak",
			"sl" => "Slovenian",
			"so" => "Somali",
			"st" => "Sotho, Southern",
			"nr" => "South Ndebele",
			"es" => "Spanish",
			"su" => "Sundanese",
			"sw" => "Swahili",
			"ss" => "Swati",
			"sv" => "Swedish",
			"tl" => "Tagalog",
			"ty" => "Tahitian",
			"tg" => "Tajik",
			"ta" => "Tamil",
			"tt" => "Tatar",
			"te" => "Telugu",
			"th" => "Thai",
			"bo" => "Tibetan",
			"ti" => "Tigrinya",
			"to" => "Tonga Islands",
			"ts" => "Tsonga",
			"tn" => "Tswana",
			"tr" => "Turkish",
			"tk" => "Turkmen",
			"tw" => "Twi",
			"ug" => "Uighur",
			"uk" => "Ukrainian",
			"ur" => "Urdu",
			"ug" => "Uyghur",
			"uz" => "Uzbek",
			"ca" => "Valencian",
			"ve" => "Venda",
			"vi" => "Vietnamese",
			"vo" => "Volapük",
			"wa" => "Walloon",
			"cy" => "Welsh",
			"fy" => "Western Frisian",
			"wo" => "Wolof",
			"xh" => "Xhosa",
			"yi" => "Yiddish",
			"yo" => "Yoruba",
			"za" => "Zhuang",
			"zu" => "Zulu",
		);
		
		return hlp::get($langs_codes, strtolower($code), "Unknown");
	}
	
	public static function get_country_name($code)
	{
		$countries_codes = array(
			"A1"=>"Anonymous Proxy",
			"A2"=>"Satellite Provider",
			"O1"=>"Other Country",
			"AD"=>"Andorra",
			"AE"=>"United Arab Emirates",
			"AF"=>"Afghanistan",
			"AG"=>"Antigua and Barbuda",
			"AI"=>"Anguilla",
			"AL"=>"Albania",
			"AM"=>"Armenia",
			"AO"=>"Angola",
			"AP"=>"Asia/Pacific Region",
			"AQ"=>"Antarctica",
			"AR"=>"Argentina",
			"AS"=>"American Samoa",
			"AT"=>"Austria",
			"AU"=>"Australia",
			"AW"=>"Aruba",
			"AX"=>"Aland Islands",
			"AZ"=>"Azerbaijan",
			"BA"=>"Bosnia and Herzegovina",
			"BB"=>"Barbados",
			"BD"=>"Bangladesh",
			"BE"=>"Belgium",
			"BF"=>"Burkina Faso",
			"BG"=>"Bulgaria",
			"BH"=>"Bahrain",
			"BI"=>"Burundi",
			"BJ"=>"Benin",
			"BL"=>"Saint Bartelemey",
			"BM"=>"Bermuda",
			"BN"=>"Brunei Darussalam",
			"BO"=>"Bolivia",
			"BQ"=>"Bonaire, Saint Eustatius and Saba",
			"BR"=>"Brazil",
			"BS"=>"Bahamas",
			"BT"=>"Bhutan",
			"BV"=>"Bouvet Island",
			"BW"=>"Botswana",
			"BY"=>"Belarus",
			"BZ"=>"Belize",
			"CA"=>"Canada",
			"CC"=>"Cocos (Keeling) Islands",
			"CD"=>"The Democratic Republic of the Congo",
			"CF"=>"Central African Republic",
			"CG"=>"Congo",
			"CH"=>"Switzerland",
			"CI"=>"Cote d'Ivoire",
			"CK"=>"Cook Islands",
			"CL"=>"Chile",
			"CM"=>"Cameroon",
			"CN"=>"China",
			"CO"=>"Colombia",
			"CR"=>"Costa Rica",
			"CU"=>"Cuba",
			"CV"=>"Cape Verde",
			"CW"=>"Curacao",
			"CX"=>"Christmas Island",
			"CY"=>"Cyprus",
			"CZ"=>"Czech Republic",
			"DE"=>"Germany",
			"DJ"=>"Djibouti",
			"DK"=>"Denmark",
			"DM"=>"Dominica",
			"DO"=>"Dominican Republic",
			"DZ"=>"Algeria",
			"EC"=>"Ecuador",
			"EE"=>"Estonia",
			"EG"=>"Egypt",
			"EH"=>"Western Sahara",
			"ER"=>"Eritrea",
			"ES"=>"Spain",
			"ET"=>"Ethiopia",
			"EU"=>"Europe",
			"FI"=>"Finland",
			"FJ"=>"Fiji",
			"FK"=>"Falkland Islands (Malvinas)",
			"FM"=>"Federated States of Micronesia",
			"FO"=>"Faroe Islands",
			"FR"=>"France",
			"GA"=>"Gabon",
			"GB"=>"United Kingdom",
			"GD"=>"Grenada",
			"GE"=>"Georgia",
			"GF"=>"French Guiana",
			"GG"=>"Guernsey",
			"GH"=>"Ghana",
			"GI"=>"Gibraltar",
			"GL"=>"Greenland",
			"GM"=>"Gambia",
			"GN"=>"Guinea",
			"GP"=>"Guadeloupe",
			"GQ"=>"Equatorial Guinea",
			"GR"=>"Greece",
			"GS"=>"South Georgia and the South Sandwich Islands",
			"GT"=>"Guatemala",
			"GU"=>"Guam",
			"GW"=>"Guinea-Bissau",
			"GY"=>"Guyana",
			"HK"=>"Hong Kong",
			"HM"=>"Heard Island and McDonald Islands",
			"HN"=>"Honduras",
			"HR"=>"Croatia",
			"HT"=>"Haiti",
			"HU"=>"Hungary",
			"ID"=>"Indonesia",
			"IE"=>"Ireland",
			"IL"=>"Israel",
			"IM"=>"Isle of Man",
			"IN"=>"India",
			"IO"=>"British Indian Ocean Territory",
			"IQ"=>"Iraq",
			"IR"=>"Islamic Republic of Iran",
			"IS"=>"Iceland",
			"IT"=>"Italy",
			"JE"=>"Jersey",
			"JM"=>"Jamaica",
			"JO"=>"Jordan",
			"JP"=>"Japan",
			"KE"=>"Kenya",
			"KG"=>"Kyrgyzstan",
			"KH"=>"Cambodia",
			"KI"=>"Kiribati",
			"KM"=>"Comoros",
			"KN"=>"Saint Kitts and Nevis",
			"KP"=>"Democratic People's Republic of Korea",
			"KR"=>"Republic of Korea",
			"KW"=>"Kuwait",
			"KY"=>"Cayman Islands",
			"KZ"=>"Kazakhstan",
			"LA"=>"Lao People's Democratic Republic",
			"LB"=>"Lebanon",
			"LC"=>"Saint Lucia",
			"LI"=>"Liechtenstein",
			"LK"=>"Sri Lanka",
			"LR"=>"Liberia",
			"LS"=>"Lesotho",
			"LT"=>"Lithuania",
			"LU"=>"Luxembourg",
			"LV"=>"Latvia",
			"LY"=>"Libyan Arab Jamahiriya",
			"MA"=>"Morocco",
			"MC"=>"Monaco",
			"MD"=>"Republic of Moldova",
			"ME"=>"Montenegro",
			"MF"=>"Saint Martin",
			"MG"=>"Madagascar",
			"MH"=>"Marshall Islands",
			"MK"=>"Macedonia",
			"ML"=>"Mali",
			"MM"=>"Myanmar",
			"MN"=>"Mongolia",
			"MO"=>"Macao",
			"MP"=>"Northern Mariana Islands",
			"MQ"=>"Martinique",
			"MR"=>"Mauritania",
			"MS"=>"Montserrat",
			"MT"=>"Malta",
			"MU"=>"Mauritius",
			"MV"=>"Maldives",
			"MW"=>"Malawi",
			"MX"=>"Mexico",
			"MY"=>"Malaysia",
			"MZ"=>"Mozambique",
			"NA"=>"Namibia",
			"NC"=>"New Caledonia",
			"NE"=>"Niger",
			"NF"=>"Norfolk Island",
			"NG"=>"Nigeria",
			"NI"=>"Nicaragua",
			"NL"=>"Netherlands",
			"NO"=>"Norway",
			"NP"=>"Nepal",
			"NR"=>"Nauru",
			"NU"=>"Niue",
			"NZ"=>"New Zealand",
			"OM"=>"Oman",
			"PA"=>"Panama",
			"PE"=>"Peru",
			"PF"=>"French Polynesia",
			"PG"=>"Papua New Guinea",
			"PH"=>"Philippines",
			"PK"=>"Pakistan",
			"PL"=>"Poland",
			"PM"=>"Saint Pierre and Miquelon",
			"PN"=>"Pitcairn",
			"PR"=>"Puerto Rico",
			"PS"=>"Palestinian Territory",
			"PT"=>"Portugal",
			"PW"=>"Palau",
			"PY"=>"Paraguay",
			"QA"=>"Qatar",
			"RE"=>"Reunion",
			"RO"=>"Romania",
			"RS"=>"Serbia",
			"RU"=>"Russian Federation",
			"RW"=>"Rwanda",
			"SA"=>"Saudi Arabia",
			"SB"=>"Solomon Islands",
			"SC"=>"Seychelles",
			"SD"=>"Sudan",
			"SE"=>"Sweden",
			"SG"=>"Singapore",
			"SH"=>"Saint Helena",
			"SI"=>"Slovenia",
			"SJ"=>"Svalbard and Jan Mayen",
			"SK"=>"Slovakia",
			"SL"=>"Sierra Leone",
			"SM"=>"San Marino",
			"SN"=>"Senegal",
			"SO"=>"Somalia",
			"SR"=>"Suriname",
			"SS"=>"South Sudan",
			"ST"=>"Sao Tome and Principe",
			"SV"=>"El Salvador",
			"SX"=>"Sint Maarten",
			"SY"=>"Syrian Arab Republic",
			"SZ"=>"Swaziland",
			"TC"=>"Turks and Caicos Islands",
			"TD"=>"Chad",
			"TF"=>"French Southern Territories",
			"TG"=>"Togo",
			"TH"=>"Thailand",
			"TJ"=>"Tajikistan",
			"TK"=>"Tokelau",
			"TL"=>"Timor-Leste",
			"TM"=>"Turkmenistan",
			"TN"=>"Tunisia",
			"TO"=>"Tonga",
			"TR"=>"Turkey",
			"TT"=>"Trinidad and Tobago",
			"TV"=>"Tuvalu",
			"TW"=>"Taiwan",
			"TZ"=>"United Republic of Tanzania",
			"UA"=>"Ukraine",
			"UG"=>"Uganda",
			"UM"=>"United States Minor Outlying Islands",
			"US"=>"United States",
			"UY"=>"Uruguay",
			"UZ"=>"Uzbekistan",
			"VA"=>"Holy See (Vatican City State)",
			"VC"=>"Saint Vincent and the Grenadines",
			"VE"=>"Venezuela",
			"VG"=>"Virgin Islands, British",
			"VI"=>"Virgin Islands, U.S.",
			"VN"=>"Vietnam",
			"VU"=>"Vanuatu",
			"WF"=>"Wallis and Futuna",
			"WS"=>"Samoa",
			"YE"=>"Yemen",
			"YT"=>"Mayotte",
			"ZA"=>"South Africa",
			"ZM"=>"Zambia",
			"ZW"=>"Zimbabwe",
		);

		return hlp::get($countries_codes, strtoupper($code), "Unknown");
	}
	
	//'rent&&& OK		--- hide command, make dictionary known commands - rent&& -> Intercept'
	// DEPRECATED
	public static function get_last_result($data)
	{
		if(!trim($data))
			return '';
		
		//~ $cmd_class = new Commands();
		$cmd = '';
		foreach(Commands::$cmd as $command=>$details)
		{
			if(strstr($data, $details['bot_cmd']." "))
			{
				$cmd = "<i style='color: darkred' title='{$details['descr']}'>{$details['name']}</i>";
				break;
			}
		}
		
		if(strstr($data, "OK"))
			$cmd .= " &#151; <i style='font-size: 11pt'>done</i>";
			
		return $cmd;
	}
	
	public static function na_value()
	{
		return '<span style="color: darkred">n/a</span>';
	}

	public static function get_package_name($apk, $aapt_path="../aapt")
	{
		$cmd = "{$aapt_path}/aapt dump badging {$apk} | grep package:\ name";

		$code = exec($cmd, $responce);
		preg_match("#package: name='([^']+)#", $responce[0], $res);
		if($res)
			return $res[1];
		
		return false;
	}
	
	public static function human_filesize($size, $unit="") 
	{
	  if( (!$unit && $size >= 1<<30) || $unit == "GB")
		return number_format($size/(1<<30),2)."GB";
	  if( (!$unit && $size >= 1<<20) || $unit == "MB")
		return number_format($size/(1<<20),2)."MB";
	  if( (!$unit && $size >= 1<<10) || $unit == "KB")
		return number_format($size/(1<<10),2)."KB";
	  return number_format($size)." bytes";
	}
	
	public static function human_date($ts)
	{
		if(strstr($ts, " "))
			$ts = strtotime($ts);
			
		if(date("d.m.y", $ts) == date("d.m.y", time()))
			$d = "Today, " . date("H:i", $ts);
		else
			$d = date("d.m.y H:i", $ts);
			
		return $d;
	}

}
 
