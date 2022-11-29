using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public bool isDead = false;

    public GameObject cuerpoMuerto;

    // Start is called before the first frame update
    void Start()
    {
        cuerpoMuerto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        cuerpoMuerto.SetActive(true);
        gameObject.SetActive(false);
        gameObject.GetComponent<enemyDeath>().isDead = true;
    }

    void OnEnable()
    {
        isDead = false;
    }
}
