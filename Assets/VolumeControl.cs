using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource; 
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = audioSource.volume;
    }

    public void OnVolumeChanged()
    {
        audioSource.volume = volumeSlider.value;
    }
}