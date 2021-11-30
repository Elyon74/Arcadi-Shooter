using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIA : MonoBehaviour
{

    [SerializeField]
    public Player player;
    public PlayerShield Shield;
    public AudioSource fireIA;
    public Rigidbody2D Impulse;
    public BoxCollider2D boxCollider2D;

    void Start()
    {
        Impulse = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        Shield = GetComponent<PlayerShield>();
    }

    void Update()
    {
        AddForceIA();
        SelfDestroy();
    }

    public void AddForceIA()
    {
        // Appliquez une force a l' objet pour le tir d'une IA
        Impulse.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
    }
    public void SelfDestroy()
    {
            Destroy(GameObject.FindWithTag("ProjectileIA"), 1f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" & (Shield.playershielddef == 0))
        {
            player.currentplayerhp -= 1;
            Destroy(GameObject.FindWithTag("ProjectileIA"));
        }

        if (collision.collider.gameObject.tag == "UI")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("ProjectileIA"));
        }

        if (collision.collider.gameObject.tag == "PlayerShieldRegen")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("ProjectileIA"));
        }

        if (collision.collider.gameObject.tag == "AmmoRegen")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("ProjectileIA"));
        }

        if (collision.collider.gameObject.tag == "PlayerHPRegen")
        {
            gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("ProjectileIA"));
        }
    }
}
