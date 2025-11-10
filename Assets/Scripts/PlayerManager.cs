using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public bool atSpawn;

    [SerializeField]
    private GameObject _goBackButton, _moveForward, _moveToRight, _jumpToRoad;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private AudioSource _audioSource;

    public bool hasKey = false, lockerBroken, parkingBrake, gameOver = false, playerCanMove = false;

    [SerializeField]
    private Enemy _enemy;

    [SerializeField] private GameObject _startEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startEffect.SetActive(true);
        playerCanMove = false;
        atSpawn = true;
        
        _jumpToRoad.SetActive(false);
        
        StartCoroutine(LaunchingGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (atSpawn)
        {
            _goBackButton.SetActive(false);
            _moveForward.SetActive(true);
            _moveToRight.SetActive(true);
        }
        else
        {
            _goBackButton.SetActive(true);
            _moveForward.SetActive(false);
            _moveToRight.SetActive(false);

            if (_enemy.lookingAtPlayer && !gameOver)
            {
                gameOver = true;
                playerCanMove = false;
                StartCoroutine(Screamer());
            }
        }

        if (lockerBroken)
        {
            _jumpToRoad.SetActive(true);
        }

    }

    public void RotateToRight()
    {
        StartCoroutine(RotationToRight());
    }

    public void RotateToLeft()
    {
        StartCoroutine(RotationToLeft());
    }
    private IEnumerator RotationToRight()
    {
        for (int i = 0; i < 90; i++)
        {
            _playerTransform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private IEnumerator RotationToLeft()
    {
        for (int i = 0; i < 90; i++)
        {
            _playerTransform.Rotate(0, -1, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    private IEnumerator Screamer()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadSceneAsync(2);
    }

    private IEnumerator LaunchingGame()
    {
        yield return new WaitForSeconds(3.17f);
        playerCanMove = true;
        _startEffect.SetActive(false);
    }
}
