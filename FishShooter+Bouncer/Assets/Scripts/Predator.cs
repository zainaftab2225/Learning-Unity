using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    const float ImpulseForce = 20f;
    Timer changeLayerTimer;
    PredatorManager script;
    // Start is called before the first frame update
    void Start()
    {
        script = Camera.main.GetComponent<PredatorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        // get object position
        Vector3 position = transform.position;


        

        // apply impulse force to get game object moving
        Vector2 direction = new Vector2(0, 1);
        float magnitude = ImpulseForce;
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
        gameObject.layer = LayerMask.NameToLayer("PredatorHitter");

        // instantiate a new one
        GameObject newFishSpawn =Instantiate<GameObject>(gameObject, position, Quaternion.identity);
        Camera.main.GetComponent<PredatorManager>().PredatorFish.Add(newFishSpawn);
        Debug.Log("New Predator fish added to list, total count: " + Camera.main.GetComponent<PredatorManager>().PredatorFish.Count);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Camera.main.GetComponent<PredatorManager>().PredatorFish.Remove(gameObject);
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Debug.Log("Predator fish removed from list, total count: " + Camera.main.GetComponent<PredatorManager>().PredatorFish.Count);
        ScoreScript.scoreValue++;
    }

    private void OnBecameInvisible()
    {
        Camera.main.GetComponent<PredatorManager>().PredatorFish.Remove(gameObject);
        Destroy(gameObject);
        Debug.Log("Predator fish removed from list, total count: " + Camera.main.GetComponent<PredatorManager>().PredatorFish.Count);
    }
}
