using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{

    public Image ImageWin;
    public Image ImageLose;
    public Text TextWin;
    public Text TextLose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
            ImageWin.gameObject.SetActive(false);
            TextWin.gameObject.SetActive(false);
            ImageLose.gameObject.SetActive(false);
            TextLose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowEndScreen(bool win)
    {
        gameObject.SetActive(true);
        if (win)
        {
            ImageWin.gameObject.SetActive(true);
            TextWin.gameObject.SetActive(true);
        }
        else
        {
            ImageLose.gameObject.SetActive(true);
            TextLose.gameObject.SetActive(true);
        }

    }
    
}
