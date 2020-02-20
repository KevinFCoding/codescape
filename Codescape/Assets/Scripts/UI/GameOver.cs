using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	GameObject[] gameOverObjects;
	[SerializeField] GameObject player;

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
		HideGameOver();
	}

	// Update is called once per frame
	void Update()
	{
		if (player.GetComponent <PlayerMovement>().IsInTraps)
        {
			ShowGameOver();
        }
	}

	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//shows objects with ShowOnGameOver tag
	public void ShowGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(true);
		}
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.Confined;
	}

	//hides objects with ShowOnGameOver tag
	public void HideGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(false);
		}
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
	}


}
