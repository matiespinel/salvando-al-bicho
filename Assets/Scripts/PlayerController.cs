 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;


public class PlayerController : MonoBehaviour
{
    bool canJump; 

    public float timeBtwAttack = 0;
    public float startTimeBtWAttack;
    SpriteRenderer sr;
   // Start is called before the first frame update
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
            sr.flipX = true;
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(800f * Time.deltaTime, 0));
            sr.flipX = false;
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 220f));
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && sr.flipX == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400f, 0));
                timeBtwAttack = 1;
            } 
            if (Input.GetKeyDown(KeyCode.LeftShift) && sr.flipX == false)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }
    }
}
