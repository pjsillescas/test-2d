using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
			await SceneLoader.Instance.UnloadScene("MainMenu");
			switch (num)
            {
                case 0:
					await SceneLoader.Instance.LoadSceneAdditive("Forest");
					await SceneLoader.Instance.LoadSceneAdditive("Audio");
					await SceneLoader.Instance.LoadSceneAdditive("HUD");

					break;

                case 1:
					await SceneLoader.Instance.LoadSceneAdditive("Desert");
					await SceneLoader.Instance.LoadSceneAdditive("Audio");
					await SceneLoader.Instance.LoadSceneAdditive("HUD");
					break;

                case 2:
					await SceneLoader.Instance.LoadSceneAdditive("Snow");
					await SceneLoader.Instance.LoadSceneAdditive("Audio");
					await SceneLoader.Instance.LoadSceneAdditive("HUD");
					break;
            }



        }
    }
}