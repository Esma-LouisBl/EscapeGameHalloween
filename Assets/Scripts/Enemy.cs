using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _enemyTransform;
    [SerializeField]
    private Light _light;

    public bool hasSeenPlayer = false, lookingAtPlayer = false;
    private int _time;
    private bool _needingNumber = true, _isWaiting = false, _needToLookPlayer = false, _feint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_needingNumber && !_isWaiting)
        {
            _isWaiting = true;
            StartCoroutine(Wait(_time));
        }

        else if (_needingNumber && !_isWaiting) //génération du temps d'attente et feinte ou non
        {
            _time = Random.Range(10, 41);
            _needingNumber = false;

            int r = Random.Range(0, 2);
            if (r == 0)
            {
                _feint = false;
            }
            else
            {
                _feint = true;
            }
        }

        if (_needToLookPlayer)
        {
            _needToLookPlayer = false;
            StartCoroutine(StayAtPlayer());
        }
    }

    private void TurnBack()
    {
        if (_feint)
        {
            StartCoroutine(FeintRotating());
        }
        else
        {
            StartCoroutine(Rotating());
        }
    }

    private IEnumerator Rotating()
    {
        for (int i = 0; i < 180; i++)
        {
            _enemyTransform.Rotate(0, 1, 0);
            _light.intensity += 10;
            yield return new WaitForSeconds(.01f);
        }

        _needToLookPlayer = true;
    }

    private IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
        TurnBack();
    }

    private IEnumerator StayAtPlayer()
    {
        lookingAtPlayer = true;
        yield return new WaitForSeconds(3);
        lookingAtPlayer = false;

        StartCoroutine(Returning());
    }

    private IEnumerator Returning()
    {
        for (int i = 0; i < 180; i++)
        {
            _enemyTransform.Rotate(0, -1, 0);
            _light.intensity -= 10;
            yield return new WaitForSeconds(.01f);
        }
        _needingNumber = true;
        _isWaiting = false;
    }

    private IEnumerator FeintRotating()
    {
        for (int i = 0; i < 90; i++)
        {
            _enemyTransform.Rotate(0, 1, 0);
            _light.intensity += 10;
            yield return new WaitForSeconds(.01f);
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(FeintReturning());

    }
    private IEnumerator FeintReturning()
    {
        for (int i = 0; i < 90; i++)
        {
            _enemyTransform.Rotate(0, -1, 0);
            _light.intensity -= 10;
            yield return new WaitForSeconds(.01f);
        }
        _needingNumber = true;
        _isWaiting = false;
    }
}
