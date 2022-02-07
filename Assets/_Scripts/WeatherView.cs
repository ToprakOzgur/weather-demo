using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherView : MonoBehaviour
{
    public IconRequest iconRequest;
    public Text temperature;
    public Text time;

    public void InitializeView(Hour hour)
    {
        //icon.sprite =
        temperature.text = $"{hour.temp_c}C / {hour.temp_f}F";
        time.text = $"{hour.time}";
        iconRequest.DownloadIcon(hour.condition.icon);
    }
}
