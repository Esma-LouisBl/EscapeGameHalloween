using System;
using System.Collections;
using UnityEngine;

public class Candies : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField] private Transform _candiesTransform;
    [SerializeField] private GameObject _candiesGO, _keyGO;
    
    [SerializeField] private AudioClip _eating, _key;
    
    private int _clickNumber = 0;

    private bool _canClick = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource.clip = _eating;
        _keyGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!_playerManager.atSpawn && _canClick)
        {
            switch (_clickNumber)
            {
                case 3:
                    _audioSource.clip = _key;
                    _keyGO.SetActive(false);
                    _playerManager.hasKey = true;
                    _audioSource.Play();
                    _canClick = false;
                    break;
                case < 3:
                    if (_clickNumber < 2)
                    {
                        _candiesTransform.Translate(0, -0.3f, 0);
                    }
                    else
                    {
                        _candiesGO.SetActive(false);
                        _keyGO.SetActive(true);
                    }
                    _clickNumber++;
                    StartCoroutine(Cooldown());
                    _audioSource.Play();
                    break;
            }
            
            
        }
    }

    private IEnumerator Cooldown()
    {
        _canClick = false;
        yield return new WaitForSeconds(_audioSource.clip.length);
        _canClick = true;
    }
}
