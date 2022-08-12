using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBtwAttack = 0;
    public float startTimeBtwAttack = 1f;
    public Transform attackPose;
    public float attackRange;
    public LayerMask WhatIsDestroy;
    public int damage;
    public Animator AnimAttack;
    private float DurationAttack = 0f;

    private float timeattack = 0f;

    public AudioClip AttackSound;
    public AudioSource Myfx;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            DurationAttack += Time.deltaTime;

            if (Input.GetButtonDown("Fire1") && timeBtwAttack <= 0)
            {
                Myfx.PlayOneShot(AttackSound);
                DurationAttack = 0;
                AnimAttack.Play("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, WhatIsDestroy);
                if (DurationAttack <= 0.22f)
                {
                    while (timeattack <= 0.22f)
                    {
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            enemiesToDamage[i].GetComponent<DestroyBlock>().TakeDamage(damage);
                        }
                        timeattack += Time.deltaTime;
                    }
                    timeattack = 0f;
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
}
