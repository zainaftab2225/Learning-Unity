using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse position
        Vector3 position = Input.mousePosition;

        //Transform screen position of mouse into world position
        position = Camera.main.ScreenToWorldPoint(position);
        position.z = -Camera.main.transform.position.z;

        //Set object position to mouse position
        transform.position = position;
    }
}
