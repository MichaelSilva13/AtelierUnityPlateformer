using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public float MAX_HEALTH = 5f;
	public float currHealth, recoil;

	public bool invincible = false;
	
	public float maxTime, timer, blinkTimer, blinkMaxTime;

	// Use this for initialization
	void Start ()
	{
		currHealth = MAX_HEALTH;
	}
	
	public void Dammage(float dammage)
	{
		//takes care if invincibility
		if (!invincible)
		{
			//Reduce health
			currHealth -= dammage;
			invincible = true;
		}

		//Death, if more complex should use method
		if (currHealth <= 0)
			gameObject.SetActive(false);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//hit Stun and invincible time
		if (invincible)
		{
			timer += Time.deltaTime;
			//Blinking "animation"
			/*blinkTimer += Time.deltaTime;
			if (blinkTimer >= blinkMaxTime)
			{
				//this.GetComponent<MeshRenderer>().enabled = !this.GetComponent<MeshRenderer>().enabled;
				blinkTimer = 0;
			}*/
			if (timer >= maxTime)
			{
				invincible = false;
				timer = 0f;
				blinkTimer = 0;
				//this.GetComponent<MeshRenderer>().enabled = true;
			}
		}
	}
}
