using UnityEngine;

public class SceneBootstrapper : MonoBehaviour
{
	[SerializeField]
	private string[] requiredScenes;

	private async void Start()
	{
		foreach (var scene in requiredScenes)
		{
			await SceneLoader.Instance.LoadSceneAdditive(scene);
		}
	}
}
