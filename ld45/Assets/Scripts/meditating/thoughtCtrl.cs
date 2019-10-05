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

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = thoughtsPossible[(int) Mathf.Round(Random.Range(0,8))];
    	gm = GameObject.Find("_GM");
        //Checking which way the thought should be heading
        if(transform.position.x > 0)
        {
        	isLeft = false;
        }
        else
        {
        	isLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	 //Move Right
    	 if(isLeft)
    	 {
    	 	transform.Translate(transform.right * Time.deltaTime * 2);
    	 }
    	 //Move Left
    	 else
    	 {
			transform.Translate(-transform.right * Time.deltaTime * 2);	
    	 }
    	 
    }

    void OnMouseDown()
    {
    	gm.GetComponent<meditating>().points++;
    	GameObject.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Head")
        {
            gm.GetComponent<meditating>().lives--;
            GameObject.Destroy(gameObject);
        }
    }
}
