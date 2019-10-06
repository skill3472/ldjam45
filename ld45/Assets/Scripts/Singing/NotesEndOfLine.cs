using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesEndOfLine : MonoBehaviour
{
    public SingingTrialGenerator singingTrialGenerator;
    private CameaBahaviourHandler _cam;

    private void Start()
    {
       _cam = Camera.main.gameObject.GetComponent<CameaBahaviourHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SingingNote"))
        {
            Note thisNote = collision.gameObject.GetComponent<Note>();
            if (singingTrialGenerator.notesToGenerate <= 0 &&
                singingTrialGenerator.notes.IndexOf(thisNote)
                == singingTrialGenerator.notes.Count - 1)
            {
                singingTrialGenerator.notes.Remove(thisNote);
                Destroy(collision.gameObject);
                singingTrialGenerator.notesControlling.Win();
                return;
            }
            singingTrialGenerator.notes.Remove(thisNote);
            if (!thisNote.isDone)
            {
                thisNote.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                FindObjectOfType<AudioManager>().Play("WrongNote");
                _cam.Shake();
            }
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
