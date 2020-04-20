<?php 
include 'config.php';

   $connection = new PDO('mysql:host='.SERVER.';dbname='.DB, USER, PASSWORD);
   $connection->exec('SET NAMES utf8');       
   $sql = "SELECT * FROM kliets";
   

  echo '<table border="1">';
  echo '<thead>';
  echo '<tr>';
  echo '<th>id</th>';
  echo '<th>IMEI</th>';
  echo '<th>country</th>';
  echo '</tr>';
  echo '</thead>';
  echo '<tbody>';
  foreach($connection->query($sql) as $row)
		{
  
    echo '<tr>';
    echo '<td>' . $row['id'] . '</td>';
    echo '<td>' . $row['IMEI'] . '</td>';
    echo '<td>' . $row['country'] . '</td>';
    echo '</tr>';
  }
  
    echo '</tbody>';
  echo '</table>';
?>