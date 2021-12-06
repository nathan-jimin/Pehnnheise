using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn()
    {
        while (true)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);


            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            Debug.Log("enemy spawned: " + (int)Time.time);
            yield return new WaitForSeconds(1);
        }
    }

}
