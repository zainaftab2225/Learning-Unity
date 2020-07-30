using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newScale = transform.localScale;
        newScale = newScale * 4;
        transform.localScale = newScale;

        if (name == "Player1Front")
        {
            Vector3 newScaleHeight = transform.localScale;
            newScaleHeight.y = newScaleHeight.y * 3;
            transform.localScale = newScaleHeight;
        }
    }
}
