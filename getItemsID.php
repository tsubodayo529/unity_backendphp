<?php

//参考：https://www.w3schools.com/php/php_mysql_select.asp

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

$userID = $_POST["userID"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); //die()で関数から抜け出す.break()みたいなもの
}




$sql = "SELECT itemID FROM usersitems WHERE userID = '".$userID."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  //jsonを使用する
  $rows = array();
  while($row = $result->fetch_assoc()){
      $rows[] = $row; //配列に追加していく
  }
  echo json_encode($rows);
}
else{
    echo "no results.";
}

$conn->close();

?>