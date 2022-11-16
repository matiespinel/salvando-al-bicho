 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;


public class PlayerController : MonoBehaviour
{
    bool canJump;

    public float timeBtwAttack = 0;
    public float startTimeBtWAttack;

    bool mirandoDerecha;

    Vector3 startScale;

    SpriteRenderer sr;

    private Animator animator;

    private AudioSource audioSource;

    [SerializeField] private AudioClip dashear;
    [SerializeField] private AudioClip saltar;
    
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startScale = transform.localScale;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-550f * Time.deltaTime, 0));
            mirandoDerecha = false;
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3 (-startScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(550f * Time.deltaTime, 0));
            mirandoDerecha = true;
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3 (startScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown("space") && canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500f));
            animator.SetBool("enSuelo", false);
            audioSource.PlayOneShot(saltar);
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && mirandoDerecha == false)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700f, 0));
                timeBtwAttack = 1;
                animator.SetBool("isDashing", true);
                audioSource.PlayOneShot(dashear);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && mirandoDerecha == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(700f, 0));
                timeBtwAttack = 1;
                animator.SetBool("isDashing", true);
                audioSource.PlayOneShot(dashear);
            }
            else
            {
                animator.SetBool("isDashing", false);
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
            animator.SetBool("enSuelo",true);
        }
    }
}
