using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private GameObject laser;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed,hp;
    public float ammo=0;
    [SerializeField]
    bool canShoot=true,isShooting=false;
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
            animator.SetBool("isOpened",true);
            StartCoroutine(Shoot());
            canShoot=false;
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.3f);
        if(isShooting)
        {
            ammo--;
            GameObject newLaser=Instantiate(laser);
            newLaser.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,12));
            newLaser.GetComponent<Rigidbody2D>().gravityScale=-8;
            newLaser.transform.position=transform.position;
            Destroy(newLaser,2);
            
        }
        if(ammo>0)
            StartCoroutine(Shoot());
        else
        {
            animator.SetBool("isOpened",false);
            canShoot=true;
        }
    }
}
