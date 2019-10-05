using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsWateringManager : MonoBehaviour
{
    public GameController gameManger;
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
        Invoke("GameEnd", 0.3f);
    }

    public void GameOver()
    {
        if (!isPlaying) return;
        Instantiate(gameOverTestSprite, transform);
        Invoke("GameEnd", 0.3f);
    }

    private void GameEnd()
    {
        gameManger.GameEnd();
    }

}
