using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/** Notes :
 * 
 * Newtonsoft.Json has a few issues with unity :/
 * https://stackoverflow.com/questions/71664312/using-unity-plastic-newtonsoft-json-not-found-in-rider
 * https://discussions.unity.com/t/json-newtonsoft-the-type-or-namespace-name-plastic-does-not-exist-in-the-namespace-unity/256898/2
 *
*/

[CreateAssetMenu()]
public class WeatherInfo : ApiInfo
{
    public WeatherData data { get; set; } = null;

    private void Awake()
    {
        if (data is null) Reset();
    }

    public override void Reset()
    {
        this.data = new WeatherData(
            new Location(
                "Villecresnes",
                "Ile-de-France",
                "France",
                48.72,
                2.53,
                "Europe/Paris",
                1688227250,
                "2023-07-01 18:00"
            ),
            new Current(
                1688227200,
                "2023-07-01 18:00",
                24,
                75.2,
                1,
                new Condition(
                    "Partly cloudy",
                    "//cdn.weatherapi.com/weather/64x64/day/116.png",
                    1003
                ),
                17.4,
                27.1,
                260,
                "W",
                1010,
                29.83,
                0,
                0,
                47,
                75,
                25.1,
                77.1,
                10,
                6,
                6,
                11.6,
                18.7,
                new AirQuality(
                    227,
                    3.5999999046325684,
                    64.4000015258789,
                    1.7000000476837158,
                    5.199999809265137,
                    6.099999904632568,
                    1,
                    1
                )
            )
        );
    }

    public void Override(WeatherData data)
    {

    }
}