using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float speed = 5;
    public GameObject shotPrefab;
    public float gravityModifier;
    public bool isOnGround = true;
    private Vector3 offset = new Vector3(21, 3.5f, -2.9f);
    public bool endOfGame = false;
    public ParticleSystem jumpParticle;
    public ParticleSystem groundParticle;
    public Animator animator;
    public HealthController healthControl;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }
    // Update is called once per frame
    void Update()
    {
        if(endOfGame == false)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true)
        {
            groundParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpParticle.Play();
            isOnGround = false;
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shotPrefab, transform.position + offset, shotPrefab.transform.rotation);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        animator.SetBool("isRunning", Input.GetAxis("Horizontal") != 0);
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; 
            groundParticle.Play();
            jumpParticle.Stop();
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            healthControl.CheckHealth(-1);
            if(healthControl.playerHealth == 0)
            {
                endOfGame = true;
                Debug.Log("Game Over");
            }
        }  
    }
}
