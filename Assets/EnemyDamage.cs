using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int healthPoints = 5;
    [SerializeField] Collider collisionMesh;

	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(healthPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        healthPoints = healthPoints - 1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
