using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    public static int points;
    public static int combo = 1;
    public static int maxCombo = 8;

    public static Text pointsText;
    public string prefixOfText;

    void Start()
    {
        pointsText = GameObject.FindGameObjectWithTag("PointsText").GetComponent<Text>();
        SetText();
        
    }

    void Update()
    {
        
    }

    public void AddPoints(int amount)
    {
        points += amount * combo;
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
