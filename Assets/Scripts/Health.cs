using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int playerHealth;
    public int numOfHearts;
    public GameObject PlayerDeathCnvas;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    public static bool GameIsPaused = false; 
    

    public SpriteRenderer sr;
    private AudioSource audioSource;

    [SerializeField] private AudioClip gemir;
    [SerializeField] private AudioClip morir;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (playerHealth > numOfHearts)
        {
            playerHealth = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth) 
            {
                hearts[i].sprite = fullHearts;
            } else
            {
                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        if (playerHealth <= 0) 
        {
            PlayerDeathCnvas.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true; 
            //audioSource.PlayOneShot(morir);
        }

       
    }
    public void ColorChange()
    {
        sr.color = Color.red;
        audioSource.PlayOneShot(gemir);
        StartCoroutine(PonerseRojo());
    }

    IEnumerator PonerseRojo()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        sr.color = Color.white;
    }

    internal void UpdateHealth()
    {
        throw new NotImplementedException();
    }
}
