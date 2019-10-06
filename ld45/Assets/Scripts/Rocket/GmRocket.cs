using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmRocket : MonoBehaviour
{
    public static GmRocket instance;
    public float speed;
    private GameObject background;
    private Rigidbody2D rb2dOfBack;
    void Awake() {
        if(instance == null)
            instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        background=GameObject.Find("tlorakieta");
        rb2dOfBack=background.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2dOfBack.velocity.magnitude<-speed)
        {
            rb2dOfBack.drag=1;
            rb2dOfBack.AddForce(new Vector2(0,speed));
        }
        else
        {
            rb2dOfBack.drag+=0.1f;
        }
    }
}
