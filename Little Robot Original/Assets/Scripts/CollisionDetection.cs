using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(gameObject.CompareTag("Player") && other.gameObject.CompareTag("Heart"))
        {
            if(gameObject.CompareTag("Heart") && other.gameObject.CompareTag("Player"))
            Destroy(other.gameObject);
            Debug.Log("Heart si eaten");
        }
        else if(gameObject.CompareTag("Shot") && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }   
    }
}
