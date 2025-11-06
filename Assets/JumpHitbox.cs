using Unity.VisualScripting;
using UnityEngine;

public class JumpHitbox : MonoBehaviour
{
    public bool onGround;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            onGround = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            onGround = false;
        }
    }

    public bool Grounded()
    {
        return onGround;
    }

}
