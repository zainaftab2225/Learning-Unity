using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Percentage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        const int MaxScore = 100;
        int score = 45;
        float percentage = ((float)score / MaxScore)*100;
        print("Percentage is " + percentage + "%");
    }
}
