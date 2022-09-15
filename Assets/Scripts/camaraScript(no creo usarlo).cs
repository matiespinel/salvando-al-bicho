using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraScript : MonoBehaviour
{
    public GameObject jWick;
    private void Update()
    {
        if (jWick != null)
        {
            Vector3 position = transform.position;
            position.x = jWick.transform.position.x;
            position.y = jWick.transform.position.y;
            transform.position = position;
        }
    }
}
