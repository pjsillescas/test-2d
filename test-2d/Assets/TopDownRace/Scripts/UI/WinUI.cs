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
			await SceneLoader.Instance.UnloadScene(SceneManager.GetActiveScene().name);
			await SceneLoader.Instance.LoadSceneAdditive(SceneManager.GetActiveScene().name);
			// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public async void Continue()
        {
            //SceneManager.LoadScene("MainMenu");
            await SceneLoader.Instance.UnloadScene(SceneManager.GetActiveScene().name);
			await SceneLoader.Instance.UnloadScene("HUD");
			await SceneLoader.Instance.UnloadScene("Audio");

			await SceneLoader.Instance.LoadSceneAdditive("MainMenu");
		}
	}

}