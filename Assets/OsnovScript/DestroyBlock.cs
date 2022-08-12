using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    public int health;
    public float cooldowndamage = 0f;
    public bool BossLvl = false;
    public BossKod Boss;
    private Animator anim;

    private void Awake()
    {
        GetComponent<BossKod>();
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
            if (cooldowndamage >= 0.23f)
            {
                health -= damage;
                cooldowndamage = 0;
            if (BossLvl ==false)
            anim.Play("blockdamage");
            if (BossLvl == true)
                Boss.TakeDamage(1);
            }
    }
    private void Update()
    {
    cooldowndamage += Time.deltaTime;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
    }
}
