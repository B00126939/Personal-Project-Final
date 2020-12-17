using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    public float horizontalInput;
    private Rigidbody playerRb;
    public float xRange = 16.0f;
    public float jumpForce = 300;
    public bool isOnGround = true;

    public GameObject projectilePrefab;
    private float reloadRate = 1f; // time player should wait
    private float shootRate = 0; // time player can shoot after waiting

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        ConstraintPlayer();
        ProjectileLaunch();
    }

    void Movement()
    {
    horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    void ConstraintPlayer()
    {
                // inbounds
            if (transform.position.x < -xRange)
            {
               transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
		    }
            if (transform.position.x > xRange)
            {
               transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
		    }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
               isOnGround = false;
               playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);                 
	        }

            
     }

     void ProjectileLaunch()
     {
             if (Input.GetKeyDown(KeyCode.E)&& Time.time > shootRate )
            {
               shootRate = Time.time + reloadRate;  // reset shootRate to current time + reloadRate
               Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);               
	        }
	 }

    private void OnCollisionEnter(Collision collision)
    {

      

      if (collision.gameObject.CompareTag("Ground"))
      {
        isOnGround = true;
	  }
	}

    private void OnTriggerEnter(Collider other)
    {
    
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy.");
	    }

        if(other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
		}

	}
}
