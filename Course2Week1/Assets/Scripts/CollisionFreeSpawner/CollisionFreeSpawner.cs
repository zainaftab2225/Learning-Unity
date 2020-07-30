using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFreeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabGreenAlien;


    const float SpawnDelay = 0.01f;
    Timer spawnTimer;

    //collision free spawner support variables
    const int MaxSpawnTries = 20;
    float alienColliderHalfWidth;
    float alienColliderHalfHeight;
    Vector2 min = new Vector2();
    Vector2 max = new Vector2();

    // Spawn Location Support
    //const int SpawnBorderSize = 100;
    //int minSpawnX;
    //int maxSpawnX;
    //int minSpawnY;
    //int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        //minSpawnX = SpawnBorderSize;
        //maxSpawnX = Screen.width - SpawnBorderSize;
        //minSpawnY = SpawnBorderSize;
        //maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnDelay;
        spawnTimer.Run();

        //calculate variables for efficiency
        GameObject tempAlien = Instantiate(prefabGreenAlien) as GameObject;
        BoxCollider2D colliderAlien = tempAlien.GetComponent<BoxCollider2D>();
        alienColliderHalfWidth = colliderAlien.size.x / 2;
        alienColliderHalfHeight = colliderAlien.size.y / 2;
        Destroy(tempAlien);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnAlien();

            spawnTimer.Duration = SpawnDelay;
            spawnTimer.Run();
        }
    }

    void SpawnAlien()
    {
        UnityEngine.Vector3 location = new UnityEngine.Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight), Random.Range(ScreenUtils.ScreenBotttom, ScreenUtils.ScreenTop), -Camera.main.transform.position.z);
        //UnityEngine.Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        SetMinMaxOfLocation(location);

        int spawnTries = 1;
        while (Physics2D.OverlapArea(min,max) != null && spawnTries < MaxSpawnTries)
        {
            location = new UnityEngine.Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight), Random.Range(ScreenUtils.ScreenBotttom, ScreenUtils.ScreenTop), -Camera.main.transform.position.z);
            SetMinMaxOfLocation(location);

            spawnTries++;
        }

        if (Physics2D.OverlapArea(min,max) == null)
        { 
            Instantiate<GameObject>(prefabGreenAlien, location, UnityEngine.Quaternion.identity); 
        }
    }

    void SetMinMaxOfLocation(Vector3 location)
    {
        min.x = location.x - alienColliderHalfWidth;
        min.y = location.y - alienColliderHalfHeight;
        max.x = location.x + alienColliderHalfWidth;
        max.y = location.y + alienColliderHalfHeight;
    }
}
