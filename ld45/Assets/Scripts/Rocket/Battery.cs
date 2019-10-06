using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.transform.tag);
        if(other.transform.tag=="player")
        {
            other.gameObject.GetComponent<RocketController>().ammo=9;
            Destroy(this.gameObject);
        }    
    }
}
