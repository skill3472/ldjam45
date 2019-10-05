using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SingingTrialGenerator : MonoBehaviour
{
	public Vector2 pointsCountMaxs;

    public List<float> yOfEachLine;
    public Vector2 xMaxLine;
    public Vector2 noteMargin;

	public List<Vector3> trialPoints;
    public Note note;

    private LineRenderer _lineRenderer;

	private float _pointsCount;

    void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
		_pointsCount = Random.Range(pointsCountMaxs.x, pointsCountMaxs.y);

        CreateRandomPoints();
        _lineRenderer.positionCount = (int)_pointsCount;
        _lineRenderer.SetPositions(trialPoints.ToArray());

        foreach (Vector2 pos in trialPoints)
            Instantiate(note, pos, Quaternion.identity);
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
