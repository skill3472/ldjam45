using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummarySceneMusic : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Music");
    }

}
