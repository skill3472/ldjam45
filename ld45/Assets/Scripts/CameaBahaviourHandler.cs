using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameaBahaviourHandler : MonoBehaviour
{
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

    public void ChangeScene()
    {
        SceneManager.LoadScene(Random.Range(2, 4));
    }
}
