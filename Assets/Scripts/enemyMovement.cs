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
        transform. localScale = new Vector2 (transform. localScale. x * -1 ,transform. localScale.y);
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

                transform. localScale = new Vector2 (transform. localScale. x * -1 ,transform. localScale.y);
                
                if (siguientePosicion >= wayPoints.Count){
                    siguientePosicion = 0;
                }
            }
    }

}
