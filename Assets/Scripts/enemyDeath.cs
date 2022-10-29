using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<enemyDeath>().isDead = true;
    }

    void OnEnable()
    {
        isDead = false;
    }
}
