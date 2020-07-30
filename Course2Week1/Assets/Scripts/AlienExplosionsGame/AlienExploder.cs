using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AlienExploder : MonoBehaviour
{
    List<GameObject> allExplosions = new List<GameObject>();
    bool removeAtPreviousFrame = false;
    Timer explosionAnimationTimer;
    // Start is called before the first frame update
    void Start()
    {
        explosionAnimationTimer = gameObject.AddComponent<Timer>();
        explosionAnimationTimer.Duration = 2;
        explosionAnimationTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("BlowUpGreen") > 0)
        {
            if (AlienSpawner.ListOfGreenAliens.Count != 0)
            {
                if (removeAtPreviousFrame == false)
                {
                    GameObject greenAlien = AlienSpawner.ListOfGreenAliens[0];
                    AlienSpawner.ListOfGreenAliens.RemoveAt(0);
                    Vector3 alienLocation = greenAlien.transform.position;
                    Destroy(greenAlien);
                    removeAtPreviousFrame = true;
                    allExplosions.Add(Instantiate<GameObject>((GameObject)Resources.Load(@"ExplosionPrefabs/ExplosionAnimation"), alienLocation, Quaternion.identity));
                   
                }
            }
        }
        else
        {
            removeAtPreviousFrame = false;
        }

        if (Input.GetAxis("BlowUpPurple") > 0)
        {
            if (AlienSpawner.ListOfPurpleAliens.Count != 0)
            {
                if (removeAtPreviousFrame == false)
                {
                    GameObject purpleAlien = AlienSpawner.ListOfPurpleAliens[0];
                    AlienSpawner.ListOfPurpleAliens.RemoveAt(0);
                    Vector3 alienLocation = purpleAlien.transform.position;
                    Destroy(purpleAlien);
                    removeAtPreviousFrame = true;
                    allExplosions.Add(Instantiate<GameObject>((GameObject)Resources.Load(@"ExplosionPrefabs/ExplosionAnimation"), alienLocation, Quaternion.identity));
                }
            }
        }
        else
        {
            removeAtPreviousFrame = false;
        }

        if (Input.GetAxis("BlowUpPink") > 0)
        {
            if (AlienSpawner.ListOfPinkAliens.Count != 0)
            {
                if (removeAtPreviousFrame == false)
                {
                    GameObject pinkAlien = AlienSpawner.ListOfPinkAliens[0];
                    AlienSpawner.ListOfPinkAliens.RemoveAt(0);
                    Vector3 alienLocation = pinkAlien.transform.position;
                    Destroy(pinkAlien);
                    removeAtPreviousFrame = true;
                    allExplosions.Add(Instantiate<GameObject>((GameObject)Resources.Load(@"ExplosionPrefabs/ExplosionAnimation"), alienLocation, Quaternion.identity));
                }
            }
        }
        else
        {
            removeAtPreviousFrame = false;
        }

        if (explosionAnimationTimer.Finished)
        {
            explosionAnimationTimer.Run();
            foreach (GameObject explosion in allExplosions)
            {
                Destroy(explosion);

            }
        }
    }
}
