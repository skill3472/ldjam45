using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingingTrialGenerator : MonoBehaviour
{
	public Vector2 pointsCountMaxs;
	public List<Vector2> trialPoints;

	private int _pointsCount;

    void Start()
    {
		pointsCount = Random.Range(0, pointsCountMaxs - 1);

    }

    void Update()
    {
        
    }

    private void CreateRandomPoints()
	{
        foreach(int i in pointsCount)
		{
		}
	}
}
