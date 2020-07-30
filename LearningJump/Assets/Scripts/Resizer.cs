using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    const float TotalResizeSeconds = 1;
    const float ScaleFactorPerSecond = 1;
    float elapsedResizeSeconds = 0;
    int scaleFactorSizeMultiplier = 1;

    // Update is called once per frame
    void Update()
    {

        elapsedResizeSeconds = elapsedResizeSeconds + Time.deltaTime;
        if (elapsedResizeSeconds >= TotalResizeSeconds)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = newScale.x + ScaleFactorPerSecond * scaleFactorSizeMultiplier;
            newScale.y = newScale.y + ScaleFactorPerSecond * scaleFactorSizeMultiplier;
            scaleFactorSizeMultiplier = scaleFactorSizeMultiplier * -1;
            transform.localScale = newScale;
            elapsedResizeSeconds = 0;  
        } 
    }
}
