using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thoughtCtrl : MonoBehaviour
{
    //Da
	private GameObject gm,monksHead;
	[SerializeField]
	private bool isLeft;
    public Sprite[] thoughtsPossible;
	//public float movementTick;
    
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = thoughtsPossible[Random.Range(0,8)];
    	gm = GameObject.Find("_GM");

        isLeft = transform.position.x <= 0;

    }

    void Update()
    {
    	//Nie zmieniać nazwy!!
        monksHead=GameObject.Find("HeadPosition");
    	//transform.Translate(transform.right * Time.deltaTime * (isLeft ? 2 : -2));
        float step = 3 * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, monksHead.transform.position, step);
    }

    void OnMouseDown()
    {
        gm.GetComponent<meditating>().AddPoints(100);
    	Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Head")
        {
            gm.GetComponent<meditating>().lives--;
            Destroy(gameObject);
        }
    }
}
