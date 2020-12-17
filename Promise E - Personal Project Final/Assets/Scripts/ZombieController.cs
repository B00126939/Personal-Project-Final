using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody enemyRb;

    public GameObject projectilePrefab;

    private float projectileSpawnTime = 4.0f;
    private float startDelay = 1.0f;
    //Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        InvokeRepeating("ProjectileLaunch", startDelay, projectileSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
 
            if(collision.gameObject.CompareTag("Orb"))
            {
                Debug.Log("Enemy Collided with Orb");
	        }

	}

    void ProjectileLaunch()
    {             
             Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);               
	}
}
