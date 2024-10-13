using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField] Button setting_UI;
    public static MainMenu_UI Instance;
    [SerializeField] Transform settingUI;
  // [SerializeField] Transform tutorialUI;


    public event EventHandler OnSettingBtnClick;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        setting_UI.onClick.AddListener(() =>
        {
            OnSettingBtnClick?.Invoke(this, EventArgs.Empty);
        });


        if(settingUI.gameObject == null)
        {
            return;
        }
       /* if(tutorialUI.gameObject == null) 
        { return; }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if(settingUI.gameObject.activeSelf == true ) { 

            tutorialUI.gameObject.SetActive(false);
        }
        else
        {
            tutorialUI.gameObject.SetActive(true);
        }*/
    }
}
