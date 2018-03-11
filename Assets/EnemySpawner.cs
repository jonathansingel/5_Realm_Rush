using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] GameObject enemyToSpawn;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    IEnumerator SpawnEnemy()
    {
        while (true) //forever
        {
            print("spawning");

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
