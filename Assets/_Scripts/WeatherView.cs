using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherView : MonoBehaviour
{
    [SerializeField] private IconRequest iconRequest;
    [SerializeField] private Text temperature;
    [SerializeField] private Text time;

    public void InitializeView(Hour hour)
    {
        temperature.text = $"{hour.temp_c}C / {hour.temp_f}F";
        time.text = $"{hour.time}";
        iconRequest.DownloadIcon(hour.condition.icon);
    }
}
