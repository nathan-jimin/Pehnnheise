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

    public SpriteRenderer sprite;

    Color color1 = new Color(1, 0, 0, 1f);
    Color color2 = new Color(1, 1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0) {
            if (Input.GetButton("Jump")) {
                attackTime = startTimeAttack;
                // deal damage to all enemies within attack range
                Debug.Log("space button pressed");
                sprite.color = color1;
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++) {
                    Destroy(damage[i].gameObject);
                }
            }
        }
        else {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0) {
            sprite.color = color2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }

}
