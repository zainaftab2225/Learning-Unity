using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (name == "Player1Front")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        }
        else if (name == "Player2Front")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
        else if (name == "Player3Front")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Force);
        }
    }
}
