using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    const float minX = -8.5f;
    const float maxX = 8.5f;
    const float minY = -4.5f;
    const float maxY = 4.5f;
    const float TotalJumpDelaySeconds = 1;
    float elapsedJumpDelaySeconds = 0;

    // Update is called once per frame
    void Update()
    {
        elapsedJumpDelaySeconds = elapsedJumpDelaySeconds+Time.deltaTime;

        if (elapsedJumpDelaySeconds >= TotalJumpDelaySeconds)
        {
            elapsedJumpDelaySeconds = 0;
            Vector3 newPosition = new Vector3((UnityEngine.Random.Range(minX, maxX)), UnityEngine.Random.Range(minY, maxY));
            transform.position = newPosition;
        }
    }
}
