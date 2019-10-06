using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public CameaBahaviourHandler _camera;
    public bool isPlaying;

    public void GameEnd()
    {
        _camera.FadeOut();
    }
}
