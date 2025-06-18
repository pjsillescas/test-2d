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
			await (Test2dSceneLoader.Instance as Test2dSceneLoader).RestartCurrentLevel();
		}
		public async void BtnExit()
		{
			await (Test2dSceneLoader.Instance as Test2dSceneLoader).LoadMainMenu();
		}

	}

}