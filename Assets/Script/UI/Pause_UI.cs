using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_UI : MonoBehaviour
{
    [SerializeField] Button resumeBtn;
    [SerializeField] Button settingBtn;
    [SerializeField] Transform settingUI;
  //  [SerializeField] Button mainMenuBtn;
    // Start is called before the first frame update
    void Start()
    {
        resumeBtn.onClick.AddListener(() =>
        {
            Resume();
        });
        settingBtn.onClick.AddListener(() =>
        {
            Setting();
        });
       /* mainMenuBtn.onClick.AddListener(() =>
        {
            MainMenuSence();
        });*/
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    private void Setting()
    {
        settingUI.gameObject.SetActive(true);
        
    }

    private void MainMenuSence()
    {
        GameManager.Instance.GoToMainMenu();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
