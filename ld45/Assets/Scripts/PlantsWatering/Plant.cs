using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Plant : MonoBehaviour
{
    public bool state = true;
    public bool isDone;
    public bool isTooMuch;
    public bool isFocused;
    public GameObject focusEffect;
    public int waterLevel = 1;
    [HideInInspector]
    public int maxWaterLevel;

    public List<Sprite> growStates;

    private PlantsWateringManager _plantsWateringManager;

    private SpriteRenderer _spiteRenderer;

    private void Start()
    {
        _spiteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _plantsWateringManager = FindObjectOfType<PlantsWateringManager>();


        maxWaterLevel = growStates.Count-2;

        waterLevel = Random.Range(0, maxWaterLevel-2);
        _spiteRenderer.sprite = growStates[waterLevel];

        if (state)
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
            isTooMuch = true;
            _spiteRenderer.sprite = growStates[growStates.Count-1];
            _plantsWateringManager._cam.Shake();
            _plantsWateringManager.pointsCounter.AddPoints(-80, transform.position);
            FindObjectOfType<AudioManager>().Play("TooMuchWater" + Random.Range(1,3));
        }
        if (isDone) return;

        if (waterLevel > maxWaterLevel)
            return;
       
        SetWaterLevel(waterLevel+1);
        _plantsWateringManager.pointsCounter.AddPoints(20, transform.position);
        if (waterLevel >= maxWaterLevel) Done();
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
        _plantsWateringManager.PlantWaterd(transform);
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

    private void SetWaterLevel(int level)
    {
        waterLevel = level;
        _spiteRenderer.sprite = growStates[waterLevel];
        if(waterLevel<maxWaterLevel)
            FindObjectOfType<AudioManager>().Play("Watering");
    }
}
