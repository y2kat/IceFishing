using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private FishingRod fishingRod;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private FishPool fishPool;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        fishingRod.ResetGame();
        enemyPool.ResetPool();
        fishPool.ResetPool();

        level.SetActive(true);
        menu.SetActive(false);

        enemyPool.InitializePool();
        fishPool.InitializePool();

        enemyPool.StartSpawning();
        fishPool.StartSpawning();
    }

    public void quitGame()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }

    public void returnToMenu()
    {
        level.SetActive(false);
        menu.SetActive(true);
        deathPanel.SetActive(false);
    }

    public void showDeathScreen()
    {
        deathPanel.SetActive(true);
    }
}
