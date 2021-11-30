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
    public int currentplayerprojectile = 25;
    public bool dead;
    public bool maxplayerhptrigger;
    public bool fireenclenched = true;
    public float speed = 4;

    // Position des bordures de la fenetre
    public float minposx;
    public float maxposx;
    public float minposy;
    public float maxposy;

    private Vector3 velocity = Vector3.zero;
    public PlayerShield Shield;
    public Rigidbody2D RigidPlayer;
    public BoxCollider2D ColliderPlayer;
    public SpriteRenderer PlayerSpriteRenderer;
    public Transform firingPoint;
    public Transform firingPoint2;
    public Transform HPPoint1;
    public Transform HPPoint2;
    public Transform HPPoint3;
    public Transform SpriteHP1;
    public Transform SpriteHP2;
    public Transform SpriteHP3;
    public Transform Spritefire;
    public Transform Spriteshield;
    public Transform Spriteshieldposition;

    private void Awake()
    {
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = transform.position;
        HP();
        ExpMax();
        PlayerMaxGold();
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = pos;

        // Blocage du joueur sur les bords de l' écran
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minposx, maxposx),Mathf.Clamp(transform.position.y, minposy, maxposy), transform.position.z);
        PlayerAttack();
        PlayerMove();
        PlayerShield();
    }

public void HP()
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
            maxplayerhptrigger = false;
            Destroy(GameObject.Find("Sprite-HP3"), 1f);
        }

        if (currentplayerhp == 1)
        {
            Destroy(GameObject.Find("Sprite-HP2"), 1f);
        }

        if (maxplayerhptrigger == true)
        {
            currentplayerhp = 3;
            var hpTransform = Instantiate(SpriteHP1);
            hpTransform.position = HPPoint1.position;

            var hpTransform2 = Instantiate(SpriteHP2);
            hpTransform.position = HPPoint2.position;

            var hpTransform3 = Instantiate(SpriteHP3);
            hpTransform.position = HPPoint3.position;

        }
    }

public void ExpMax()
    {
        if (currentplayerexp == 100)
        {
        currentplayerlevel += 1;
        currentplayerexp = 0;
        maxplayerhp += 1;
        }
}

public void PlayerMaxGold()
    {
        if (currentplayergold > maxplayergold)
            currentplayergold = 999;
    }
public void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (PlayerSpriteRenderer != null)
            {
                PlayerSpriteRenderer.flipY = false;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
   }

public void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) & (currentplayerprojectile >= 1))  //Key Appuie continue sur la touche KeyDown Un seul appui
        {
            if (fireenclenched == true)
            {
                currentplayerprojectile -= 1;
                var shotTransform = Instantiate(Spritefire);
                shotTransform.position = firingPoint.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) & (currentplayerprojectile >= 1))
        {
            if (fireenclenched == true)
            {
                currentplayerprojectile -= 1;
                var shotTransform = Instantiate(Spritefire);
                shotTransform.position = firingPoint2.position;
            }
        }
    }

public void PlayerShield()
    {
        if (Input.GetKeyDown(KeyCode.A) & currentnumberofshield == 1)
        {
            var shieldTransform = Instantiate(Spriteshield);
            shieldTransform.position = Spriteshieldposition.position;
            currentnumberofshield -= 1;
            Shield.playershielddef = 6;
        }
    }
}
