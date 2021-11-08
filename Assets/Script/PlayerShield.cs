using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

    [SerializeField]
    public int playershielddef = 6;
    public Player player;
    public AudioSource Shield;
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D CircleCollider2D;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == ("Projectile"))
        {
            playershielddef -= 1;
            if (playershielddef == 0)
            {
                Destroy(this, 1f);
            }
        }
    }
}
