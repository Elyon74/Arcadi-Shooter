using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA1 : MonoBehaviour
{
    [SerializeField]
    public int currentia1hp = 3;
    public int currentia1level = 1;
    public int currentia1goldforkill = 10;
    public int currentia1expforkill = 10;
    public float ia1firerate = 100;
    public float ia1firenext = 1;
    public bool ia1dead;
    public float ia1speed = 3;
    public float minposx;
    public float maxposx;
    public float minposy;
    public float maxposy;
    public Player player;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D RigidPlayer;
    public BoxCollider2D ColliderPlayer;
    public SpriteRenderer PlayerSpriteRenderer;
    public Transform firingPoint;
    public Transform SpritefireIA;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        IAGoldAndExpGained();
        IAAttack();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minposx, maxposx), Mathf.Clamp(transform.position.y, minposy, maxposy), transform.position.z);
    }
    public void IAGoldAndExpGained()
    {
        if (currentia1hp == 0)
        {
            ia1dead = true;
            if (ia1dead == true)
            {
                player.currentplayergold += currentia1goldforkill;
                player.currentplayerexp += currentia1expforkill;
                Destroy(this, 0f);
            }
        }
    }

    public void IAAttack()
    {
        if(Time.time > ia1firenext)
        {
            var shotTransform = Instantiate(SpritefireIA);
            shotTransform.position = firingPoint.position;
            ia1firenext = Time.time + ia1firerate;
        }
    }
}
