using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpForce = 200;
    private Rigidbody playerRb;
    private bool isJumping;
    private float horizontalInput;
    private float speed = 5;
    public GameObject shotPrefab;
    private Vector3 offset = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumping == false)
        {
            isJumping = Input.GetKeyDown(KeyCode.UpArrow);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(shotPrefab, transform.position + offset, shotPrefab.transform.rotation);
        }
    }

    void FixedUpdate()
    {
        if(isJumping)
        {
            playerRb.AddForce(Vector3.up * jumpForce);
            isJumping = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
    }
}
