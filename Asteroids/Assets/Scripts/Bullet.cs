using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const int BulletDuration = 2;
    Timer bulletAliveTimer;
    // Start is called before the first frame update
    void Start()
    {
        bulletAliveTimer = gameObject.AddComponent<Timer>();
        bulletAliveTimer.Duration = BulletDuration;
        bulletAliveTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletAliveTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        float impulseForceOfBullet = 20f;
        GetComponent<Rigidbody2D>().AddForce(impulseForceOfBullet * direction, ForceMode2D.Impulse);
    }
}
