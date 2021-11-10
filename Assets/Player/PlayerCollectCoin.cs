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
    public float attackRange;
    public LayerMask Coin;

    public Text scoreText;
    public int scoreValue = 0;

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
                
                // deal damage to all enemies within attack range
                print("space button pressed");
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, Coin);

                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy(damage[i].gameObject);
                    AddPoint();
                }
               
                
            }
            attackTime = startTimeAttack;

            
        }
        else
        {
            attackTime -= Time.deltaTime;
        }


    }

    public void AddPoint()
    {
        scoreValue += 1;
        scoreText.text = "Scores: " + scoreValue.ToString();
    }


}
