using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bee"))
        {
            GameManager.Instance.DecrementHealth();
        }
    }
}
