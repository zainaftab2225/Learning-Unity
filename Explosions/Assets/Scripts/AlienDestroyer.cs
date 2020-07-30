using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AlienDestroyer : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    Timer explodeTimer;
    Timer explosionAnimationTimer;

    // Start is called before the first frame update
    void Start()
    {
        explodeTimer = gameObject.AddComponent<Timer>();
        explodeTimer.Duration = 1;
        explodeTimer.Run();
        explosionAnimationTimer = gameObject.AddComponent<Timer>();
        explosionAnimationTimer.Duration = 2;
        explosionAnimationTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (explodeTimer.Finished)
        {
            explodeTimer.Run();

            GameObject explosiveAlien = GameObject.FindWithTag("ExplosiveAlien");
            if (explosiveAlien != null)
            {
                Instantiate<GameObject>(prefabExplosion, explosiveAlien.transform.position, Quaternion.identity);
                Destroy(explosiveAlien);
                
            }
        }

        if (explosionAnimationTimer.Finished)
        {
            explosionAnimationTimer.Run();
            GameObject explosionAnimation = GameObject.FindWithTag("ExplosionAnimation");

            if (explosionAnimation != null)
            {
                Destroy(explosionAnimation);
                explosionAnimationTimer.Run();
            }    
        }
    }
}
