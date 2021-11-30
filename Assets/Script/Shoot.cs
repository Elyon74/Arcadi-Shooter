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
        Impulse = GetComponent<Rigidbody2D>();
        Ia1 = GetComponent<IA1>();
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
        Destroy(GameObject.FindWithTag("Projectile"), 1f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "IA1")
        {
            Ia1.currentia1hp -= 1;
            Destroy(GameObject.FindWithTag("Projectile"));
        }

        if (collision.collider.gameObject.tag == "UI")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("Projectile"));
        }

        if (collision.collider.gameObject.tag == "PlayerShieldRegen")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("Projectile"));
        }

        if (collision.collider.gameObject.tag == "AmmoRegen")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("Projectile"));
        }


        if (collision.collider.gameObject.tag == "PlayerHPRegen")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("Projectile"));
        }
    }
}
