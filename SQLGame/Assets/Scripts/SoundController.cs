using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite playing;
    [SerializeField] private Sprite mute;

    public void ToggleSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            this.gameObject.GetComponent<Image>().sprite = mute;
        }
        else
        {
            audioSource.Play();
            this.gameObject.GetComponent<Image>().sprite = playing;
        }
    }
}
