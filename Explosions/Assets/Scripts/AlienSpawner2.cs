using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AlienSpawner2 : MonoBehaviour
{
    [SerializeField]
    GameObject prefabGreenAlien;

    [SerializeField]
    GameObject prefabPurpleAlien;

    [SerializeField]
    GameObject prefabPinkAlien;


    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    // Spawn Location Support
    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnAlien();

            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnAlien()
    {
        UnityEngine.Vector3 location = new UnityEngine.Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
        UnityEngine.Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        int spriteNumber = Random.Range(0, 3);

        if (spriteNumber == 0)
        {
            Instantiate<GameObject>(prefabGreenAlien, worldLocation, UnityEngine.Quaternion.identity);
        }
        else if (spriteNumber == 1)
        {
            Instantiate<GameObject>(prefabPurpleAlien, worldLocation, UnityEngine.Quaternion.identity);
        }
        else if (spriteNumber == 2)
        {
            Instantiate<GameObject>(prefabPinkAlien, worldLocation, UnityEngine.Quaternion.identity);
        }
    }
}
