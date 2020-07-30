using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AlienSpawner1 : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAlien;

    [SerializeField]
    Sprite alienObject0;

    [SerializeField]
    Sprite alienObject1;

    [SerializeField]
    Sprite alienObject2;

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
        GameObject alien = Instantiate(prefabAlien) as GameObject;
        alien.transform.position = worldLocation;

        SpriteRenderer alienSpriteRenderer = alien.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0,3);

        if (spriteNumber == 0)
        {
            alienSpriteRenderer.sprite = alienObject0;
        }
        else if (spriteNumber == 1)
        {
            alienSpriteRenderer.sprite = alienObject1;
        }
        else if (spriteNumber == 2)
        {
            alienSpriteRenderer.sprite = alienObject2;
        }
    }
}
