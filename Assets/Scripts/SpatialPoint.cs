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
    [SerializeField] private AudioSource _audioSource;

    [SerializeField]
    private PlayerManager _playerManager;
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

        if (gameObject.CompareTag("TurnRight"))
        {
            // _playerManager.RotateToRight();
        }
        if (gameObject.CompareTag("TurnLeft"))
        {
            // _playerManager.RotateToLeft();
        }
    }

    private IEnumerator Moving()
    {   
        _audioSource.Play();
        while (_playerTransform.position != _destinationTransform.position)
        {
            _playerTransform.position = _playerTransform.position + _range;
            yield return new WaitForSeconds(.01f);
        }
        _audioSource.Stop();

        _playerManager.atSpawn = false;
    }

}
