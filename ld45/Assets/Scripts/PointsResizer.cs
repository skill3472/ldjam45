using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsResizer : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/3, Screen.height/6);
        GetComponent<RectTransform>().position = new Vector2(Screen.width / 6, Screen.height*11/12);
    }

}
