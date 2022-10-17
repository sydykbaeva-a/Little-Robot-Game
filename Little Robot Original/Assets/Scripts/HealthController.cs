using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth = 3;
    [SerializeField] Image[] health;
    // Start is called before the first frame update
    
    public int CheckHealth(int number)
    {
        playerHealth += number;
        return playerHealth;
    }
    void Start()
    {
        HealthUpdate();
    }
    // Update is called once per frame
    public void HealthUpdate()
    {
        for(int i = 0; i < health.Length; i++){
            if(i < playerHealth){
                health[i].color = Color.red;
            }else{
                health[i].color = Color.black;
            }
        }
    }
}
