using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class API_Handler : MonoBehaviour
{
    public static API_Handler Singleton;
    [SerializeField]
    private string url = "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";

    public Root RootData { get; private set; }

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else if (Singleton != this || Singleton != this)
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        StartCoroutine(GetJsonObject());
    }
    private IEnumerator GetJsonObject()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }

            var api_data_text = webRequest.downloadHandler.text;
            RootData = JsonConvert.DeserializeObject<Root>(api_data_text);
        }
    }
}
//Json equivalent to C# Object
[System.Serializable]
public class Root
{
    public List<Client> clients = new();
    public Dictionary<string, UserData> data = new();
    public string label;
}
[System.Serializable]
public class Client
{
    public bool isManager;
    public int id;
    public string label;
}

[System.Serializable]
public class UserData
{

    public string address;
    public string name;
    public int points;
}