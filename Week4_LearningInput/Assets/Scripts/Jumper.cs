using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    Vector3 mouseClickPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickPosition = Input.mousePosition;
            mouseClickPosition.z = -Camera.main.transform.position.z;
            mouseClickPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);

            transform.position = mouseClickPosition;
        }


    }
}
