using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyAnimator.SetTrigger("Scenedebut");
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
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }
}
