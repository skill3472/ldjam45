using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnThings());
    }
    IEnumerator spawnThings()
    {
        yield return new WaitForSeconds(3);
        spawnThings();
    }
}
