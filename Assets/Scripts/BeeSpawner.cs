using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] GameObject beePrefab;
    // Horizontal Spawning
    float initX = -100f;
    float lowerY = -40f;
    float upperY = 40f;

    // Vertical Spawning
    float initY = 60f;
    float lowerX = -80f;
    float upperX = 80f;

    const float waveIntermission = 7f;

    const float lowerBeeWait = 0.5f;
    const float upperBeeWait = 1.5f;

    const float maxSpawnTime = 8f;

    int currentWave = 1;

    void Start()
    {
        StartCoroutine(BeeSpawningLoop());
    }
    
    IEnumerator BeeSpawningLoop()
    {
        while (true)
        {
            Coroutine leftSpawner = StartCoroutine(nextWaveLeft());
            Coroutine topSpawner = StartCoroutine(nextWaveTop());

            yield return leftSpawner;
            yield return topSpawner;

            yield return new WaitForSeconds(waveIntermission);

            currentWave++;
        }
    }

    IEnumerator nextWaveLeft()
    {
        int beeCount = CalculatedBeeCount(currentWave);
        for (int i = 0; i < beeCount; i++)
        {
            SpawnFromLeft();
            yield return new WaitForSeconds(Random.Range(lowerBeeWait, upperBeeWait));
        }

    }

    IEnumerator nextWaveTop()
    {
        int beeCount = CalculatedBeeCount(currentWave);
        for (int i = 0; i < beeCount; i++)
        {
            SpawnFromTop();
            yield return new WaitForSeconds(Random.Range(lowerBeeWait, upperBeeWait));
        }

    }

    int CalculatedBeeCount(int wave)
    {
        return Mathf.RoundToInt(Mathf.Log(wave + 1, 2)); 

    }

    void SpawnFromTop()
    {
        GameObject beeObject = Instantiate(beePrefab, new Vector2(Random.Range(lowerX, upperX), initY), Quaternion.identity);

        beeObject.GetComponent<SpriteRenderer>().flipY = true;
        beeObject.GetComponent<BeeMovement>().direction = Vector2.down;
    }

    void SpawnFromLeft()
    {
        BeeMovement movement = Instantiate(beePrefab,new Vector2(initX, Random.Range(lowerY, upperY)), Quaternion.identity).GetComponent<BeeMovement>();

        movement.direction = Vector2.right;
    }
}
