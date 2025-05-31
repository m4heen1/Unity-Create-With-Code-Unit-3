using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpforce = 10;
    public float gravityModifer;
    public bool isOnground = true;
    public bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifer;
        
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnground && !gameOver) {
        playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        isOnground = false;
        playerAnim.SetTrigger("Jump_trig");
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
          playerAnim.SetBool("Death_b", true);
          playerAnim.SetInteger("DeathType_int",1);
      }
    }
}

