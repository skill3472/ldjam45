using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Note : MonoBehaviour
{
    public bool isDone;

    public float speed = 4;

    public ParticleSystem doneEffect;

    public List<Sprite> sprites;

    private PointsCounter _pointsCounter;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _pointsCounter = FindObjectOfType<PointsCounter>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    private void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
    }

    public void Done(float time, int points)
    {
        isDone = true;
        Instantiate(doneEffect, transform);

        if (time <= .5f) _pointsCounter.AddCombo();
        else _pointsCounter.DecreaseCombo();

        _pointsCounter.AddPoints(points);

    }

    public void FocusOn()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void FocusOff()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

}
