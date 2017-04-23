<?php

$Email = $_REQUEST("Email");
$Password = $_REQUEST("Password");

$HostName = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "";

mysql_connect($HostName,$User,$PasswordP) or die("Cant Connect to DB");
mysql_select_db($DBName) or die ("Cant connect to DB");

if(!$Email || !$Password){
	echo "Empty";
}

else{
		$SQL = "SELECT  * FROM accounts WHERE Email = '" .$Email. "'"; 
		$Result = @mysql_query($SQL) or die ("DB ERROR");
		$Total = mysql_num_rows($Result);
		if($Total == 0){
			$insert = "INSERT INTO 'accounts' ('Email', 'Password')VALUES (' " .$Email. "' , MD5('" .$Password. "'))";
			$SQL1 = mysql_query($insert);
			echo "Success";
		}
		else{
			echo "AlreadyUSED";
			
		}
		
		
		
	}

	mysql_close();
?>