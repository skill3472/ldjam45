using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRowManager : MonoBehaviour
{
    public Transform gameOverTestSprite;

    public List<Transform> plantsPoints;
    public List<Plant> plantsTypes;

    private void Start()
    {
        SpawnPlants();
    }

    private void Update()
    {
        
    }

    public void GameOver()
    {
        Instantiate(gameOverTestSprite, transform);
        Time.timeScale = 0;
    }

    private void SpawnPlants()
    {
        foreach(Transform t in plantsPoints)
            Instantiate(plantsTypes[Random.Range(0, plantsTypes.Count)], t);
    }
}
