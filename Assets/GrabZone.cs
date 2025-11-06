using UnityEngine;

public class GrabZone : MonoBehaviour
{
    public bool canGrab;
    public Sprite normalSprite;
    public Sprite grabSprite;
    public SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canGrab = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canGrab = false;
        }
    }

    public bool IsGrabed()
    {
        return canGrab;
    }
}
