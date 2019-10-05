using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlantWaterLevelLine : MonoBehaviour
{
    public Plant parentPlant;

    private float _posChangePerLevel;

    private LineRenderer _lineRenderer;
    private float xLineValue;

    private void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();

        xLineValue = _lineRenderer.GetPosition(1).x - _lineRenderer.GetPosition(0).x;

        _posChangePerLevel = xLineValue / parentPlant.maxWaterLevel;
    }

    private void Update()
    {
        if (parentPlant.waterLevel * _posChangePerLevel < xLineValue / 2 || parentPlant.waterLevel * _posChangePerLevel > xLineValue / 2)
            SetLineCoordinates();
    }

    private void SetLineCoordinates()
    {
        xLineValue = parentPlant.waterLevel * _posChangePerLevel;
        _lineRenderer.SetPosition(1, new Vector2(xLineValue / 2, 1.3f));
        _lineRenderer.SetPosition(0, new Vector2(-xLineValue / 2, 1.3f));
    }
}
