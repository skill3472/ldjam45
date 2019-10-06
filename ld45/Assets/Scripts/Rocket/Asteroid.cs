using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    void Death()
    {
        GameObject newExp=Instantiate(explosion);
        newExp.transform.position=transform.position;
        Destroy(newExp,2);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag=="bullet")
        {
            Death();
        }    
    }
}
