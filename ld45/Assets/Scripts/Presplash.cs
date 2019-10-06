using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Presplash : MonoBehaviour
{
    public List<Sprite> presplashes;
    public float timeToNextSlide = 1;
    public GameController gameManager;

    private int _actual;
    private Image _presplashImg;
    private float _actualtime;

    private void Start()
    {
        _presplashImg = GetComponent<Image>();
        SetSprite();
        _actualtime = timeToNextSlide;
    }

    private void Update()
    {
        _actualtime -= Time.deltaTime;
        if (_actualtime < 0)
        {
            if (_actual >= presplashes.Count-1)
            {
                gameObject.SetActive(false);
                gameManager.isPlaying = true;
                return;
            }
            _actual++;
            _actualtime = timeToNextSlide;
            SetSprite();
        }
    }

    private void SetSprite()
    {
        _presplashImg.sprite = presplashes[_actual];
    }
}
