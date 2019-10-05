using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControlling : MonoBehaviour
{
    public SingingTrialGenerator singingTrialGenerator;

    public bool isOnTrial;

    public Note actualNote;
    public Note lastDoneNote;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0)){
            if (actualNote != null){
                if (lastDoneNote != null){
                    if (singingTrialGenerator.notes.IndexOf(lastDoneNote)
                        == singingTrialGenerator.notes.IndexOf(actualNote) - 1) { 
                        actualNote.Done();
                        lastDoneNote = actualNote;
                    }
                }else {
                    if (singingTrialGenerator.notes.IndexOf(actualNote) == 0){
                        actualNote.Done();
                        lastDoneNote = actualNote;
                    }
                    else
                        MissClick();
                }
            }
        }
            
    }

    private void MissClick()
    {
        Debug.Log("MISS CLICK");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SingingTrial"))
        {
            isOnTrial = true;
            Debug.Log("GOT ON TRIAL");
        }else
        if (collision.gameObject.CompareTag("SingingNote"))
        {
            actualNote = collision.gameObject.GetComponent<Note>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SingingTrial"))
            Debug.Log("LEFT THE TRIAL");
        else if (collision.gameObject.CompareTag("SingingNote"))
        {
            actualNote = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
