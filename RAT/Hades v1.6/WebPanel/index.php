<?php
session_start();

// Chargement du fichier INI
$load = parse_ini_file("strings.ini");

// Chargement des textes
$error_mdp = $load['error_mdp'];

$form_mdp = $load['form_mdp'];
$form_valid = $load['form_valid'];

$com1 = $load['com1'];
$com2 = $load['com2'];
$com3 = $load['com3'];
$com_header = $load['com_header'];

$header_mdp = $load['header_mdp'];
$header = $load['header'];

$titre = $load['titre'];

if(isset($_POST['mdp']))
{
	$mdp = $_POST['mdp'];
	
	if($mdp == $load['mdp'])
	{
		$_SESSION['valide']['m'] = 1;
	}
	
	else
	{
		$_SESSION['valide']['m'] = 0;
		
		print <<<EOF
			<html>
			<head>
				<link rel="stylesheet" href="design.css" />
				<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<meta name="robots" content="noarchive" />
				
				<title>$titre</title>
			</head>
				
			<body>
				<div id="header">
					$error_mdp
				</div>
EOF;
	}
}

if(isset($_SESSION['valide']['m']) AND $_SESSION['valide']['m'] == 1)
{
	$commande1_fichier = fopen("commandes/commande1.txt", "r+");
	$commande2_fichier = fopen("commandes/commande2.txt", "r+");
	$commande3_fichier = fopen("commandes/commande3.txt", "r+");
	
	$commande1_string = fgets($commande1_fichier);
	$commande2_string = fgets($commande2_fichier);
	$commande3_string = fgets($commande3_fichier);
	
	if(isset($_POST['commande1'], $_POST['commande2'], $_POST['commande3']))
	{
		$commande1 = $_POST['commande1'];
		$commande2 = $_POST['commande2'];
		$commande3 = $_POST['commande3'];
		
		fseek($commande1_fichier, 0); fseek($commande2_fichier, 0); fseek($commande3_fichier, 0);
		
		$commande1_whipe = fopen("commandes/commande1.txt", "w+");
		$commande2_whipe = fopen("commandes/commande2.txt", "w+");
		$commande3_whipe = fopen("commandes/commande3.txt", "w+");
		
		fclose($commande1_whipe); fclose($commande2_whipe); fclose($commande3_whipe);
		
		fputs($commande1_fichier, $commande1); fputs($commande2_fichier, $commande2); fputs($commande3_fichier, $commande3);
		
		fclose($commande1_fichier); fclose($commande2_fichier); fclose($commande3_fichier);
		
		header('Location: index.php');
	}
		
	else
	{
		print <<<EOF
				<html>
				<head>
					<link rel="stylesheet" href="design.css" />
					<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
					<meta name="robots" content="noarchive" />
					
					<title>$titre</title>
				</head>
						
				<body>
					<div id="header">
						<img src="$header" alt="" />
					</div>
					
					<div id="includer">
					
						<div id="bloc">
						
							<div class="header">
								$titre
							</div>
							
							<div class="includer">
								<i>$com_header</i><br />
								<br />
								<form method="post">
									<input type="text" placeholder="$com1" name="commande1" value="$commande1_string" /><br />
									<input type="text" placeholder="$com2" name="commande2" value="$commande2_string" /><br />
									<input type="text" placeholder="$com3" name="commande3" value="$commande3_string" /><br />
									<br />
									<input type="submit" value="$form_valid" />
								</form>
							</div>
							
						</div>
						
					</div>
EOF;
	}
}

else
{
	print <<<EOF
		<html>
		<head>
			<link rel="stylesheet" href="design.css" />
			<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
			<meta name="robots" content="noarchive" />
			
			<title>$titre</title>
		</head>
			
		<body>
			<div id="header">
				<img src="$header_mdp" alt="" /><br />
				<br />
				
				<form method="post">
					<input type="text" name="mdp" placeholder="$form_mdp" /> <input type="submit" value="Valider" />
				</form>
			</div>
EOF;
}