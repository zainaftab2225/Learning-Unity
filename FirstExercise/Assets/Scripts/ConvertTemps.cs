using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertTemps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float originalTemperature = 32;
        float celciusTemperature, farenheitTemperature;
        print("Original Value: " + originalTemperature);
        celciusTemperature = (((originalTemperature - 32) / 9) * 5);
        print("Celcius Value: " + celciusTemperature);
        farenheitTemperature = ((celciusTemperature * 9) / 5) + 32;
        print("Farenheit Value: " + farenheitTemperature);
    }
}