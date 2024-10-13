using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton_UI : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Transform pauseUI; 
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(() =>
        {
            PauseGame();
        });
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseUI.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
