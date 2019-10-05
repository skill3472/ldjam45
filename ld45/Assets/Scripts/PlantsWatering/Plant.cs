using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Plant : MonoBehaviour
{
    public bool state = true;
    public bool isDone;
    public bool isFocused;
    public GameObject focusEffect;
    public int waterLevel = 1;
    public int maxWaterLevel = 5;

    private PlantsWateringManager _plantsWateringManager;

    private SpriteRenderer _spiteRenderer;

    private void Start()
    {
        _spiteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _plantsWateringManager = FindObjectOfType<PlantsWateringManager>();

        waterLevel = Random.Range(2, 4);

        if(state)
            _plantsWateringManager.plantsToWater++;
    }

    public void AddWater()
    {
        if (!isFocused) return;
        if (!state){
            Dead();
            return;
        }

        if(waterLevel == maxWaterLevel)
        {
            waterLevel = 1;
        }

        if (waterLevel > maxWaterLevel)
        {
            return;
        }
       
        waterLevel++;
        if (waterLevel >= maxWaterLevel) Done();

        //UpdateSprite
        _spiteRenderer.color = new Color(_spiteRenderer.color.r + .1f, _spiteRenderer.color.g + .1f, _spiteRenderer.color.b + .1f);
    }

    public void Focus()
    {
        isFocused = true;
        focusEffect.SetActive(true);
    }

    public void UnFocus()
    {
        isFocused = false;
        focusEffect.SetActive(false);
    }

    private void Done()
    {
        isDone = true;
        _plantsWateringManager.PlantWaterd();
    }

    private void Dead()
    {
        _plantsWateringManager.GameOver();
    }

    private void OnMouseDown()
    {
        //if (!_plantsWateringManager.isPlaying) return;

        //if (state)
        //    AddWater();
        //else
        //    Dead();
    }
}
