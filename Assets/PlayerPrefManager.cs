using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
    [Range(0,1)] public float MusicVolume = 1;
    [Range(0,1)] public float FXVolume = 1;
    [Range(0,1)] public float UIVolume = 1;
    void Start()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("FXVolume", FXVolume);
        PlayerPrefs.SetFloat("UIVolume", UIVolume);
    }
}
