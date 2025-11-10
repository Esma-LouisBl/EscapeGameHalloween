using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Locker : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;

    [SerializeField]
    private TextMeshProUGUI _lockedText;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _locked, _unlocked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lockedText.enabled = false;
        _audioSource.clip = _locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (_playerManager.atSpawn)
        {
            if (_playerManager.hasKey)
            {
                StartCoroutine(Unlock());
            }
            else
            {
                StartCoroutine(LockedMessage());
            }
        }
    }

    private IEnumerator LockedMessage()
    {
        _lockedText.enabled = true;
        _audioSource.Play();
        yield return new WaitForSeconds(2);
        _lockedText.enabled = false;
    }

    private IEnumerator Unlock()
    {
        _audioSource.clip = _unlocked;
        _audioSource.Play();
        yield return new WaitForSeconds(_unlocked.length);
        _playerManager._lockerBroken = true;
        Destroy(gameObject);
    }
}
