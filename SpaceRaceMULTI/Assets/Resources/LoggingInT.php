<?php
$Email = $_REQUEST["Email"];
$Password = $_REQUEST["Password"];

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
		$SQL1 = "SELECT  * FROM accounts WHERE Email = '" . $Email . "'"; 
	
		$result_id = @mysql_query($SQL1) or die ("DB ERROR");
		
		$total = mysql_num_rows($result_id);
		echo $total;
		if($total){
			$datas = @mysql_fetch_array($result_id);
			
			if(strcmp($Password,$datas["Password"])){
				$sql2 = "SELECT Characters FROM accounts WHERE Email = '" .$Email. "'";
				
				$result_id2 = @mysql_query($sql2) or die ("DATABASE Error!");
				
				while($row = mysql_fetch_array($result_id2))
				{
					echo $row['Characters'];
					echo ":";
					echo "Success";
				}
				
			
		}
		else{
			echo "Wrong Password";
			
		}
		}else {
			
			echo "EmailDoesNotExist";
		}
		}
		
echo mysql_error();
	mysql_close();
?>