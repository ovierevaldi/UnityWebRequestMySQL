<?php 
    require 'MySQL_ConnectionFile.php';

    $sql = "SELECT Username, Level, Cost FROM users";

    $result = $conn->query($sql);
    
    if (mysqli_num_rows($result) > 0) 
    {
        while ($row = mysqli_fetch_assoc($result)) 
        {
            echo "Username: ". $row['Username']. " Level: ". $row['Level']. " Cost: ". $row['Cost']. "<br>" ;    
        }
    }
    else 
    {
        echo "Error: There's no data in database";
    }

    $conn->close();
?>