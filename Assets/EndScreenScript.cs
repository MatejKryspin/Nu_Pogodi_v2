using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{

    public Image shownImage;
    public Text shownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowEndScreen(string text, Sprite sprite)
    {
        gameObject.SetActive(true);
        shownText.text = text;
        shownImage.sprite = sprite;
    }
    
}
