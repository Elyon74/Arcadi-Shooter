using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField]
    public Player player;
    private TextMeshPro UILevel;
    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        CurrentPlayerLevelInUI();
    }

    void CurrentPlayerLevelInUI()
    {
        UILevel = GameObject.Find("UILevel").GetComponent<TextMeshPro>();
        UILevel.SetText(player.currentplayerlevel.ToString());
    }
}
