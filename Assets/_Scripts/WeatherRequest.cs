using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherRequest : MonoBehaviour
{
    readonly string getURL = "http://api.weatherapi.com/v1/forecast.json?key=898147f83a734b7dbaa95705211612&q=Berlin&days=3&aqi=no&alerts=no";

    private void Start()
    {

        StartCoroutine(MakeNetworkRequest());

        IEnumerator MakeNetworkRequest()
        {
            var request = UnityWebRequest.Get(getURL);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var weather = JsonConvert.DeserializeObject<WeatherResponse>(request.downloadHandler.text);
                Debug.Log(weather.current.temp_c);
            }
        }
    }
}
