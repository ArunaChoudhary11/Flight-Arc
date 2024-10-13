using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _scorePrefab;
    [SerializeField] GameObject player;
   // public Image image;


    public int score;
   

    private void Awake()
    {
       
        
            Instance = this;
          

        
        
    }
   
    private void Start()
    {
        GameManager.Instance.IsInitialized = true;

        score = 0;
        _scoreText.text = score.ToString();
        SpawnScore();
    }
    private void Update()
    {
       // UpdateScore();
    }

    public void UpdateScore()
    {
        score++;
        _scoreText.text = score.ToString();
        SpawnScore();
    }

    private void SpawnScore()
    {
        if(_scorePrefab != null)
        {
        Instantiate(_scorePrefab);

        }
        else
        {
            return;
        }
    }

    public void GameEnded()
    {
        PlayerPrefs.SetInt("Score", score);
        
      //  GameManager.Instance.CurrentScore = score;
        GameManager.Instance.HighScore(score);
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        Destroy(player);
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.GoToMainMenu();
    }
    
}
