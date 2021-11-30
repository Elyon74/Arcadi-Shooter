using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegen : MonoBehaviour
{
    [SerializeField]
    public Player player;
    public AudioSource HPRegen1;
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D CircleCollider2D;

    void Start()
    {
        HPRegen1 = GetComponent<AudioSource>();
        player = GetComponent<Player>();
    }

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" & (player.currentplayerhp >= 1) & (player.currentplayerhp <= 2))
        {
            player.maxplayerhptrigger = true;
            Destroy(GameObject.FindWithTag("PlayerHPRegen"), 0f);
            HPRegen1.Play(0);
        }
    }
}
