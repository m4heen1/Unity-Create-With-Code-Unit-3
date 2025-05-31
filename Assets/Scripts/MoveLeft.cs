using UnityEngine;

public class Move_Left : MonoBehaviour
{
    private float speed = 30;
    private PlayerControl playerControllerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControl>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        
    }
}
