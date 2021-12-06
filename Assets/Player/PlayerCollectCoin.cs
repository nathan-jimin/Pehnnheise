using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerCollectCoin : MonoBehaviour
{
    //private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform collectLocation;

    public bool collecting;

    static bool green = false;
    static bool red = false;
    public float attackRange;
    public LayerMask Coin;

    public bool holding;
    public Text scoreText;
    public int scoreValue;
    
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        holding = false;
        collecting = false;
        this.scoreValue = 0;
        this.scoreText.text = "Scores: " + this.scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetButton("Jump"))
            {
                attackTime = startTimeAttack;
                if(!holding)
                {
                    // deal damage to all enemies within attack range
                    
                    Collider2D[] damage = Physics2D.OverlapCircleAll(collectLocation.position, attackRange, Coin);
                    for (int i = 0; i < damage.Length; i++)
                    {
                        if (damage[i].gameObject.CompareTag("GreenCoin") || damage[i].gameObject.CompareTag("RedCoin")) {
                            holding = true; 
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
    }

    public int getScore() {
        return this.scoreValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GreenCoin") && !holding)
        {
            green = true;
            Debug.Log("GGGGGGRRRRRRRREEEEEEEENNNNN");
        }

        if(other.gameObject.CompareTag("RedCoin") && !holding)
        {
            red = true;
            Debug.Log("REDDDDDDDDDDDDDDDDDD");
        }

        if(other.gameObject.CompareTag("GreenDrop") && green && holding)
        {
            AddPoint();
            holding = false;
            green = false;
        }

        if(other.gameObject.CompareTag("RedDrop") && red && holding)
        {
            AddPoint();
            holding = false;
            red = false;
        }          
    }


    public void AddPoint()
    {
        this.scoreValue += 1;
        this.scoreText.text = "Scores: " + this.scoreValue.ToString();
        Debug.Log(this.scoreValue); 
        if (scoreValue >= 4) {
            SceneManager.LoadScene(4);
        }
    }
}
