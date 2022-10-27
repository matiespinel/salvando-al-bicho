using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adaministradorDeOleadas : MonoBehaviour
{
    public GameObject[] enemigos;
    public int waveCount = 0;
    public int maxWaveCount = 3;

    public void ActivateAllEnemies()
    {
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].SetActive(true);
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (GetDefeatedEnemiesCount() == enemigos.Length)
        {
            if(waveCount < maxWaveCount -1)
            {
                waveCount++;
                ActivateAllEnemies();
            }
            else 
            {
                //termina el juego
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateAllEnemies();
        }
    }

    int GetDefeatedEnemiesCount()
    {
        int count = 0;

        for (int i = 0; i < enemigos.Length; i++)
        {
            if(enemigos[i].GetComponent<enemyDeath>().isDead)
            {
                count++;
            }
        }
        return count;
    }
}
