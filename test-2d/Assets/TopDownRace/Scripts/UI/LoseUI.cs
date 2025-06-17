using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
namespace TopDownRace
{

	public class LoseUI : MonoBehaviour
	{


		void Start()
		{

		}

		void Update()
		{

		}


		public async void BtnRestart()
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			await SceneLoader.Instance.UnloadScene(SceneManager.GetActiveScene().name);
			await SceneLoader.Instance.LoadSceneAdditive(SceneManager.GetActiveScene().name);

		}
		public async void BtnExit()
		{

			//SceneManager.LoadScene("MainMenu");
			await SceneLoader.Instance.UnloadScene(SceneManager.GetActiveScene().name);
			await SceneLoader.Instance.UnloadScene("HUD");
			await SceneLoader.Instance.UnloadScene("Audio");

			await SceneLoader.Instance.LoadSceneAdditive("MainMenu");

		}

	}

}