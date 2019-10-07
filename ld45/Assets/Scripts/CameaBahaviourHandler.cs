using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameaBahaviourHandler : MonoBehaviour
{
    public TextMesh pointsEffect;

    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void FadeOut()
    {
        _animator.SetTrigger("FadeOut");
    }

    public void FadeInDone()
    {
        _animator.SetBool("FadeIn", false);
    }

    public void ChangeScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void StartAgain()
    {
        FindObjectOfType<PointsCounter>().Reset();
        SceneManager.LoadScene(0);
    }

    public void Shake()
    {
        _animator.SetTrigger("CameraShake");
    }

    public void MakePointsEffect(string points, Vector3 pos)
    {
        if (pos == Vector3.zero)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -5;
        }
        TextMesh t = Instantiate(pointsEffect, pos, transform.rotation);
        t.text = points;
    }
}
