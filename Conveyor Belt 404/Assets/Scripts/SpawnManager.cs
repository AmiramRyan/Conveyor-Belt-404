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
        //left
        if (rnd == 1)
        {
            Instantiate(toxGreenPrefab, originLeft.position, Quaternion.identity);
        }
        //right
        else
        {
            Instantiate(toxGreenPrefab, originRight.position, Quaternion.identity);
        }
        canSpawn = false;
    }

    IEnumerator SpawnDelayCo()
    {
        yield return new WaitForSeconds(Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax));
        canSpawn = true;
    }
}
