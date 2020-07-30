using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        position.x = 1;
        print("I am the best game object! " + name);   
    }
}
