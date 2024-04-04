using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishingRod : MonoBehaviour
{
    public int lives = 3;
    public int points = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI pointsText;

    public PanelManager panelManager;
    public Menu menu;

    [SerializeField] Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }


    void Update()
    {
        livesText.text = "Vidas: " + lives;
        pointsText.text = "Puntos: " + points;
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void AddPoints()
    {
        points++;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;

        menu.showDeathScreen();
    }

    public void ResetGame()
    {
        lives = 3;
        points = 0;

        transform.position = initialPosition;

        Time.timeScale = 1;
    }
}
