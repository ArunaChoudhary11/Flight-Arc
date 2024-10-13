using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrefs : MonoBehaviour
{
    private const string TutorialCompletedKey = "TutorialCompleted";

    [SerializeField] Transform tutirialBtn;
    void Start()
    {
        tutirialBtn.gameObject.SetActive(false);
        if (!PlayerPrefs.HasKey(TutorialCompletedKey))
        {
            tutirialBtn.gameObject.SetActive(true);

            Debug.Log("Starting tutorial...");

            // Mark the tutorial as completed
            PlayerPrefs.SetInt(TutorialCompletedKey, 1);
            PlayerPrefs.Save();
        }
        else
        {
            // Tutorial has been completed
            Debug.Log("Tutorial already completed.");
            tutirialBtn.gameObject.SetActive(false) ;
        }
    }
}
