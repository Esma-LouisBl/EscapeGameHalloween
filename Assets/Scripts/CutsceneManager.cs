using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip1, _clip2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyAnimator.SetTrigger("Scenedebut");
        _audioSource.clip = _clip1;
        _audioSource.Play();
        StartCoroutine(Intro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Intro()
    {
        yield return new WaitForSeconds(6);
        _enemyAnimator.SetTrigger("Take");
        _audioSource.clip = _clip2;
        _audioSource.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }
}
