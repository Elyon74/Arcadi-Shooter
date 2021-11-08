using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int currentplayerhp = 3;
    public int maxplayerhp = 3;
    public int currentplayerexp = 0;
    public int maxplayerexp = 99;
    public int currentplayerlevel = 1;
    public int maxplayerlevel = 10;
    public int currentplayergold = 0;
    public int maxplayergold = 999;
    public int currentnumberofshield = 1;
    public int maxnumberofshield = 3;
    public bool dead;
    public bool fireenclenched;
    public bool shieldenclenched;
    public float speed = 4;

    // Position des bordures de la fenetre
    public float minposx;
    public float maxposx;
    public float minposy;
    public float maxposy;

    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D RigidPlayer;
    public BoxCollider2D ColliderPlayer;
    public SpriteRenderer PlayerSpriteRenderer;
    public new Transform transform;
    public Transform Spritefire;
    public Transform Spriteshield;

    private void Awake()
    {
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        transform = GetComponent<Transform>();

    }

    void Update()
    {
        Vector3 pos = transform.position;
        HP(currentplayerhp, dead);
        ExpMax(currentplayerexp, currentplayerlevel, maxplayerhp);
        PlayerMaxGold(currentplayergold, maxplayergold);
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = pos;

        // Blocage du joueur sur les bords de l' écran
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minposx, maxposx),Mathf.Clamp(transform.position.y, minposy, maxposy), transform.position.z);
        PlayerAttack(fireenclenched);
        PlayerMove(fireenclenched);
        PlayerShield(shieldenclenched, currentnumberofshield);
    }

public void HP(int currentplayerhp, bool dead)
    {
        if (currentplayerhp == 0)
        {
            dead = true;
            if (dead == true)
            {
                Destroy(GameObject.Find("Sprite-HP1"), 1f);
                SceneManager.LoadScene(3);
                Destroy(this);
            }
        }
        if (currentplayerhp == 2)
        {
            Destroy(GameObject.Find("Sprite-HP3"), 1f);
        }
        if (currentplayerhp == 1)
        {
            Destroy(GameObject.Find("Sprite-HP2"), 1f);
        }
    }

public void ExpMax(int currentplayerexp, int currentplayerlevel, int maxplayerhp)
    {
        if (currentplayerexp == 100)
        {
        currentplayerlevel += 1;
            currentplayerexp = 0;
        maxplayerhp += 1;
        }
}

public void PlayerMaxGold(int currentplayergold, int maxplayergold)
    {
        if (currentplayergold > maxplayergold)
            currentplayergold = 999;
    }
public void PlayerMove(bool fireenclenched)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (PlayerSpriteRenderer != null)
            {
                PlayerSpriteRenderer.flipY = false;
            }
        }
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            if (PlayerSpriteRenderer != null)
            {
                PlayerSpriteRenderer.flipY = true;
            }
        }*/
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
   }

public void PlayerAttack(bool fireenclenched)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //Key Appuie continue sur la touche KeyDown Un seul appui
        {
            fireenclenched = true;
            if (fireenclenched == true)
            {
                var shotTransform = Instantiate(Spritefire) as Transform;
                shotTransform.position = transform.position;
            }
        }
        else
            fireenclenched = false;
    }

public void PlayerShield(bool shieldenclenched, int currentnumberofshield)
    {
        if (Input.GetKeyDown(KeyCode.A) & currentnumberofshield >=1)
            {
            shieldenclenched = true;
            if (shieldenclenched == true & currentnumberofshield >=1)
            {
                currentnumberofshield -= 1;
                var shieldTransform = Instantiate(Spriteshield) as Transform;
                shieldTransform.position = transform.position;
            }
        }
        else if (currentnumberofshield <= 0)
        {
            shieldenclenched = false;
        }
        if (currentnumberofshield <= 0)
        {
            currentnumberofshield = 0;
        }
    }
}
