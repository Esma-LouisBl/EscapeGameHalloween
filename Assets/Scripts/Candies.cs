using System;
using UnityEngine;

public class Candies : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;

    private int _clickNumber = 0;
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
        switch (_clickNumber)
        {
            case 3:
                _playerManager.hasKey = true;
                break;
            case < 3:
                _clickNumber++;
                break;
        }
    }
}
