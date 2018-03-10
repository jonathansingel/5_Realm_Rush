using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int healthPoints = 10;
    [SerializeField] Collider collisionMesh;

	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
