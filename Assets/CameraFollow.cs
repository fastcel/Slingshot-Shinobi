using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform

    void LateUpdate()
    {
        if (player != null)
        {
            // Lock the camera's position to the player's position
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        else
        {
            Debug.LogWarning("Player transform is not assigned.");
        }
    }
}
