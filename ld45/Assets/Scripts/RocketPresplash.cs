using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPresplash : MonoBehaviour
{
    public RocketController rocket;
    void Start()
    {
        Invoke("Ded", 3f);
    }

    // Update is called once per frame
    void Ded()
    {
        rocket.canSkip = true;
        Destroy(gameObject);
    }
}
