using System;
using System.Collections;
using UnityEngine;

public class Brake : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private PlayerManager _playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(PullingBrake());
    }

    private IEnumerator PullingBrake()
    {
        for (int i = 0; i < 85; i++)
        {
            _transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        _playerManager.parkingBrake = true;
    }
}
