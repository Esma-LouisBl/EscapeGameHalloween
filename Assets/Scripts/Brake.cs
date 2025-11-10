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
        if (!_playerManager.parkingBrake)
        {
            StartCoroutine(PullingBrake());
        }
    }

    private IEnumerator PullingBrake()
    {
        _audioSource.Play();
        for (int i = 0; i < 85; i++)
        {
            _transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        _playerManager.parkingBrake = true;
    }
}
