using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
		else Destroy(gameObject);
	}

	public async Task LoadSceneAdditive(string sceneName)
	{
		if (SceneManager.GetSceneByName(sceneName).isLoaded) return;

		var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		while (!op.isDone) await Task.Yield();
	}

	public async Task UnloadScene(string sceneName)
	{
		if (!SceneManager.GetSceneByName(sceneName).isLoaded) return;

		var op = SceneManager.UnloadSceneAsync(sceneName);
		while (!op.isDone) await Task.Yield();
	}
}