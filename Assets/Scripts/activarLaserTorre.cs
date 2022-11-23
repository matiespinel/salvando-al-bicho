using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarLaserTorre : MonoBehaviour
{
    float timer = 0;
    public GameObject laserTorre;
    bool estadoTorre = false;

    private AudioSource audioSource;

    [SerializeField] private AudioClip activarTorre;
    [SerializeField] private AudioClip desactivarTorre;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f && estadoTorre == false)
        {
            laserTorre.SetActive(true);
            timer = 0;
            estadoTorre = true;
            audioSource.PlayOneShot(activarTorre);
        } 
        else if(timer >= 2f && estadoTorre == true) 
        {
            laserTorre.SetActive(false);
            timer = 0;
            estadoTorre = false;
            audioSource.PlayOneShot(desactivarTorre);
        }
    }
}
