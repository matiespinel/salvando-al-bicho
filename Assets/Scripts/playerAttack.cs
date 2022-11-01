using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float timeBtwAttack = 0;
    public float startTimeBtWAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    private Animator animator;
    SpriteRenderer sr;    
    //si esta en true, esta mirando a la derecha
    //si esta en false, esta mirando a la izquierda

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isAttacking", false);
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("isAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    try 
                    {
                        enemiesToDamage[i].GetComponent<enemyDeath>().TakeDamage(damage);
                    }
                    catch
                    {
                        enemiesToDamage[i].GetComponent<bossScript>().TakeDamage(damage);
                    }
                }
                timeBtwAttack = 1;
            } 
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
