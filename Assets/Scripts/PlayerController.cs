using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpforce = 10;
    public float gravityModifer;
    public bool isOnground = true;
    public bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifer;
        
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnground) {
        playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        isOnground = false;
      }  
    }
    
    
    private void OnCollisionEnter(Collision collision)
    {
    
      if (collision.gameObject.CompareTag("Ground"))
      {
        isOnground = true;

      } else if (collision.gameObject.CompareTag("Obstacle"))
      {
          Debug.Log("Game Over");
          gameOver = true;
      }
    }
}

