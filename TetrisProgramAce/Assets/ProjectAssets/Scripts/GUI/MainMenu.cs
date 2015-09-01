using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public void StartGame()
	{
		Application.LoadLevel("GameField");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
