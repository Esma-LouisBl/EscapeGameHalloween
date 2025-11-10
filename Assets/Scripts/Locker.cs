using System;
using Unity.VisualScripting;
using UnityEngine;

public class Locker : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
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
        if (_playerManager.hasKey)
        {
            Destroy(gameObject);
        }
    }
}
