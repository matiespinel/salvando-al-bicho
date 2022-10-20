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

    SpriteRenderer sr;    
    //si esta en true, esta mirando a la derecha
    //si esta en false, esta mirando a la izquierda

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<enemyDeath>().TakeDamage(damage);
                    HitStop(.3f);
                }
                timeBtwAttack = 1;
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

    public void HitStop (float TimeStopped)
    {
        StartCoroutine(HitStopCoroutine(TimeStopped));
    }

    IEnumerator HitStopCoroutine (float TimeStopped)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime (TimeStopped);
        Time.timeScale = 1f;
    }
}
