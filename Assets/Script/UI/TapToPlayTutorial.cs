using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlayTutorial : MonoBehaviour
{
    public static TapToPlayTutorial Instance;
    [SerializeField] Button playTutorial;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameObject.SetActive(true);
        playTutorial.onClick.AddListener(() =>
        {
            LoadScene();
        });
    }

    private void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
