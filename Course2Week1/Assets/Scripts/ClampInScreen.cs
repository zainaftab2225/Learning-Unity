using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampInScreen : MonoBehaviour
{

    float colliderHalfWidth;
    float colliderHalfHeight;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = boxCollider.size.x / 2;
        colliderHalfHeight = boxCollider.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        clampByMath();
    }

    void clampByMath()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, ScreenUtils.ScreenLeft + colliderHalfWidth, ScreenUtils.ScreenRight - colliderHalfWidth);
        position.y = Mathf.Clamp(position.y, ScreenUtils.ScreenBotttom + colliderHalfHeight, ScreenUtils.ScreenTop - colliderHalfHeight);
        transform.position = position;
    }

    Vector3 ClampManual(UnityEngine.Vector3 position)
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
