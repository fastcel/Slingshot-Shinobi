using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    // Call this method when the player dies
    public void OnPlayerDeath()
    {
        gameOverPanel.SetActive(true);
    }

    // This method is called by the Start Again button
    public void RestartGame()
    {
        // Assuming your game scene is the first scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
