using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{

	public Text playerHealthText;

	public GameObject gameOverScreen;
	public Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = this.GetComponentInParent<Animator>();
	}
	
	public void Dammage(float dammage)
	{
		if (!invincible)
		{
			currHealth -= dammage;
			invincible = true;
		}

		if (currHealth <= 0)
		{
			currHealth = 0;
			Time.timeScale = 0;
			gameOverScreen.SetActive(true);
			gameObject.SetActive(false);
		}
	
		
			
		
	}

	private void LateUpdate()
	{
		playerHealthText.text = "HP : " + currHealth;
		anim.SetBool("Hit", invincible);
	}
}
