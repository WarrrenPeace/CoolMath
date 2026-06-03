using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public static event Action CountDownOver;
    [SerializeField] private Slider monthVisualSlider;
    [SerializeField] private float timeGoal = 120;
    [SerializeField] private float timeRemaining;


    private bool isClockStarted = false;
    private bool isFinishedCounting = false;
    [SerializeField] private bool CountUp = false;


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
    void Start()
    {
        timeRemaining = timeGoal;
    }
    void Update()
    {
        if(isClockStarted)
        {
            if(!isFinishedCounting)
            {
                if(!CountUp) {TickDownClock();}
                else {TickUpClock();}
            }
        }
        
    }
    public void StartClock()
    {
        isClockStarted = true;
    }
    void TickDownClock()
    {
        if (timeRemaining <= 0)
        {
            CountdownCompleted();
        }
        else
        {
            timeRemaining -= 1 * Time.deltaTime;
        }
    }
    void TickUpClock()
    {
        timeRemaining += 1 * Time.deltaTime;
        if (timeRemaining >= timeGoal)
        {
            CountdownCompleted();
        }
    }
    void CountdownCompleted()
    {
        isFinishedCounting = true;
        CountDownOver?.Invoke();
    }

    public float HowMuchTimeIsLeft()
    {
        return timeRemaining;
    }
    
}
