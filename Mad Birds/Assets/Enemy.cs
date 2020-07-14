﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudParticlePrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y < 0)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        if (collision.contacts[0].normal.x > 0.5 || collision.contacts[0].normal.x < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
            
    }
}