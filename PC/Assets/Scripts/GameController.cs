using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalEnemies;
    public int playerHealth = 100;
    private int currentLevel = 1;

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void EnemyDefeated()
    {
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            if (currentLevel == 1)
            {                
                SceneManager.LoadScene("Nivel2");
                currentLevel = 2;
            }
            else if (currentLevel == 2)
            {
                SceneManager.LoadScene("Victoria");
            }
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Nivel" + currentLevel);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Creditos");
    }
}

