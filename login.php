<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity";

//variables submitted by user
//web.cs側でPOSTされたデータを受け取る
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); //die()で関数から抜け出す.break()みたいなもの
}



//loginuserがusernameと一致した場合のみ
$sql = "SELECT password, level FROM test WHERE username = '".$loginUser."'"; //bindValueしているからややこしい
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    // echo " - Username: " . $row["username"]. " - Lv: " . $row["level"]. "<br>";
    //Passwordが一致しているかの確認
    if($row["password"] == $loginPass){
        //Username と Passwordがどちらも一致していた場合
        echo "login Success.";
        //Get User's data.
    }
    else{
        echo "Wrong Credentials!";
    }
  }
} else {
  echo "Username does not exists.";
}

$conn->close();

?>