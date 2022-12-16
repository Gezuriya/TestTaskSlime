using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void FindDestination();
    void Attack(int attackValue);
    void GetDamage(int damageTaken);
    void Die();
}
