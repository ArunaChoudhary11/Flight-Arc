using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public event EventHandler OnGameStart;
public enum State
{
    
    CountDownToStart,
    GamePlaying
}

    private State state;
    public static GameManager Instance;
  //  private const string highScoreKey = "HighScore";
    public int highScore;
  [SerializeField]  float countdownToStart;
   

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject  );
        }
            Init();
    }
       
        

    private void Start()
    {
       highScore =  PlayerPrefs.GetInt("highScore", 0);
      //  Debug.Log(highScore);
            
    }
    private void Update()
    {
        switch(state)
        {
            case State.CountDownToStart:
                countdownToStart -= Time.deltaTime;
               ;
                if (countdownToStart < 0f)
                {
                    state = State.GamePlaying;                 
                    OnGameStart?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                
                break;
        }
    }
    public float GetCountdownToStartTimer()
    {
        return countdownToStart;
    }


    public void HighScore(int score)
    {
        int currentScore = score;
       if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("highScore", highScore);

        }

        
    }



    public int CurrentScore { get; set; }
    public bool IsInitialized { get; set; }


    private void Init()
    {
        CurrentScore = 0;
       // IsInitialized = false;
    }

    private const string MainMenu = "MainMenu";
    private const string Gameplay = "Gameplay";

    public void GoToMainMenu()
    {
       
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }

    public void GoToGameplay()
    {
        countdownToStart = 3;
        state = State.CountDownToStart;
        UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);


    }

   
}
