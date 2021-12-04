using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{

    public int maxHP = 5;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int dmg) {
        currentHP -= dmg;
    }

    //called when an enemy collides with the player
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Collide!");
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Taken Damage!");
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}

