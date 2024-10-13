using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton_UI : MonoBehaviour
{
    [SerializeField] Button home;

    // Start is called before the first frame update
    void Start()
    {
        home.onClick.AddListener(() =>
        {
            LoadScene();
        });
    }
    private void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
