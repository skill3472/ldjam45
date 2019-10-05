using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meditating : MonoBehaviour
{

	public Transform[] spawnpoints;
	public float timeBeforeNextSpawn;
	public GameObject thought;
	public float LocalDifficulty;
	public int points;
	public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void SpawnThought()
    {
    	Instantiate(thought, spawnpoints[(int) Mathf.Round(Random.Range(0,6))].position, transform.rotation);
    }
}
