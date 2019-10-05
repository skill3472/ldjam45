using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Plant : MonoBehaviour
{
    public bool state = true;
    public int waterLevel = 1;

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
        waterLevel++;
        //UpdateSprite
        _spiteRenderer.color = new Color(_spiteRenderer.color.r + 20, _spiteRenderer.color.g + 20, _spiteRenderer.color.b + 20);
    }

    private void OnMouseDown()
    {
        AddWater();
    }
}
