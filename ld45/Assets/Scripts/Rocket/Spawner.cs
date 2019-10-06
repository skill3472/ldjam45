using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public List<GameObject> objectsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnThings());
    }
    IEnumerator spawnThings()
    {
        transform.position=new Vector2(Random.Range(-10,10),transform.position.y);
        GameObject newObj=Instantiate(objectsToSpawn[Random.Range(0,objectsToSpawn.Count-1)]);
        newObj.transform.position=transform.position;
        newObj.transform.GetComponent<Rigidbody2D>().gravityScale=Random.Range(0.4f,2);
        
        yield return new WaitForSeconds(1);
        StartCoroutine(spawnThings());
    }
}
