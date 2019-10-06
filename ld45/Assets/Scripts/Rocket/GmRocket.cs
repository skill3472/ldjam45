using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmRocket : MonoBehaviour
{
    public float speed;
    private GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        background=GameObject.Find("tlorakieta");
    }

    // Update is called once per frame
    void Update()
    {
        background.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,speed));
    }
}
