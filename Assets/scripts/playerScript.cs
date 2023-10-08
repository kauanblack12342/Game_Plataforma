using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform gun;
    public GameObject bullet;

    private float movement;
    private SpriteRenderer sr;
    private Rigidbody2D rig;
    private bool isGrounded;
    private Animator anim;
    private bool shooting;

    


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
        
        
    }

    
    void Update()
    {
        Move();
        Jump();
        shoot();

    }

    private void Move()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.Translate(movement, 0, 0);
        flip();
        
    }

    private void flip()
    {
        if(movement < 0)
        {
            sr.flipX = true;
            anim.SetFloat("walking", 1f);
        }
        else if(movement > 0)
        {
            sr.flipX = false;
            anim.SetFloat("walking", 1f);
        }
       else if(movement == 0)
        {
            anim.SetFloat("walking", 0f);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.velocity = new Vector2(0, jumpForce);
            isGrounded = false;
            anim.SetBool("isjumping", true);
        }
    }

    private void shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            
            
            anim.SetBool("isShooting", true);
            speed = 0;
            StartCoroutine(ShootTimer());
            
           
            



        }
        else if(Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isShooting", false);
            speed = 5;
            StopCoroutine(ShootTimer());
        }
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(bullet, gun.position, transform.rotation);
        
        

        
       
        

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isGrounded = true;
            anim.SetBool("isjumping", false);

        }
    }
}
