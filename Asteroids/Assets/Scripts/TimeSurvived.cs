using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSurvived : MonoBehaviour
{
    [SerializeField]
    Text TimeSurvivedText;

    float timeSurvived;
    const string TimePrefix = "Time Survived: ";
    // Start is called before the first frame update
    void Start()
    {
        timeSurvived = FinalSurviveTime.SurviveTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSurvivedText.text = TimePrefix + timeSurvived.ToString("0.0");
    }
}
