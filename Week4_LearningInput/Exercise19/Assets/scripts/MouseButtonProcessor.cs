using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;

    // first frame input support
    bool spawnInputOnPreviousFrame = false;
	bool explodeInputOnPreviousFrame = false;

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{



        // spawn teddy bear as appropriate
        teddySpawner();
        // explode teddy bear as appropriate
        explodeTeddy();
    }

    void explodeTeddy()
    {
        GameObject teddyBear = GameObject.FindWithTag("TeddyBear");
        if (Input.GetAxis("TeddyBearExploder") > 0)
        {
            if (!explodeInputOnPreviousFrame)
            {
                explodeInputOnPreviousFrame = true;
                UnityEngine.Vector3 explosionPostion = teddyBear.transform.position;
                Destroy(teddyBear);
                Instantiate<GameObject>(prefabExplosion, explosionPostion, UnityEngine.Quaternion.identity);
            }
        }
        else
        {
            explodeInputOnPreviousFrame = false;
        }
    }

    void teddySpawner()
    {
        UnityEngine.Vector3 mousePositionScreen = Input.mousePosition;
        UnityEngine.Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        mousePositionWorld.z = -Camera.main.transform.position.z;

        if (Input.GetAxis("TeddyBearSpawner") > 0)
        {
            if (!spawnInputOnPreviousFrame)
            {
                spawnInputOnPreviousFrame = true;
                Instantiate<GameObject>(prefabTeddyBear, mousePositionWorld, UnityEngine.Quaternion.identity);
            }
        }
        else
        {
            spawnInputOnPreviousFrame = false;
        }
    }
}
