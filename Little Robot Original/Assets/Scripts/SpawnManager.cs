using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject heartPrefab;
    private int posY;
    private float delayTime = 2;
    private float repeatTime = 3;
    private float delayTime2 = 4;
    private float repeatTime2 = 4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", delayTime, repeatTime);
        InvokeRepeating("SpawnHeart", delayTime2, repeatTime2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        posY = Random.Range(1, 5);
        Vector3 spawnPos = new Vector3(0, posY, 0);
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    void SpawnHeart()
    {
        Vector3 spawnpos = new Vector3(0, 1, 0);
        Instantiate(heartPrefab, spawnpos, heartPrefab.transform.rotation);
    }
}
