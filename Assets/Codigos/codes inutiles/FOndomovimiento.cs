using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOndomovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D jugadorRB; 
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        offset = (jugadorRB.velocity.x * 0.1F )* velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset; 
    }
}
