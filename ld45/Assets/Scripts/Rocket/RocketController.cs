using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RocketController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    private GameObject laser,exp;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed;
    private int hp;
    public float ammo=0;
    public bool end=false;
    [SerializeField]
    bool canShoot=true,isShooting=false,canMove=true;
    public bool isPlaying = false;
    public GameObject playInfo;
    public Rigidbody2D background;
    public GameObject dieInfo;
    public bool canSkip = false;

    public List<GameObject> livesImg;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
        hp = livesImg.Count - 1;
        FindObjectOfType<AudioManager>().Play("Music", true);
        InvokeRepeating("Music", 2f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetMouseButtonDown(0) && canSkip)
            {
                FindObjectOfType<AudioManager>().Play("Rocket", true);
                InvokeRepeating("rocketSound", 2f, 1);
                isPlaying = true;
                playInfo.SetActive(false);
                Cursor.visible = false;
                background.bodyType = RigidbodyType2D.Dynamic;
            }
            return;
        }

        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        transform.position = targetPosition;
        if(ammo>0&&canShoot)
        {
            animator.SetBool("isOpened",true);
            StartCoroutine(Shoot());
            canShoot=false;
        }
        if(end)
        {
            StartCoroutine(landing());
        }
    }
    IEnumerator landing()
    {
        isPlaying = false;
        rb2d.AddForce(new Vector2(0,99));
        
        yield return new WaitForSeconds(1f);
        Camera.main.GetComponent<CameaBahaviourHandler>().FadeOut();
    }
    IEnumerator ded()
    {
        if (isPlaying)
        {
            canMove = false;
            dieInfo.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Explode");
            GameObject e = Instantiate(exp);
            e.transform.position = transform.position;
            Destroy(e, 2);
            isPlaying = false;
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Rakieta2");
            
        }
    }
    IEnumerator Shoot()
    {
        if (isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
            if (isShooting)
            {
                FindObjectOfType<AudioManager>().Play("Shoot");
                ammo--;
                GameObject newLaser = Instantiate(laser);
                newLaser.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 12));
                newLaser.GetComponent<Rigidbody2D>().gravityScale = -8;
                newLaser.transform.position = transform.position;
                Destroy(newLaser, 2);

            }
            if (ammo > 0)
                StartCoroutine(Shoot());
            else
            {
                animator.SetBool("isOpened", false);
                canShoot = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag=="asteroid" && isPlaying)
        {
            Camera.main.GetComponent<CameaBahaviourHandler>().Shake();
            FindObjectOfType<AudioManager>().Play("Hit");
            livesImg[hp].SetActive(false);
            hp--;
            if(hp<0)
                StartCoroutine(ded());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Battery"))
        {
            ammo += 10;
            Destroy(collision.gameObject);
        }
    }

    private void rocketSound()
    {
        FindObjectOfType<AudioManager>().Play("Rocket", true);
    }

    private void Music()
    {
        FindObjectOfType<AudioManager>().Play("Music", true);
    }

}
