using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuteButtonBehavior : MonoBehaviour
{
    private bool isMuted = false;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.HasKey("volume") ? PlayerPrefs.GetFloat("volume") : 1f;
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        AudioListener.volume = isMuted ? 0f : 1f;
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
    }
}
