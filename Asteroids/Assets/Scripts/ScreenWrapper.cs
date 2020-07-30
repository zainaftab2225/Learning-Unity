using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float colliderRadius;
    // Start is called before the first frame update
    void Start()
    { 
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        UnityEngine.Vector2 position = transform.position;

        if (position.x + colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        else if (position.x - colliderRadius < ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
        }

        if (position.y + colliderRadius > ScreenUtils.ScreenTop)
        {
            position.y *= -1;
        }
        else if (position.y - colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }
        transform.position = position;
        //enabled = false;
    }
}
