using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
