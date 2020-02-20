using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
	GameObject[] gameOverObjects;

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
		hideGameOver();
	}

	// Update is called once per frame
	void Update()
	{

	}


	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//controls the pausing of the scene
	public void gameOverControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showGameOver();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hideGameOver();
		}
	}

	//shows objects with ShowOnGameOver tag
	public void showGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(true);
			Cursor.lockState = CursorLockMode.Confined;
		}
	}

	//hides objects with ShowOnGameOver tag
	public void hideGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(false);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Traps"))
		{
			gameOverControl();
		}
	}


}
