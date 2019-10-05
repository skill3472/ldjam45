using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thoughtCtrl : MonoBehaviour
{
	private GameObject gm;
	[SerializeField]
	private bool isLeft;
	//public float movementTick;

    // Start is called before the first frame update
    void Start()
    {
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
}
