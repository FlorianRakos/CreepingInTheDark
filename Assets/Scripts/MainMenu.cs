using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] Canvas mainCanvas, storyCanvas, controllCanvas, mainBackground, storyBackground;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioSource audioSource;
    

    void Start()
    {
        showMainMenu();
    }

    public void showMainMenu () {
        disableAll();
        mainCanvas.enabled = true;
        mainBackground.enabled = true;
    }

    public void showStoryMenu () {
        disableAll();
        storyCanvas.enabled = true;
        storyBackground.enabled = true;
    }

    public void showControllMenu () {
        disableAll();
        controllCanvas.enabled = true;
        storyBackground.enabled = true;
    }

    private void disableAll () {
        mainCanvas.enabled = false;
        storyCanvas.enabled = false;
        controllCanvas.enabled = false;
        mainBackground.enabled = false;
        storyBackground.enabled = false;
    }
    
    public void playButtonSound () {
        audioSource.PlayOneShot(buttonSound);
    }
}
