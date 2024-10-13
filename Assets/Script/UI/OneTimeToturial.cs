using UnityEngine;
using UnityEngine.UI;

public class OneTimeToturial : MonoBehaviour
{
    [SerializeField] Button rightBtn;
    [SerializeField] Transform rightArrow;
    [SerializeField] Button leftBtn;
    [SerializeField] Transform leftArrow;
    [SerializeField] Player player;
    [SerializeField] Transform parent;

    bool start;
    bool left;
    bool right;

    // Start is called before the first frame update
    void Start()
    {
        player.OnClickRight += Player_OnClick;
        player.OnClickLeft += Player_OnClickLeft;
        leftArrow.gameObject.SetActive(false);
        rightArrow.gameObject.SetActive(false);
        start = false;
        right = true;
        left = true;

        GameManager.Instance.OnGameStart += Instance_OnGameStart;
        if (start)
        {
            rightBtn.onClick.AddListener(() =>
            {
                Debug.Log("btnWorking");
                if (right == false)
                {
                    leftArrow.gameObject.SetActive(true);
                    rightArrow.gameObject.SetActive(false);
                    left = false;
                   // right = true;
                    Debug.Log("touch");
                }
            });

            leftBtn.onClick.AddListener(() =>
            {
                Debug.Log("btnWorking");
                if (!left)
                {
                    Debug.Log("touchleft");
                    leftArrow.gameObject.SetActive(true);
                    left = true;
                }
            });

        }
    }

    private void Player_OnClickLeft(object sender, System.EventArgs e)
    {
       if (left == false)
        {
            Debug.Log("touchleft");
            leftArrow.gameObject.SetActive(true);
            rightArrow.gameObject.SetActive(false);
            left = false;
            parent.gameObject.SetActive(false);
        }
    }

    private void Player_OnClick(object sender, System.EventArgs e)
    {
        Debug.Log("touchright");
        if (right == false)
        {
            leftArrow.gameObject.SetActive(true);
            rightArrow.gameObject.SetActive(false);
            left = false;
            // right = true;
          
        }


       
    }

    private void Instance_OnGameStart(object sender, System.EventArgs e)
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            rightArrow.gameObject.SetActive(true);
            right = false;
            start = false;

        }

      

       

    }
}
