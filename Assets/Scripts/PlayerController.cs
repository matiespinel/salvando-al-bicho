 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;


public class PlayerController : MonoBehaviour
{
    bool canJump;

    public float timeBtwAttack = 0;
    public float startTimeBtWAttack;

    bool mirandoDerecha;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800f * Time.deltaTime, 0));
            mirandoDerecha = false;
            transform.localScale = new Vector3 (-1, 1, 1);
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(800f * Time.deltaTime, 0));
            mirandoDerecha = true;
            transform.localScale = new Vector3 (1, 1, 1);
        }

        if (Input.GetKeyDown("space") && canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 220f));
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && mirandoDerecha == false)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400f, 0));
                timeBtwAttack = 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && mirandoDerecha == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400f, 0));
                timeBtwAttack = 1;
            }
        }

        else if (timeBtwAttack > 0)
        {
                timeBtwAttack -= Time.deltaTime;
        }
    }

    private void girar()
    {
        sr.flipX = false;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }
    }
}
