using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class Intro : MonoBehaviour
{
    public GameObject fixer;
    private VideoPlayer _videoPlayer;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        fixer.SetActive(false);
        Camera.main.GetComponent<CameaBahaviourHandler>().FadeOut();
    }
}
