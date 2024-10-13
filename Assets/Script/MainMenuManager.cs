using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TMP_Text _newBestText;
    [SerializeField] private TMP_Text _bestScoreText;

   /* [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    int HighScore;*/

    /*[SerializeField] Button play;

    private void OnEnable()
    {
        play.onClick.AddListener(ClickedPlay);
    }

    private void OnDisable()
    {
        play.onClick.RemoveListener(ClickedPlay);
    }*/

    private void FixedUpdate()
    {
      
        
           _scoreText.text = GameplayManager.Instance.score.ToString();
        _bestScoreText.text = GameManager.Instance.highScore.ToString();
    }
    private void Start()
    {
        //   _bestScoreText.text = GameManager.Instance.HighScore.ToString();


     //   Debug.Log(GameManager.Instance.IsInitialized);
        if(!GameManager.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);
            _newBestText.gameObject.SetActive(false);
        }
       
        else
        {
           // StartCoroutine(ShowScore());
        }
    }

   /* private IEnumerator ShowScore()
    {
        int tempScore = 0;
      //  _scoreText.text = tempScore.ToString();

        int currentScore = GameplayManager.Instance.score;
        Debug.Log(currentScore + "currentScore");
       
        Debug.Log(highScore + "highScore");

        if(currentScore > highScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameplayManager.Instance.score = highScore;
            Debug.Log(currentScore);
            highScore = HighScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }

       *//* float speed = 1 / _animationTime;
        float timeElapsed = 0f;
        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;

            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();

        }*//*
            yield return null;

      //  tempScore = currentScore;
        _scoreText.text = GameManager.Instance.CurrentScore.ToString();
        Debug.Log(tempScore.ToString());
    }
*/
    [SerializeField] private AudioClip _clickSound;

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickSound);
        GameManager.Instance.GoToGameplay();
    }




}
