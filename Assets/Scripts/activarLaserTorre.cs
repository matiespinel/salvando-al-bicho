using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarLaserTorre : MonoBehaviour
{
    
    public GameObject laserTorre;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            laserTorre.SetActive(false);
        }
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            laserTorre.SetActive(true);
        }
        
    }
}
