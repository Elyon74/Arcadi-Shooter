using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIA : MonoBehaviour
{

    [SerializeField]
    public Player player;
    public AudioSource fireIA;
    public Rigidbody2D Impulse;
    public BoxCollider2D boxCollider2D;

    void Start()
    {
        Impulse = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AddForceIA();
    }

    public void AddForceIA()
    {
        // Appliquez une force a l' objet pour le tir d'une IA
        Impulse.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == ("Player"))
        {
            player.currentplayerhp -= 1;
            Destroy(this, 1f);
        }
    }
}
