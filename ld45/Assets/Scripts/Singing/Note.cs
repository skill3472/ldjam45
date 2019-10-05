using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Note : MonoBehaviour
{
    public bool isDone;

    public List<Sprite> sprites;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    public void Done()
    {
        isDone = true;
        //Some effect
        transform.localScale = new Vector3(2, 2, 2);
        Debug.Log("DONE!");
    }

}
