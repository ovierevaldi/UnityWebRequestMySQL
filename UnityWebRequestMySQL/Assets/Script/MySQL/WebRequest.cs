using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /* Test Hello World from PHP File*/
        StartCoroutine(TestHelloWorld());

        /* Test read user data from PHP file*/
        StartCoroutine(GetUserInfo());

        /* Test Login User from PHP file with registered user*/
        StartCoroutine(CheckUserLogin("Ebrahim", "123456"));
    }

    IEnumerator TestHelloWorld()
    {
        using(UnityWebRequest www = 
            UnityWebRequest.Get("https://shiplightsstudio.000webhostapp.com/UnityWebServiceMySQL/HelloWorld.php"))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                /* Show Result as Text */
                Debug.Log(www.downloadHandler.text);

                /* Or retrieve results as binary data*/
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator GetUserInfo()
    {
        using(UnityWebRequest www = UnityWebRequest.Get("https://shiplightsstudio.000webhostapp.com/UnityWebServiceMySQL/ReadAllDataFromMySQL.php"))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                /* Show the result as text */
                Debug.Log(www.downloadHandler.text);

                /* Or Retrieve results as binary data*/
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator CheckUserLogin(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePOST", username);
        form.AddField("passwordPOST", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://shiplightsstudio.000webhostapp.com/UnityWebServiceMySQL/CheckUserLogin.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                /* Show the result as text */
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
