using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> objectsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnThings());
    }
    IEnumerator spawnThings()
    {
        GameObject newObj=Instantiate(objectsToSpawn[Random.Range(0,objectsToSpawn.Count-1)]);
        yield return new WaitForSeconds(3);
        spawnThings();
    }
}
