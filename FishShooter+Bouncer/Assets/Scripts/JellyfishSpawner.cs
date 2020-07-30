using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JellyfishSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject prefabJellyfish;

    float jellyfishColliderHeight;

    float spawnDelay = 1f;
    Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        GetJellyfishColliderHeight();

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnDelay;
        spawnTimer.Run();
    }

    void GetJellyfishColliderHeight()
    {
        //get jellyfish collider height
        GameObject tempJellyfish = Instantiate<GameObject>(prefabJellyfish);
        jellyfishColliderHeight = tempJellyfish.GetComponent<BoxCollider2D>().size.y;
        Destroy(tempJellyfish);
    }


    void Spawn()
    {
        if (spawnTimer.Finished)
        {
            float randomXPosition = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
            Vector3 position = new Vector3(randomXPosition, ScreenUtils.ScreenTop + jellyfishColliderHeight);
            GameObject jellyboy = Instantiate<GameObject>(prefabJellyfish, position, Quaternion.identity);

            spawnTimer.Duration = spawnDelay;
            spawnTimer.Run();
        }
    }
    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
}
