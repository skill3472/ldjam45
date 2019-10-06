using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed,hp;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
