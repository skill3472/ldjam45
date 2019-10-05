using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControlling : MonoBehaviour
{

    public bool isOnTrial;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SingingTrial"))
            isOnTrial = true;
        Debug.Log("GOT ON TRIAL");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SingingTrial") && isOnTrial)
            Debug.Log("LEFT THE TRIAL");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
