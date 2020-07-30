using System;
using UnityEngine;

public class AlienCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float minForce = 2f;
        float maxForce = 5f;
        float angle = UnityEngine.Random.Range(0, (float)(2 * Math.PI));
        float magnitude = UnityEngine.Random.Range(minForce, maxForce);
        Vector3 direction = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OUCH!");
    }
}
