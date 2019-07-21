<?php
    require 'MySQL_ConnectionFile.php';

    $username = $_POST['usernamePOST'];
    $password = $_POST['passwordPOST'];
    $defaulLevelValue = 1;
    $defaultCostValue = 50;

    $sql = "SELECT Username FROM users WHERE Username = '".$username."' ";
    $result = mysqli_query($conn, $sql);

    if($result)
    {
        if(mysqli_num_rows($result) > 0)
        {
            echo "Username is already taken";
        }

        else
        {
            echo "Creating User...";
        
            $sql2 = "INSERT INTO users (Username, Password, Level, Cost) VALUES 
            ('".$username."', '".$password."', '".$defaulLevelValue."', '".$defaultCostValue."')";

            $result2 = mysqli_query($conn,$sql2);

            if ($result2) 
            {
                echo "New record succecfully created";
            }

            else 
            {
                echo "Error Creating User: " . $sql2 . "<br>" . $conn->error();   
            }
        }
    }

    else
    {
        echo "There's an error in SQL Command";
    }

    

    $conn->close();
?>