using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour



{
    private void OnCollisionEnter2D(Collision2D hit)
    {
        
        if (hit.gameObject.tag == "Player")
        {
            Destroy(hit.gameObject);
            
            /*
            private void OnTriggerEnter(Collider2D collision)

            {/*
                if (collision.gameObject.CompareTag("Enemigo"))
                {
                    Destroy(gameObject);
                }
            }
            /*{
                Destroy(gameObject);
            }*/
            /*{
                if (other.tag == "Kurapika")
                {
                    Destroy(gameObject);
                }
              }*/
        }
    }
}
