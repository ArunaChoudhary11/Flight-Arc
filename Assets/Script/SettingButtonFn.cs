using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 


public class SettingButtonFn : MonoBehaviour
{

    public GameObject image;
    public bool setting;


    public  Sprite soundOnimage;
    public Sprite soundOffimage;
    public Button btn;
    private bool ison = true;
    public AudioSource audioSource; 


    // Start is called before the first frame update
    void Start()
    {
        soundOffimage = btn.image.sprite;
        setting = false;



    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void ButtononClicked()
    {
        if(ison)
        {
            btn.image.sprite = soundOffimage;
            ison = false;
            audioSource.mute = true;


        }
        else
        {
            
                btn.image.sprite = soundOnimage;
                ison = true;
                audioSource.mute = false;


            
        }
    }
}
