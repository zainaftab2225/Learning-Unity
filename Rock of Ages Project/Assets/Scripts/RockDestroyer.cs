using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroyer : MonoBehaviour
{

    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject rock = GameObject.FindWithTag("RockTag");

        if (rock != null)
        {
            Vector3 rockInScreenPosition = cam.WorldToScreenPoint(rock.transform.position);
            if (rockInScreenPosition.x > cam.pixelWidth || rockInScreenPosition.x < 0 || rockInScreenPosition.y > cam.pixelHeight || rockInScreenPosition.y < 0)
            {
                Destroy(rock);
                GetComponent<RockSpawner>().rockCount--;
            }
        }
    }
}
