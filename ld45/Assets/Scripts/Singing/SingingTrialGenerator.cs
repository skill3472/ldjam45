using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(LineRenderer))]
public class SingingTrialGenerator : MonoBehaviour
{
	public Vector2 pointsCountMaxs;

    public List<float> yOfEachLine;
    public Vector2 xMaxLine;
    public Vector2 noteMargin;

	public List<Vector2> trialPoints;
    public Note note;
    public List<Note> notes;

    private EdgeCollider2D _edgeCollider;

    private float _pointsCount;

    void Start()
    {
        _edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        _pointsCount = Random.Range(pointsCountMaxs.x, pointsCountMaxs.y);

        CreateRandomPoints();

        _edgeCollider.points = trialPoints.ToArray();


        foreach (Vector2 pos in trialPoints)
            notes.Add(Instantiate(note, pos, Quaternion.identity));
    }

    void Update()
    {
        
    }

    private void CreateRandomPoints()
	{
        trialPoints.Add(new Vector2(xMaxLine.x,
            yOfEachLine[Random.Range(0, yOfEachLine.Count)]));
        for (int i = 1; i < _pointsCount; i++)
            trialPoints.Add(GetNextPoint(trialPoints[i - 1].x));
	}

    private Vector2 GetNextPoint(float lastX)
    {
        return new Vector2(lastX + Random.Range(noteMargin.x, noteMargin.y),
            yOfEachLine[Random.Range(0, yOfEachLine.Count)]);
    }
}
