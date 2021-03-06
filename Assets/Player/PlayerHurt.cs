using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{

    public int maxHP = 5;
    public int currentHP;
    public SpriteRenderer img;

    private bool dead;
    public Image hp1;
    public Image hp2;
    public Image hp3;
    public Image hp4;
    public Image hp5;

    public PlayerMovement p;

    public bool slow;

    private Color filled = new Color(1, 1, 1, 255);
    private Color empty = new Color(1, 0, 0, 255);
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        img.enabled = false;
        img.color = new Color(0, 0, 0, 0);
        dead = false;
        hp1.color = filled;
        hp2.color = filled;
        hp3.color = filled;
        hp4.color = filled;
        hp5.color = filled;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        switch (currentHP)
        {
            case 4:
                hp5.color = empty;
                break;
            case 3:
                hp4.color = empty;
                break;
            case 2:
                hp3.color = empty;
                break;
            case 1:
                hp2.color = empty;
                break;
            case 0:
                hp1.color = empty;
                break;
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("Player has died!");
        img.enabled = true;
        dead = true;
        SceneManager.LoadScene(8);
    }

    //called when an enemy collides with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collide!");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Taken Damage!");
            TakeDamage(1);
            Destroy(other.gameObject);
            if (currentHP <= 0 && !dead)
            {
                PlayerDeath();
            }
        }

        if (other.gameObject.CompareTag("void")) {
            Debug.Log("Slow!");
            p.moveSpeed = 2.5f;
        }

        if (other.gameObject.CompareTag("safe")) {
            p.moveSpeed = 5;
        }
    }
}

