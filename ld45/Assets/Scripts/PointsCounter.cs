using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    public int points;
    public int combo = 1;
    public int maxCombo = 8;

    public Text pointsText;
    public string prefixOfText;

    void Start()
    {
        SetText();   
    }

    void Update()
    {
        
    }

    public void AddPoints(int amount)
    {
        points += amount;
        SetText();
    }

    public void AddCombo()
    {
        if (combo < maxCombo) combo++;
    }

    public void DecreaseCombo()
    {
        if (combo >1) combo--;
    }

    private void SetText()
    {
        pointsText.text = prefixOfText + points.ToString();
    }
}
