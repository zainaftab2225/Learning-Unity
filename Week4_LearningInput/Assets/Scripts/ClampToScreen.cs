using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    float colliderHalfWidth;
    float colliderHalfHeight;

    const float MoveUnitsPerSecond = 5f;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider.size.x/ 12;
        colliderHalfHeight = collider.size.y / 12;
    }

    // Update is called once per frame
    void Update()
    {
        clampByMath();
    }


    void clampByMath()
    {
        UnityEngine.Vector3 position = new UnityEngine.Vector3(Mathf.Clamp(transform.position.x, ScreenUtils.ScreenLeft + colliderHalfWidth, ScreenUtils.ScreenRight - colliderHalfWidth), 
            Mathf.Clamp(transform.position.y, ScreenUtils.ScreenBotttom + colliderHalfHeight, ScreenUtils.ScreenTop - colliderHalfHeight));
        transform.position = position;
    }

    UnityEngine.Vector3 ClampInScreen(UnityEngine.Vector3 position)
    {

        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        
        if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBotttom)
        {
            position.y = ScreenUtils.ScreenBotttom + colliderHalfHeight;
        }

        return position;
    }
}
