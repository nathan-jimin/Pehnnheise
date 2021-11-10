using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    SpriteRenderer sprite;
    Collider2D[] damage;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0) {
            if (Input.GetButton("Jump")) {
                // deal damage to all enemies within attack range
                print("cooldown");
                sprite.color = new Color(0, 0, 0, 1);
                damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++) {
                    Destroy(damage[i].gameObject);
                }
                attackTime = startTimeAttack;
            }
            
        }
        else {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0)
            sprite.color = new Color(1, 1, 1, 1);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }

}
