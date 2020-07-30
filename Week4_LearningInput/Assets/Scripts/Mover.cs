using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Mover : MonoBehaviour
{
    bool mouseMoves = false;
    const float MoveUnitsPerSecond = 5f;
    const float MouseFixSpeed = 5f;



    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        //KEYBOARD AND MOUSE BOTH INPUT
        UnityEngine.Vector3 position = transform.position;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float[] listOfMovers = { mouseX, mouseY, horizontal, vertical };

        for (int i =0; i< listOfMovers.Length; i++)
        {
            if (listOfMovers[0]!= 0 || listOfMovers[1] != 0)
            {
                mouseMoves = true;
                position.x = position.x + listOfMovers[0] * MoveUnitsPerSecond * MouseFixSpeed * Time.deltaTime;
                position.y = position.y + listOfMovers[1] * MoveUnitsPerSecond * MouseFixSpeed * Time.deltaTime;
            }
            else if (listOfMovers[2] != 0 || listOfMovers[3] !=0 && !mouseMoves)
            {
                position.x = position.x + listOfMovers[2] * MoveUnitsPerSecond * Time.deltaTime;
                position.y = position.y + listOfMovers[3] * MoveUnitsPerSecond * Time.deltaTime;
            }
            else
            {
                mouseMoves = false;
            }
        }
        transform.position = position;
        //convert mouse position to world position
        //UnityEngine.Vector3 screentoWorldPosition = Input.mousePosition;
        //screentoWorldPosition.z = -Camera.main.transform.position.z;
        //screentoWorldPosition = Camera.main.ScreenToWorldPoint(screentoWorldPosition);
        //transform.position = screentoWorldPosition;
    }
}
