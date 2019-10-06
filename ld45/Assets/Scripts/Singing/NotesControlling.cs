using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControlling : MonoBehaviour
{
    public GameController gameManager;
    public SingingTrialGenerator singingTrialGenerator;
    public PointsCounter pointsCounter;

    public bool isOnTrial;
    public bool isPlaying;

    public int pointsPerNote;
    public int minusPointsPerMissClick;

    public Note actualNote;
    public Note lastDoneNote;

    private float timeFromLastNote;
    
    private void Start()
    {
        isPlaying = true;
    }

    private void Update()
    {
        if (!isPlaying) return;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        timeFromLastNote += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)){
            //if (actualNote != null){
            //    if (lastDoneNote != null){
            //        if (singingTrialGenerator.notes.IndexOf(lastDoneNote)
            //            == singingTrialGenerator.notes.IndexOf(actualNote) - 1)
            //        {
            //            actualNote.Done(timeFromLastNote, pointsPerNote);
            //            timeFromLastNote = 0;
            //            lastDoneNote = actualNote;
            //        }
            //        else
            //            MissClick();
            //    }else {
            //        if (singingTrialGenerator.notes.IndexOf(actualNote) == 0){
            //            actualNote.Done(timeFromLastNote, pointsPerNote);
            //            timeFromLastNote = 0;
            //            lastDoneNote = actualNote;
            //        }
            //        else
            //            MissClick();
            //    }
            //}else
            //    MissClick();

            if (actualNote != null)
                actualNote.Done(timeFromLastNote, pointsPerNote);
            else
                MissClick();
        }
            
    }

    private void MissClick()
    {
        //pointsCounter.AddPoints(-minusPointsPerMissClick);
    }

    public void Win()
    {
        isPlaying = false;
        Invoke("EndGame", 0.3f);
        Debug.Log("WIN");
    }

    private void EndGame()
    {
        gameManager.GameEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlaying) return;
        if (collision.gameObject.CompareTag("SingingTrial"))
        {
            isOnTrial = true;
        }else
        if (collision.gameObject.CompareTag("SingingNote"))
        {
            if(actualNote != null)
                actualNote.FocusOff();
            actualNote = collision.gameObject.GetComponent<Note>();
            actualNote.FocusOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isPlaying) return;
        if (collision.gameObject.CompareTag("SingingTrial"))
            Debug.Log("LEFT THE TRIAL");
        else if (collision.gameObject.CompareTag("SingingNote"))
        {
            if(actualNote != null)
                actualNote.FocusOff();
            actualNote = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPlaying) return;
    }
}
