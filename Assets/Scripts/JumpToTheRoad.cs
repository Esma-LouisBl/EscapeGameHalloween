using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToTheRoad : MonoBehaviour
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
        if (_playerManager.parkingBrake)
        {
            SceneManager.LoadSceneAsync(3);
        }
        else
        {
            SceneManager.LoadSceneAsync(4);
        }
    }
}
