using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    float bulletCooldown = 0.8f;
    float bulletClock = 0f;
    [SerializeField] Transform bulletPrefab;
    PlayerMovement playerMovement;
    Vector2 shootLeftOffset = new Vector2(-8, 5);
    Vector2 shootRightOffset = new Vector2(8, 5);
    Vector2 shootUpOffset = new Vector2(0, 15);
    Vector2 shootDownOffset = new Vector2(0, -2);

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        bulletClock += Time.deltaTime;
    

        if (Input.GetKey("j") && bulletClock >= bulletCooldown)
{
            BulletMovement bullet;
            Vector2 facing = playerMovement.GetFacingVector();
            bulletClock = 0;

            if (facing == Vector2.right)
            {
                bullet = Instantiate(bulletPrefab, transform.position + (Vector3)facing + (Vector3)shootRightOffset, Quaternion.identity).GetComponent<BulletMovement>();
            }
            else if (facing == Vector2.left)
            {
                bullet = Instantiate(bulletPrefab, transform.position + (Vector3)facing + (Vector3)shootLeftOffset, Quaternion.identity).GetComponent<BulletMovement>();
            }
            else if (facing == Vector2.up)
            {
                bullet = Instantiate(bulletPrefab, transform.position + (Vector3)facing + (Vector3)shootUpOffset, Quaternion.identity).GetComponent<BulletMovement>();
            }
            else if (facing.y == 1 && facing.x != 0)
            {
                bullet = Instantiate(bulletPrefab, transform.position + Vector3.up + (Vector3)shootUpOffset, Quaternion.identity).GetComponent<BulletMovement>();
            }
            else
            {
                bullet = Instantiate(bulletPrefab, transform.position + (Vector3)facing + (Vector3)shootDownOffset, Quaternion.identity).GetComponent<BulletMovement>();
            }

            // prevent diagonal bullets
            if (facing.y == 1 && facing.x != 0)
            {
                bullet.direction = Vector2.up;
            }
            else if (facing.y == -1 && facing.x != 0)
            {
                bullet.direction = Vector2.down;
            }
            else
            {
                bullet.direction = facing;
            }

            bullet.baseVelocity = playerMovement.GetMovementVector();
        }
        
    }
}
