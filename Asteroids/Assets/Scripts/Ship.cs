using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    [SerializeField]
    GameObject prefabLaser;

    const float ThrustForce = 2f;
    const float RotateDegreesPerSecond = 170f;

    Rigidbody2D shipRigidBody;
    UnityEngine.Vector2 thrustDirection;
    float maxSpeed = 10f;

    //for HUD support
    public float surviveTimer;
    HUDManager hudReference;
    // Start is called before the first frame update
    void Start()
    {
        hudReference = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDManager>();
        surviveTimer = 0;
        //hudReference.TimeSetter(surviveTimer);
        shipRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        surviveTimer += Time.deltaTime;
        hudReference.TimeSetter(surviveTimer);
        //Debug.Log(surviveTimer);
        //OnBecameInvisible();

        ShipRotations();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate<GameObject>(prefabLaser, transform.position, UnityEngine.Quaternion.identity);
            AudioManager.Play(AudioClipName.PlayerShot);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
        }
        
    }

    void ShipRotations()
    {
        float rotationInput = Input.GetAxis("Rotate");
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        if (rotationInput != 0)
        {
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
                transform.Rotate(UnityEngine.Vector3.forward, rotationAmount);
                thrustDirection = transform.eulerAngles;

            }
            else if (rotationInput > 0)
            {
                transform.Rotate(UnityEngine.Vector3.forward, rotationAmount);
            }
        }

        UnityEngine.Vector3 anglesInDegrees = transform.eulerAngles;
        float angleZRadians = anglesInDegrees.z * Mathf.Deg2Rad;
        thrustDirection = new UnityEngine.Vector2(Mathf.Cos(angleZRadians), Mathf.Sin(angleZRadians));
        //Debug.Log("Direction changed to: " + thrustDirection);
    }

    // FixedUpdate is used for physics-based updates
    // Applying a force to the Ship game object when user presses 'Space'
    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            
            UnityEngine.Vector3 finalForce = ThrustForce * thrustDirection;    
            shipRigidBody.AddForce(finalForce, ForceMode2D.Force);
            if (shipRigidBody.velocity.magnitude > maxSpeed)
            {
                shipRigidBody.velocity = shipRigidBody.velocity.normalized * maxSpeed;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Asteroid")
        {
            FinalSurviveTime.SurviveTime = surviveTimer;
            Instantiate(prefabExplosion, transform.position, UnityEngine.Quaternion.identity);
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //void OnCollisionExit2D(Collision2D other)
    //{
    //    GetComponent<Rigidbody2D>().freezeRotation = true;
    //}
}
