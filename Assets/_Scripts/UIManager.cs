using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private WeatherView weatherViewPrefab;
    [SerializeField] private GameObject listView;

    private void Awake()
    {
        Instance = this;
    }
    public void RefreshUI(WeatherResponse weatherResponse)
    {
        for (int i = 0; i < weatherResponse.forecast.forecastday.Count; i++)
        {
            var forecastday = weatherResponse.forecast.forecastday[i];
            CreateDay(forecastday);
        }

    }
    private void CreateDay(Forecastday forecastday)
    {
        for (int i = 0; i < forecastday.hour.Count; i++)
        {
            var hour = forecastday.hour[i];

            var weather = GameObject.Instantiate(weatherViewPrefab);
            weather.transform.parent = listView.transform;
            weather.GetComponent<RectTransform>().localScale = Vector3.one;

            weather.InitializeView(hour);
        }

    }
}
