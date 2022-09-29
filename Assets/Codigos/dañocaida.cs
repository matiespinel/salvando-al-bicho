using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañocaida : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int damage;

    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }

        void Damage()
        {
            _health.playerHealth = _health.playerHealth - damage;
        }
    }

}
