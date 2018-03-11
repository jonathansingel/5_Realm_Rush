using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 35f;
    [SerializeField] ParticleSystem bulletSystem;

	// Use this for initialization
	void Start ()
    {
        ShootEnemy(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (targetEnemy)
        {
            TargetEnemy();
        }
        else
        {
            ShootEnemy(false);
        }
    }

    private void TargetEnemy()
    {
        float enemyDistanceAway = Vector3.Distance(targetEnemy.transform.position, objectToPan.transform.position);

        if (enemyDistanceAway <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            ShootEnemy(true);
        }
        else
        {
            ShootEnemy(false);
        }
        
    }

    private void ShootEnemy(bool isActive)
    {
        var emissionModule = bulletSystem.emission;
        emissionModule.enabled = isActive;
    }
}
