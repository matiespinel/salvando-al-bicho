using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adaministradorDeOleadas : MonoBehaviour
{
    public GameObject[] enemigos;
    public int waveCount = 0;
    public int maxWaveCount = 3;
    public GameObject laserTorre;

    

    public void ActivateAllEnemies()
    {
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].SetActive(true);
        }
        laserTorre.SetActive(true);
        waveCount = 0;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (GetDefeatedEnemiesCount() == enemigos.Length)
        {
            if(waveCount < maxWaveCount)
            {
                waveCount++;
                laserTorre.SetActive(false);
            }
            else 
            {
                //termina el juego
            }
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
