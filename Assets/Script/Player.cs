using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _moveClip, _loseClip, _pointClip;

    public event EventHandler OnClickRight;
    public event EventHandler OnClickLeft;

    [SerializeField] private GameplayManager _gm;
    [SerializeField] private GameObject _explosionPrefab, _scoreParticlePrefab;

    private bool canClick;

    [SerializeField] private float _startRadius;
    [SerializeField] private float _moveTime;

    [SerializeField] private List<float> _rotateRadius;
     private float currentRadius;

    /*[SerializeField] Button leftBtt;
    [SerializeField] Button rightBtt;*/

    private int level;

    float screenWidth = Screen.width;

    /*private void OnEnable()
    {
        leftBtt.onClick.AddListener(OnLeft);
        rightBtt.onClick.AddListener(OnRight);
    }

    private void OnDisable()
    {
        leftBtt.onClick.RemoveListener(OnLeft);
        rightBtt.onClick.RemoveListener(OnRight);
    }*/

    private void Awake()
    {
        canClick = true;
        level = 0;
        currentRadius = _startRadius;
    }

    void OnLeft()
    {
        if (canClick)
        {
            StartCoroutine(ChangeRadius(true));
            SoundManager.Instance.PlaySound(_moveClip);
        }
    }

    void OnRight()
    {
        if (canClick)
        {
            StartCoroutine(ChangeRadius(false));
            SoundManager.Instance.PlaySound(_moveClip);
        }
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))
        {
            if (mousePos.x < (screenWidth / 2))
            {
                if (canClick)
                {
                    OnClickLeft?.Invoke(this, EventArgs.Empty);
                    StartCoroutine(ChangeRadius(true));
                    SoundManager.Instance.PlaySound(_moveClip);
                }
            }
            else
            {
                if (canClick)
                {
                 
                    OnClickRight?.Invoke(this, EventArgs.Empty);
                    StartCoroutine(ChangeRadius(false));
                    SoundManager.Instance.PlaySound(_moveClip);
                }
            }
        }
      
    }

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _rotateTransform;

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.up * currentRadius;
        float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / currentRadius;
        _rotateTransform.Rotate(0, 0, rotateValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySound(_loseClip);
            _gm.GameEnded();
            return;
        }

        if(collision.CompareTag("Score"))
        {
            Destroy(Instantiate(_scoreParticlePrefab, transform.position, Quaternion.identity),0.5f);
            SoundManager.Instance.PlaySound(_pointClip);
            _gm.UpdateScore();
            collision.gameObject.GetComponent<Score>().ScoreAdded();
            return;
        }
    }


    


    private IEnumerator ChangeRadius(bool left)
    {
        canClick = false;
        float moveStartRadius = _rotateRadius[level];
        float moveEndRadius = _rotateRadius[(level + 1) % _rotateRadius.Count];
        float moveOffset = moveEndRadius - moveStartRadius;
        float speed = 1 / _moveTime;
        float timeElasped = 0f;
        int currentRing = 0;
        while(timeElasped < 1f)
        {
            timeElasped += speed * Time.fixedDeltaTime;
            if (left)
            {
                if(currentRadius == 4)
                {
                    //cameraShake
                }
                else if(currentRadius == 8)
                {
                    currentRing = 1;  
                }
                else if (currentRadius == 12)
                {
                    currentRing = 2;
                }
            }
            else
            {
                if (currentRadius == 12)
                {
                    //cameraShake
                }
                else if (currentRadius == 8)
                {
                    currentRing = 3;
                }
                else if (currentRadius == 4)
                {
                    currentRing = 2;
                }
            }
            yield return new WaitForFixedUpdate(); 
        }

        canClick = true;
        level = (level + 1) % _rotateRadius.Count;
        if(currentRing == 1)
        {
            currentRadius = 4;
        }
        else if (currentRing == 2)
        {
            currentRadius = 8;
        }
        else if (currentRing == 3)
        {
            currentRadius = 12;
        }
        //currentRadius = _rotateRadius[level];
    }
}
