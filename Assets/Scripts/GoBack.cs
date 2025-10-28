using UnityEngine;
using System.Collections;

public class GoBack : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform, _destinationTransform;
    private Vector3 _range;

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

    public void Return()
    {
        _range = _destinationTransform.position - _playerTransform.position;
        _range /= 100;
        StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {   
        while (_playerTransform.position != _destinationTransform.position)
        {
            _playerTransform.position = _playerTransform.position + _range;
            yield return new WaitForSeconds(.01f);
        }
        _playerManager.atSpawn = true;
    }
}
