using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithJoystick : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick;

    void Update()
    {
        Vector2 input = joystick.InputVector;
        Vector3 move = new Vector3(input.x, input.y, 0);
        transform.position += move * speed * Time.deltaTime;

        // Update the player's facing direction
        //if (move != Vector3.zero)
        //{
        //    float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg - 90f; // Adjusted angle to align with the sprite direction
        //    transform.rotation = Quaternion.Euler(0, 0, angle);
        //}
    }
}