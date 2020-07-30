using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintGamerTag : MonoBehaviour
{
    [SerializeField]
    Text GamerTagText;

    InputField gamertag;

    float secondSinceLastOutput = 0;
    // Start is called before the first frame update
    void Start()
    {
        gamertag = GamerTagText.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        secondSinceLastOutput += Time.deltaTime;
        if (secondSinceLastOutput>1)
        {
            secondSinceLastOutput = 0;
            print(gamertag.text);
            Debug.Log(secondSinceLastOutput);
        }
        
    }
}
