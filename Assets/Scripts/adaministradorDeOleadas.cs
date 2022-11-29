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
    private AudioSource audioSource;
    [SerializeField] private AudioClip apagarTorre;

    public GameObject tumba;
    public GameObject tumba2;
    public GameObject tumba3;
    public GameObject tumba4;
    public GameObject tumba5;
    public GameObject tumba6;
    public GameObject tumba7;
    public GameObject tumba8;

    public void ActivateAllEnemies()
    {
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].SetActive(true);
            tumba.SetActive(false);
            tumba2.SetActive(false);
            tumba3.SetActive(false);
            tumba4.SetActive(false);
            tumba5.SetActive(false);
            tumba6.SetActive(false);
            tumba7.SetActive(false);
            tumba8.SetActive(false);
        }
        laserTorre.SetActive(true);
        waveCount = 0;
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GetDefeatedEnemiesCount() == enemigos.Length)
        {
            if(waveCount < maxWaveCount)
            {
                waveCount++;
                laserTorre.SetActive(false);
                audioSource.PlayOneShot(apagarTorre);
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
