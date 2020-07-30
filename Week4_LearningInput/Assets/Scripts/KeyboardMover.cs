using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class KeyboardMover : MonoBehaviour
{

    const float MoveUnitsPerSecond = 5f;
    // Update is called once per frame
    void Update()
    {
        //input using keyboard
        UnityEngine.Vector3 position = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
        }
        if (verticalInput != 0)
        {
            position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;
        }
        transform.position = position;
    }
}
