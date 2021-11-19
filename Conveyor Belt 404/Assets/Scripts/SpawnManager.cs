using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform originLeft, originRight;
    [SerializeField] private GameObject toxGreenPrefab, toxYellowPrefab;
    [SerializeField] private bool canSpawn;
    [SerializeField] private float timeBetweenSpawnsMax;
    [SerializeField] private float timeBetweenSpawnsMin;
    [SerializeField] private bool spawnerActive;

    private void Start()
    {
        canSpawn = true;
        spawnerActive = false;
    }
    void Update()
    {
        if (spawnerActive)
        {
            if (canSpawn)
            {
                Spawn();
                StartCoroutine(SpawnDelayCo());
            }
        }
        
    }

    private void Spawn()
    {
        int rnd = Random.Range(0, 2);
        int rndColor = Random.Range(0, 2);
        GameObject tempPrefab;
        if (rndColor == 1)
        {
            tempPrefab = toxGreenPrefab;
        }
        else
        {
            tempPrefab = toxYellowPrefab;
        }
        //left
        if (rnd == 1)
        {
            
            Instantiate(tempPrefab, originLeft.position, Quaternion.identity);
        }
        //right
        else
        {
            Instantiate(tempPrefab, originRight.position, Quaternion.identity);
        }
        canSpawn = false;
    }

    IEnumerator SpawnDelayCo()
    {
        yield return new WaitForSeconds(Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax));
        canSpawn = true;
    }
}
