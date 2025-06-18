using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownRace
{
    public class WinUI : MonoBehaviour
    {
        public static WinUI m_Current;

        private void Awake()
        {
            m_Current = this;
        }
        void Start()
        {

        }

        void Update()
        {
        }

        public async void Restart()
        {
			await (Test2dSceneLoader.Instance as Test2dSceneLoader).RestartCurrentLevel();
        }

        public async void Continue()
        {
			await (Test2dSceneLoader.Instance as Test2dSceneLoader).LoadMainMenu();
		}
	}

}