﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public RocketController rocket;
    public List<GameObject> objectsToSpawn;
    public GameObject battery;
    private bool hasStarted;

    void Start()
    {
        
    }

    private void Update()
    {
        if (rocket.isPlaying && !hasStarted)
        {
            StartCoroutine(spawnThings());
            hasStarted = true;
        }
    }
    IEnumerator spawnThings()
    {

            transform.position = new Vector2(Random.Range(-10, 10), transform.position.y);
            GameObject newObj = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count - 1)]);
            newObj.transform.position = transform.position;
            newObj.transform.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.4f, 2);
            //newObj.transform.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-43,43));
            if (Random.Range(1, 4) == 1)
            {
                GameObject newBattery = Instantiate(battery);
                newBattery.transform.position = this.transform.position;
            }
            yield return new WaitForSeconds(0.6f);
            StartCoroutine(spawnThings());
    }
}
