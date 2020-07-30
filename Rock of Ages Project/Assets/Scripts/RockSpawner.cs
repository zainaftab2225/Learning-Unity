using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabGreenRock;

    [SerializeField]
    GameObject prefabWhiteRock;

    [SerializeField]
    GameObject prefabMagentaRock;

    const int maxRocksOnScreen = 3;
    const float SpawnDelay = 2;
    public int rockCount = 0;
    Timer spawnTimer;

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
        spawnTimer.Duration = SpawnDelay;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished && rockCount<3)
        {
            SpawnRock();

            spawnTimer.Duration = 1;
            spawnTimer.Run();
        }
    }

    void SpawnRock()
    {
        UnityEngine.Vector3 location = new UnityEngine.Vector3(maxSpawnX/2, maxSpawnY/2, -Camera.main.transform.position.z);
        UnityEngine.Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        int spriteNumber = Random.Range(0, 3);

        if (spriteNumber == 0)
        {
            Instantiate<GameObject>(prefabGreenRock, worldLocation, UnityEngine.Quaternion.identity);
        }
        else if (spriteNumber == 1)
        {
            Instantiate<GameObject>(prefabWhiteRock, worldLocation, UnityEngine.Quaternion.identity);
        }
        else if (spriteNumber == 2)
        {
            Instantiate<GameObject>(prefabMagentaRock, worldLocation, UnityEngine.Quaternion.identity);
        }
        rockCount++;
    }


}
