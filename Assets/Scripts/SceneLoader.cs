using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    Animator animator;

    void Start () {
        animator = GetComponentInChildren<Animator>();
        print (animator);
    }

    public void LoadGame() {

        animator.SetTrigger("FadeStart");
        Invoke("LoadScene", 2f);

    }

    private void LoadScene() {

                SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
