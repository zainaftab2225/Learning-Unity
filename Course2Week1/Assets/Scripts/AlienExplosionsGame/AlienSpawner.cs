using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{

    List<GameObject> prefabAliens;

    static List<GameObject> listOfGreenAliens;
    static List<GameObject> listOfPurpleAliens;
    static List<GameObject> listOfPinkAliens;

    public static List<GameObject> ListOfGreenAliens
    {
        get
        {
            return listOfGreenAliens;
        }
    }

    public static List<GameObject> ListOfPurpleAliens
    {
        get
        {
            return listOfPurpleAliens;
        }
    }

    public static List<GameObject> ListOfPinkAliens
    {
        get
        {
            return listOfPinkAliens;
        }
    }

    Timer spawnTimer;
    float spawnDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //populating the prefabs
        prefabAliens = new List<GameObject>(3);
        prefabAliens.Add((GameObject)Resources.Load(@"ExplosionPrefabs/Character3"));
        prefabAliens.Add((GameObject)Resources.Load(@"ExplosionPrefabs/Character4"));
        prefabAliens.Add((GameObject)Resources.Load(@"ExplosionPrefabs/Character5"));
        
        //delcaring list of aliens that will spawn
        listOfGreenAliens = new List<GameObject>();
        listOfPurpleAliens = new List<GameObject>();
        listOfPinkAliens = new List<GameObject>();

        //declaring and starting spawner
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnDelay;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //if spawner has finished, spawn an alien
        //restart spawner
        if (spawnTimer.Finished == true)
        {
            spawnAlien();
            spawnTimer.Duration = spawnDelay;
            spawnTimer.Run();
        }
    }

    private void spawnAlien()
    {
        //initialization variables
        int randomSpawner = UnityEngine.Random.Range(0, 3);
        Vector3 spawnLocation = new Vector3(ScreenUtils.ScreenMiddleX, ScreenUtils.ScreenMiddleY);

        //make a random alien and add it to the total list of aliens
        GameObject randomAlien = Instantiate<GameObject>(prefabAliens[randomSpawner], spawnLocation, Quaternion.identity);

        if (randomSpawner == 0)
        {
            listOfGreenAliens.Add(randomAlien);
        }
        else if (randomSpawner == 1)
        {
            listOfPurpleAliens.Add(randomAlien);
        }
        else if (randomSpawner == 2)
        {
            ListOfPinkAliens.Add(randomAlien);
        }
    }
}
