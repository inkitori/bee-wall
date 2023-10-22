using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector2 direction;
    float bulletSpeed = 100f;
    Rigidbody2D rb;
    public Vector2 baseVelocity = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = baseVelocity + direction * bulletSpeed;
    }
}
