using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyMovement : MonoBehaviour
{

    [SerializeField] List<Transform> wayPoints;
    float velocidad = 30;
    float distanciaCambio = 0.2f;
    byte siguientePosicion = 0; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            wayPoints[siguientePosicion].transform.position,
            velocidad * Time.deltaTime);
            

        if (Vector3.Distance(transform.position,
            wayPoints[siguientePosicion].transform.position) < distanciaCambio){
                
                siguientePosicion++;
                
                if (siguientePosicion >= wayPoints.Count){
                    siguientePosicion = 0;
                }
            }
            
    }

}
