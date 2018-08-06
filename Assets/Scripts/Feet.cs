using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{

	public float dammage, recoil;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Enemy"))
        {
            otherObject.GetComponent<Health>().Dammage(dammage);
	        this.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, recoil, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
