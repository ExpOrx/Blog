<?php

function aes_encrypt($input, $key) {
	$size = mcrypt_get_block_size(MCRYPT_RIJNDAEL_128, MCRYPT_MODE_ECB); 
	//$input = Security::pkcs5_pad($input, $size); 
	
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

function aes_decrypt($sStr, $sKey) {
	$decrypted= mcrypt_decrypt(
		MCRYPT_RIJNDAEL_128,
		$sKey, 
		base64_decode($sStr), 
		MCRYPT_MODE_ECB
	);
	$dec_s = strlen($decrypted); 
	$padding = ord($decrypted[$dec_s-1]); 
	$decrypted = substr($decrypted, 0, -$padding);
	return $decrypted;
}	

#echo aes_encrypt("http://192.168.2.144/local/", md5("not-cache")); die;
#echo aes_decrypt("oTAwZx47NH2C/YGzoQmtObSHc9Hwb2BUx05WQgfulfdPtJfwWtK6rnRwJlPRH7kc", md5("not-cache")); die;

echo aes_encrypt($argv[1], md5($argv[2]));
die;




