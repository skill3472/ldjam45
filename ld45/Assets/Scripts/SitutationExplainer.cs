using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitutationExplainer : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Music", true);
        InvokeRepeating("Music", 2f, 1);
        Cursor.visible = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GoNext();
    }

    private void GoNext()
    {
        Camera.main.GetComponent<CameaBahaviourHandler>().FadeOut();
    }

    private void Music()
    {
        FindObjectOfType<AudioManager>().Play("Music", true);
    }
}
