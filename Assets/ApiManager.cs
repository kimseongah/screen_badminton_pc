using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class ApiManager : MonoBehaviour
{
    public ServerConfig serverConfig;
    public TextMeshProUGUI code;

    void Start()
    {
        getCode();
    }

    void getCode()
    {
        StartCoroutine(UnityWebRequestGETTest());
    }

    IEnumerator UnityWebRequestGETTest()
    {
        string url = serverConfig.baseUrl + serverConfig.roomApi;

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            code.text = www.downloadHandler.text;
        }
        else
        {
            Debug.Log("error");
        }
    }
}