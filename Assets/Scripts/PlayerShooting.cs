using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject pebblePrefab;  // The pebble prefab
    public Transform shootPoint;     // The point from where the pebble will be shot
    public float shootForce = 10f;   // The force with which the pebble will be shot
    public float shootInterval = 20f; // Time interval between shots
    public string enemyTag = "Enemy"; // Tag assigned to enemies

    private float shootTimer;

    void Update()
    {
        // Check if enough time has passed to shoot another pebble
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        // Find the closest enemy
        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy == null) return; // If no enemy is found, exit

        // Calculate shooting direction towards the closest enemy
        Vector2 shootingDirection = (closestEnemy.transform.position - shootPoint.position).normalized;

        // Instantiate the pebble at the shoot point
        GameObject pebble = Instantiate(pebblePrefab, shootPoint.position, shootPoint.rotation);

        // Get the Rigidbody component of the pebble and apply force in the calculated direction
        Rigidbody2D rb = pebble.GetComponent<Rigidbody2D>();
        rb.velocity = shootingDirection * shootForce;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(shootPoint.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
