using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class meditating : MonoBehaviour
{
    public GameObject dymek;

    public AudioSource audioSrc;
    public AudioClip plum;
    public AudioClip whispers;

    public Color twoLife;
    public Color oneLife;
    public Color noLife;

    public GameController gameManager;
    public PointsCounter pointsCounter;

	public Transform[] spawnpoints;
	public float timeBeforeNextSpawn;
	public GameObject thought;
	public float LocalDifficulty;
	public int points;
    public int lives;

    private CameaBahaviourHandler _cam;

    void Start()
    {
        _cam = Camera.main.gameObject.GetComponent<CameaBahaviourHandler>();
        lives = 3;
    	points = 0;
        LocalDifficulty = 1f;
    }

    void Update()
    {
        timeBeforeNextSpawn -= Time.deltaTime;
        if(timeBeforeNextSpawn <= 0)
        {
        	LocalDifficulty += 0.1f;
        	timeBeforeNextSpawn = 2 / LocalDifficulty;
        	SpawnThought();
        }

        if(lives <= 0)
            Loose();
       
    }

    public void SpawnThought()
    {
    	Instantiate(thought, spawnpoints[(int) Mathf.Round(Random.Range(0,6))].position, transform.rotation);
    }

    public void Loose()
    {
        Debug.Log("u r dead");

        Invoke("EndGame", 0.3f);
    }

    private void EndGame()
    {
        gameManager.GameEnd();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        pointsCounter.AddPoints(amount, Vector3.zero);
    }

    public void DecreaseLives()
    {
        //whispers.Play(); NIE DZIAŁA
        if(lives == 2) dymek.GetComponent<SpriteRenderer>().color = twoLife;
        else if(lives == 1) dymek.GetComponent<SpriteRenderer>().color = oneLife;
        if(lives <= 0)
        {
            dymek.GetComponent<SpriteRenderer>().color = noLife;
            Loose();
        }

        lives--;
        _cam.Shake();
    }

}
