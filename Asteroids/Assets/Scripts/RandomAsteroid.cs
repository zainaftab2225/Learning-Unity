using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RandomAsteroid : MonoBehaviour
{

    [SerializeField]
    GameObject prefabExplosion;

    [SerializeField]
    GameObject prefabMeteor;

    SpriteRenderer meteorSprite;
    string spriteName;
    int spriteListSize;
    int randomSelector;
    float angle;
    const float MinImpulseForce = 0.5f;
    const float MaxImpulseForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // add a random sprite to the asteroid
    void SetRandomSprite()
    {
        meteorSprite = gameObject.GetComponent<SpriteRenderer>();
        spriteListSize = AsteroidSpriteList.AsteroidListSize;
        if (spriteListSize != -1)
        {
            randomSelector = UnityEngine.Random.Range(0, spriteListSize);
            meteorSprite.sprite = AsteroidSpriteList.AsteroidSprites[randomSelector];
            spriteName = meteorSprite.sprite.name;
        }
    }

    public void Initialize(Direction direction, Vector2 position)
    {
        // set initial position
        transform.position = position;

        // set random angle based on direction
        float randomAngle = UnityEngine.Random.value * 30f * Mathf.Deg2Rad;
        if (direction == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }


        //push asteroid by force
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && gameObject.GetComponent<SpriteRenderer>().sprite.name == "BigMeteor")
        {
            //play sound
            AudioManager.Play(AudioClipName.AsteroidHit);
            //Instantiate<GameObject>(prefabExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("BigMeteor destroyed.");
            SpriteRenderer spriteMedium = prefabMeteor.GetComponent<SpriteRenderer>();
            for (int i=0; i<AsteroidSpriteList.AsteroidListSize; i++)
            {
                if (AsteroidSpriteList.AsteroidSprites[i].name == "MediumMeteor")
                {
                    spriteMedium.sprite = AsteroidSpriteList.AsteroidSprites[i];
                    break;
                }
            }
            prefabMeteor.GetComponent<SpriteRenderer>().sprite = spriteMedium.sprite;
            GameObject med1 = Instantiate<GameObject>(prefabMeteor, gameObject.transform.position, Quaternion.identity);
            float randomAngle = UnityEngine.Random.Range(0, (float)(Math.PI * 2));
            Vector2 moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            float magnitude = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
            med1.GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
            med1.GetComponent<SpriteRenderer>().sprite.name = "MediumMeteor";
            med1.AddComponent<CircleCollider2D>();
            GameObject med2 = Instantiate<GameObject>(prefabMeteor, gameObject.transform.position, Quaternion.identity);
            float randomAngle2 = UnityEngine.Random.Range(0, (float)(Math.PI * 2));
            Vector2 moveDirection2 = new Vector2(Mathf.Cos(randomAngle2), Mathf.Sin(randomAngle2));
            float magnitude2 = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
            med2.GetComponent<Rigidbody2D>().AddForce(moveDirection2 * magnitude2, ForceMode2D.Impulse);
            med2.GetComponent<SpriteRenderer>().sprite.name = "MediumMeteor";
            med2.AddComponent<CircleCollider2D>();
            Debug.Log("Two Mediums spawned.");
        }

        else if (collision.gameObject.tag == "Bullet" && gameObject.GetComponent<SpriteRenderer>().sprite.name == "MediumMeteor")
        {
            //play sound
            AudioManager.Play(AudioClipName.AsteroidHit);
            //Instantiate<GameObject>(prefabExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("MediumMeteor destroyed.");
            SpriteRenderer spriteMedium = prefabMeteor.GetComponent<SpriteRenderer>();
            for (int i = 0; i < AsteroidSpriteList.AsteroidListSize; i++)
            {
                if (AsteroidSpriteList.AsteroidSprites[i].name == "SmallMeteor")
                {
                    spriteMedium.sprite = AsteroidSpriteList.AsteroidSprites[i];
                    break;
                }
            }
            prefabMeteor.GetComponent<SpriteRenderer>().sprite = spriteMedium.sprite;
            GameObject med1 = Instantiate<GameObject>(prefabMeteor, gameObject.transform.position, Quaternion.identity);
            float randomAngle = UnityEngine.Random.Range(0, (float)(Math.PI * 2));
            Vector2 moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            float magnitude = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
            med1.GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
            med1.AddComponent<CircleCollider2D>();
            GameObject med2 = Instantiate<GameObject>(prefabMeteor, gameObject.transform.position, Quaternion.identity);
            float randomAngle2 = UnityEngine.Random.Range(0, (float)(Math.PI * 2));
            Vector2 moveDirection2 = new Vector2(Mathf.Cos(randomAngle2), Mathf.Sin(randomAngle2));
            float magnitude2 = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
            med2.GetComponent<Rigidbody2D>().AddForce(moveDirection2 * magnitude2, ForceMode2D.Impulse);
            med2.AddComponent<CircleCollider2D>();
            Debug.Log("Two Smalls spawned.");
        }

        else if (collision.gameObject.tag == "Bullet" && gameObject.GetComponent<SpriteRenderer>().sprite.name == "SmallMeteor")
        {
            //play sound
            AudioManager.Play(AudioClipName.AsteroidHit);
            //Instantiate<GameObject>(prefabExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SpriteRenderer spriteMedium = prefabMeteor.GetComponent<SpriteRenderer>();
            for (int i = 0; i < AsteroidSpriteList.AsteroidListSize; i++)
            {
                if (AsteroidSpriteList.AsteroidSprites[i].name == "TinyMeteor")
                {
                    spriteMedium.sprite = AsteroidSpriteList.AsteroidSprites[i];
                    break;
                }
            }
            prefabMeteor.GetComponent<SpriteRenderer>().sprite = spriteMedium.sprite;
            GameObject med1 = Instantiate<GameObject>(prefabMeteor, gameObject.transform.position, Quaternion.identity);
            float randomAngle = UnityEngine.Random.Range(0, (float)(Math.PI * 2));
            Vector2 moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            float magnitude = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
            med1.GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
            med1.AddComponent<CircleCollider2D>();
            GameObject med2 = Instantiate<GameObject>(prefabMeteor, gameObject.transform.position, Quaternion.identity);
            float randomAngle2 = UnityEngine.Random.Range(0, (float)(Math.PI * 2));
            Vector2 moveDirection2 = new Vector2(Mathf.Cos(randomAngle2), Mathf.Sin(randomAngle2));
            float magnitude2 = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
            med2.GetComponent<Rigidbody2D>().AddForce(moveDirection2 * magnitude2, ForceMode2D.Impulse);
            med2.AddComponent<CircleCollider2D>();
        }

        else if (collision.gameObject.tag == "Bullet" && gameObject.GetComponent<SpriteRenderer>().sprite.name == "TinyMeteor")
        {
            //play sound
            AudioManager.Play(AudioClipName.AsteroidHit);
            //Instantiate<GameObject>(prefabExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
