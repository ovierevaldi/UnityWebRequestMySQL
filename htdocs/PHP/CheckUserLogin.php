<?php 
	# Include connection file to connect the databases
	require 'MySQL_ConnectionFile.php';

	$username = $_POST["usernamePOST"];
	$password = $_POST["passwordPOST"];

	$sql = "SELECT Password FROM users WHERE Username = '".$username."'";
	$result = mysqli_query($conn, $sql);

	if ($result) 
	{
		if (mysqli_num_rows($result) > 0) 
		{
			while ($row = mysqli_fetch_assoc($result)) 
			{
				if ($row['Password'] == $password) 
				{
					echo "Login Success";
				}
				else
				{
					echo "Wrong Password";
				}
			}
		}
		else
		{
			echo "Username not found";
		}	
	}
	else
	{
		echo "There's an error in sql command";
	}
	$conn->close();
 ?>