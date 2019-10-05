using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonk : MonoBehaviour
{
    public Plant actualPlant;

    public float speed;
    public float speedingUp;

    public Transform maxLeftMove;
    public Transform maxRightMove;

    private int _dir = -1;

    void Update()
    {
        if (transform.position.x > maxLeftMove.position.x && _dir < 0)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0);
            if (transform.position.x <= maxLeftMove.position.x) _dir = 1;
        }
        else if (transform.position.x < maxRightMove.position.x && _dir > 0)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0);
            if (transform.position.x >= maxRightMove.position.x) _dir = -1;
        }
        speed += Time.deltaTime * speedingUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            actualPlant.UnFocus();
            actualPlant = collision.gameObject.GetComponent<Plant>();
            actualPlant.Focus();
        }
    }

}
