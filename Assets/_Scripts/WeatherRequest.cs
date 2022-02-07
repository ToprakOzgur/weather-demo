using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherRequest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MakeNetworkRequest());
    }

    IEnumerator MakeNetworkRequest()
    {
        var request = UnityWebRequest.Get(Constants.getURL);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request?.error);
        }
        else
        {
            var weather = JsonConvert.DeserializeObject<WeatherResponse>(request.downloadHandler.text);
            UIManager.Instance.RefreshUI(weather);
        }
    }
}
