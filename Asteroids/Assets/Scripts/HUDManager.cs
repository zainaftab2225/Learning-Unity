using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    Text TimeSurvivedText;

    float timeSurvived;
    const string TimePrefix = "TIME: ";
    // Start is called before the first frame update
    void Start()
    {
        timeSurvived = 0;
        TimeSurvivedText.text = TimePrefix + timeSurvived.ToString("0.0");
    }

    public void TimeSetter(float timeSurvived)
    {
        this.timeSurvived = timeSurvived;
    }

    public float GetFinalTime()
    {
        return timeSurvived;
    }
    // Update is called once per frame
    void Update()
    {
        //timeSurvived += Time.deltaTime;
        TimeSurvivedText.text = TimePrefix + timeSurvived.ToString("0.0");
    }
}
