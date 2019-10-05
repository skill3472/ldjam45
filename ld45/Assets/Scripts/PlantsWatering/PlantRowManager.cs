using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRowManager : MonoBehaviour
{
    public int maxBadPlants = 2;
    public List<Transform> plantsPoints;
    //First plant is the bad one!
    public List<Plant> plantsTypes;


    private void Start()
    {
        SpawnPlants();
    }

    private void SpawnPlants()
    {
        foreach (Transform t in plantsPoints)
        {
            if (Random.Range(0, 2) == 1 && maxBadPlants > 0)
            {
                Instantiate(plantsTypes[0], t);
                maxBadPlants--;
            }
            else
                Instantiate(plantsTypes[Random.Range(1, plantsTypes.Count)], t);
        }
    }
}
