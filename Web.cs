using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Web : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        // StartCoroutine(GetDate("http://localhost:8888/php/phptest/getData.php")); //ここに参照するphpURLを入力

        // StartCoroutine(GetUsers("http://localhost:8888/php/phptest/getUsers.php"));
        // StartCoroutine(Login("test2", "test2"));
        // StartCoroutine(Register("test3", "test3"));
        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetDate(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }


    IEnumerator GetUsers(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }

//ログインデータをlogin.phpにPOSTして、結果を返す関数
//参考：https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Networking.UnityWebRequest.Post.html
   public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        //送信するフォームの追加。form変数に内容を追加している
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/php/phptest/login.php", form)) //データをポストしている
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text); //これにすることでlogin.phpの結果を返してるぽい https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Networking.DownloadHandler.html
            }
        }
    }

//ユーザー登録する関数
    public IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        //送信するフォームの追加。form変数に内容を追加している
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/php/phptest/register.php", form)) //データをポストしている
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text); //これにすることでregister.phpの結果を返してるぽい https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Networking.DownloadHandler.html
            }
        }
    }
}
