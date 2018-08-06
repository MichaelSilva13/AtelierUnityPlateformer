using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{

	public float dammage;

	public float speed, maxTime, timer;

	public Vector3 dirrection;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
	    //Dammage player if touched
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Dammage(dammage);
        }
    }

    // Update is called once per frame
    void Update ()
    {
	    
	    //Moving pattern this one is going back and forth
	    this.GetComponent<Rigidbody>().velocity = dirrection.normalized * speed;
	    transform.LookAt( new Vector3(dirrection.x * speed + transform.position.x, dirrection.y * speed + transform.position.y, dirrection.z * speed + transform.position.z));
	    timer += Time.deltaTime;
	    if (timer >= maxTime)
	    {
		    timer = 0;
		    speed *= -1;
	    }
    }
}
