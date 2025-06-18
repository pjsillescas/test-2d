using UnityEngine;
using TopDownRace.ScriptableObjects;
using System.Threading.Tasks;
namespace TopDownRace
{
	public class MainMenuUI : MonoBehaviour
	{
		[SerializeField, Space]
		private DataStorage m_DataStorage;

		[SerializeField, Space]
		private GameplayData m_GameplayData;
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
		}

		public void BtnExit()
		{
			Application.Quit();
		}

		public async void BtnLevel(int num)
		{
			m_GameplayData.LevelNumber = num;
			switch (num)
			{
				case 0:
					await (Test2dSceneLoader.Instance as Test2dSceneLoader).LoadForestFromMainMenu();
					break;
				case 1:
					await (Test2dSceneLoader.Instance as Test2dSceneLoader).LoadDesertFromMainMenu();
					break;
				case 2:
					await (Test2dSceneLoader.Instance as Test2dSceneLoader).LoadSnowFromMainMenu();
					break;
			}

		}

		
	}
}