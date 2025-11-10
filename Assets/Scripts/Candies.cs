using System;
using System.Collections;
using UnityEngine;

public class Candies : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
    [SerializeField]
    private AudioSource _audioSource;

    private int _clickNumber = 0;

    private bool _canClick = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                    _playerManager.hasKey = true;
                    break;
                case < 3:
                    _clickNumber++;
                    _audioSource.Play();
                    StartCoroutine(Cooldown());
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
