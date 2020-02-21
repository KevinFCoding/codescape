using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

	//GameObject[] menuObjects;
	[SerializeField] GameObject player;
	[SerializeField] GameObject playerEyes;

	[SerializeField] GameObject gameOverPanel;
	[SerializeField] GameObject startGamePanel;
	[SerializeField] GameObject victoryPanel;

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		ShowMenu(startGamePanel);
		HideMenu(gameOverPanel);
		HideMenu(victoryPanel);
	}

	// Update is called once per frame
	void Update()
	{
		if (player.GetComponent<PlayerMovement>().IsInTraps)
		{
			ShowMenu(gameOverPanel);
		}
        if(player.GetComponent<PlayerMovement>().IsInVictory)
		{
			ShowMenu(victoryPanel);
		}
		LockPlayer();
	}

	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//shows objects with ShowOnGameOver tag
	public void ShowMenu(GameObject menuToActivate)
	{
		menuToActivate.SetActive(true);
	}

	//hides objects with ShowOnGameOver tag
	public void HideMenu(GameObject menuToDesactivate)
	{
		menuToDesactivate.SetActive(false);
		
	}

	public void LockPlayer()
    {
        if (!gameOverPanel.activeInHierarchy
            && !startGamePanel.activeInHierarchy
            && !victoryPanel.activeInHierarchy)
        {
			Time.timeScale = 1;
			player.GetComponent<PlayerCamera>().enabled = true;
			playerEyes.GetComponent<PlayerCamera>().enabled = true;
			Cursor.lockState = CursorLockMode.Locked;

		}
        else
        {
			Time.timeScale = 0;
			player.GetComponent<PlayerCamera>().enabled = false;
			playerEyes.GetComponent<PlayerCamera>().enabled = false;
			Cursor.lockState = CursorLockMode.Confined;
		}
    }
}

