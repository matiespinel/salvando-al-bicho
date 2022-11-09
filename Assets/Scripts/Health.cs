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

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public SpriteRenderer sr;

    void Start()
    {
        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ColorChange()
    {
        sr.color = Color.red;
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
