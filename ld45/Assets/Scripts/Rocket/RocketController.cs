﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private GameObject laser;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed,hp,ammo;
    bool canShoot=true;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        if(ammo>0&&canShoot)
        {
            StartCoroutine(Shoot());
            canShoot=false;
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        ammo--;
        GameObject newLaser=Instantiate(laser);
        newLaser.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,12));
        newLaser.GetComponent<Rigidbody2D>().gravityScale=-8;
        newLaser.transform.position=transform.position;
        Destroy(newLaser,2);
        if(ammo>0)
            StartCoroutine(Shoot());
    }
}
