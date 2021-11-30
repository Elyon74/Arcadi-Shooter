using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRegen : MonoBehaviour
{
    [SerializeField]
    public Player player;
    public AudioSource AmmoRegen1;
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D CircleCollider2D;

    void Start()
    {
        AmmoRegen1 = GetComponent<AudioSource>();
        player = GetComponent<Player>();
    }

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" & (player.currentplayerprojectile >= 0))
        {
            player.currentplayerprojectile += 25;
            Destroy(GameObject.FindWithTag("AmmoRegen"), 0f);
            AmmoRegen1.Play(0);
        }
    }
}
