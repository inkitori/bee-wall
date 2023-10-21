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

    void Start()
    {
        StartCoroutine(BeeSpawningLoop());
    }
    
    IEnumerator BeeSpawningLoop()
    {
        while (true)
        {
            SpawnFromTop();
            SpawnFromLeft();

            yield return new WaitForSeconds(5);
        }
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
