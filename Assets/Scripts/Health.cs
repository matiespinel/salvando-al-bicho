using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject jon;
    public int playerHealth;
    public int numOfHearts;
    public GameObject PlayerDeathCnvas;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    public static bool GameIsPaused = false;
    Vector2 posjon;
    

    public SpriteRenderer sr;
    private AudioSource audioSource;

    [SerializeField] private AudioClip gemir;
    [SerializeField] private AudioClip morir;

    void Start()
    {
        jon = gameObject;
        audioSource = GetComponent<AudioSource>();
        posjon = jon.transform.position;
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
       public void REI ()
    {
        jon.transform.position = posjon;
        playerHealth = 3;
        Time.timeScale = 1f;
        PlayerDeathCnvas.SetActive(false);
        GameIsPaused = false; 
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
