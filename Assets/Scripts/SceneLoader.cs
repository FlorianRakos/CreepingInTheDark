using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void LoadGame()
    {
        animator.SetTrigger("FadeStart");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(1);
        animator.SetTrigger("FadeEnd");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
