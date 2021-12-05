using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{

    public int maxHP = 5;
    public int currentHP;
    public SpriteRenderer img;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        img.enabled = false;
        img.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int dmg) {
        currentHP -= dmg;
    }

    public void PlayerDeath() {
        Debug.Log("Player has died!");
        img.enabled = true;
        img.color = new Color(0, 0, 0, 255);
    }

    //called when an enemy collides with the player
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Collide!");
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Taken Damage!");
            TakeDamage(1);
            Destroy(other.gameObject);
            if (currentHP <= 0) {
                PlayerDeath();
            }
        }
    }
}

