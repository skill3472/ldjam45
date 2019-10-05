using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingingTrialGenerator : MonoBehaviour
{
    public int notesToGenerate = 30;
    public float notesSpeed;
    public float notesSpeedingUp;
    public Vector2 xMax;
    public Vector2 randomXMargin;
    public Note note;

    public List<float> yOfEachLine;

    public List<Note> notes;

    public NotesControlling notesControlling;
    private float _margin;

    void Start()
    {
        SetRandomMargin();
        SpawnNote();
    }

    void Update()
    {
        if (!notesControlling.isPlaying) return;
        if (notes[notes.Count - 1].transform.position.x <= xMax.y - _margin)
        {
            SpawnNote();
            SetRandomMargin();
        }
        notesSpeed += Time.deltaTime * notesSpeedingUp;
    }


    private Vector2 GetPoint()
    {
        return new Vector2(xMax.y,
            yOfEachLine[Random.Range(0, yOfEachLine.Count-1)]);
    }

    private void SpawnNote()
    {
        if (notesToGenerate <= 0) return;
        Note newNote = Instantiate(note, GetPoint(), Quaternion.identity);
        newNote.speed *= notesSpeed;
        notes.Add(newNote);
        notesToGenerate--;
    }

    private void SetRandomMargin()
    {
        _margin = Random.Range(randomXMargin.x, randomXMargin.y);
    }
}
