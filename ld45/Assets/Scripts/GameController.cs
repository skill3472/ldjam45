using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void GameEnd()
    {
        SceneManager.LoadScene(Random.Range(2,4));
    }
}
