using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRegen : MonoBehaviour
{

    [SerializeField]
    public Player player;
    public AudioSource ShieldRegen1;
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D CircleCollider2D;

    void Start()
    {
        ShieldRegen1 = GetComponent<AudioSource>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" & (player.currentnumberofshield == 0))
        {
            player.currentnumberofshield += 1;
            Destroy(GameObject.FindWithTag("PlayerShieldRegen"), 0f);
            ShieldRegen1.Play(0);
        }
    }
}
