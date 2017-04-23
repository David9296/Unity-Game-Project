<?php


echo "HelloWorld"
$HostName = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "";

$Email = $_REQUEST["Email"];
$potion = $_REQUEST["Potion"];
$Score = $_REQUEST["Score"];
echo mysql_error();

mysql_connect($HostName,$User,$PasswordP) or die("Cant Connect to DB");
mysql_select_db($DBName) or die ("Cant connect to DB");

echo $Email;
echo $Score;
echo $potion;
	
	$SQL = "UPDATE `accounts` SET `Potion` = '".$potion."' , `Score` = '".$Score."'  WHERE Email = '" .$Email. "'"; 
	echo $potion;
	$SQL1 = mysql_query($SQL);
		
			
			
echo mysql_error();
	mysql_close();
?>