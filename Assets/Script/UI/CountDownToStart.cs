using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownToStart : MonoBehaviour
{
    public static CountDownToStart Instance;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] Transform Obstecals;
    [SerializeField] Transform Player;
    [SerializeField] Transform tutorialPopup;
    int perviousCountDownNo;
    // Start is called before the first frame update

    private void Awake()
    {
        

    }
    void Start()
    {
        Obstecals.gameObject.SetActive(false);
        Player.gameObject.SetActive(false);
        GameManager.Instance.OnGameStart += Instance_OnGameStart1;
    }

    private void Instance_OnGameStart1(object sender, System.EventArgs e)
    {
        Obstecals.gameObject.SetActive(true);
        Player.gameObject.SetActive(true);
        tutorialPopup.gameObject.SetActive(false);
        Hide();
    }
    // Update is called once per frame
    void Update()
    {
        int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();
        if (perviousCountDownNo != countdownNumber)
        {
            perviousCountDownNo = countdownNumber;

           //effects or sounds;
        }

    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
