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
}
