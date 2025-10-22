using System.Collections;
using UnityEngine;

public class SpatialPoint : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform, _destinationTransform;
    [SerializeField]
    private MeshRenderer _renderer;
    [SerializeField]
    private GameObject _text;

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
        _renderer.enabled = false;
        _text.SetActive(false);
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
    }

}
