using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    int health;

    AudioSource teddyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        teddyAudioSource = gameObject.GetComponent<AudioSource>();
        //health initialized
        health = 100;
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().setHP(health);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new UnityEngine.Vector2(3,3), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        teddyAudioSource.Play();
        health -= 10;
        GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().setHP(health);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color -= new Color(0, 0, 0, 0.1f);
        Debug.Log(health);
        if (health<=0)
        {
            UnityEngine.Vector2 position = transform.position;
            Instantiate<GameObject>(prefabExplosion, position, UnityEngine.Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
