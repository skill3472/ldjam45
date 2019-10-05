using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thoughtCtrl : MonoBehaviour
{
	private GameObject gm;
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

    	transform.Translate(transform.right * Time.deltaTime * (isLeft ? 2 : -2));
    	 
    }

    void OnMouseDown()
    {
        FindObjectOfType<PointsCounter>().AddPoints(100);
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
