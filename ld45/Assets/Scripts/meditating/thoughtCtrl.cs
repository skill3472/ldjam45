using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thoughtCtrl : MonoBehaviour
{
	private GameObject gm,monksHead;
	[SerializeField]
	private bool isLeft;
    public Sprite[] thoughtsPossible;
    public GameObject explosion;
    
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = thoughtsPossible[Random.Range(0,8)];
    	gm = GameObject.Find("_GM");

        isLeft = transform.position.x <= 0;

    }

    void Update()
    {
        monksHead = GameObject.FindGameObjectWithTag("Head");
        float step = 3 * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, monksHead.transform.position, step);
    }

    void OnMouseDown()
    {
    	Explode();
    }
    void Explode()
    {
        gm.GetComponent<meditating>().AddPoints(100);
        GameObject exp=Instantiate(explosion);
        exp.transform.position=transform.position;
        Destroy(exp,2);
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Head")
        {
            gm.GetComponent<meditating>().DecreaseLives();
            Explode();
        }
    }
}
