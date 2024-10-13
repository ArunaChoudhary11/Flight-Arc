using UnityEngine;
using UnityEngine.UI;

public class SettingMenuInGameUI : MonoBehaviour
{
    [SerializeField] Button soundMute;
    [SerializeField] Transform soundOnIcon;
    [SerializeField] Transform soundOffIcon;
    [SerializeField] Button musicMute;
    [SerializeField] Transform musicOnIcon;
    [SerializeField] Transform musicOffIcon;
    [SerializeField] Button moreGames;
    [SerializeField] Button companyInfo;
    [SerializeField] Button okButton;

    // Start is called before the first frame update
    void Start()
    {
        soundOffIcon.gameObject.SetActive(true);
        musicOffIcon.gameObject.SetActive(true);
        MusicManager_.Instance.musicSource.Play();

        musicMute.onClick.AddListener(() =>
        {

            MusicMute();
        });

        soundMute.onClick.AddListener(() =>
        {
            EffectMute();

        });


        moreGames.onClick.AddListener(() =>
        {

        });

        companyInfo.onClick.AddListener(() =>
        {

        });
        okButton.onClick.AddListener(() =>
        {
            Back();
        });

        Hide();
    }
    private void Back()
    {
        gameObject.SetActive(false);
    }

    private void EffectMute()
    {
        if (!soundOnIcon.gameObject.activeSelf == true)
        {
            SoundManager.Instance._effectSource.volume = 1;
            soundOnIcon.gameObject.SetActive(true);
            soundOffIcon.gameObject.SetActive(false);
        }
        else
        {
            SoundManager.Instance._effectSource.volume = 0;
            soundOffIcon.gameObject.SetActive(true);
            soundOnIcon.gameObject.SetActive(false);

        }
    }

    public void MusicMute()
    {

        if (!musicOnIcon.gameObject.activeSelf == true)
        {
            MusicManager_.Instance.musicSource.volume = 0.5f;
            musicOnIcon.gameObject.SetActive(true);
            musicOffIcon.gameObject.SetActive(false);
            MusicManager_.Instance.musicSource.Play();
        }
        else
        {
            MusicManager_.Instance.musicSource.volume = 0;
            musicOffIcon.gameObject.SetActive(true);
            musicOnIcon.gameObject.SetActive(false);
            MusicManager_.Instance.musicSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

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
