using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public Player player;
    private TextMeshPro UIProjectile;
    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        //CurrentPlayerProjectileInUI();
    }

    void CurrentPlayerProjectileInUI()
    {
        UIProjectile = GameObject.Find("UIProjectile").GetComponent<TextMeshPro>();
        UIProjectile.SetText(player.currentplayerprojectile.ToString());
    }
}
