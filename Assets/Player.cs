using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour

{

    public AudioSource clip;
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    float dirX;
    public AudioSource golpe;


    
    public Animator _animator;
    Rigidbody2D _rBody;
    BoxCollider2D boxCollider;
    
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponentInParent<BoxCollider2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        
        if (hit.gameObject.tag == "Item")
        {
            Destroy(hit.gameObject);
        }
    }
    public void Atack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool("Atack", true);
            golpe.Play();
        }
        else
        {
            _animator.SetBool("Atack", false);
        }
    }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Disparo");
            _animator.SetBool("Shoot", true);
        }
        else
        {
            _animator.SetBool("Shoot", false);
        }
    }
    
    void FixedUpdate()
        {
            _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);
        }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        Atack();
        Shoot();

        Debug.Log(dirX);      

        if (dirX == -1)
        {
            //spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("Running", true);
        }
        else if (dirX == 1)
        {
            //spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jumping", true);
            clip.Play();
        }

        
    }
}
