using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonk : MonoBehaviour
{
    public Plant actualPlant;
    public PlantsWateringManager plantsWateringManager;
    public Sprite standardSprite;
    public Sprite wateringSprite;

    public float speed;
    public float maxSpeed = 6;
    public float speedingUp;

    public Transform maxLeftMove;
    public Transform maxRightMove;

    private int _dir = -1;
    public SpriteRenderer spriteRenderer;

    private float timeToNextSound;

    private void Start()
    {
        timeToNextSound = 1 / speed;
    }

    private void Update()
    {
        if (!plantsWateringManager.isPlaying) return;

        if (transform.position.x > maxLeftMove.position.x && _dir < 0)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0);
            if (transform.position.x <= maxLeftMove.position.x) _dir = 1;
        }
        else if (transform.position.x < maxRightMove.position.x && _dir > 0)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0);
            if (transform.position.x >= maxRightMove.position.x) _dir = -1;
        }
        if(speed < maxSpeed)
            speed += Time.deltaTime * speedingUp;
        spriteRenderer.flipX = _dir < 0;
        timeToNextSound -= Time.deltaTime;
        if (timeToNextSound <= 0) PlayRandomFootstep();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            actualPlant.UnFocus();
            actualPlant = collision.gameObject.GetComponent<Plant>();
            actualPlant.Focus();
        }
    }

    public void ChangeSprite(bool isWatering)
    {
        spriteRenderer.sprite = (isWatering) ? wateringSprite : standardSprite;
    }

    private void PlayRandomFootstep()
    {
        string n = "footestep" + Random.Range(1, 11);
        FindObjectOfType<AudioManager>().Play(n);
        timeToNextSound = 1/speed*2;
    }

}
