using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    [SerializeField]
    public Player player;
    private TextMeshPro UIGold;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        CurrentPlayerGoldInUI();
    }

    void CurrentPlayerGoldInUI()
    {
        UIGold = GameObject.Find("UIGold").GetComponent<TextMeshPro>();
        UIGold.SetText(player.currentplayergold.ToString());
    }
}
