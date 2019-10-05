using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Plant : MonoBehaviour
{
    public bool state = true;
    public int waterLevel = 1;
    public int maxWaterLevel = 5;

    private SpriteRenderer _spiteRenderer;

    private void Start()
    {
        _spiteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    private void AddWater()
    {
        if (waterLevel >= maxWaterLevel) return;
        waterLevel++;

        //UpdateSprite
        _spiteRenderer.color = new Color(_spiteRenderer.color.r + .1f, _spiteRenderer.color.g + .1f, _spiteRenderer.color.b + .1f);
    }

    private void Dead()
    {
        FindObjectOfType<PlantRowManager>().GameOver();
    }

    private void OnMouseDown()
    {
        if (state)
            AddWater();
        else
            Dead();
    }
}
