using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public static event Action GameIsOver;
    [SerializeField] private GameObject gameWonMenu;
    [SerializeField] private GameObject gameOverMenu;
    private bool isGameOver = false;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public bool IsTheGameOver()
    {
        return isGameOver;
    }
    public void WonGame()
    {
        if(!isGameOver)
        {
            isGameOver = true;

            //Show game over menu
            gameWonMenu.SetActive(true);

            //Pitch music
            MusicManager.instance.MuffleMusic(true);

            //Despawn all objects
            ItemSpawner.instance.ShutDown();
        }
        
    }

    public void EndGame() 
    {
        if(!isGameOver)
        {
            isGameOver = true;
            //Show game over menu
            gameOverMenu.SetActive(true);

            //Pitch music
            MusicManager.instance.PitchMusic(true);

            //Despawn all objects
            ItemSpawner.instance.ShutDown();
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
