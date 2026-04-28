using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicTutorial : MonoBehaviour
{


    public Image basics;
    public Image core;
    public Image special;
    public Image advanced;
    public GameObject playButton;
    public GameObject menuButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        core.enabled = false;
        special.enabled = false;
        advanced.enabled = false;
        playButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Previous()
    {
        if (basics.enabled)
        {
            return;
        }
        else if (core.enabled)
        {
            menuButton.SetActive(true);
            basics.enabled = true;
            core.enabled = false;
        }
        else if (special.enabled)
        {
            core.enabled = true;
            special.enabled = false;
        }
        else if (advanced.enabled)
        {
            playButton.SetActive(false);
            special.enabled = true;
            advanced.enabled = false;
        }
    }

    public void Next()
    {
        if (basics.enabled)
        {
            menuButton.SetActive(false);
            core.enabled = true;
            basics.enabled = false;
        }
        else if (core.enabled)
        {
            special.enabled = true;
            core.enabled = false;
        }
        else if (special.enabled)
        {
            playButton.SetActive(true);
            advanced.enabled = true;
            special.enabled = false;
        }
        else if (advanced.enabled)
        {
            return;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
