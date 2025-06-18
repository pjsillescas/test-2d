using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	async void Start()
	{
		await (Test2dSceneLoader.Instance as Test2dSceneLoader).LoadMainMenu();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
