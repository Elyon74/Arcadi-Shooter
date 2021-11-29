using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField]
    public int firerate = 1;
    public AudioSource fire;
    public Rigidbody2D Impulse;
    public BoxCollider2D boxCollider2D;
    public IA1 Ia1;

    void Start()
    {
        Impulse = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AddForce();
        SelfDestroy();
    }

    public void AddForce()
    {
       // Appliquez une force a l' object pour le tir du joueur
       Impulse.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    }

    public void SelfDestroy()
    {
        Destroy(this, 5f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == ("IA1"))
        {
            Ia1.currentia1hp -= 1;
            Destroy(this, 1f);
        }
    }
}
