using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public GameObject gameOverScreen;
	public Text text; 
	public GameObject[] enemies;
	private bool gameOver = false;
	
	// Use this for initialization
	void Start ()
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		int counter = 0;
		for (int i = 0; i < enemies.Length; i++)
		{
			if (!enemies[i].active)
			{
				counter++;
			}
		}

		if (counter == enemies.Length)
		{
			gameOverScreen.SetActive(true);
			text.text = "You win";
		}
	}
}
