using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsWateringManager : MonoBehaviour
{
    public GameController gameManger;
    public PointsCounter pointsCounter;
    public int pointsPerWaterdPlant = 100;
    public bool isPlaying = true;

    public int plantsToWater;

    public WaterMonk monk;

    public CameaBahaviourHandler _cam;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Start");
        _cam = Camera.main.gameObject.GetComponent<CameaBahaviourHandler>();
    }

    private void Update()
    {
        if (!isPlaying)
        {
            isPlaying = gameManger.isPlaying;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            monk.actualPlant.AddWater();
            monk.ChangeSprite(true);
        }
        else if(Input.GetMouseButtonUp(0))
            monk.ChangeSprite(false);
    }

    public void PlantWaterd(Transform plant)
    {
        FindObjectOfType<AudioManager>().Play("PlantReady");
        plantsToWater--;
        pointsCounter.AddPoints(pointsPerWaterdPlant, plant.position);
        if (plantsToWater <= 0)
            Invoke("Win", 0.3f);
    }

    private void Win()
    {
        if (!isPlaying) return;
        Invoke("GameEnd", 0.3f);
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().Play("BadPlant");
        _cam.Shake();
        if (!isPlaying) return;
        Invoke("GameEnd", 0.3f);
    }

    private void GameEnd()
    {
        gameManger.GameEnd();
    }

}
