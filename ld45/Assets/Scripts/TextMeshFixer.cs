using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class TextMeshFixer : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "UI";
        GetComponent<MeshRenderer>().sortingOrder = 100;

    }

}
