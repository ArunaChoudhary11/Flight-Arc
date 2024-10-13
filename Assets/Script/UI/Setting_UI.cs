using UnityEngine;
using UnityEngine.UI;

public class Setting_UI : MonoBehaviour
{
    public static Setting_UI instance;
    [SerializeField] Button soundMute;
    [SerializeField] Transform soundOnIcon;
    [SerializeField] Transform soundOffIcon;
    [SerializeField] Button musicMute;
    [SerializeField] Transform musicOnIcon;
    [SerializeField] Transform musicOffIcon;
    [SerializeField] Button moreGames;
    [SerializeField] Button companyInfo;
    [SerializeField] Button okButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);

        // Load saved preferences
        LoadPreferences();

        MainMenu_UI.Instance.OnSettingBtnClick += Instance_OnSettingBtnClick;

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
            Games();
        });

        companyInfo.onClick.AddListener(() =>
        {
            company();
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
        bool isSoundMuted = PlayerPrefs.GetInt("SoundMuted", 0) == 1;

        if (isSoundMuted)
        {
            SoundManager.Instance._effectSource.volume = 1;
            soundOnIcon.gameObject.SetActive(true);
            soundOffIcon.gameObject.SetActive(false);
            PlayerPrefs.SetInt("SoundMuted", 0);
        }
        else
        {
            SoundManager.Instance._effectSource.volume = 0;
            soundOffIcon.gameObject.SetActive(true);
            soundOnIcon.gameObject.SetActive(false);
            PlayerPrefs.SetInt("SoundMuted", 1);
        }
    }

    public void MusicMute()
    {
        bool isMusicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;

        if (isMusicMuted)
        {
            MusicManager_.Instance.musicSource.volume = 0.5f;
            musicOnIcon.gameObject.SetActive(true);
            musicOffIcon.gameObject.SetActive(false);
            MusicManager_.Instance.musicSource.Play();
            PlayerPrefs.SetInt("MusicMuted", 0);
        }
        else
        {
            MusicManager_.Instance.musicSource.volume = 0;
            musicOffIcon.gameObject.SetActive(true);
            musicOnIcon.gameObject.SetActive(false);
            MusicManager_.Instance.musicSource.Stop();
            PlayerPrefs.SetInt("MusicMuted", 1);
        }
    }

    private void Instance_OnSettingBtnClick(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void company()
    {
        Application.OpenURL("https://codex2d.com");
    }

    public void Games()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7946245812126462670&pli=1");
    }

    private void LoadPreferences()
    {
        bool isSoundMuted = PlayerPrefs.GetInt("SoundMuted", 0) == 1;
        bool isMusicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;

        if (isSoundMuted)
        {
            SoundManager.Instance._effectSource.volume = 0;
            soundOffIcon.gameObject.SetActive(true);
            soundOnIcon.gameObject.SetActive(false);
        }
        else
        {
            SoundManager.Instance._effectSource.volume = 1;
            soundOnIcon.gameObject.SetActive(true);
            soundOffIcon.gameObject.SetActive(false);
        }

        if (isMusicMuted)
        {
            MusicManager_.Instance.musicSource.volume = 0;
            musicOffIcon.gameObject.SetActive(true);
            musicOnIcon.gameObject.SetActive(false);
            MusicManager_.Instance.musicSource.Stop();
        }
        else
        {
            MusicManager_.Instance.musicSource.volume = 0.5f;
            musicOnIcon.gameObject.SetActive(true);
            musicOffIcon.gameObject.SetActive(false);
            MusicManager_.Instance.musicSource.Play();
        }
    }
}
