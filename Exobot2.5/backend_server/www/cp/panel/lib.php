<?php

function generate_folder()
{
	$names = array("the","name","of","very","to","through","and","just","a","form","in","much","is","great","it","think","you","say","that","help","he","low","was","line","for","before","on","turn","are","cause","with","same","as","mean","differ","his","move","they","right","be","boy","at","old","one","too","have","does","this","tell","from","sentence","or","set","had","three","by","want","hot","air","but","well","some","also","what","play","there","small","we","end","can","put","out","home","other","read","were","hand","all","port","your","large","when","spell","up","add","use","even","word","land","how","here","said","must","an","big","each","high","she","such","which","follow","do","act","their","why","time","ask","if","men","will","change","way","went","about","light","many","kind","then","off","them","need","would","house","write","picture","like","try","so","us","these","again","her","animal","long","point","make","mother","thing","world","see","near","him","build","two","self","has","earth","look","father","more","head","day","stand","could","own","go","page","come","should","did","country","my","found","sound","answer","no","school","most","grow","number","study","who","still","over","learn","know","plant","water","cover","than","food","call","sun","first","four","people","thought","may","let","down","keep","side","eye","been","never","now","last","find","door","any","between","new","city","work","tree","part","cross","take","since","get","hard","place","start","made","might","live","story","where","saw","after","far","back","sea","little","draw","only","left","round","late","man","run","year","dont","came","while","show","press","every","close","good","night","me","real","give","life","our","few","under","stop","open","ten","seem","simple","together","several","next","vowel","white","toward","children","war","begin","lay","got","against","walk","pattern","example","slow","ease","center","paper","love","often","person","always","money","music","serve","those","appear","both","road","mark","map","book","science","letter","rule","until","govern","mile","pull","river","cold","car","notice","feet","voice","care","fall","second","power","group","town","carry","fine","took","certain","rain","fly","eat","unit","room","lead","friend","cry","began","dark","idea","machine","fish","note","mountain","wait","north","plan","once","figure","base","star","hear","box","horse","noun","cut","field","sure","rest","watch","correct","color","able","face","pound","wood","done","main","beauty","enough","drive","plain","stood","girl","contain","usual","front","young","teach","ready","week","above","final","ever","gave","red","green","list","oh","though","quick","feel","develop","talk","sleep","bird","warm","soon","free","body","minute","dog","strong","family","special","direct","mind","pose","behind","leave","clear","song","tail","measure","produce","state","fact","product","street","black","inch","short","lot","numeral","nothing","class","course","wind","stay","question","wheel","happen","full","complete","force","ship","blue","area","object","half","decide","rock","surface","order","deep","fire","moon","south","island","problem","foot","piece","yet","told","busy","knew","test","pass","record","farm","boat","top","common","whole","gold","king","possible","size","plane","heard","age","best","dry","hour","wonder","better","laugh","true","thousand","during","ago","hundred","ran","am","check","remember","game","step","shape","early","yes","hold","hot","west","miss","ground","brought","interest","heat","reach","snow","fast","bed","five","bring","sing","sit","listen","perhaps","six","fill","table","east","travel","weight","less","language","morning","among");
	
	$new_name = "";
	for($i=0; $i<rand(2,4); $i++)
	{
		$new_name .= $names[array_rand($names)];
	}
	
	return substr($new_name, 0, 15);
}

function get_new_id($dir)
{
	$ids = [];
	foreach(glob("{$dir}config_*.php") as $config_file)
	{
		if(strstr($config_file, "/blank/"))
			continue;
		
		//$data = file_get_contents($cfg);
		
		$out = array();
		exec("php config_loader.php {$config_file}", $out);
		
		$uid = 0;
		foreach($out as $opt)
		{
			if(!strstr($opt, ":"))
				continue;
				
			list($name, $val) = explode(":", $opt);
			if($name == 'UID')
			{
				$uid = $val;
				break;
			}
		}
		$ids[] = $uid;
	}
	
	if(!sizeof($ids))
		return 0;
		
	return max($ids) + 1;
}

function startsWith($haystack, $needle)
{
	$length = strlen($needle);
	return (substr($haystack, 0, $length) === $needle);
}

function endsWith($haystack, $needle)
{
	$length = strlen($haystack)-strlen($needle);
	return (substr($haystack, $length) === $needle);
}
	
function password($len) {
    $alphabet = '%abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890';
    $pass = array(); //remember to declare $pass as an array
    $alphaLength = strlen($alphabet) - 1; //put the length -1 in cache
    for ($i = 0; $i < $len; $i++) {
        $n = rand(0, $alphaLength);
        $pass[] = $alphabet[$n];
    }
    return implode($pass); //turn the array into a string
}

function html_msg($text, $type="info")
{
	return "<div class='ad-notif-{$type} grid_12'><p>{$text}</p></div>";
}

function html_back($text="Back")
{
	return "<div class='grid_12' style='text-align: center'><button type='button' class='button blue' onclick='window.history.back()'>{$text}</button></div>";
}

function file_replace($file, $from, $to)
{
	$d = file_get_contents($file);
	$d = str_replace($from, $to, $d);
	file_put_contents($file, $d);
}





















