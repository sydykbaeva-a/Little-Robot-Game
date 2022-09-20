using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject heartPrefab;
    private int posY;
    private float delayTime = 2;
    private float repeatTime = 1.2f;
    private float delayTime2 = 4;
    private float repeatTime2 = 10;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnEnemy", delayTime, repeatTime);
        InvokeRepeating("SpawnHeart", delayTime2, repeatTime2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        if(playerScript.endOfGame == false)
        {
            posY = Random.Range(1, 5);
            Vector3 spawnPos = new Vector3(15, posY, 0);
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }

    void SpawnHeart()
    {
        if(playerScript.endOfGame == false)
        {
            Vector3 spawnpos = new Vector3(17, 1, 0);
            Instantiate(heartPrefab, spawnpos, heartPrefab.transform.rotation);
        }
    }
}
