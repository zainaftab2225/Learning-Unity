using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PredatorManager : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPredatorFish;

    float predatorColliderWidth;
    float predatorColliderHeight;

    List<GameObject> predatorFish;

    public List<GameObject> PredatorFish { get => predatorFish; set => predatorFish = value; }

    // Start is called before the first frame update
    void Start()
    {
        PredatorFish = new List<GameObject>();
        GetPredatorFishDimensions();
        SpawnPredators();
        Debug.Log("Predators after initial spawn: " + PredatorFish.Count);
    }

    void GetPredatorFishDimensions()
    {
        GameObject tempPredator = Instantiate<GameObject>(prefabPredatorFish);
        predatorColliderWidth = prefabPredatorFish.GetComponent<BoxCollider2D>().size.x;
        predatorColliderHeight = prefabPredatorFish.GetComponent<BoxCollider2D>().size.y;
        Destroy(tempPredator);
    }

    void SpawnPredators()
    {   
        float spawnStartPointX = ScreenUtils.ScreenLeft;
        float spawnEndPointX = ScreenUtils.ScreenRight;
        float spawnBottom = ScreenUtils.ScreenBottom + predatorColliderHeight;


        Vector3 spawnNextPoint = new Vector3(spawnStartPointX + predatorColliderWidth / 2, ScreenUtils.ScreenBottom + predatorColliderHeight);
        while (spawnNextPoint.x < ScreenUtils.ScreenRight)
        {
            GameObject currentPredatorFish = Instantiate<GameObject>(prefabPredatorFish, spawnNextPoint, Quaternion.identity);
            PredatorFish.Add(currentPredatorFish);
            spawnNextPoint.x += predatorColliderWidth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (predatorFish.Count == 0)
        {
            ScoreScript.scoreValue = 0;
            SceneManager.LoadScene("FishGame");
        }
    }
}
