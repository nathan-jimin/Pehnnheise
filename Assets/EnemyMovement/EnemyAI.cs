using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
 {
         public BoxCollider territory;
         GameObject player;
         bool playerInTerritory;
 
         public GameObject enemy;
         BasicEnemy basicenemy;
 
         // Use this for initialization
         void Start ()
         {
             player = GameObject.FindGameObjectWithTag ("Player");
             basicenemy = enemy.GetComponent <BasicEnemy> ();
             playerInTerritory = false;
         }
     
         // Update is called once per frame
         void Update ()
         {
             if (playerInTerritory == true)
             {
                 basicenemy.MoveToPlayer ();
             }
 
             if (playerInTerritory == false)
             {
                 basicenemy.Rest ();
             }
         }
 
         void OnTriggerEnter (Collider other)
         {
             if (other.gameObject == player)
             {
                 playerInTerritory = true;
             }
         }
     
         void OnTriggerExit (Collider other)
         {
             if (other.gameObject == player) 
             {
                     playerInTerritory = false;
             }
         }
 }
 
 public class BasicEnemy : MonoBehaviour
 {
         public Transform target;
         public float speed = 3f;
         public float attack1Range = 1f;
         public int attack1Damage = 1;
         public float timeBetweenAttacks;
 
 
         // Use this for initialization
         void Start ()
         {
             Rest ();
         }
     
         // Update is called once per frame
         void Update ()
         {
             
         }
 
         public void MoveToPlayer ()
         {
             //rotate to look at player
             transform.LookAt (target.position);
             transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
         
             //move towards player
             if (Vector3.Distance (transform.position, target.position) > attack1Range) 
             {
                     transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
             }
         }
 
         public void Rest ()
         {
 
         }
         
 public class EnemyAttack : MonoBehaviour
 {
 
     public float enemyCooldown = 1;
     public float damage = 1;
 
     private bool playerInRange = false;
     private bool canAttack = true;
 
     private void Update()
     {
         if (playerInRange && canAttack)
         {
             GameObject.Find("Player").GetComponent<ControllerForPlayer>().currentHealth -= damage;
             StartCoroutine(AttackCooldown());
         }
     }
 
     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Player"));
          {
             playerInRange = true;
         }
     }
     void OnTriggerExit(Collider other)
     {
         if (other.gameObject.CompareTag("Player"));
          {
             playerInRange = false;
         }
     }
     IEnumerator AttackCooldown()
     {
         canAttack = false;
         yield return new WaitForSeconds(enemyCooldown);
         canAttack = true;
     }
 }
 }
