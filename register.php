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
$sql = "SELECT username FROM test WHERE username = '".$loginUser."'"; //bindValueしてないからややこしい.。変数を''で囲わなければいけない。
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // ユーザーにusernameが既に使われていることを通知
  echo "Username is already taken.";


} else {
    echo "Creating user ...";
    //dbにデータを追加
    $sql2 = "INSERT INTO test (username, password, level, money) VALUES ('".$loginUser."', '".$loginPass."', 1, 0)";
    if ($conn->query($sql2) === TRUE) {
        echo "New record created successfully";
      } else {
        echo "Error: " . $sql2 . "<br>" . $conn->error;
      }
}

$conn->close();

?>