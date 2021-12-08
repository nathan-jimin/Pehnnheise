using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerCollectCoinLvl2 : MonoBehaviour
{
    //private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform collectLocation;
    public SpriteRenderer[] collects;

    public SpriteRenderer sprite;

    public bool collecting;

    public static bool green = false;
    public static bool red = false;
    public float attackRange;
    public LayerMask Coin;

    public bool holding;
    public Text scoreText;
    public int scoreValue;

    public Color en = new Color(1, 1, 1, 255);
    public Color dis = new Color(1, 1, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        holding = false;
        collecting = false;
        this.scoreValue = 0;
        this.scoreText.text = "Scores: " + this.scoreValue.ToString();
        collects[1].color = dis;
        collects[0].color = dis;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
                attackTime = startTimeAttack;
                sprite.color = new Color(0, 0, 255, 255);
                if (!holding)
                {
                    // deal damage to all enemies within attack range
                    Collider2D[] damage = Physics2D.OverlapCircleAll(collectLocation.position, attackRange, Coin);
                    for (int i = 0; i < damage.Length; i++)
                    {
                        if (damage[i].gameObject.CompareTag("GreenCoin") && !holding)
                        {
                            holding = true;
                            green = true;
                            Debug.Log("GGGGGGRRRRRRRREEEEEEEENNNNN");
                            collects[0].color = en;
                            collects[1].color = dis;
                        }
                        else if (damage[i].gameObject.CompareTag("RedCoin") && !holding)
                        {
                            holding = true;
                            red = true;
                            Debug.Log("REDDDDDDDDDDDDDDDDDD");
                            collects[0].color = dis;
                            collects[1].color = en;
                        }
                        Destroy(damage[i].gameObject);
                        AddPoint();

                    }
                }
            }
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0) {
            sprite.color = new Color(255, 255, 255, 255);
        }
    }

    public int getScore()
    {
        return this.scoreValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GreenDrop") && green && holding)
        {
            AddPoint();
            holding = false;
            green = false;
            collects[0].color = dis;
            collects[1].color = dis;
        }

        if (other.gameObject.CompareTag("RedDrop") && red && holding)
        {
            AddPoint();
            holding = false;
            red = false;
            collects[0].color = dis;
            collects[1].color = dis;
        }
    }


    public void AddPoint()
    {
        this.scoreValue += 1;
        this.scoreText.text = "Scores: " + this.scoreValue.ToString();
        Debug.Log(this.scoreValue);
        if (scoreValue >= 8)
        {
            SceneManager.LoadScene(4);
        }
    }
}
