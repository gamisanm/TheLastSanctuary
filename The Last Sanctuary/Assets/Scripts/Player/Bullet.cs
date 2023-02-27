using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EnemyAI eAI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyAI eAI = collision.gameObject.GetComponent<EnemyAI>();
            if (eAI != null)
            {
                eAI.TakeDamage(1);
            }
            Destroy(gameObject);
        }
        else
        {
            // Schedule the destruction of the bullet after 2 seconds
            Invoke("DestroyBullet", 2f);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
