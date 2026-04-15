using UnityEngine;
using UnityEngine.UI;

public class SprintBarScript : MonoBehaviour
{

    public PlayerScript player;
    public Vector3 offset = new Vector3 (0, 1.2f, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = player.transform.position + offset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        transform.position = screenPos;
        
    }
}
