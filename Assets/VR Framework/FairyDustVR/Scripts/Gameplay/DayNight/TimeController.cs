using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    [SerializeField] private float timeMultiplier; //Controls how fast the day progresses
    [SerializeField] private float startHour; //What time of day we want the game to start out (day)

    //Variables that will control the sunrise and sunset hours
    [SerializeField] private Light sunLight;
    [SerializeField] private float sunriseHour;
    [SerializeField] private float sunsetHour;

    //Keep track of the time in game
    private DateTime currentTime;
    
    //TimeSpan controls for sunrise and sunset
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;
    
    //Ambient Colour for moonlight and sunlight
    [SerializeField] private Color dayAmbLight;
    [SerializeField] private Color nightAmbLight;

    [SerializeField] private AnimationCurve lightChange;
    [SerializeField] private Light moonLight;
    
    //Maximum daylight
    [SerializeField] private float maxSunIntensity;
    [SerializeField] private float maxMoonIntensity;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    /// <summary>
    /// This method will track how much time has passed in game.
    /// </summary>
    private void UpdateTimeOfDay()
    {
        //Time updating
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
    }

    private void RotateSun()
    {
        float sunlightRot;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunlightRot = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunrise = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetToSunrise, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunrise.TotalMinutes;

            sunlightRot = Mathf.Lerp(180, 360,(float)percentage);
        }
        
        //Rotate the sun
        sunLight.transform.rotation = Quaternion.AngleAxis(sunlightRot, Vector3.right);
    }

    /// <summary> This method will control changing the direction of the sun. </summary>
    private TimeSpan CalculateTimeDifference(TimeSpan _fromTime, TimeSpan _toTime)
    {
        TimeSpan difference = _toTime - _fromTime;

        //If the difference is negative, then two times overlap, so add 24 hours difference
        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }

    private void UpdateLightSettings()
    {
        //Adjust intensity of the sun, calculate dot product of down direction of sunlight and moonlight
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunIntensity, lightChange.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonIntensity, 0, lightChange.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbLight, dayAmbLight, lightChange.Evaluate(dotProduct));
    }
    
}
