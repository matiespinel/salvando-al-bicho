using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private Health _health;

    private AudioSource audioSource;

    [SerializeField] private AudioClip gemir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }

        void Damage()
        {
            _health.playerHealth = _health.playerHealth - damage;
            _health.ColorChange();
            audioSource.PlayOneShot(gemir);
        }
    }
    
}
