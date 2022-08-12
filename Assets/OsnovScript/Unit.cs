using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public virtual void ReciveDamage()
    {
        Die();
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
