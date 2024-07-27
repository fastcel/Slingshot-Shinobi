using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batmovement : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}

