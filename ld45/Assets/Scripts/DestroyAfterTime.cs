using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 0.5f;
    void Start()
    {
        Invoke("Dead", time); 
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}
