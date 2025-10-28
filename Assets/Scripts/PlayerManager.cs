using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool atSpawn;

    [SerializeField]
    private GameObject _goBackButton, _moveForward, _moveToRight;
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Enemy _enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (atSpawn)
        {
            _goBackButton.SetActive(false);
            _moveForward.SetActive(true);
            _moveToRight.SetActive(true);
        }
        else
        {
            _goBackButton.SetActive(true);
            _moveForward.SetActive(false);
            _moveToRight.SetActive(false);

            if (_enemy.lookingAtPlayer)
            {
                Debug.Log("PERDU");
            }
        }

    }

    public void RotateToRight()
    {
        StartCoroutine(RotationToRight());
    }

    public void RotateToLeft()
    {
        StartCoroutine(RotationToLeft());
    }
    private IEnumerator RotationToRight()
    {
        for (int i = 0; i < 90; i++)
        {
            _playerTransform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private IEnumerator RotationToLeft()
    {
        for (int i = 0; i < 90; i++)
        {
            _playerTransform.Rotate(0, -1, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
