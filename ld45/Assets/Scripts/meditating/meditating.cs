﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class meditating : MonoBehaviour
{
    public GameController gameManager;

	public Transform[] spawnpoints;
	public float timeBeforeNextSpawn;
	public GameObject thought;
	public float LocalDifficulty;
	public int points;
	public Text scoreText;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    	points = 0;
        timeBeforeNextSpawn = 5f;
        LocalDifficulty = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeNextSpawn -= Time.deltaTime;
        if(timeBeforeNextSpawn <= 0)
        {
        	LocalDifficulty += 0.1f;
        	timeBeforeNextSpawn = 2 / LocalDifficulty;
        	SpawnThought();
        }
        scoreText.text = points.ToString();

        //Detecting death
        if(lives <= 0)
        {
            Loose();
        }
    }

    public void SpawnThought()
    {
    	Instantiate(thought, spawnpoints[(int) Mathf.Round(Random.Range(0,6))].position, transform.rotation);
    }

    public void Loose()
    {
        Debug.Log("u r dead");
        //Show score, splash screen, ect. HERE
        //
        //
        //Show score, splash screen, ect. HERE
        Invoke("EndGame", 0.3f);
    }

    private void EndGame()
    {
        gameManager.GameEnd();
    }
}
