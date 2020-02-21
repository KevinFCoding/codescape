using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu1 : MonoBehaviour
{
	GameObject[] menuObjects;
	[SerializeField] GameObject player;
	[SerializeField] GameObject playerEyes;
	[SerializeField] string menuType;

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		menuObjects = GameObject.FindGameObjectsWithTag(menuType);

		if (menuType == "StartGame")
		{
			ShowMenu();
		}
		else
		{
			HideMenu();
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (player.GetComponent<PlayerMovement>().IsInTraps && menuType == "GameOver")
		{
			ShowMenu();
		}
	}

	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//shows objects with ShowOnGameOver tag
	public void ShowMenu()
	{
		foreach (GameObject g in menuObjects)
		{
			g.SetActive(true);
		}
		Time.timeScale = 0;
		player.GetComponent<PlayerCamera>().enabled = false;
		playerEyes.GetComponent<PlayerCamera>().enabled = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	//hides objects with ShowOnGameOver tag
	public void HideMenu()
	{
		foreach (GameObject g in menuObjects)
		{
			g.SetActive(false);
		}
		Time.timeScale = 1;
		player.GetComponent<PlayerCamera>().enabled = true;
		playerEyes.GetComponent<PlayerCamera>().enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
	}
}

