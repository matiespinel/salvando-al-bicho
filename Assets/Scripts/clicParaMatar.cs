using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicParaMatar : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<enemyDeath>().isDead = true;
    }
}
