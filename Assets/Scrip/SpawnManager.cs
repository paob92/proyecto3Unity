using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float starDelay = 2;
    private float repeatRate = 2;
    private PlayerContoller playerContollerScript;
   

    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
        InvokeRepeating("SpawnObstacle", starDelay, repeatRate);
    }
        void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        if(playerContollerScript.gameOver == false) //para detener la generacion de obstaculos cuando sea Game Over
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);//para llamar copias del prefab
        }

    }
} 