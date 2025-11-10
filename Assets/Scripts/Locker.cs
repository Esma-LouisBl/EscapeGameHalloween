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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lockedText.enabled = false;
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
                Destroy(gameObject);
                _audioSource.Play();
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
        yield return new WaitForSeconds(2);
        _lockedText.enabled = false;
    }
}
