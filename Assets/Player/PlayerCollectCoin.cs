using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollectCoin : MonoBehaviour
{
    //private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;

    

    static bool green = false;
    static bool red = false;
    public float attackRange;
    public LayerMask Coin;


    public Text scoreText;
    public Text Warning;
    public static int scoreValue = 0;
    static bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetButton("Jump"))
            {
                if(!holding)
                {
                    // deal damage to all enemies within attack range
                    Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, Coin);
                    for (int i = 0; i < damage.Length; i++)
                    {
                        Destroy(damage[i].gameObject);
                        AddPoint();
                    }
                    holding = true;
                } 
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }

    
        
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
        scoreValue += 1;
        scoreText.text = "Scores: " + scoreValue.ToString();
    }
}
