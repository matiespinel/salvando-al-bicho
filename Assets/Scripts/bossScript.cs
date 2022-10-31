using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bossScript : MonoBehaviour
{
    private new Vector2 posInicial;
    public GameObject player;
    public adaministradorDeOleadas admOleadas;
    int vidaBoss = 3; 
    public GameObject laserTorre;
    bool estadoTorre = true;

    public void TakeDamage(int damage)
    {
        vidaBoss--;
        if (vidaBoss <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }

        laserTorre.SetActive(true);
        estadoTorre = true;
        admOleadas.ActivateAllEnemies();
        player.transform.position = new Vector2(-374, 793);;

    }
}