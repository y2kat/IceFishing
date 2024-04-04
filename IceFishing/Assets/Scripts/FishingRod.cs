using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public int lives = 3;
    public int points = 0;

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            //si la ca�a de pescar se queda sin vidas, desactiva la ca�a de pescar
            gameObject.SetActive(false);
        }
    }

    public void AddPoints()
    {
        points++;
    }
}
