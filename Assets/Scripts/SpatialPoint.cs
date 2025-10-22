using System.Collections;
using UnityEngine;

public class SpatialPoint : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform, _destinationTransform;

    private Vector3 _range;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        _range = _destinationTransform.position - _playerTransform.position;
        _range /= 100;
        StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {   while (_playerTransform.position != _destinationTransform.position)
        {
            _playerTransform.position = _playerTransform.position + _range;
            yield return new WaitForSeconds(.01f);
        }
    }

}
