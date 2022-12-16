using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int DamageDealed;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void GiveDamage(GameObject enemy)
    {
        enemy.GetComponent<BasicEnemy>().GetDamage(DamageDealed);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            GiveDamage(collision.gameObject);
        }
    }
}
