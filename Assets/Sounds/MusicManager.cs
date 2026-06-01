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
    }
    public void MuffleMusic(bool state)
    {
        if(!state)
        {
            AS.volume = 1;
        }
        else
        {
            AS.volume = 0.4f;
        }
    }
}
