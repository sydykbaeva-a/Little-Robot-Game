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
    private Vector3 offset = new Vector3(1, 0, 0);
    public bool endOfGame = false;
    public ParticleSystem jumpParticle;
    public ParticleSystem groundParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround == true)
        {
            groundParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpParticle.Play();
            isOnGround = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shotPrefab, transform.position + offset, shotPrefab.transform.rotation);
        }

        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            Debug.Log("Heart + 1");
        }
        else if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; 
            groundParticle.Play();
            jumpParticle.Stop();
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            endOfGame = true;
            Debug.Log("Game Over");
        }  
    }
}
