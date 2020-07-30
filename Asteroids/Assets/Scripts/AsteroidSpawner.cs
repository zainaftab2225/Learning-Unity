using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    float screenWidth;
    float screenHeight;

    Timer spawnTimer;
    const float SpawnDelay = 4;

    float asteroidColliderRadius;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
        //temp asteroid
        GameObject tempAsteroid = Instantiate<GameObject>(prefabAsteroid);
        asteroidColliderRadius = tempAsteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(tempAsteroid);

        //inital 4 asteroids
        InitialSpawn();

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnDelay;
        spawnTimer.Run();
        
    }

    private void InitialSpawn()
    {
        //right asteroid
        GameObject rightAsteroid = Instantiate<GameObject>(prefabAsteroid);
        rightAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Left, new Vector2(ScreenUtils.ScreenRight + asteroidColliderRadius, ScreenUtils.ScreenMiddleY));

        //left asteroid
        GameObject leftAsteroid = Instantiate<GameObject>(prefabAsteroid);
        leftAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Right, new Vector2(ScreenUtils.ScreenLeft - asteroidColliderRadius, ScreenUtils.ScreenMiddleY));

        //up asteroid
        GameObject upAsteroid = Instantiate<GameObject>(prefabAsteroid);
        upAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Down, new Vector2(ScreenUtils.ScreenMiddleX, ScreenUtils.ScreenTop + asteroidColliderRadius));

        //down asteroid
        GameObject downAsteroid = Instantiate<GameObject>(prefabAsteroid);
        downAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Up, new Vector2(ScreenUtils.ScreenMiddleX, ScreenUtils.ScreenBottom - asteroidColliderRadius));
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            int randomDirection = UnityEngine.Random.Range(0, 4);

            if (randomDirection == 0)
            {
                //right asteroid
                GameObject rightAsteroid = Instantiate<GameObject>(prefabAsteroid);
                rightAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Left, new Vector2(ScreenUtils.ScreenRight + asteroidColliderRadius, ScreenUtils.ScreenMiddleY));
            }
            else if (randomDirection == 1)
            {
                //left asteroid
                GameObject leftAsteroid = Instantiate<GameObject>(prefabAsteroid);
                leftAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Right, new Vector2(ScreenUtils.ScreenLeft - asteroidColliderRadius, ScreenUtils.ScreenMiddleY));
            }
            else if (randomDirection == 2)
            {

                //up asteroid
                GameObject upAsteroid = Instantiate<GameObject>(prefabAsteroid);
                upAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Down, new Vector2(ScreenUtils.ScreenMiddleX, ScreenUtils.ScreenTop + asteroidColliderRadius));
            }
            else if (randomDirection == 3)
            {
                GameObject downAsteroid = Instantiate<GameObject>(prefabAsteroid);
                downAsteroid.GetComponent<RandomAsteroid>().Initialize(Direction.Up, new Vector2(ScreenUtils.ScreenMiddleX, ScreenUtils.ScreenBottom - asteroidColliderRadius));
            }

            spawnTimer.Duration = SpawnDelay;
            spawnTimer.Run();
        }
    }
}
