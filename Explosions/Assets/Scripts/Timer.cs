using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields
    //timer duration
    float totalSeconds = 0;

    //timer execution
    float elapsedSeconds = 0;

    //flags
    bool running = false;
    bool started = false;
    #endregion

    #region Properties

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Running
    {
        get
        {
            return running;
        }
    }

    public bool Finished
    {
        get
        {
            return started && !running;
        }
    }
    #endregion

    

    #region Methods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds = elapsedSeconds + Time.deltaTime;
            if(elapsedSeconds>=totalSeconds)
            {
                running = false;
            }
        }
    }

    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    #endregion
}
