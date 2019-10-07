﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitutationExplainer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GoNext();
    }

    private void GoNext()
    {
        Camera.main.GetComponent<CameaBahaviourHandler>().FadeOut();
    }
}
