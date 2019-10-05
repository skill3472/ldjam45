using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantsWateringManager : MonoBehaviour
{
    public bool isPlaying = true;

    public int plantsToWater;

    public WaterMonk monk;

    public Transform winTestSprite;
    public Transform gameOverTestSprite;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            monk.actualPlant.AddWater();
        }
    }

    public void PlantWaterd()
    {
        plantsToWater--;
        if (plantsToWater <= 0)
            Win();
    }

    private void Win()
    {
        if (!isPlaying) return;
        Instantiate(winTestSprite, transform);
        GameEnd();
    }

    public void GameOver()
    {
        if (!isPlaying) return;
        Instantiate(gameOverTestSprite, transform);
        GameEnd();
    }

    private void GameEnd()
    {
        Time.timeScale = 0;
        isPlaying = false;
        SceneManager.LoadScene(2);
    }

}
