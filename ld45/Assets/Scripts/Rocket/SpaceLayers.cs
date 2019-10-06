using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLayers : MonoBehaviour
{
    public float changeSpeed=0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="MainCamera")
        {
            Debug.Log("daaa");
            GmRocket.instance.speed=-changeSpeed;
        }    
    }
}
