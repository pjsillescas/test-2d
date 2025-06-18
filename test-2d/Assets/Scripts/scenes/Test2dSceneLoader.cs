using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test2dSceneLoader : SceneLoader
{
	private string currentLevel = "";

	private async Task LoadCurrentSceneFromMainMenu(string level)
	{
		currentLevel = level;
		await UnloadScene("MainMenu");
		await LoadSceneAdditive(currentLevel);
		await LoadSceneAdditive("Audio");
		await LoadSceneAdditive("HUD");
	}
	public async Task LoadForestFromMainMenu()
	{
		await LoadCurrentSceneFromMainMenu("Forest");
	}
	public async Task LoadDesertFromMainMenu()
	{
		await LoadCurrentSceneFromMainMenu("Desert");
	}

	public async Task LoadSnowFromMainMenu()
	{
		await LoadCurrentSceneFromMainMenu("Snow");
	}

	public async Task RestartCurrentLevel()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		await UnloadScene(currentLevel);
		await LoadSceneAdditive(currentLevel);
	}

	public async Task LoadMainMenu()
	{
		if (currentLevel != "")
		{
			//SceneManager.LoadScene("MainMenu");
			await UnloadScene(currentLevel);
			await UnloadScene("HUD");
			await UnloadScene("Audio");
		}

		currentLevel = "MainMenu";
		await LoadSceneAdditive("MainMenu");
	}
}
