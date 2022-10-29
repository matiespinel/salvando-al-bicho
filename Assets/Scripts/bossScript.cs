using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public adaministradorDeOleadas admOleadas;
    int vidaBoss = 3; 
    public GameObject laserTorre;
    bool estadoTorre = true;

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
        vidaBoss--;
        if (vidaBoss <= 1)
        {
            Destroy(gameObject);
        }

        laserTorre.SetActive(true);
        estadoTorre = true;
        admOleadas.ActivateAllEnemies();
    }
}