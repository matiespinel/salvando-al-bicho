using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
   public void REI ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale = 1f;
    }
}
