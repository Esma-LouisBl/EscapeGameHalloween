using System;
using System.Collections;
using UnityEngine;

public class Brake : MonoBehaviour
{
    private Transform _transform;
    private AudioSource _audioSource;
    [SerializeField] private PlayerManager _playerManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!_playerManager.atSpawn)
        {
            if (!_playerManager.parkingBrake)
            {
                StartCoroutine(PullingBrake());
            }
            
        }
    }

    private IEnumerator PullingBrake()
    {
        _audioSource.Play();
        _playerManager.parkingBrake = true;
        for (int i = 0; i < 85; i++)
        {
            _transform.Rotate(0, 0, -1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
