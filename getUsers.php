<?php

//参考：https://www.w3schools.com/php/php_mysql_select.asp

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); //die()で関数から抜け出す.break()みたいなもの
}
echo "Connected successfully, now we will show the users.<br><br>";



$sql = "SELECT username, level FROM test";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo " - Username: " . $row["username"]. " - Lv: " . $row["level"]. "<br>";
  }
} else {
  echo "0 results";
}

$conn->close();

?>