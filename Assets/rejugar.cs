using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rejugar : MonoBehaviour
{
 
   void update ()
   {

   }

     public void PlayGamesss ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -7);
    }
}