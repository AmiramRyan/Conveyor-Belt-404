using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GenericSingletonClass_spawn<MonoBehaviour>
{ 
    [SerializeField] private Transform originLeft, originRight;
    [SerializeField] private GameObject toxGreenPrefab, toxYellowPrefab;
    private bool canSpawn;
    private float timeBetweenSpawnsMax;
    private float timeBetweenSpawnsMin;
    public bool spawnerActive;


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

    public void SetSpawner(float maxRndTime, float minRndTime)
    {
        timeBetweenSpawnsMax = maxRndTime;
        timeBetweenSpawnsMin = minRndTime;
        canSpawn = true;
    }

    IEnumerator SpawnDelayCo()
    {
        yield return new WaitForSeconds(Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax));
        canSpawn = true;
    }
}
