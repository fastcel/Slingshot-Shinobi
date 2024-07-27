using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the pebble hit an enemy
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy the enemy GameObject
            Destroy(gameObject);       // Destroy the pebble GameObject
        }
    }
}
