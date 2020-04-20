<?php
	//*************************************
	function encrypt($string, $key) //шифрование траффа логов
	{	
		$str = urlencode($string);
		$ret = "";
		for($i=0; $i<mb_strlen($str); $i++)
		{
			$r1 = ord(mb_substr($str, $i, 1));
			$ret  = "$ret $r1";
		}
	
		for($i=0; $i<mb_strlen($key); $i++)
		{
			$ret = str_replace($i, mb_substr($key, $i, 1), $ret);
		}
		$ret = mb_substr($ret, 1, mb_strlen($ret)); //!
		return $ret;
	}
	
	function decrypt($string, $key)
	{
		$ret = $string;
		$ret = mb_substr($ret, 0, mb_strlen($ret)); //!
		
		for($i=0; $i<mb_strlen($key); $i++)
		{
			$ret = str_replace(mb_substr($key, $i, 1), $i, $ret);
		}
		$massivRet = explode(" ", $ret);
		
		$ret="";
		foreach($massivRet as $massivR)
		{
			$r1 = chr($massivR);
			$ret = "$ret$r1";
		}
		$str = urldecode($ret);
		return $str;
	}
?>