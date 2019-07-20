using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());      
    }

    IEnumerator GetText()
    {
        using(UnityWebRequest www = 
            UnityWebRequest.Get("https://shiplightsstudio.000webhostapp.com/UnityWebServiceMySQL/HelloWorld.php"))
        {
            yield return www.Send();

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
}
