using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager_ : MonoBehaviour
{
    public static MusicManager_ Instance;
    public AudioSource musicSource;
    [SerializeField] AudioClip musicClip;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
        
    }
    private void Update()
    {
        
    }



    public void PlaySound()
    {
        musicSource.Play();

    }
}
