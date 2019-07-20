<?php
    $serverName = "localhost";
    $serverUsername = "id10230813_ebrahimerik";
    $serverPassword = "revaldi10";
    $serverDatabase = "id10230813_unitywebrequest";

    $conn = mysqli_connect($serverName, $serverUsername, $serverPassword, $serverDatabase);

    if (!$conn) 
	{
		die("Connection to database failed. ". mysqli_connect_error());
    }
    else
    {
        echo "Connection Succesfull";
    }
?>