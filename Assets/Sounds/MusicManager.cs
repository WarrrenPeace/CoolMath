using System.Runtime.CompilerServices;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] private AudioSource AS;
    [SerializeField] private AudioClip track;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else {instance = this;}
    }
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void MuffleMusic(bool state)
    {
        float currentVolume = PlayerPrefs.GetFloat("MusicVolume");
        float muffleVolume = currentVolume/2;
        if(!state)
        {
            AS.volume = currentVolume;
        }
        else
        {
            AS.volume = muffleVolume;
        }
    }
}
