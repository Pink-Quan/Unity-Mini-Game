using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public static SoundScript instance;
    [SerializeField] private AudioClip hitAudio,gunShotAudio;
    [SerializeField] private AudioSource hitAudioSourse,gunShotSource;
    [SerializeField] private AudioSource backgrodMusicSourse;
    [SerializeField] private Toggle backgrodMusic, soundEffect;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        backgrodMusic.onValueChanged.AddListener(delegate { TurnOnOffBackgroundMusic(backgrodMusic);});
        soundEffect.onValueChanged.AddListener(delegate { TurnOnOffSoundEffect(soundEffect); });
    }
    public void hitSound()
    {
        hitAudioSourse.clip = hitAudio;
        hitAudioSourse.Play();
    }
    public void gunSound()
    {
        gunShotSource.clip = gunShotAudio;
        gunShotSource.Play();
    }
    public void TurnOnOffBackgroundMusic (Toggle change)
    {
        Debug.Log("Change background sound");
        backgrodMusicSourse.mute = change.isOn;
    }
    public void TurnOnOffSoundEffect(Toggle change)
    {
        Debug.Log("Change hit sound");
        hitAudioSourse.mute = change.isOn;
    }
}
