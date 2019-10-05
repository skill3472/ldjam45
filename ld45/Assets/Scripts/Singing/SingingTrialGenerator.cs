using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(LineRenderer))]
public class SingingTrialGenerator : MonoBehaviour
{
    public Vector2 randomMargin;
    public Note note;

    public List<float> yOfEachLine;
    public Vector2 xMaxLine;
    public Vector2 noteMargin;

    public List<Note> notes;


    private float _margin;

    void Start()
    {
        SetRandomMargin();
    }

    void Update()
    {
        if (notes[notes.Count - 1].transform.position.x <= xMaxLine.y - _margin)
        {
            SpawnNote();
            SetRandomMargin();
        }
    }


    private Vector2 GetPoint()
    {
        return new Vector2(noteMargin.y,
            yOfEachLine[Random.Range(0, yOfEachLine.Count)]);
    }

    private void SpawnNote()
    {
        notes.Add(Instantiate(note, GetPoint(), Quaternion.identity));
    }

    private void SetRandomMargin()
    {
        _margin = Random.Range(randomMargin.x, randomMargin.y);
    }
}
